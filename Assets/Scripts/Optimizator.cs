using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Optimizator : MonoBehaviour
{
    //public GameObject ActiveObject;
    //public GameObject DeactivationObject;

    public GameObject[] ActiveObjects;
    public GameObject[] DeactiveObjects;
    public GameObject[] DelayActiveObjects;
    public float Delay = 0.5f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(DelayForActive());
            //Instantiate(Object, transform.position, Quaternion.identity);
            //if (DeactivationObject) DeactivationObject.SetActive(false);
            //if (ActiveObject) ActiveObject.SetActive(true);
            for (int i = 0; i <= Mathf.Max(DeactiveObjects.Length, ActiveObjects.Length); i++)
            {
                if (i < DeactiveObjects.Length) DeactiveObjects[i].SetActive(false);
                if (i < ActiveObjects.Length) ActiveObjects[i].SetActive(true);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(DelayForActive());
            //Instantiate(Object, transform.position, Quaternion.identity);
            //if (DeactivationObject) DeactivationObject.SetActive(false);
            //if (ActiveObject) ActiveObject.SetActive(true);
            for (int i = 0; i <= Mathf.Max(DeactiveObjects.Length, ActiveObjects.Length); i++)
            {
                if (i < DeactiveObjects.Length) DeactiveObjects[i].SetActive(false);
                if (i < ActiveObjects.Length) ActiveObjects[i].SetActive(true);
            }
        }
    }

    IEnumerator DelayForActive()
    {
        yield return new WaitForSeconds(Delay);
        for (int i = 0; i <= DelayActiveObjects.Length; i++)
        {
            yield return new WaitForSeconds(Delay);
            DelayActiveObjects[i].SetActive(true);
        }
        Destroy(gameObject);
    }
}
