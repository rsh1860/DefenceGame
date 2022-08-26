using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float moveSpeed = 70f;

    public GameObject impactPrefab;

    public float damageRange = 7f;

    public float attackDamage = 50f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(this.gameObject);
            return;
        }

        Vector3 dir = target.position - this.transform.position;
        
        float distance = Vector3.Distance(target.position, this.transform.position);
        float distanceThisFrame = Time.deltaTime * moveSpeed;

        if (distance <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * Time.deltaTime * moveSpeed, Space.World);

        transform.LookAt(target);//missile
    }

    private void HitTarget()
    {
        GameObject eff = (GameObject)Instantiate(impactPrefab, this.transform.position, Quaternion.identity);
        Destroy(eff.gameObject, 2f);

        if (damageRange > 0)
        {
            Explosion();
        }
        else
        {
            Damage(target);
        }
        Destroy(this.gameObject);
    }

    private void Explosion()
    {
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, damageRange);
        foreach (Collider collider in hitColliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    private void Damage(Transform enemy)
    {
        enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        //Destroy(enemy.gameObject);
    }

    public void SetTarget(Transform _target)
    {
        target = _target;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, damageRange);
    }
}
