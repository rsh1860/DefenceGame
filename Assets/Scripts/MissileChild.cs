using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileChild : Bullet
{
    /*
    public float damageRange = 7f;

    public override void HitTarget()
    {
        //base.HitTarget();

        GameObject eff = (GameObject)Instantiate(impactPrefab, this.transform.position, Quaternion.identity);
        Destroy(eff.gameObject, 2f);

        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, damageRange);
        foreach (Collider collider in hitColliders)
        {
            if (collider.tag == "Enemy")
            {
                Destroy(collider.gameObject);
            }
        }

        Destroy(this.gameObject);
    }
    */
}
