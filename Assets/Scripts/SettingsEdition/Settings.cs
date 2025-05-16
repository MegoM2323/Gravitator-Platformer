using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    public GameObject sound;
    public GameObject falsound;
    public GameObject EnLang;
    public GameObject RuLang;
    public GameObject AboutDevelopPanel;
    private string EnText = "HIHIHIHIHIHIHIIHIIHHIHHIHIHIIHIHIHIHIHIIH";
    private string RuText = "Привет";

    static public int VolChecer = 1;
    private string language = "En";

    private void Start()
    {
        if (PlayerPrefs.HasKey("VolChecer"))
        {
            VolChecer = PlayerPrefs.GetInt("VolChecer");
        }
        else
        {
            PlayerPrefs.SetInt("VolChecer", 1);
            VolChecer = PlayerPrefs.GetInt("VolChecer");
        }

        if (PlayerPrefs.GetInt("VolChecer") == -1)
        {
            falsound.SetActive(true);
            sound.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("VolChecer") == 1)
        {
            sound.SetActive(true);
            falsound.SetActive(false);
        }

        if (PlayerPrefs.GetString("language") == "Ru")
        {
            RuLang.SetActive(true);
            EnLang.SetActive(false);
        }
        else if (PlayerPrefs.GetString("language") == "En")
        {
            EnLang.SetActive(true);
            RuLang.SetActive(false);
        }
    }

    private void Update()
    {
        if(PlayerPrefs.GetString("language") == "En")
        {
            AboutDevelopPanel.GetComponent<UnityEngine.UI.Text>().text = EnText.ToString();
        }
        else if (PlayerPrefs.GetString("language") == "Ru")
        {
            AboutDevelopPanel.GetComponent<UnityEngine.UI.Text>().text = RuText.ToString();
        }
    }
    public void VolumeChecer()
    {
        VolChecer = -VolChecer;
        PlayerPrefs.SetInt("VolChecer", VolChecer);

        if (sound.activeSelf == true)
        {
            falsound.SetActive(true);
            sound.SetActive(false);
        }
        else if (sound.activeSelf == false)
        {
            sound.SetActive(true);
            falsound.SetActive(false);
            SceneManager.LoadScene(0);
        }
    }

    public void Language()
    {
        
        if (PlayerPrefs.GetString("language") == "En")
        {
            RuLang.SetActive(true);
            EnLang.SetActive(false);
            language = "Ru";
        }
        else if (PlayerPrefs.GetString("language") == "Ru")
        {
            EnLang.SetActive(true);
            RuLang.SetActive(false);
            language = "En";
        }

        PlayerPrefs.SetString("language", language);
    }

    public void AboutDeveloper()
    {
        if(AboutDevelopPanel.activeSelf == false)
        {
            AboutDevelopPanel.SetActive(true);
        }
        else if(AboutDevelopPanel.activeSelf == true)
        {
            AboutDevelopPanel.SetActive(false);
        }
    }

    public void YouTubeButton()
    {
        Application.OpenURL("https://www.youtube.com/channel/UCU2XY0Q1jnLs7WmqdTEzv2Q");
    }
    public void VKButton()
    {
        Application.OpenURL("https://vk.com/public197254415");
    }

}
