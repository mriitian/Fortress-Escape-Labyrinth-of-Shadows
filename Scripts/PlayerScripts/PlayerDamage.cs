using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public int damageamount = 2;
    public LayerMask EnemyLayer;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, 0.7f, EnemyLayer);
        if (hits.Length > 0)
        {
            if (hits[0].gameObject.tag == MyTags.ENEMY_TAG)
            {
                hits[0].gameObject.GetComponent<EnemyHealth>().ApplyDamage(damageamount);
            }
        }
    }
}
