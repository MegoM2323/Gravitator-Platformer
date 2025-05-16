using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_Text : MonoBehaviour
{
    private void Start()
    {
        GetComponent<UnityEngine.UI.Text>().text = Score.score.ToString();
    }
}
