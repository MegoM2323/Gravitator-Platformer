using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelMenuController : MonoBehaviour
{
    public GameObject[] TrueLevels;
    public GameObject[] FalseLevels;
    private void Start()
    {
        OpenAndCloseLevels(PlayerPrefs.GetInt("openlevels"));
        //LightLevels(Play
        //erPrefs.GetInt("openlevels") - 1);
    }
    private void OpenAndCloseLevels(int LastOpnelevel)
    {
        for(int i = 0; i <= LastOpnelevel; i++)
        {
            FalseLevels[i].SetActive(false);
            if(i < LastOpnelevel) TrueLevels[i].GetComponent<Image>().color = Color.green;   //.HSVToRGB(104, 100f, 100f);
        }
    }

    private void LightLevels(int LastCompleteLevel)
    {
        for (int i = 0; i <= LastCompleteLevel; i++)
        {
        }
    }
}  
