using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public static int money;
    public static int lives;

    public int startMoney = 400;
    public int startLife = 10;

    // Start is called before the first frame update
    void Start()
    {
        PlayDataInit();
    }

    public void PlayDataInit()
    {
        money = startMoney;
        lives = startLife;
    }

    public static void AddMoney(int amount)
    {
        money += amount;
    }

    public static bool UseMoney(int amount)
    {
        if (money < amount)
        {
            Debug.Log("돈이 부족합니다.");
            return false;
        }

        money -= amount;
        return true;
    }

    public static bool HaveMoney(int amount)
    {
        return money >= amount;
    }

    public static void UseLife(int amount)
    {
        lives -= amount;
    }    

    public static void AddLife(int amount)
    {
        lives += amount;
    }
}
