using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreControl : MonoBehaviour {

    public static int score;


    Text text;

    void Start()
    {
        text = GetComponent<Text>();
        //score = 0;
        score = PlayerPrefs.GetInt("CurrentPlayerScore");
    }
    
    void Update()
    {
        if(score < 0)
        {
            score = 0;
        }

        text.text = "" + score;
    }

	public static void AddPoints(int pointsToAdd)
    {
        score += pointsToAdd;
        PlayerPrefs.SetInt("CurrentPlayerScore", score);
    }

   
}
