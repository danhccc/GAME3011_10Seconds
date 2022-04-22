using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class TimerManager : MonoBehaviour
{
    [Header("Variables")]
    public float maxTime = 10f;
    public float timer;
    public int supplyPoint;

    [Header("TMPro References")]
    //public TextMeshProUGUI TimerText;
    public TextMeshProUGUI supplyPointText;
    public TextMeshPro onPlayerTimerText;
    public GameObject onPlayerTimer;
    public TextMeshProUGUI FinalTime;
    public TextMeshProUGUI FinalScore;

    [Header("Win/Lose Panel")]
    public GameObject SupplyPointPanal;
    public GameObject GameoverScreen;
    public GameObject PauseMenu;
    //public TextMeshProUGUI Score;
    //public TextMeshProUGUI TimeRemain;

    public GameObject LevelClearScreen;

    public bool gameStarted;
    public bool AllowGameInput;
    public bool isPause = false;

    public bool isPlayed = false;
    //audio 
    private AudioSource audioSource;
    
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

        audioSource = GetComponent<AudioSource>();
        
        StartNewGame();
    }

    void Update()
    {
        if (!gameStarted) return;

        timer -= Time.deltaTime;
        //TimerText.text = timer.ToString("F2");

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
        Time.timeScale = 1.0f;

        SupplyPointPanal.SetActive(true);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Gameover()
    {
        timer = 0;
        Time.timeScale = 0.0f;

        SupplyPointPanal.SetActive(false);
        GameoverScreen.SetActive(true);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        AllowGameInput = false;
    }

    public void LevelClear()
    {
        Time.timeScale = 0.0f;
        FinalTime.text = "Time Remain: " + timer.ToString("F2");
        FinalScore.text = "Supply Gather: " + supplyPoint.ToString();
        SupplyPointPanal.SetActive(false);
        LevelClearScreen.SetActive(true);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        TimerManager.Instance.AllowGameInput = false;
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
