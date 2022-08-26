using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform target;

    public float speed = 10f;

    private int wayPointIndex = 0;

    public float enemyHp;
    public float startEnemyHp = 100f;

    public int rewardMoney = 50;

    public GameObject deathEffectPrefab;

    // Start is called before the first frame update
    void Start()
    {
        enemyHp = startEnemyHp;
        target = WayPoints.points[wayPointIndex];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - this.transform.position;
        transform.Translate(dir.normalized * Time.deltaTime * speed);

        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= 0.1f)
        {
            GetNextPoint();
        }
    }

    private void GetNextPoint()
    {
        if (wayPointIndex == WayPoints.points.Length - 1)
        {
            EndPoint();
            return;
        }

        wayPointIndex++;
        target = WayPoints.points[wayPointIndex];
    }

    private void EndPoint()
    {
        PlayerStats.UseLife(1);
        Destroy(this.gameObject);
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
