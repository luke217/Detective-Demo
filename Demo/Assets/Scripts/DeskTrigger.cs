using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskTrigger : MonoBehaviour {

    private DialogueManager dMAn;

    public int questNumberA;
    public QuestObject questA;
    public int questNumberB;
    public QuestObject questB;
    public QuestManager theQM;
    
    


    /// <summary>
    /// once=false means not happened yet;
    /// once=ture means already been triggered
    /// </summary>
    public bool once = false;


    // Use this for initialization
    void Start()
    {
        dMAn = FindObjectOfType<DialogueManager>();
       
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            if (!theQM.questCompleted[questNumberA])
            {
                if (Input.GetKeyDown(KeyCode.E))
                {                   

                    questA.EndQuest(true);
                    
                    if (!theQM.questCompleted[questNumberB])
                    {

                        if (!once && theQM.questCompleted[questNumberA])
                        {


                            for (int i = 0; i < questB.startText.Length; i++)
                            {
                                dMAn.dialogueLines[i] = questB.startText[i];
                            }

                            ///even though this one is not calling from loading but I just don't want to display the task alert
                            questB.StartQuest(false);

                            once = true;
                        }
                    }

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
                if (!once)
                    theQM.quests[questNumberB].gameObject.SetActive(true);
            }
        }
    }
}
