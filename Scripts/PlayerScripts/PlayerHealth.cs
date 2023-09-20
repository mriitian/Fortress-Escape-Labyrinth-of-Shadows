using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int Health = 100;
    private PlayerScript playerscript;
    private Animator anim;

    void Awake()
    {
        playerscript = GetComponent<PlayerScript>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        GamePlayController.instance.DisplayHealth(Health);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyDamage(int DamageAmount)
    {
        Health -= DamageAmount;
        if(Health < 0)
        {
            Health = 0;
        }
        GamePlayController.instance.DisplayHealth(Health);

        if (Health ==  0)
        {
            playerscript.enabled = false;
            anim.Play(MyTags.DEAD_ANIMATION);
            //GameOver()
            GamePlayController.instance.IsPlayerAlive = false;
            //GameOverPanel()
            StartCoroutine(Wait());
            GamePlayController.instance.GameOver();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == MyTags.COIN_TAG)
        {
            other.gameObject.SetActive(false);
            GamePlayController.instance.CoinCollected();
            SoundManager.instance.PlayCoinSound();
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
    }
}
