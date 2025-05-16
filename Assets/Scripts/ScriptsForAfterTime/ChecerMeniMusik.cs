using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChecerMeniMusik : MonoBehaviour
{
    private GameObject MenuMusik;

    private void Awake()
    {
        Menu.SoundActiveMenu = true;
        MenuMusik = GameObject.FindGameObjectWithTag("MenuMusik");
        if(MenuMusik == null)
        {
            Menu.SoundActiveMenu = true;
        }

    }
}
