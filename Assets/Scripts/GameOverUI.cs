using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public SceneFader fader;

    public TextMeshProUGUI roundsText;

    public string loadToScene = "MainMenu";

    private void OnEnable()
    {
        roundsText.text = PlayerStats.rounds.ToString();
    }

    public void Retry()
    {
        fader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        fader.FadeTo(loadToScene);
    }

}
