using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform target;

    public float speed = 10f;

    private int wayPointIndex = 0;

    public static int hp;
    public int startHp = 100;

    // Start is called before the first frame update
    void Start()
    {
        hp = startHp;
        target = WayPoints.points[wayPointIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            Destroy(this.gameObject);
            return;
        }

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
            PlayerStats.lives -= 1;
            Destroy(this.gameObject);
            return;
        }

        wayPointIndex++;
        target = WayPoints.points[wayPointIndex];
    }
}
