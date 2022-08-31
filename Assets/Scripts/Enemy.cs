using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [HideInInspector]
    public float speed = 10f;
    public float startSpeed = 10f;

    private float enemyHp;
    public float startEnemyHp = 100f;

    public int rewardMoney = 50;

    public GameObject deathEffectPrefab;

    // Start is called before the first frame update
    void Start()
    {
        enemyHp = startEnemyHp;
    }

    public void Slow(float rate)
    {
        speed = startSpeed * (1 - rate);
    }

    public void TakeDamage(float amount)
    {
        enemyHp -= amount;

        if (enemyHp <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        PlayerStats.AddMoney(rewardMoney);

        GameObject deathEffect = Instantiate(deathEffectPrefab, transform.position, Quaternion.identity);

        Destroy(deathEffect, 2f);
        Destroy(gameObject);
    }
}
