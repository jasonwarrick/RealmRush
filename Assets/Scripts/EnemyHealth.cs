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
            gameObject.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void OnEnable() {
        currentHP = maxHP;
    }
}
