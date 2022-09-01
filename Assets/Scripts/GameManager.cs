using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool isGameOver = false;

    public bool isCheating = false;

    public GameObject gameoverUI;

    void Start()
    {
        InitData();
    }

    private void InitData()
    {
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
            return;

        if (Input.GetKeyDown(KeyCode.P))
        {
            ShowMeTheMoney();
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            if (isCheating)
                GameOver();
        }

        if (PlayerStats.lives <= 0 && !isGameOver)
        {
            GameOver();
        }
    }

    private void ShowMeTheMoney()
    {
        if (!isCheating)
            return;

        PlayerStats.AddMoney(100000);
    }

    private void GameOver()
    {
        isGameOver = true;

        gameoverUI.SetActive(true);
    }
}

