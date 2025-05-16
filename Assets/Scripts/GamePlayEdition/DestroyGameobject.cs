using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameobject : MonoBehaviour
{
    [Header("Time Untill destroy")]
    public float TimeUntillD = -1; // время до уничтожения
    // когдф равна -1, то уничтожения не происходит 
    [Header("Tag Name for destroy")]
    public string TagNameForD = "";// тег для уничтожения 

    public void Start()
    {
        if (TimeUntillD != -1)
            StartCoroutine(DestroyGameObject());
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(TagNameForD) || TagNameForD == "all")
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagNameForD) || TagNameForD == "all")
        {
            Destroy(gameObject);
        }
    }
    IEnumerator DestroyGameObject()
    {
        yield return new WaitForSeconds(TimeUntillD);
        Destroy(gameObject);
    }
}
