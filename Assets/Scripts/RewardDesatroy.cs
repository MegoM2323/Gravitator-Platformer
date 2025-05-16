using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardDesatroy : MonoBehaviour
{
    //[Header("Time Untill destroy")]
    //public float TimeUntillColl = -1; // ����� �� �����������
    [Header("Score GameObject")]
    public GameObject ScoreObject;
    [Header("Reward Object")]
    public GameObject RewardObject;
    [Header("Tag Name for collision")]
    public string TagNameForColl = "";// ��� ��� ����������� ��������� 
    [Header("Limit Counter")]
    public int Limit�ounter = 1; // ���������� ��������� �� ������� �� ����������� � ������������� ����-��
    private int counter = 0; // ������� ���������� ��������� �� �������  

    public void FixedUpdate()
    {
        if(counter >= Limit�ounter)//�������� ����� ��������� ���������� ���������
        {
            Instantiate(RewardObject, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(TagNameForColl))
        {
            Instantiate(ScoreObject, new Vector2(transform.position.x + 2f, transform.position.y + 2f) , Quaternion.identity);
            counter++;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagNameForColl))
        {
            Instantiate(ScoreObject, new Vector2(transform.position.x + 2f, transform.position.y + 2f), Quaternion.identity);
            counter++;
        }
    }
}