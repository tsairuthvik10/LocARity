using UnityEngine;
using UnityEngine.UI;
using System;

public class TimerManager : MonoBehaviour
{
    public Text globalTimerText;
    public Text treasureTimerText;
    private float globalDuration = 600f; // 10 mins
    private float treasureDuration = 60f;
    private float globalTimeRemaining;
    private float treasureTimeRemaining;

    void Start()
    {
        globalTimeRemaining = globalDuration;
        treasureTimeRemaining = treasureDuration;
    }

    void Update()
    {
        globalTimeRemaining -= Time.deltaTime;
        treasureTimeRemaining -= Time.deltaTime;
        globalTimerText.text = FormatTime(globalTimeRemaining);
        treasureTimerText.text = FormatTime(treasureTimeRemaining);
    }

    public void ResetTreasureTimer()
    {
        treasureTimeRemaining = treasureDuration;
    }

    string FormatTime(float t)
    {
        t = Mathf.Max(0, t);
        TimeSpan time = TimeSpan.FromSeconds(t);
        return time.ToString(@"mm\:ss");
    }
}