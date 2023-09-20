using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int Health = 100;
    private EnemyScript enemyscript;
    private Animator anim;

    void Awake()
    {
        enemyscript = GetComponent<EnemyScript>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ApplyDamage(int DamageAmount)
    {
        Health -= DamageAmount;
        if (Health < 0)
        {
            Health = 0;
        }
        if (Health == 0)
        {
            enemyscript.enabled = false;
            anim.Play(MyTags.DEAD_ANIMATION);

            Invoke("DeactivateEnemy", 3f);
        }
    }

    void DeactivateEnemy()
    {
        gameObject.SetActive(false);
    }
}
