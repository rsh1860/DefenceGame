using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [HideInInspector]
    public float speed = 10f;
    public float startSpeed = 10f;

    private float enemyHp;
    public float startEnemyHp = 100f;

    public int rewardMoney = 50;

    public GameObject deathEffectPrefab;

    public Image hpBar;

    private bool isDeath = false;

    // Start is called before the first frame update
    void Start()
    {
        enemyHp = startEnemyHp;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    
    }

    private void Update()
    {
        
    }

    public void Slow(float rate)
    {
        speed = startSpeed * (1 - rate);
    }

    public void TakeDamage(float amount)
    {
        enemyHp -= amount;

        hpBar.fillAmount = enemyHp / startEnemyHp;

        if (enemyHp <= 0 && !isDeath)
        {
            Death();
        }
    }

    private void Death()
    {
        if (isDeath)
            return;

        isDeath = true;

        PlayerStats.AddMoney(rewardMoney);

        GameObject deathEffect = Instantiate(deathEffectPrefab, transform.position, Quaternion.identity);
        Destroy(deathEffect, 2f);

        WaveSpawner.enemyAlive--;

        Destroy(gameObject);
    }
}
