using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
using UnityEngine.Purchasing;

public class GamePlayProvider : MonoBehaviour
{
    public float Rotationspeed = 2.5f;
    public static GameObject MoverForPlayer;

    private bool Gravitation = true;

    public static int CounterForMove;

    public static bool RightButtonClick = false;
    public static bool LeftButtonClick = false;

    public GameObject LeftPlayButton;
    public GameObject RightPlayButton;
    public GameObject GravitationPlayButton;

    public static float BostSpeed = 0f;
    public static bool PauseGamePlay = false;
    public GameObject PauseButton;
    public GameObject PauseMenu;
    public GameObject GameOverMenu;
    private GameObject Player;
    public GameObject ContinueDestroyPanel;
    public GameObject WinMenu;
    public GameObject NextLevelButton;


    public GameObject GameSounder;

    private Vector2 ScorePos;// позиция следующего добавления очка
    //public float ScoreOffset = 1f;// промежуток между добовдением очков(расстояние)
    private Vector2 PLayerPos;// позиция игрока

    bool GameOverHeppend = false;

    private void Start()
    {
        Instantiate(GameSounder, transform.position, Quaternion.identity);
        if (SceneManager.GetActiveScene().buildIndex == 19) Destroy(NextLevelButton); //Уничтожение кнопки следуюшего уровня, если уровней больше нет
        if (Advertisement.isSupported) // Ads suppurting
        {
            Advertisement.Initialize("3734065", false);
        }
     
        MoverForPlayer = GameObject.FindGameObjectWithTag("FollowObject");
        RightButtonClick = false;
        LeftButtonClick = false;
        PlayerController.WinFlag = false;
        WinMenu.SetActive(false);
        //ContinueDestroyPanel.SetActive(false);
        Player = GameObject.FindGameObjectWithTag("Player");
        PauseGamePlay = false;
        PlayerController.GameOverFlag = false;
        PauseMenu.SetActive(false);
    }
    private void FixedUpdate()
    {
        if (PlayerController.WinFlag)
        {
            Win();
        }
        if (RightButtonClick)
        {
            Player.transform.position = Vector3.MoveTowards(Player.transform.position, new Vector3(MoverForPlayer.transform.position.x, Player.transform.position.y, Player.transform.position.z), PlayerController.PlayerSpeed * Time.deltaTime);
            //Player.transform.Translate(new Vector2(1, 0) * PlayerController.PlayerSpeed * Time.deltaTime);
            if(Gravitation)Player.transform.Rotate(new Vector3(0, 0, -Rotationspeed));
            if(!Gravitation)Player.transform.Rotate(new Vector3(0, 0, Rotationspeed));
        }
        if (LeftButtonClick)
        {
            Player.transform.position = Vector3.MoveTowards(Player.transform.position, new Vector3(MoverForPlayer.transform.position.x, Player.transform.position.y, Player.transform.position.z), -PlayerController.PlayerSpeed * Time.deltaTime);
            //Player.transform.Translate(new Vector2(-1, 0) * PlayerController.PlayerSpeed * Time.deltaTime);
            if (Gravitation) Player.transform.Rotate(new Vector3(0, 0, Rotationspeed));
            if (!Gravitation) Player.transform.Rotate(new Vector3(0, 0, -Rotationspeed));
        }
        //Debug.Log(Random.Range(1,4));
        if (!PlayerController.GameOverFlag) 
            PLayerPos = Player.transform.position;
        if (PLayerPos.y >= ScorePos.y)
        {
            //Score.score += 1;
            //ScorePos.y = Player.transform.position.y + ScoreOffset;
        }
        if (PlayerController.GameOverFlag && !GameOverHeppend)
        {
            GameOverHeppend = true;
            GameOver();
        }
    }

