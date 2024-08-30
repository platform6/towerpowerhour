using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Room : MonoBehaviour
{
    public string RoomName { get; set; }
    public int Size { get; set; }
    public int Occupants { get; set; }

    public void Initialize(string name, int size)
    {
        RoomName = name;
        Size = size;
        Occupants = 0;
    }

    public abstract void SimulateDay();
}

public class Office : Room
{
    public override void SimulateDay()
    {
        // Simulate office work here
        Occupants = Size * 2; // Example logic: each office has 2 people per unit of size
        Debug.Log($"Office {RoomName} now has {Occupants} occupants.");
    }
}

public class Apartment : Room
{
    public override void SimulateDay()
    {
        // Simulate apartment living here
        Occupants = Size; // Example logic: each apartment has 1 person per unit of size
        Debug.Log($"Apartment {RoomName} now has {Occupants} occupants.");
    }
}


