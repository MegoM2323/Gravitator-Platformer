using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopProvider : MonoBehaviour
{
    public GameObject[] BuyBtn;
    public GameObject[] ActiveBtn;
    public GameObject[] NoActiveBtn;
    public int[,] InfoCharecters = { {1, 2, 3}, {0, 0, 0}, {1000, 2000, 3000} };//номер скина, куплен или нет (не влияет(потом будет сорт функция), цена скина)
    public int CountCharecters = 3;
    private void Awake()
    {
        for (int j = 0; j < CountCharecters; j++) // Узнаем что уже купленно
        {
            if (PlayerPrefs.HasKey("Skin" + j))
            {
                if (PlayerPrefs.GetInt("Skin" + j) == 1)
                {
                    InfoCharecters[2, j] = 1;
                }
                
            }
        }
        for(int i = 0; i <= BuyBtn.Length; i++)//Убираем использованные кнопки купить
        {
            if(InfoCharecters[2,i] == 1)
            {
                Destroy(BuyBtn[i]);
            }
        }
        ActiveBtn[PlayerPrefs.GetInt("ActiveCharecter")].SetActive(true); //Показываем какой персонаж активирован
    }

    public void Buy(int number)//
    {
        if (PlayerPrefs.GetInt("Money") >= InfoCharecters[3, number])
        {
            Debug.Log("Skin" + number);
            PlayerPrefs.SetInt("Skin" + number, 1);
            InfoCharecters[2, number] = 1;
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - InfoCharecters[3, number]);
        }
    }
    public void Activate(int number)//
    {
        ActiveBtn[PlayerPrefs.GetInt("ActiveCharecter")].SetActive(false);
        ActiveBtn[number].SetActive(true);
        PlayerPrefs.SetInt("ActiveCharecter", number);
    }

}

/*
 static public GameObject[] Charecters;
    public GameObject SuperPowerText;

    private int ActiveCharecter = 0;
    public GameObject SkinMenu;
    private void Start()
    {
        Charecters = GlobalProvider.CharectersST;
        ActiveCharecter = 0;
        ActiveCharecter = PlayerPrefs.GetInt("ActiveCharecter");
        ChangeActiveCharecter(ActiveCharecter);

    }
    private void  UnlockCharecters() // Не сделанно 
    {
        for(int i = 0; i < Charecters.Length; i++)
        {
            //if ()
            {

            }
        }
    }   
    private void ChangeActiveCharecter(int ActivateCharecterNumber ) // Со старого скрипта (Надо настроить)
    {
        if(ActivateCharecterNumber >= Charecters.Length)
        {
            ActivateCharecterNumber = 0;
        }
        else if (ActivateCharecterNumber < 0)
        {
            ActivateCharecterNumber = Charecters.Length-1;
        }
        ActiveCharecter = ActivateCharecterNumber;
        Charecters[ActivateCharecterNumber].SetActive(true);
        for (int i = 0; i < Charecters.Length; i++)
        {
            if (i != ActivateCharecterNumber)
            {
                Charecters[i].SetActive(false);
            }
        }
    }
    public void SelectButton() // С прошлого скрипта 
    {
        PlayerPrefs.SetInt("ActiveCharecter", ActiveCharecter);
    }
    public void ClickOnSkin(int SkinNumber)//(int Skin, int Health = 1, bool SuperPower = false, string SuperPowerText = "")
    {
        SkinMenu.SetActive(true);
        PlayerShopConstract SkinForActivate = new PlayerShopConstract(SkinNumber);
        if (SkinForActivate.SetText() != "-1")
        {
            SuperPowerText.SetActive(true);
            SuperPowerText.GetComponent<UnityEngine.UI.Text>().text = SkinForActivate.SetText();
        }
        else
        {
            SuperPowerText.SetActive(false);
        }
    }
    public void CloseButton()
    {
        SkinMenu.SetActive(false);
    }
    public void Uprage(int SkinNumber, int Price , int Health = 1)
    {
        PlayerShopConstract SkinForActivate = new PlayerShopConstract(SkinNumber);
        SkinForActivate.BuySkin(Price);
    }

}
public class PlayerShopConstract : MonoBehaviour
{
    public GameObject SuperPowerText;
    private int SkinNumber; 

    private int[] SkinsHealth = new int[] { }; 

    private string[] SkinsSuperPowerText = new string[] { 
        "", // скин №0 не учитывается
        "super cool 11111111111111111", // скин №1
        "super cool 22222222222222222", // скин №2
        "super cool 33333333333333333", // скин №3
        "super cool 44444444444444444", // скин №4
        "-1", // скин №5
        "-1", // скин №6
        "-1", // скин №7
        "-1", // скин №8
        "-1", // скин №9
        "-1", // скин №10
        "-1", // скин №11
        "-1", // скин №12
    };
    public PlayerShopConstract(int SkinNumber)
    {
        this.SkinNumber = SkinNumber;
        //this.Health = Health;
    }
    /*public PlayerShopConstract(int SkinNumber)
    {
        this.SkinNumber = SkinNumber;
        //this.Health = Health;
    }*/
/*
public void BuySkin(int Price)
{
    PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - Price);
    PlayerPrefs.SetInt("pl" + SkinNumber + "active", PlayerPrefs.GetInt("pl" + SkinNumber + "active") + 1);
}
public void Upgrade(int AddHealth = 1, int Price = 250)
{
    PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - Price);
    SkinsHealth[SkinNumber] += AddHealth;
    PlayerPrefs.SetInt("pl" + SkinNumber + "health", PlayerPrefs.GetInt("pl" + SkinNumber + "Health") + AddHealth);
}
public string SetText()
{
    if (SkinsSuperPowerText[SkinNumber] != "-1")
    {
        return SkinsSuperPowerText[SkinNumber];
    }
    else
    {
        return "-1";
    }
}
*/