    public void Win()
    {
        if (!PlayerPrefs.HasKey("openlevels") || PlayerPrefs.GetInt("openlevels") < 1)
        {
            PlayerPrefs.SetInt("openlevels", 1);
        }
        else if (PlayerPrefs.GetInt("openlevels") < SceneManager.GetActiveScene().buildIndex - 3) {
            PlayerPrefs.SetInt("openlevels", SceneManager.GetActiveScene().buildIndex - 3);
        }
        RightButtonClick = false;
        LeftButtonClick = false;
        WinMenu.SetActive(true);
        Player.SetActive(false);
        LeftPlayButton.SetActive(false);
        RightPlayButton.SetActive(false);
        GravitationPlayButton.SetActive(false);
        PauseGamePlay = false;
        PauseMenu.SetActive(false);
    }

    public void Pause()
    {
        if (PauseGamePlay)
        {
            Player.SetActive(true);
            LeftPlayButton.SetActive(true);
            RightPlayButton.SetActive(true);
            GravitationPlayButton.SetActive(true);
            PauseGamePlay = false;
            PauseMenu.SetActive(false);
        }
        else if (!PauseGamePlay)
        {
            Player.SetActive(false);
            LeftPlayButton.SetActive(false);
            RightPlayButton.SetActive(false);
            GravitationPlayButton.SetActive(false);
            PauseGamePlay = true;
            PauseMenu.SetActive(true);
        }
    }
    public void GameOver()
    {
        PlayAds();
        PauseButton.SetActive(false);
        Player.SetActive(false);
        PauseGamePlay = true;
        GameOverMenu.SetActive(true);

        RightButtonClick = false;
        LeftButtonClick = false;

        //From 
        LeftPlayButton.SetActive(false);
        RightPlayButton.SetActive(false);
        GravitationPlayButton.SetActive(false);
        //PauseGamePlay = false;
        //PauseMenu.SetActive(false);
    }
    public void Retry()
    {
        PlayerController.GameOverFlag = false;
        GamePlayProvider.PauseGamePlay = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ChangeGravity()
    {
        Player.GetComponent<Rigidbody2D>().gravityScale *= -1;
        Gravitation = !Gravitation;
        GravitationPlayButton.transform.eulerAngles =
            new Vector3(GravitationPlayButton.transform.eulerAngles.x, GravitationPlayButton.transform.eulerAngles.y, (GravitationPlayButton.transform.eulerAngles.z + 180) % 360);
    }
    public void RightButtonDown()
    {
        RightButtonClick = true;
    }
    public void LeftButtonDown()
    {
        LeftButtonClick = true;
    }
    public void RightButtonUp()
    {
        RightButtonClick = false;
    }
    public void LeftButtonUp()
    {
        LeftButtonClick = false;
    }

    public void ContinuePlay() // продолжение игры (за просмотр рекламы)
    {
        ContinueDestroyPanel.SetActive(true);
        Player.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Player.transform.position.z);
        PlayerController.GameOverFlag = false;
        PauseButton.SetActive(true);
        Player.SetActive(true);
        PauseGamePlay = false;
        GameOverMenu.SetActive(false);
        new WaitForSeconds(0.5f);
        StartCoroutine(WaitForSetActFalse());
    }
    IEnumerator WaitForSetActFalse()
    {
        yield return new WaitForSeconds(0.3f);
        ContinueDestroyPanel.SetActive(false);
        PauseGamePlay = false;
    }

    private void PlayAds()
    {
        if (PlayerPrefs.GetInt("NoAds") == 0 || !PlayerPrefs.HasKey("NoAds"))
        {
            if (PlayerPrefs.GetInt("ads_counter") % 5 == 0)
            {
                //Instantiate(GameOverSound, new Vector3(0, 0, 0), Quaternion.identity);
                if (Advertisement.IsReady())
                {
                    Advertisement.Show("video");
                    PlayerPrefs.SetInt("ads_counter", 1);
                }
                Handheld.Vibrate();
            }
            else if (!PlayerPrefs.HasKey("ads_counter"))
            {
                PlayerPrefs.SetInt("ads_counter", 1);
            }
            else
            {
                PlayerPrefs.SetInt("ads_counter", PlayerPrefs.GetInt("ads_counter") + 1);
            }
        }
    }
}
