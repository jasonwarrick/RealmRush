using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] [Range(0f, 5f)] float speed = 1f;

    List<Node> path = new List<Node>();

    Enemy enemy;
    GridManager gridManager;
    Pathfinder pathfinder;

    void Awake() {
        enemy = FindObjectOfType<Enemy>();
        gridManager = FindObjectOfType<GridManager>();
        pathfinder = FindObjectOfType<Pathfinder>();
    }
    
    // Start is called before the first frame update
    void OnEnable() {
        ReturnToStart();
        RecalculatePath(true);
    }

    void RecalculatePath(bool resetPath) {
        Vector2Int coordinates = new Vector2Int();

        if (resetPath) {
            coordinates = pathfinder.StartCoordinates;
        } else {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);
        }
        
        StopAllCoroutines(); // New path won't conflict with existing path following
        path.Clear();
        path = pathfinder.GetNewPath(coordinates);
        StartCoroutine(FollowPath());
    }

    void ReturnToStart() {
        transform.position = gridManager.GetPositionFromCoordinates(pathfinder.StartCoordinates);
    }

    IEnumerator FollowPath() { // IEnumerator makes the method a coroutine
        Vector3 startPosition;
        Vector3 endPosition;

        for (int i = 1; i < path.Count; i++) {
            startPosition = transform.position;
            endPosition = gridManager.GetPositionFromCoordinates(path[i].coordinates);
            
            float travelPercent = 0f; // Resets the travel counter so it always starts from 0

            transform.LookAt(endPosition); // Rotates the enemy to face in its movement direction

            while (travelPercent < 1f) {
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
