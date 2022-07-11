using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class deadTextBehaviour : MonoBehaviour
{
    public string text;
    // Start is called before the first frame update
    void Start()
    {
        text = "";
        if(gameObject.tag == "CoinsText")
        {
            coins();
        }

        if(gameObject.tag == "TimerText")
        {
            timer();
        }

        gameObject.GetComponent<Text>().text = text;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void coins()
    {
        if (!PlayerPrefs.HasKey("maxCoins") || PlayerPrefs.GetInt("maxCoins") < PlayerPrefs.GetInt("currCoins"))
        {
            PlayerPrefs.SetInt("maxCoins", PlayerPrefs.GetInt("currCoins"));
            text = "Congratulations! You broke the score of max coins in a single game! The new Maximum Coins are: " + PlayerPrefs.GetInt("currCoins").ToString();
        }
        else
        {
            text = "You couldn't break the score of max coins. The current Maximum Coins are: " + PlayerPrefs.GetInt("maxCoins").ToString();
        }
    }

    public void timer()
    {
        if (!PlayerPrefs.HasKey("maxTime") || PlayerPrefs.GetFloat("maxTime") < PlayerPrefs.GetFloat("currTime"))
        {
            PlayerPrefs.SetFloat("maxTime", PlayerPrefs.GetFloat("currTime"));
            text = "Congratulations! You broke the score of max time in a single game! The new Maximum Time is: " + PlayerPrefs.GetFloat("currTime").ToString() + " seconds.";
        }
        else
        {
            text = "You couldn't break the score of max time. The current Maximum Time is: " + PlayerPrefs.GetFloat("maxTime").ToString() + " seconds.";
        }

    }
}
