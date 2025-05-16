using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceDontTouch : MonoBehaviour
{
    [Header("Tag Name for destroy")]
    public string TagNameForD = "";// тег для уничтожения 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(TagNameForD))
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(TagNameForD))
        {
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagNameForD))
        {
            Destroy(collision.gameObject);
        }
    }
}
