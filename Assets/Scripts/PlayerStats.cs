using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int money;
    public int startMoney = 400;


    // Start is called before the first frame update
    void Start()
    {
        money = startMoney;
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
}
