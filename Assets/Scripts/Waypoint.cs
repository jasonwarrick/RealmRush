using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] GameObject towerPrefab;

    [SerializeField] bool isPlaceable;
    public bool IsPlacable { get { return isPlaceable; } } // Makes a property (a variable that we can make read only)
    
    void OnMouseDown() {
        if (Input.GetMouseButtonDown(0) && isPlaceable)  {
            Instantiate(towerPrefab, transform.position, Quaternion.identity);
            isPlaceable = false;
        }
    }
}
