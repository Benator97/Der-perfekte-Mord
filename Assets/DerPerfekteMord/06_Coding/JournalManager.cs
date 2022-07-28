using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AC;

public class JournalManager : MonoBehaviour
{
    public JournalData journalData;
    public GameObject stickyNotePoster;
    public GameObject stickyNoteBomb;
    public GameObject stickyNoteGlue;

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
