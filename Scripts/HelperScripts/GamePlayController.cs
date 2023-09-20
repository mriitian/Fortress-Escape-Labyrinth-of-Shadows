using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GamePlayController : MonoBehaviour
{
    public static GamePlayController instance;
    private TextMeshProUGUI CoinText, HealthText, TimerText;
    private int CoinScore;
    [HideInInspector]
    public bool IsPlayerAlive;
    public float TimerTime = 1000f;
    public GameObject endPanel;
    void Awake()
    {
        MakeInstance();
        CoinText = GameObject.Find("CoinText").GetComponent<TextMeshProUGUI>();
        HealthText = GameObject.Find("HealthText").GetComponent<TextMeshProUGUI>();
        TimerText = GameObject.Find("TimerText").GetComponent<TextMeshProUGUI>();

        CoinText.text = "Coins: " + CoinScore;
    }
    void Start()
    {
        IsPlayerAlive = true;
        endPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CoutdownTimer();
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }else if(instance != null)
        {
            Destroy(gameObject);
        }
    }

    public void CoinCollected()
    {
        CoinScore++;
        CoinText.text = "Coins: " + CoinScore;

    }

    public void DisplayHealth(int Health)
    {
        HealthText.text = "Health: " + Health;
    }

    void CoutdownTimer()
    {
        TimerTime -= Time.deltaTime;
        TimerText.text = "Time:" + TimerTime.ToString("F0");
        if(TimerTime <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        endPanel.SetActive (true);
    }
}
