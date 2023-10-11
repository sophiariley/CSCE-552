using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerBehavior : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime;
    public bool countDown;

    [Header("Limit Settings")]
    public bool hasLimit;
    public float timerLimit;

    [Header("Format Settings")]
    public bool hasFormat;
    public TimerFormats format;
    private Dictionary <TimerFormats, string> timeFormats = new Dictionary <TimerFormats, string> ();


    // Start is called before the first frame update
    void Start()
    {
        timeFormats.Add(TimerFormats.Whole, "0");
        timeFormats.Add(TimerFormats.TenthDecimal, "0.0");
        timeFormats.Add(TimerFormats.HundredthDecimal, "0.00");
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;
        if(hasLimit && (countDown && currentTime <= timerLimit) || (!countDown && currentTime >= timerLimit))
        {
            currentTime = timerLimit;
            HandleTimerLimitReached();
            SetTimerText();
            timerText.color = Color.red;
            enabled = false;
        }
        SetTimerText();
    }

    private void SetTimerText()
    {
        timerText.text = hasFormat ? currentTime.ToString(timeFormats[format]) : currentTime.ToString();    
    }
    private void HandleTimerLimitReached() // WORK GOD DAMN YOU
    {
        timerText.color = Color.red;
        // Check if the scene "LoseScreen" exists before loading it
        if (SceneManager.GetSceneByName("LoseScreen").isLoaded)
        {
            SceneManager.LoadScene("LoseScreen");
        }
        // Debugging...
        else
        {
            Debug.LogError("The 'LoseScreen' scene does not exist.");
        }
        enabled = false;
    }
}

public enum TimerFormats
{
    Whole,
    TenthDecimal,
    HundredthDecimal
}
