using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Building Building;

    void Start()
    {
        Building = FindObjectOfType<Building>();

        // Example: Add a couple of floors and rooms
        AddFloor(1);
        AddFloor(2);

        AddRoomToFloor(1, CreateRoom<Office>("Office A", 10));
        AddRoomToFloor(2, CreateRoom<Apartment>("Apartment B", 5));
    }

    public void AddFloor(int floorNumber)
    {
        GameObject floorObject = new GameObject($"Floor {floorNumber}");
        Floor floor = floorObject.AddComponent<Floor>();
        floor.Initialize(floorNumber);
        Building.AddFloor(floor);
    }

    public void AddRoomToFloor(int floorNumber, Room room)
    {
        var floor = Building.GetFloor(floorNumber);
        if (floor != null)
        {
            floor.AddRoom(room);
        }
    }

    private T CreateRoom<T>(string name, int size) where T : Room
    {
        GameObject roomObject = new GameObject(name);
        T room = roomObject.AddComponent<T>();
        room.Initialize(name, size);
        return room;
    }

    public void SimulateDay()
    {
        foreach (var floor in Building.Floors)
        {
            foreach (var room in floor.Rooms)
            {
                room.SimulateDay();
            }
        }
    }
}

