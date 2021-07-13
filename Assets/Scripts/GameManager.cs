using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public enum GameState { start, playing, pause, death }
    public GameState gameState;
    [SerializeField] GameObject pauseCanvas;
    [SerializeField] GameObject gameCanvas;
    [SerializeField] GameObject startCanvas;
    [SerializeField] GameObject deathCanvas;
    [SerializeField] SphereController sphereController;
    [SerializeField] PlatformMovement platformMovement;
    [SerializeField] Transform corridorStart;
    [SerializeField] int pointAmount;
    [SerializeField] Text pointsText;

    public void GameLost()
    {
        gameCanvas.SetActive(false);
        gameState = GameState.death;
        deathCanvas.SetActive(true);
    }

    public void SetPause()
    {
        Time.timeScale = 0;
        gameState = GameState.pause;
        pauseCanvas.SetActive(true);
    }

    public void RemovePause()
    {
        Time.timeScale = 1;
        gameState = GameState.playing;
        StartCoroutine(MovePlatform());
        gameCanvas.SetActive(true);
    }

    public void RestartLevel()
    {
        ReturnGravity();
        sphereController.gameObject.transform.localPosition = Vector3.zero;
        platformMovement.gameObject.transform.position = corridorStart.position;
        gameState = GameState.start;
        pointAmount = 0;
        pointsText.text = "Score: " + pointAmount;
        sphereController.isGravityReversed = false;
        startCanvas.SetActive(true);
    }

    public void Click()
    {
        if (gameState == GameState.start)
        {
            startCanvas.SetActive(false);
            gameCanvas.SetActive(true);
            gameState = GameState.playing;
            StartGame();
            sphereController.StartRotation();
            StartCoroutine(MovePlatform());
        }
        else if (gameState == GameState.playing)
        {
            sphereController.StartRotation();
        }
    }

    private void ReturnGravity()
    {
        if(Physics.gravity.y > 0)
        {
            Physics.gravity *= -1;
        }
    }

    private void StartGame()
    {
        sphereController.StartRotation();
    }

    IEnumerator MovePlatform()
    {
        while (gameState == GameState.playing)
        {
            platformMovement.StartPlatformMovement();
            yield return null;
        }
    }

    public void AddPoint()
    {
        pointAmount++;
        pointsText.text = "Score: " + pointAmount;
    }
}
