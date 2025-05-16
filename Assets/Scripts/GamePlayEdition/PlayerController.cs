using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static bool WinFlag = false;

    public static bool GameOverFlag = false;
    public float speed = 3f;
    public static float PlayerSpeed = 3f;
    private void Start()
    {
        PlayerSpeed = speed;
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            GamePlayProvider.RightButtonClick = false;
            GamePlayProvider.LeftButtonClick = true;
            //transform.position = Vector3.MoveTowards(transform.position, new Vector3(GamePlayProvider.MoverForPlayer.transform.position.x, transform.position.y, transform.position.z), PlayerController.PlayerSpeed * Time.deltaTime);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            GamePlayProvider.LeftButtonClick = false;
            //transform.position = Vector3.MoveTowards(transform.position, new Vector3(GamePlayProvider.MoverForPlayer.transform.position.x, transform.position.y, transform.position.z), PlayerController.PlayerSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            GamePlayProvider.RightButtonClick = true;
            GamePlayProvider.LeftButtonClick = false;
            //transform.position = Vector3.MoveTowards(transform.position, new Vector3(GamePlayProvider.MoverForPlayer.transform.position.x, transform.position.y, transform.position.z), PlayerController.PlayerSpeed * Time.deltaTime);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            GamePlayProvider.RightButtonClick = false ;
            //transform.position = Vector3.MoveTowards(transform.position, new Vector3(GamePlayProvider.MoverForPlayer.transform.position.x, transform.position.y, transform.position.z), PlayerController.PlayerSpeed * Time.deltaTime);
        }

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameOverFlag = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameOverFlag = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameOverFlag = true;
        }
        if (collision.gameObject.CompareTag("Lighter"))
        {
            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.HSVToRGB(Random.Range(0f, 1f), 1f, 1f);
        }
        if (collision.gameObject.CompareTag("WInObject"))
        {
            WinFlag = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameOverFlag = true;
        }
        if (collision.gameObject.CompareTag("Lighter"))
        {
            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.HSVToRGB(1f, 1f, 1f);
        }
        if (collision.gameObject.CompareTag("WInObject"))
        {
            WinFlag = true;
        }
    }
}