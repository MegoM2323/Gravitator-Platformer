using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Purchasing;

public class GlobalProvider : MonoBehaviour
{
    public GameObject LoadingMenu;
    public GameObject[] Charecters;
    static public GameObject[] CharectersST;
    public static int SceneIndex;
    public GameObject NoAdsButton;

    public GameObject Sounder;

    private void Awake()
    {
        Instantiate(Sounder, transform.position, Quaternion.identity);
        //PlayerPrefs.DeleteAll();
        if (PlayerPrefs.GetInt("NoAds") == 1) Destroy(NoAdsButton);
        SceneIndex = SceneManager.GetActiveScene().buildIndex;
        CharectersST = Charecters;
    }
    public void LoadScene(int i)
    {
        SceneManager.LoadScene(i);
    }
    public void StartLastLevel()
    {
        if (PlayerPrefs.HasKey("openlevels") && PlayerPrefs.GetInt("openlevels") < 15)
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("openlevels") + 4);
        }
        else if (PlayerPrefs.HasKey("openlevels") && PlayerPrefs.GetInt("openlevels") >= 15)
        {
            SceneManager.LoadScene(19);
        }
        else SceneManager.LoadScene(4);
    }
    public void NoAds(Product product)
    {
        if (product.definition.id == "NoAds")
        {
            PlayerPrefs.SetInt("NoAds", 1);
            Destroy(NoAdsButton);
        }
    }
    public void ActiveLoadMenu()
    {
        LoadingMenu.SetActive(true);
    }
}
