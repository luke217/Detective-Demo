using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwNoteComplete : MonoBehaviour {

    public GameObject paperNote;
    public QuestObject quest;

    public void throwAnimCompleted()
    {
        paperNote.SetActive(false);
        quest.EndQuest(true);
    }
}
