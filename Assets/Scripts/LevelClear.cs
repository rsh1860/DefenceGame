using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelClear : MonoBehaviour
{
    public SceneFader fader;

    public string nextLevel = "Level02";
    public string loadToScene = "MainMenu";

    public void ContinueButton()
    {
        fader.FadeTo(nextLevel);
    }

    public void MenuButton()
    {
        fader.FadeTo(loadToScene);
    }
}
