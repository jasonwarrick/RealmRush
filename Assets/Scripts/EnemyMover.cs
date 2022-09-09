using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] float waitTime = 1f;
    
    // Start is called before the first frame update
    void Start() {
        StartCoroutine(FollowPath());
    }

    IEnumerator FollowPath() { // IEnumerator makes the method a coroutine
        foreach(Waypoint waypoint in path) {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(waitTime); // Returns a function that waits for one second, delaying each loop
        }
    }
}
