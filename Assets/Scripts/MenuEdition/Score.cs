using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static int score;
    private void Start()
    {
        score = 0;
    }
    void FixedUpdate()
    {
        GetComponent<UnityEngine.UI.Text>().text = score.ToString();
        if(score >= PlayerPrefs.GetInt("BestScoreEndless"))
        {
            PlayerPrefs.SetInt("BestScoreEndless", score);
        }
    }
}
