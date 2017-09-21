using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneEnding : MonoBehaviour {

    private DialogueManager dMAn;

    public int questNumberA;
    public QuestObject questA;
    public int questNumberB;
    public QuestObject questB;
    public QuestManager theQM;
    private SFXManager sfx;

    /// <summary>
    /// used for dialogue sound effect exclusively for the phone call.
    /// </summary>
    public bool sfxset = false;

    /// <summary>
    /// once=false means not happened yet;
    /// once=ture means already been triggered
    /// </summary>
    public bool once = false;

    // Use this for initialization
    void Start()
    {
        dMAn = FindObjectOfType<DialogueManager>();
        sfx = FindObjectOfType<SFXManager>();
    }
     void Update()
    {
       if(theQM.questCompleted[questNumberA])
        {
            sfx.bell.Stop();
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            if (!theQM.questCompleted[questNumberA])
            {
                if (Input.GetKeyDown(KeyCode.E))
                {

                    for (int i = 0; i < questA.endText.Length; i++)
                    {
                        dMAn.dialogueLines[i] = questA.endText[i];
                    }

                    sfx.bell.Stop();
                    sfx.pickup.Play();
                    
                    questA.EndQuest(true);
                    theQM.ShowQuestText(questA.endText[0]);

                    sfx.n1.Play();
                    sfxset = true;
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            if (!theQM.questCompleted[questNumberB])
            {
                
                if (!once&&theQM.questCompleted[questNumberA])
                {


                    for (int i = 0; i < questB.startText.Length; i++)
                    {
                        dMAn.dialogueLines[i] = questB.startText[i];
                    }


                    questB.StartQuest(true);
                    theQM.ShowQuestText(questB.startText[0]);

                    once = true;
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            if (!theQM.questCompleted[questNumberB])
            {
                if(!once)
                theQM.quests[questNumberB].gameObject.SetActive(true);
            }
        }
    }
}
