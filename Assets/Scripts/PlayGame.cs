using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayGame : MonoBehaviour
{
    [SerializeField] Button playButton;
    bool paused;

    void Awake() {
        Paused();
    }

    public void Paused() {
        Time.timeScale = 0;
        paused = true;
        playButton.gameObject.SetActive(true);
    }

    public void Played() {
        Time.timeScale = 1;
        paused = false;
        playButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        GetInput();
    }

    void GetInput() {
        if (Input.GetKeyDown(KeyCode.P)) {
            if (paused) {
                Played();
            } else {
                Paused();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
    }
}
