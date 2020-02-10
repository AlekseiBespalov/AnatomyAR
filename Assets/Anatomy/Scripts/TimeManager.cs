using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    private Text SpeedRateText;
    [SerializeField]
    private float MinSpeedRate = 0.033f;
    [SerializeField]
    private float MaxSpeedRate = 32f;
    private bool Paused { get; set; } = false;

    public float CurrentTimeScale
    {
        get => _currentTimeScale; 
        set => _currentTimeScale = Mathf.Clamp(value, MinSpeedRate, MaxSpeedRate);
    }
    private float _currentTimeScale;
    private void Start()
    {
        CurrentTimeScale = 1;
        ApplyTimeScale();
    }

    private void ApplyTimeScale()
    {
        Time.timeScale = _currentTimeScale;
        Time.fixedDeltaTime = Time.timeScale * .02f;    // for smooth slowmotion
        SpeedRateText.text = _currentTimeScale.ToString() + "x";
        Debug.Log("Time scaled to " + _currentTimeScale);
    }

    public void DecreaseTimeScale()
    {
        CurrentTimeScale /= 2;
        ApplyTimeScale();
    }

    public void IncreaseTimeScale()
    {
        CurrentTimeScale *= 2;
        ApplyTimeScale();
    }

    public void OnStopButton()
    {
        if(Paused)
        {
            Time.timeScale = _currentTimeScale;
            Paused = false;
        }
        else
        {
            Time.timeScale = 0;
            Paused = true;
        }
    }
}
