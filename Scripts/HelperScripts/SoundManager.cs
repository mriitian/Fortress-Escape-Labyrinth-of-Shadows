using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static SoundManager instance;
    public AudioSource CoinSoundSource;
    void Awake()
    {
        MakeInstance();
    }
    void Start()
    {
        
    }
    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayCoinSound()
    {
        CoinSoundSource.Play();
    }
}
