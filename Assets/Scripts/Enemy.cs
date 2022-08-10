using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform target;

    public float speed = 10f;

    private int wayPointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        target = WayPoints.points[wayPointIndex];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - this.transform.position;
        transform.Translate(dir.normalized * Time.deltaTime * speed);

        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= 0.5f)
        {
            GetNextPoint();
        }
    }

    private void GetNextPoint()
    {
        if (wayPointIndex == WayPoints.points.Length - 1)
        {
            Debug.Log("Á¾Á¡ µµÂø!!");
            Destroy(this.gameObject);
            return;
        }

        wayPointIndex++;
        target = WayPoints.points[wayPointIndex];
    }
}
