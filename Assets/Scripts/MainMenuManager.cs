using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public string loadToScene = "PlayScene";
    public void Play()
    {
        SceneManager.LoadScene(loadToScene);
    }

    public void Quit()
    {
        Debug.Log("QUIT");
    }
}
