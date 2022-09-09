using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] bool isPlaceable;
    
    void OnMouseDown() {
        if (Input.GetMouseButtonDown(0) && isPlaceable)  {
            Debug.Log(transform.name);
        }
    }
}
