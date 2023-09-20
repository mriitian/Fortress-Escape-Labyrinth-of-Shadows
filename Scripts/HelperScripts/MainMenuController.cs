using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public Animator anim;
    public void PlayGame()
    {
        anim.Play("SlideIn");
    }
    public void Back()
    {
        anim.Play("SlideOut");
    }
}
