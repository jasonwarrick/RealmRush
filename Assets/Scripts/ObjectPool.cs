using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] float spawnTimer;
    [SerializeField] int poolSize = 5;

    GameObject[] pool;
    
    void Awake() {
        PopulatePool();
    }

    // Start is called before the first frame update
    void Start() {
        StartCoroutine(SpawnEnemy());
    }

    void PopulatePool() {
        pool = new GameObject[poolSize];

        for (int i = 0; i < pool.Length; i++) {
            pool[i] = Instantiate(enemy, transform);
            pool[i].SetActive(false);
        }
    }

    void EnableObjectInPool() {
        for (int i = 0; i < pool.Length; i++){
            if (!pool[i].activeInHierarchy) {
                pool[i].SetActive(true);
                return;
            }
        }
    }

    IEnumerator SpawnEnemy() { //Endlessly spawn enemies
        while(true) {
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnTimer);
        }
    }
}
