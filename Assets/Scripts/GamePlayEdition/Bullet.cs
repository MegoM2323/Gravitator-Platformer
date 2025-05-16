using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 3f;
    private void Start()
    {
        StartCoroutine(UntillDestroy());
    }
    private void FixedUpdate()
    {
        if(!GamePlayProvider.PauseGamePlay && !PlayerController.GameOverFlag)transform.Translate(new Vector2(1, 0).normalized * Time.deltaTime * speed);
        //if(!GamePlayProvider.PauseGamePlay && !PlayerController.GameOverFlag)
        {
            //transform.position = Vector3.MoveTowards(transform.position, new Vector3(MoverForPlayer.transform.position.x, transform.position.y, transform.position.z), -PlayerController.PlayerSpeed * Time.deltaTime);
        }
    }
    IEnumerator UntillDestroy()
    {
        yield return new WaitForSeconds(20f);
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Untagged"))
            Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Untagged"))
             Destroy(gameObject);
    }
}
