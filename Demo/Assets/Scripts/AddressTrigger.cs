using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddressTrigger : MonoBehaviour {
    private DialogueManager dMAn;

    public int questNumber;
    public QuestObject quest;
    public QuestManager theQM;
   // private SFXManager sfx;


    // Use this for initialization
    void Start()
    {
        dMAn = FindObjectOfType<DialogueManager>();
        //sfx = FindObjectOfType<SFXManager>();
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


                for (int i = 0; i < quest.startText.Length; i++)
                {
                    dMAn.dialogueLines[i] = quest.startText[i];
                }
                //sfx.bell.Play();

                quest.StartQuest(true);

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
