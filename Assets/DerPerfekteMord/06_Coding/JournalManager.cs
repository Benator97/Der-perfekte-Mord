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
    public GameObject stickyNotePoster;
    public GameObject stickyNoteBomb;
    public GameObject stickyNoteGlue;
    public GameObject stickyNoteReiner1;
    public GameObject stickyNoteTanja1;
    public GameObject stickyNoteReiner2;
    public GameObject stickyNoteTanja2;
    public GameObject stickyNoteReiner3;
    public GameObject stickyNoteReiner4;

    public void Start()
    {
        refreshUI();
    }
    
    public void checkBomb()
    {
        journalData.bombPlaced = true;
        refreshUI();
    }

    public void checkPoster()
    {
        journalData.posterPlaced = true;
        refreshUI();
    }

    public void checkGlue()
    {
        journalData.gluePlaced = true;
        refreshUI();
    }

    public void UIOn()
    {
        canvas.SetActive(true);
        timeManager.hideUI();
    }

    public void UIOff()
    {
        canvas.SetActive(false);
        timeManager.showUI();
    }

    public void resetJournal()
    {
        journalData.bombPlaced = false;
        journalData.gluePlaced = false;
        journalData.posterPlaced = false;
    }

    public void refreshUI()
    {
        stickyNoteBomb.SetActive(journalData.bombPlaced);
        stickyNotePoster.SetActive(journalData.posterPlaced);
        stickyNoteGlue.SetActive(journalData.gluePlaced);
    }
}
