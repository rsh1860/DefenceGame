using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private GameObject target;

    [Header("Attributes")]

    public float attackRange = 15f;

    public float timerFire = 1.0f;
    private float fireCountdown = 0f;

    public GameObject bulletPrefab;
    public Transform firePoint;

    [Header("Unity Setup")]

    public Transform partToRotate;

    public float turnSpeed = 5f;

    [Header("Laser Beamer")]
    public bool isLaser = false;
    public LineRenderer render;
    public ParticleSystem laserEffect;
    public Light laserLightEffect;

    public float damageOverTime = 30f;

    public float slowRate = 0.4f;

    //public float timerSearch = 0.5f;
    //private float countdown = 0f;

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
        {
            if (isLaser)
            {
                if (render.enabled)
                {
                    render.enabled = false;
                    laserEffect.Stop();
                    laserLightEffect.enabled = false;
                }
            }

            return;
        }    

        LockOn();
        
        if (isLaser)
        {
            Laser();
            return;
        }
        if (fireCountdown <= 0f)
        {
            Shoot();

            fireCountdown = timerFire;
        }
        fireCountdown -= Time.deltaTime;

    }

    private void Laser()
    {
        if (!render.enabled)
        {
            render.enabled = true;
            laserEffect.Play();
            laserLightEffect.enabled = true;
        }

        float damage = damageOverTime * Time.deltaTime;
        Enemy e = target.GetComponent<Enemy>();
        e.TakeDamage(damage);
        e.Slow(slowRate);

        render.SetPosition(0, firePoint.position);
        render.SetPosition(1, target.transform.position);

        Vector3 dir = firePoint.position - target.transform.position;
        laserEffect.transform.position = target.transform.position + dir.normalized;
        laserEffect.transform.rotation = Quaternion.LookRotation(dir);
    }

    private void Shoot()
    {
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        Bullet bullet = bulletGo.GetComponent<Bullet>();

        if (bullet != null)
            bullet.SetTarget(target.transform);
    }

    private void LockOn()
    {
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
