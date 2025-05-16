using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class Colorer : MonoBehaviour
{
    //public Color StartColor;
    public bool IsText; // Обозначает является ли объект текстом
    private SpriteRenderer SP;
    private Text TXT;
    private float a = 0f;
    private bool ColorChecker = true;
    private void Start()
    {
        if (!IsText)
        {
            SP = gameObject.GetComponent<SpriteRenderer>();
        }
        else if (IsText)
        {
            TXT = gameObject.GetComponent<Text>();
        }
        ColorChecker = true;
        a = Random.Range(0.05f, 0.95f);
    }
    public void FixedUpdate()
    {
        if (IsText) ChangeColorForText();
        if (!IsText) ChangeColorForSprite();
        if (a >= 0.955)
        {
            ColorChecker = false;
        }
        else if (a <= 0.005)
        {
            ColorChecker = true;
        }
        //StartColor = StartColor(StartColor.a++, StartColor.r, StartColor.g, StartColor.b);
        //gameObject.GetComponent<Renderer>.
    }

    private void ChangeColorForText()
    {
        if (ColorChecker)
        {
            a = a + 0.004f;
            TXT.color = Color.HSVToRGB(a, 1f, 1f);
        }
        else if (!ColorChecker)
        {
            a = a - 0.004f;
            TXT.color = Color.HSVToRGB(a, 1f, 1f);
        }
    }
    private void ChangeColorForSprite()
    {
        if (ColorChecker)
        {
            a = a + 0.004f;
            SP.color = Color.HSVToRGB(a, 1f, 1f);
        }
        else if (!ColorChecker)
        {
            a = a - 0.004f;
            SP.color = Color.HSVToRGB(a, 1f, 1f);
        }
    }
}