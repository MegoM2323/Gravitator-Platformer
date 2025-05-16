 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    [Header("Use flag ?")]
    public bool UseFlags = true;
    [Header ("BIG flag")]
    public float flag_1 = 50f;
    [Header("SMALL flag")]
    public float flag_2 = -50f;

    private SpriteRenderer SP;
    private float a = 0f;
    private float Veer;//отклонение(поворот)
    public float Rotationspeed = 2.5f;
    static public float Rotationspeed_static;
    static public float Rotationspeed_Repository;
    private bool checkR = true;
    private bool ColorChecker = true;
    void Awake()
    {
        Rotationspeed_static = Rotationspeed;
        Rotationspeed_Repository = Rotationspeed;
        a = Random.Range(0.05f , 0.95f);
        ColorChecker = true;
        SP = gameObject.GetComponent<SpriteRenderer>();
        checkR = true;
        if(UseFlags == false)
        {
            StartCoroutine(ChangeSpeed());
        }
    }
    private void FixedUpdate()
    {

        //Rotationspeed = Rotationspeed_static;

        Veer = gameObject.transform.eulerAngles.z;
        if (UseFlags == true)
        {
            if (checkR)
            {
                transform.Rotate(new Vector3(0, 0, Rotationspeed));
            }
            else if (!checkR)
            {
                transform.Rotate(new Vector3(0, 0, -Rotationspeed));
            }
            if (Veer >= flag_1)
            {
                checkR = false;
            }
            else if (Veer <= flag_2)
            {
                checkR = true;
            }
        }
        else
        {
            transform.Rotate(new Vector3(0, 0, Rotationspeed));
        }   
    }
    IEnumerator ChangeSpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(3.5f, 10));
            Rotationspeed = Random.Range(-Rotationspeed, Rotationspeed);
        }
    }
    /*IEnumerator checkerRoter()
    {
        while (true)
        {
            if (TwoRotate)
            {
                checkR = !checkR;
            }
            yield return new WaitForSeconds(CheckerTime);
        }
    }*/
}
