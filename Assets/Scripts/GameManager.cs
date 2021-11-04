using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int score;
    [Header("Ball")]
    public GameObject ball;
    Ball ballSc;
    [Header("Camera")]
    public GameObject camera;
    public float cameraYOffset;
    [Header("Wall")]
    public GameObject wall;
    public float wallCreateDuration;
    public GameObject wallCreateY;
    [Header("Canvas")]
    public Text gameCurrentText;
    public Text endGamescoreText;
    public Text bestScoreText;
    public GameObject canvas;



    void Start()
    {
        InvokeRepeating("wallInstant",0, wallCreateDuration);
        score = 0;
        gameCurrentText.text = score.ToString();
        if (!PlayerPrefs.HasKey("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", 0);
        }
        ballSc = ball.GetComponent<Ball>();
        InvokeRepeating("scoreUpdate", 0, 0.3f);
    }
    void Update()
    {
        if (ballSc.isFinishGame)
        {
            finishGame();
        }
        gameCurrentText.text = score.ToString();
        camera.transform.position = new Vector3(
            camera.transform.position.x,
            ball.transform.position.y+cameraYOffset,
            camera.transform.position.z);
    }
    void wallInstant()
    {
        float random = Random.Range(-2.4f, 2.4f);
        Instantiate(wall, new Vector3(random, wallCreateY.transform.position.y, -.5f),Quaternion.identity);
        
    }
    public void restart()
    {
        Time.timeScale = 1;
        ballSc.isFinishGame = false;
        SceneManager.LoadScene(0);
    }
    void finishGame()
    {
        Time.timeScale = 0;
        if (score > PlayerPrefs.GetInt("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", score);
        }
        bestScoreText.text = PlayerPrefs.GetInt("BestScore").ToString();
        endGamescoreText.text = score.ToString();
        canvas.SetActive(true);

    }
    void scoreUpdate()
    {
        score += 1;
    }
}
