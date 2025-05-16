using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    static public bool SoundActiveMenu = true;
    public GameObject MusikMenu;
    private int sceneIndex;
    public bool checkR = true;
    public GameObject[] Players;
    private GameObject Player;
    public float Rotationspeed = 2.5f;

    public GameObject NowText;

    private void Awake()
    {
        Debug.Log("Volchecer" + PlayerPrefs.GetInt("VolChecer"));
        Debug.Log("SoundActiveMenu" + PlayerPrefs.GetInt("SoundActiveMenu"));
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("SoundActiveMenu")) { }
        else
        {
            PlayerPrefs.SetInt("SoundActiveMenu", 1);
        }

        if (PlayerPrefs.GetInt("SoundActiveMenu") == -1 && SoundActiveMenu == true)
        {
            PlayerPrefs.SetInt("SoundActiveMenu", 1);
        }

        if (PlayerPrefs.HasKey("VolChecer"))
        {
            Settings.VolChecer = PlayerPrefs.GetInt("VolChecer");
        }
        else
        {
            PlayerPrefs.SetInt("VolChecer", 1);
            Settings.VolChecer = PlayerPrefs.GetInt("VolChecer");
        }

        if (PlayerPrefs.GetInt("SoundActiveMenu") == 1 && PlayerPrefs.GetInt("VolChecer") == 1)
        {
            Instantiate(MusikMenu, new Vector3(0, 0, 0), Quaternion.identity);
        }
        else { }

        if (PlayerPrefs.HasKey("ActiveSkin")) { }
        else
        {
            PlayerPrefs.SetString("ActiveSkin", "Skin_1");
        }

        if (PlayerPrefs.HasKey("ActiveSkin_1")) { }
        else
        {
            PlayerPrefs.SetInt("ActiveSkin_1", 1);
        }

        if (PlayerPrefs.HasKey("language")) { }
        else
        {
            PlayerPrefs.SetString("language", "En");
        }
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (sceneIndex == 0)
        {
            Instantiate(Players[PlayerPrefs.GetInt("ActiveSkin_1") - 1], new Vector3(0, 0, 0), Quaternion.identity);
        }

        Player = GameObject.FindGameObjectWithTag("Player");

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        if (sceneIndex == 0)
        {
            StartCoroutine(checkerRoter());
            Player.transform.localScale = new Vector3(1.7f , 1.7f , 1.7f);
            Player.transform.position = new Vector3(0 , 1 , 0);
        }
        if (PlayerPrefs.GetString("language") == "En")
        {
            NowText.GetComponent<UnityEngine.UI.Text>().text = "Now:";
        }
        else if (PlayerPrefs.GetString("language") == "Ru")
        {
            NowText.GetComponent<UnityEngine.UI.Text>().text = "Сейчас:";
        }
    }

    private void FixedUpdate()
    {
        if (checkR)
        {
            Player.transform.Rotate(new Vector3(0, 0, Rotationspeed));
        }
        if (!checkR)
        {
            Player.transform.Rotate(new Vector3(0, 0, -Rotationspeed));
        }
    }

        IEnumerator checkerRoter()
    {
        while (true)
        {
            checkR = !checkR;
            yield return new WaitForSeconds(2.2f);
        }
    }
}
