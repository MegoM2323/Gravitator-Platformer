using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerMover : MonoBehaviour
{
    public float LeftDistanceX = -1f;
    public float RightDistanceX = -1f;
    public float DownDistanceY = -1f;
    public float UpDistanceY = -1f;

    private bool MoveX = false;
    private bool MoveY = false;
    private float OriginalLocationX;
    private float OriginalLocationY;

    private bool StopFlag = false;

    public float speed = 1f;

    private void Start()
    {
        OriginalLocationX = transform.position.x;
        OriginalLocationY = transform.position.y;
    }

    private void FixedUpdate()
    {
        if (transform.position.x < OriginalLocationX - LeftDistanceX  && StopFlag != true)
        {
            MoveX = false;
        }
        else if (transform.position.x > RightDistanceX + OriginalLocationX && StopFlag != true)
        {
            MoveX = true;
        }

        if (transform.position.y < OriginalLocationY - DownDistanceY && StopFlag != true)
        {
            MoveY = false;
        }
        else if (transform.position.y > UpDistanceY + OriginalLocationY && StopFlag != true)
        {
            MoveY = true;
        }


        if (MoveX && (LeftDistanceX != -1 || RightDistanceX != -1)) //движение по оси X
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(OriginalLocationX + 100000f, transform.position.y, transform.position.z), -speed * Time.deltaTime);
            //transform.Translate(new Vector2(-1, 0).normalized * Time.deltaTime * speed);
        }
        else if (!MoveX && (LeftDistanceX != -1 || RightDistanceX != -1))
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(OriginalLocationX + 100000f, transform.position.y, transform.position.z), speed * Time.deltaTime);
            //transform.Translate(new Vector2(1, 0).normalized * Time.deltaTime * speed);
        }

        if (MoveY && (UpDistanceY != -1 || DownDistanceY != -1)) //движение по оси Y
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, OriginalLocationY + 100000f, transform.position.z), -speed * Time.deltaTime);
        }
        else if (!MoveY && (UpDistanceY != -1 || DownDistanceY != -1))
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, OriginalLocationY + 100000f, transform.position.z), speed * Time.deltaTime);
        }
    }
}
