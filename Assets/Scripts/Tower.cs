using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int cost = 75;
    [SerializeField] float buildTimer = 1f;

    void Start() {
        StartCoroutine(Build());
    }

    public bool CreateTower(Tower tower, Vector3 position) {
        Bank bank  = FindObjectOfType<Bank>();

        if (bank == null) { return false; }

        if (bank.CurrentBalance >= cost) {
            Instantiate(tower, position, Quaternion.identity);
            bank.Withdraw(cost);
            return true;
        }
        
        return false;
    }

    IEnumerator Build() {
        List<GameObject> pieces = new List<GameObject> ();

        foreach (Transform child in transform) {
            child.gameObject.SetActive(false);

            foreach (Transform grandchild in transform) {
                grandchild.gameObject.SetActive(false);
            }
        }

        foreach (Transform child in transform) {
            child.gameObject.SetActive(true);

            yield return new WaitForSeconds(buildTimer);

            foreach (Transform grandchild in transform) {
                grandchild.gameObject.SetActive(true);
                
            }
        }
    }
}
