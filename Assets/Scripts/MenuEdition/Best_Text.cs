using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Best_Text : MonoBehaviour
{
    private static int best;
    private void Start()
    {
        if (best < PlayerPrefs.GetInt("BestScoreEndless") & best == 0)
        {
            best = 0;
            best = PlayerPrefs.GetInt("BestScoreEndless");
        }
        if (best < Score.score)
        {
            best = Score.score;
            PlayerPrefs.SetInt("BestScoreEndless", best);
        }
        GetComponent<UnityEngine.UI.Text>().text = "BEST: " + best.ToString();
    }
}
