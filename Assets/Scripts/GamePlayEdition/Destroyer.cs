using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [Header("Tag Name for destroy")]
    public string TagNameForD = "";// ��� ��� ����������� 
    [Header("Tag Name for no destroy")]
    public string TagNameForNoD = "";// ��� �� ��� ����������� 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.CompareTag(TagNameForD) || TagNameForD == "all") && TagNameForNoD != collision.gameObject.tag)
        {
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.CompareTag(TagNameForD) || TagNameForD == "all") && TagNameForNoD != collision.gameObject.tag)
        {
            Destroy(collision.gameObject);
        }
    }
}
