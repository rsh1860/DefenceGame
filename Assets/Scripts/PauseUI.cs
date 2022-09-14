using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    public SceneFader fader;

    public GameObject pause;

    public string loadToScene = "MainMenu";

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        pause.SetActive(!pause.activeSelf);

        if (pause.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }

    public void Retry()
    {
        Toggle();
        fader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        Toggle();
        fader.FadeTo(loadToScene);
    }
}
