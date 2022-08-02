using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AC;

public class JournalManager : MonoBehaviour
{
    public JournalData journalData;
    public TimeManager timeManager;
    public GameObject canvas;
    public GameObject stickyReiner1;
    public GameObject stickyReiner2;
    public GameObject stickyReiner3;
    public GameObject stickyReiner4;
    public GameObject stickyTanja1;
    public GameObject stickyTanja2;

    public void Start()
    {
        refreshUI();
    }
    
    public void checkReiner(int i)
    {
        switch (i)
        {
            case 1: journalData.reiner1 = true; break;
            case 2: journalData.reiner2 = true; break;
            case 3: journalData.reiner3 = true; break;
            case 4: journalData.reiner4 = true; break;
        }

        refreshUI();
    }

    public void checkTanja(int i)
    {
        switch (i)
        {
            case 1: journalData.tanja1 = true; break;
            case 2: journalData.tanja2 = true; break;
        }

        refreshUI();
    }

    public void resetJournal()
    {
        journalData.reiner1 = false;
        journalData.reiner2 = false;
        journalData.reiner3 = false;        
        journalData.reiner3 = false;        
        journalData.tanja1 = false;        
        journalData.tanja2 = false;        
    }

    public void refreshUI()
    {
        stickyReiner1.SetActive(journalData.reiner1);
        stickyReiner2.SetActive(journalData.reiner2);
        stickyReiner3.SetActive(journalData.reiner3);
        stickyReiner4.SetActive(journalData.reiner4);
        stickyTanja1.SetActive(journalData.tanja1);
        stickyTanja2.SetActive(journalData.tanja2);
    }
}
