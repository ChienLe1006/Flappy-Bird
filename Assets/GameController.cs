using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public AudioClip musicClip;
    private AudioSource audioSource;
    GameObject obj;
    public bool isEndGame;
    bool isStartFirstTime = true;
    int gamePoint;
    public Text txtPoint;
    public GameObject pnlEndGame;
    public Text txtEndPoint;
    public Button btnRestart;
    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        audioSource = obj.GetComponent<AudioSource>();
        audioSource.clip = musicClip;
        audioSource.Play();
        Time.timeScale = 0;
        isEndGame = false;
        isStartFirstTime = true;
        pnlEndGame.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(isEndGame) {
            if((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && isStartFirstTime) {
                StartGame();
            }
        }
        else {
            if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
                Time.timeScale = 1;
            }
        }
    }
    public void GetPoint()
    {
        gamePoint++;
        txtPoint.text = "Điểm: " + gamePoint.ToString();
    }
    void StartGame() 
    {
        SceneManager.LoadScene(0);
    }
    public void Restart()
    {
        StartGame();
    }
    public void EndGame()
    {
        isEndGame = true;
        isStartFirstTime = false;
        Time.timeScale = 0;
        pnlEndGame.SetActive(true);
        if(gamePoint <= 10) {
            txtEndPoint.text = "Ngu vc:\n" + gamePoint.ToString();
        }
        if(gamePoint > 10 && gamePoint <= 15) {
            txtEndPoint.text = "óc cặk:\n" + gamePoint.ToString();
        }
        if(gamePoint > 15 && gamePoint <= 25) {
            txtEndPoint.text = "non:\n" + gamePoint.ToString();
        }
        if(gamePoint > 25) {
            txtEndPoint.text = "eeeeeeeeeeeeeee:\n" + gamePoint.ToString();
        }
    }
}
