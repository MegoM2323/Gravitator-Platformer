using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    public float speed = 2f;
    public float offsetX = 0.4f;
    public float offsetY = 0f;
    private GameObject targetObj;
    private Transform target;

    void Start()
    {
        targetObj = GameObject.FindGameObjectWithTag("Player");
        target = targetObj.GetComponent<Transform>();
        transform.position = target.position;   
    }

    void FixedUpdate()
    {
        //transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(target.position.x + offsetX, target.position.y + offsetY, -10), speed * Time.deltaTime);
        //transform.Translate(new Vector3(target.position.x, target.position.y, -10).normalized * Time.deltaTime * speed);
        //transform.position = new Vector3(target.position.x, target.position.y - offset , -500f);
    }
}
