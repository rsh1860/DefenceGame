using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool isGameOver = false;

    public bool isCheating = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
            return;

        if (PlayerStats.lives <= 0 && !isGameOver)
        {
            GameOver();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            ShowMeTheMoney();
        }
    }

    private void GameOver()
    {
        isGameOver = true;

        Debug.Log("GameOver");
    }

    private void ShowMeTheMoney()
    {
        if (!isCheating)
            return;

        PlayerStats.AddMoney(100000);
    }

}
