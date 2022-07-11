using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoresText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Text>().text = "Your High Scores: \n \n Maximum Time alive in a single run: " + PlayerPrefs.GetFloat("maxTime") + ". \n \n Maximum coins gathered in a single run: " + PlayerPrefs.GetInt("maxCoins") +".";

    }
}
