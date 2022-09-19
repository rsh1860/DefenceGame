using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public SceneFader fader;

    public void LoadLevel1()
    {
        fader.FadeTo("Level01");
    }
    
    public void LoadLevel2()
    {
        fader.FadeTo("Level02");
    }
}
