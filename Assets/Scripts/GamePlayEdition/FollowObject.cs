using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    /*
    public GameObject BoomEffect; // эфект после взрыва
    public float Bulletspeed = 4; // скорость 
    public Vector2 purpose1; // цель до куда двигаться
    private bool flag = true; // ВС для определения достигнута ли цель движения 
    public void Awake()
    {
        //Vector2 purpose = PlayerController.MousePosClick;
        //purpose1 = purpose;
    }
    private void Start()
    {
        StartCoroutine(BoomEff());
    }
    private void FixedUpdate()
    {
        Vector2 p1 =  new Vector2(purpose1.x * 1, purpose1.y * 1);
        if (transform.position.x != p1.x && transform.position.y != p1.y && flag == true)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, p1, Bulletspeed * Time.deltaTime);
        }
        else
        {
            flag = false;
        }
    }
    IEnumerator BoomEff()
    {
        yield return new WaitForSeconds(Random.Range(1.5f, 4.9f));
        Instantiate(BoomEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    */

}
