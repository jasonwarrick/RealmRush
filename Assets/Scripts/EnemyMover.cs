using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Tile> path = new List<Tile>();
    [SerializeField] [Range(0f, 5f)] float speed = 1f;

    Enemy enemy;

    void Start() {
        enemy = FindObjectOfType<Enemy>();
    }
    
    // Start is called before the first frame update
    void OnEnable() {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }

    void FindPath() {
        path.Clear();

        GameObject parent = GameObject.FindGameObjectWithTag("Path"); // Get the parent object

        foreach (Transform child in parent.transform) { // Loop through the children of that parent (all path tiles) IN ORDER
            Tile waypoint = child.GetComponent<Tile>();

            if (waypoint != null) {
                path.Add(child.GetComponent<Tile>()); // Add them to the path list
            }
        }
    }

    void ReturnToStart() {
        transform.position = path[0].transform.position;
    }

    IEnumerator FollowPath()
    { // IEnumerator makes the method a coroutine
        foreach (Tile waypoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0f; // Resets the travel counter so it always starts from 0

            transform.LookAt(endPosition); // Rotates the enemy to face in its movement direction

            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed; // Makes travelPercent an incrementer for the time
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame(); // Restarts or breaks from the while loop after a frame is completed
            }
        }

        FinishPath();
    }

    void FinishPath() {
        enemy.StealGold();
        gameObject.SetActive(false);
    }
}
