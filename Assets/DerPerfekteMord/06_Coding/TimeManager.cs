using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AC;

public class TimeManager : MonoBehaviour
{
    public IntVariable timeCounter;
    public IntVariable targetTime;
    public ActionListAsset restartActions;

    public void addToCounter(int timeValue)
    {
        timeCounter.value += timeValue;
        checkCounter();
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
