using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AfterPlay : MonoBehaviour
{
    //public GameObject[] Charecters;
    //static public GameObject[] CharectersST;
    private GameObject PlayerSpawnPos;
    public GameObject ControlPanel;
    private int SceneIndex;
    private void Awake()
    {
        //Charecters = ContainerCharectersDontDestroyOnLoad.CharectersST;
        SceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerSpawnPos = GameObject.FindGameObjectWithTag("PlayerSpawnPos");
        //CharectersST = ContainerCharectersDontDestroyOnLoad.CharectersST;
    }
    private void Start()
    {
        if (SceneIndex >= 4 && SceneIndex <= 10000)
        {
            Instantiate(ContainerCharectersDontDestroyOnLoad.ActiveCharecter, PlayerSpawnPos.transform.position, Quaternion.identity);
            Instantiate(ControlPanel, new Vector2(0f, 0f), Quaternion.identity);
        }
    }
}
