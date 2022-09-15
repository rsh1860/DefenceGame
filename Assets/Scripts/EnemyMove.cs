using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMove : MonoBehaviour
{
    private Transform target;

    private int wayPointIndex = 0;

    private Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>();
        
        target = WayPoints.points[wayPointIndex];
    }

    void Update()
    {
        Vector3 dir = target.position - this.transform.position;
        transform.Translate(dir.normalized * Time.deltaTime * enemy.speed, Space.World);

        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= 0.1f)
        {
            GetNextPoint();
        }

        enemy.speed = enemy.startSpeed;
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

        WaveSpawner.enemyAlive--;

        Destroy(this.gameObject);
    }
}
