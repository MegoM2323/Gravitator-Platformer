using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    private bool FlagForMove = false;
    public int speed;
    public Vector2 TargetPos;

    public static bool f;
    private void FixedUpdate()
    {
        if (FlagForMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, TargetPos, speed * Time.deltaTime);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
