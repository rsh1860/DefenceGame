using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    public GameObject pause;

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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        Toggle();
        Debug.Log("Menu");
    }
}
