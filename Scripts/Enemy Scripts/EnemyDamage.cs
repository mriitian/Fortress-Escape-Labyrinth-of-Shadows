using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    // Start is called before the first frame update
    public int damageamount = 2;
    public LayerMask PlayerLayer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, 0.1f , PlayerLayer) ;
        if (hits.Length > 0)
        {
            if (hits[0].gameObject.tag == MyTags.PLAYER_TAG)
            {
                hits[0].gameObject.GetComponent<PlayerHealth>().ApplyDamage(damageamount);
            }
        }
    }
}
