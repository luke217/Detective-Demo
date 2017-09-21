using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {

    public QuestObject[] quests;
    public bool[] questCompleted;
    public DialogueManager theDM;

    private GamePanel gamePanel;
    public QuestCompletedSavedList questList;

    // Use this for initialization
    void Start () {
        questCompleted = new bool[quests.Length];
        questList.questCompletedList = new bool[quests.Length];
        questList.questObjectActive = new bool[quests.Length];

        gamePanel = FindObjectOfType<GamePanel>();
	}

    public void ShowQuestText(string questText)
    {
        theDM.ShowBox(questText);
    }

    public void save()
    {
        questList.questCompletedList = questCompleted;
        for(int i=0;i<quests.Length;i++)
        {
            if(quests[i].gameObject.activeSelf)
            {
                questList.questObjectActive[i]=true;
            }
            else
            {
                questList.questObjectActive[i] = false;
            }
        }

        gamePanel.thisGame.questData = questList;
    }

    public void load()
    {
         questList = gamePanel.thisGame.questData;

         questCompleted = questList.questCompletedList;
        for (int i = 0; i < quests.Length; i++)
        {
            if (questList.questObjectActive[i])
            {
                quests[i].gameObject.SetActive(true);
                quests[i].StartQuest(false);
            }
            else
            {
               //if task reminder carry the info so that the quest object is active at the moment
               if(quests[i].gameObject.activeSelf)
                    quests[i].EndQuest(false);
                quests[i].gameObject.SetActive(false);
               
            }
        }
        theDM.loading = true;
    }
}


[System.Serializable]
public struct QuestCompletedSavedList
{
    /// <summary>
    /// data list of the quest completion
    /// </summary>
    public bool[] questCompletedList;

    /// <summary>
    /// data list of whether quest object is active or not 
    /// </summary>
    public bool[] questObjectActive;

}