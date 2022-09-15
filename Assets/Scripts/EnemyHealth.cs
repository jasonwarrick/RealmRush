using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))] // The EnemyHealth script will create an Enemy script if one isn't already present
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHP = 5;
    [Tooltip("Adds amount to enemy HP when the enemy dies")]
    [SerializeField] int difficultyRamp = 1;
    int currentHP;

    Enemy enemy;

    void Start() {
        enemy = GetComponent<Enemy>();
    }
    
    void OnParticleCollision(GameObject other) {
        ProcessHit();
    }

    private void ProcessHit() {
        currentHP -= 1;
        if (currentHP <= 0) {
            enemy.RewardGold();
            maxHP += difficultyRamp;
            gameObject.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void OnEnable() {
        currentHP = maxHP;
    }
}
