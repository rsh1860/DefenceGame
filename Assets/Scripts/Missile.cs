using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    private Transform target;

    public float moveSpeed = 50f;

    public GameObject impactPrefab;

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
        transform.LookAt(target);
    }

    private void HitTarget()
    {
        GameObject eff = (GameObject)Instantiate(impactPrefab, this.transform.position, Quaternion.identity);
        Destroy(eff.gameObject, 2f);

        Destroy(target.gameObject);
        Destroy(this.gameObject);
    }

    public void SetTarget(Transform _target)
    {
        target = _target;
    }    
}
