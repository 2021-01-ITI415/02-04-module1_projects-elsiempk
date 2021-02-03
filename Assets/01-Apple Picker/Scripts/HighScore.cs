using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    static public int score = 1000;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Awake()
    {
        if(PlayerPrefs.HasKey("ApplePickerHighScore"))
        {
            score = PlayerPrefs.GetInt("ApplePickerHighScore");

        }
        PlayerPrefs.SetInt("ApplePickerHighScore", score);
    }

    // Update is called once per frame
    void Update()
    {
        Text scoreGT = this.GetComponent<Text>();
        scoreGT.text = "High Score: "+score;
        if(score > PlayerPrefs.GetInt("ApplePickerHighScore"))
        {
            PlayerPrefs.SetInt("ApplePickerHighScore", score);
        }
    }
}
