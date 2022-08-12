using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private GameObject target;

    public Transform partToRotate;

    public float attackRange = 15f;

    public float turnSpeed = 5f;

    public float timerSearch = 0.5f;
    private float countdown = 0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SearchTarget", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (countdown <= 0f)
        {
            SearchTarget();

            countdown = timerSearch;
        }
        countdown -= Time.deltaTime;
        */

        if (target == null)
            return;

        Vector3 dir = target.transform.position - this.transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        //partToRotate.rotation = lookRotation;
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    private void SearchTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        float minDistance = float.MaxValue;

        GameObject nearEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearEnemy = enemy;
            }
        }

        if (nearEnemy != null && minDistance <= attackRange)
        {
            target = nearEnemy;
        }
        else
        {
            target = null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
