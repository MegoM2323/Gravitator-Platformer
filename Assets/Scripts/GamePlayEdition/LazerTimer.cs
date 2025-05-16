using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerTimer : MonoBehaviour
{
    [Header ("For Line ")]
    public Gradient Gradient1;
    public Gradient Gradient2;
    [Header("For SpriteRenderer ")]
    public Color Color1;
    public Color Color2;
    [Header("Time Flags")]
    public float TimeFlag1 = 0.7f;
    public float TimeFlag2 = 2.7f;
    private LineRenderer LR;
    private SpriteRenderer SP;
    public bool IsLine = true;

    public void Start()
    {
        if(IsLine)LR = gameObject.GetComponent<LineRenderer>();
        else SP = gameObject.GetComponent<SpriteRenderer>();
        StartCoroutine(ChangeColor());
    }
    IEnumerator ChangeColor()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(TimeFlag1, TimeFlag2));
            if (IsLine) LR.colorGradient = Gradient1;
            else SP.color = Color1;
            gameObject.tag = "Enemy";
            yield return new WaitForSeconds(Random.Range(TimeFlag1, TimeFlag2));
            if (IsLine) LR.colorGradient = Gradient2;
            else SP.color = Color2;
            gameObject.tag = "Untagged";
        }
    }
}
