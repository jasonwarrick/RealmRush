using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] TextMeshProUGUI goldText;
    
    [SerializeField] int currentBalance;
    public int CurrentBalance { get { return currentBalance; } }

    void Awake() {
        currentBalance = startingBalance;
        SetGoldText();
    }

    public void Deposit (int amount) {
        currentBalance += Mathf.Abs(amount);
        SetGoldText();
    }

    public void Withdraw(int amount) {
        currentBalance -= Mathf.Abs(amount);
        SetGoldText();

        if (currentBalance < 0) {
            ReloadScene();
        }
    }

    void Update() {
        GetInput();
    }

    void GetInput() {
        if (Input.GetKeyDown(KeyCode.R)) {
            ReloadScene();
        }
    }

    void ReloadScene() {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    void SetGoldText() {
        goldText.text = "Gold: " + currentBalance;
    }
}
