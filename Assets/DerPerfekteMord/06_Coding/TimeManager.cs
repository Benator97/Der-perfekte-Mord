using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AC;

public class TimeManager : MonoBehaviour
{
    public IntVariable timeCounter;
    public IntVariable targetTime;
    public ActionListAsset restartActions;
    public GameObject canvas;
    public Slider slider;

    public void Start()
    {
        slider.maxValue = targetTime.value;
        adjustUI();
    }

    public void hideUI()
    {
        canvas.SetActive(false);
    }

    public void showUI()
    {
        canvas.SetActive(true);
    }
    
    public void addToCounter(int timeValue)
    {
        timeCounter.value += timeValue;
        adjustUI();
        checkCounter();
    }

    public void adjustUI()
    {
        slider.value = timeCounter.value;
    }

    public void resetCounter()
    {
        timeCounter.value = 0;
        adjustUI();
    }

    private void checkCounter()
    {
        if(timeCounter.value >= targetTime.value)
        {
            timeCounter.value = 0;
            AdvGame.RunActionListAsset(restartActions);
        }
    }
}
