using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0f, 5f)] float speed = 1f;
    
    // Start is called before the first frame update
    void Start() {
        StartCoroutine(FollowPath());
    }

    IEnumerator FollowPath() { // IEnumerator makes the method a coroutine
        foreach(Waypoint waypoint in path) {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0f; // Resets the travel counter so it always starts from 0

            transform.LookAt(endPosition); // Rotates the enemy to face in its movement direction

            while(travelPercent < 1f) {
                travelPercent += Time.deltaTime * speed; // Makes travelPercent an incrementer for the time
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame(); // Restarts or breaks from the while loop after a frame is completed
            }
        }
    }
}
