using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player, PlayButton;
    public Animator anim;
    void DeactivateGameObj()
    {
        player.SetActive(false);
        PlayButton.SetActive(false);
    }
    void ActivateGameObj()
    {
        player.SetActive(true);
        PlayButton.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == MyTags.PLAYER_TAG)
        {
            anim.Play("DoorOpen");
            print("DoorOpen");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == MyTags.PLAYER_TAG)
        {
            //
            print("DoorClosed");
        }
    }
}
