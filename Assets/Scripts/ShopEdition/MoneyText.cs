using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyText : MonoBehaviour
{
    static private int money;
    private void Start()
    {
        if (PlayerPrefs.HasKey("Money"))
        {
            money = PlayerPrefs.GetInt("Money");
        }
        else if (!PlayerPrefs.HasKey("Money"))
        {
            money = 10000;
        }

        money += Score.score;
        PlayerPrefs.SetInt("Money", money);
        GetComponent<UnityEngine.UI.Text>().text = money.ToString();
    }
}
