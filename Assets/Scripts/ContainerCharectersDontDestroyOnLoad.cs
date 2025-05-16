using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContainerCharectersDontDestroyOnLoad : MonoBehaviour
{
    public GameObject[] Charecters;// 
    static public GameObject[] CharectersST;// Для взаимодействия
    static public GameObject[] CharectersAll; // все персонажи
    static public GameObject ActiveCharecter; // 
    public static int SceneIndex;

    public static bool FlagForStay = false;
    
    private void Awake()
    {
        if (PlayerPrefs.HasKey("ActiveCharecter"))
        {
            ActiveCharecter = CharectersST[PlayerPrefs.GetInt("ActiveCharecter")];
        }
        else
        {
            PlayerPrefs.SetInt("ActiveCharecter", 0);
            ActiveCharecter = CharectersST[0];
        }
        FlagForStay = true;
        DontDestroyOnLoad(gameObject);
        CharectersST = Charecters;
        if (GameObject.FindGameObjectWithTag("CharecterContainer"))
        {
            Destroy(gameObject);
        }
        gameObject.tag = "CharecterContainer";
    }
    private void FixedUpdate()
    {
        SceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
}
