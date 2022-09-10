using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHP = 5;
    int currentHP;
    
    void OnParticleCollision(GameObject other) {
        ProcessHit();
    }

    private void ProcessHit() {
        currentHP -= 1;
        Debug.Log(currentHP);
        if (currentHP <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start() {
        currentHP = maxHP;
    }
}
