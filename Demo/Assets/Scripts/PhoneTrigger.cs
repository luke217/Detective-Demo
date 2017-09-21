using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneTrigger : MonoBehaviour {

    private DialogueManager dMAn;

    public int questNumber;
    public QuestObject quest;
    public QuestManager theQM;
    private SFXManager sfx;
    public bool once = false;  

    // Use this for initialization
    void Start()
    {
        dMAn = FindObjectOfType<DialogueManager>();
        sfx = FindObjectOfType<SFXManager>();
    }

    void Update()
    {
        if (theQM.questCompleted[questNumber])
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
     {
        if (other.gameObject.name == "Player")
        {
            if (!theQM.questCompleted[questNumber])
            {
                if (!once)
                {

                    for (int i = 0; i < quest.startText.Length; i++)
                    {
                        dMAn.dialogueLines[i] = quest.startText[i];
                    }
                    sfx.bell.Play();

                    quest.StartQuest(true);
                    theQM.ShowQuestText(quest.startText[0]);
                    once = true;
                }

            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            if (!theQM.questCompleted[questNumber])
            {
                theQM.quests[questNumber].gameObject.SetActive(true);
            }
        }
    }
}
