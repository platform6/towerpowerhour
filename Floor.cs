using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public int FloorNumber { get; private set; }
    public List<Room> Rooms { get; private set; }

    public void Initialize(int floorNumber)
    {
        FloorNumber = floorNumber;
        Rooms = new List<Room>();
    }

    public void AddRoom(Room room)
    {
        Rooms.Add(room);
        room.transform.SetParent(transform); // Attach the room to the floor in the hierarchy
    }
}

public class Building : MonoBehaviour
{
    public List<Floor> Floors { get; private set; }

    void Start()
    {
        Floors = new List<Floor>();
    }

    public void AddFloor(Floor floor)
    {
        Floors.Add(floor);
        floor.transform.SetParent(transform); // Attach the floor to the building in the hierarchy
    }

    public Floor GetFloor(int floorNumber)
    {
        return Floors.Find(f => f.FloorNumber == floorNumber);
    }
}

