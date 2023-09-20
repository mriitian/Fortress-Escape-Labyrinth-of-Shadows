using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public GameObject player;
    private Rigidbody myBody;
    private Animator anim;

    private float enemy_Speed = 10f;

    private float enemy_Watch_Treshold = 70f;
    private float enemy_Attack_Treshold = 3f;

    public GameObject damagePoint;

    void Awake()
    {
        //player = GameObject.FindGameObjectWithTag(MyTags.PLAYER_TAG);
        myBody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (GamePlayController.instance.IsPlayerAlive)
        {
            EnemyAI();
        }
        else
        {
            if(anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.ATTACK_ANIMATION) ||
                anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.RUN_ANIMATION))
            {
                anim.SetTrigger(MyTags.STOP_TRIGGER);
            }
        }

            

        

    }

    void EnemyAI()
    {

        Vector3 direction = player.transform.position - transform.position;
        float distance = direction.magnitude;
        direction.Normalize();

        Vector3 velocity = direction * enemy_Speed;

        if (distance > enemy_Attack_Treshold && distance < enemy_Watch_Treshold)
        {

            myBody.velocity = new Vector3(velocity.x, myBody.velocity.y, velocity.z);

            if (anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.ATTACK_ANIMATION))
            {
                anim.SetTrigger(MyTags.STOP_TRIGGER);
            }

            anim.SetTrigger(MyTags.RUN_TRIGGER);

            transform.LookAt(new Vector3(player.transform.position.x,
                transform.position.y, player.transform.position.z));


        }
        else if (distance < enemy_Attack_Treshold)
        {

            if (anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.RUN_ANIMATION))
            {
                anim.SetTrigger(MyTags.STOP_TRIGGER);
            }

            anim.SetTrigger(MyTags.ATTACK_TRIGGER);


            transform.LookAt(new Vector3(player.transform.position.x,
                transform.position.y, player.transform.position.z));

        }
        else
        {

            myBody.velocity = new Vector3(0f, 0f, 0f);

            if (anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.RUN_ANIMATION) ||
               anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.ATTACK_ANIMATION))
            {

                anim.SetTrigger(MyTags.STOP_TRIGGER);

            }


        }

    }

    void ActivateDamagePoint()
    {
        damagePoint.SetActive(true);
    }

    void DeactivateDamagePoint()
    {
        damagePoint.SetActive(false);
    }

} // class










































