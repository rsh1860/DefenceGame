using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public string loadToScene = "LevelSelect";

    public SceneFader fader;

    public void Play()
    {
        fader.FadeTo(loadToScene);
    }

    public void Quit()
    {
        Debug.Log("QUIT");
    }
}
