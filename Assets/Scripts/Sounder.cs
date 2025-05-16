using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Sounder : MonoBehaviour
{
    public int[] ActiveScene;
    private bool lifeflag = false;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        StartCoroutine(DelayForDetect());
    }

    private void FixedUpdate()
    {
        lifeflag = false;
        for (int i = 0; i < ActiveScene.Length; i++)
        {
            if (ActiveScene[i] == SceneManager.GetActiveScene().buildIndex)
            {
                lifeflag = true;
            }
        }
        if (!lifeflag) Destroy(gameObject);
    }

    IEnumerator DelayForDetect()
    {
        yield return new WaitForSeconds(0.05f);
        if (GameObject.FindGameObjectWithTag("Sounder"))
        {
            Destroy(gameObject);
        }
        gameObject.tag = "Sounder";
    }

    /*private void FixedUpdate()
    {
        foreach (var i in DeactiveScene) {
            if(i == SceneManager.GetActiveScene().buildIndex) Destroy(gameObject);
        }
    }*/
}