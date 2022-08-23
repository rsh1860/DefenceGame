using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLauncher : MonoBehaviour
{
    private Transform target;

    public float attackRange = 30f;

    public Transform partToRotate;
    public float turnSpeed = 5f;

    public float fireTimer = 4f;
    private float countdown = 0f;

    public GameObject missilePrefab;
    public Transform firePoint;

    void Start()
    {
        InvokeRepeating("SearchTarget", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

        LockOn();

        if (countdown <= 0)
        {
            Shoot();

            countdown = fireTimer;
        }
        countdown -= Time.deltaTime;
    }

    private void Shoot()
    {
        GameObject missileGo = (GameObject)Instantiate(missilePrefab, firePoint.position, firePoint.rotation);

        Bullet missile = missileGo.GetComponent<Bullet>();

        if (missile != null)
            missile.SetTarget(target);
    }

    private void SearchTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        float minDistance = float.MaxValue;
        GameObject nearEnemy = null;

        foreach (var enemy in enemies)
        {
            float distance = Vector3.Distance(this.transform.position, enemy.transform.position);
        
            if (distance < minDistance)
            {
                minDistance = distance;
                nearEnemy = enemy;
            }
        }

        if (nearEnemy != null && minDistance <= attackRange)
        {
            target = nearEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    private void LockOn()
    {
        Vector3 dir = target.transform.position - this.transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir); ;
        Quaternion qRotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed);
        Vector3 eRotation = qRotation.eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, eRotation.y, 0f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
    
}
