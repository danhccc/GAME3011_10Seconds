using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public float maxTime = 10f;
    public float timer;

    public TextMeshProUGUI TimerText;
    public GameObject onPlayerTimer;
    public TextMeshPro onPlayerTimerText;
    public GameObject GameoverScreen;
    public GameObject PauseMenu;

    public bool gameStarted;
    public bool AllowGameInput;
    public bool isPause = false;

    private static TimerManager _instance;
    public static TimerManager Instance { get { return _instance; } }

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

    private void Start()
    {
        onPlayerTimerText = onPlayerTimer.GetComponent<TextMeshPro>();

        StartNewGame();
    }
    void Update()
    {
        if (!gameStarted) return;

        timer -= Time.deltaTime;
        TimerText.text = timer.ToString("F2");

        onPlayerTimerText.text = timer.ToString("F2");

        if (timer <= 0)
        {
            Gameover();
        }
    }

    private void StartNewGame()
    {
        AllowGameInput = true;
        timer = maxTime;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Gameover()
    {
        timer = 0;
        Time.timeScale = 0.0f;

        GameoverScreen.SetActive(true);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        AllowGameInput = false;
    }

    public void Pause()
    {
        isPause = !isPause;

        if (isPause)
        {
            PauseMenu.SetActive(true);
            Time.timeScale = 0.0f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            AllowGameInput = false;
        }
        else if (!isPause)
        {
            PauseMenu.SetActive(false);
            Time.timeScale = 1.0f;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            AllowGameInput = true;
        }

    }
}
