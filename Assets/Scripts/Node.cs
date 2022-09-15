using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // The entire class can now be serialized in the inspector
public class Node // Pure C# class - Can no longer add it to a game object
{
    public Vector2Int coordinates;
    public bool isWalkable;
    public bool isExplored;
    public bool isPath;
    public Node connectedTo;

    public Node (Vector2Int coordinates, bool isWalkable) {
        this.coordinates = coordinates; // this. refers to the coordinates of the object, the other is the passed in variable
        this.isWalkable = isWalkable;
    }
}
