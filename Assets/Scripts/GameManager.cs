using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool isGameOver = false;

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

    }

    private void GameOver()
    {
        isGameOver = true;

        Debug.Log("GameOver");
    }
}
