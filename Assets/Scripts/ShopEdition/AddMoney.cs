using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMoney : MonoBehaviour
{
    [Header("How much money add ?")]
    public int HowMuchMoneyAdd = 1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + HowMuchMoneyAdd);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + HowMuchMoneyAdd);
    }
}
