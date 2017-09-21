using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestObject : MonoBehaviour {
    public int questNumber;
    private QuestManager theQM;
    public GameObject taskAlert;
    public GameObject taskAlert2;


    public string questName;
    public string questSummary;
    public string[] startText;
    public string[] endText;

    /// <summary>
    /// The following references are for the task list button
    /// </summary>
    public Text titletext;
    public ListButton questbrief;
  

	// Use this for initialization
	void Start () {
        theQM = FindObjectOfType<QuestManager>();
       
	}

    void Update()
    {
      
    }
    /// <summary>
    /// call from load is false
    /// </summary>
    /// <param name="callfromloadisfalse"></param>
    public void StartQuest(bool callfromloadisfalse)
    {
        
        //theQM.ShowQuestText(startText[0]);
        //TODO:

        titletext.text = questName;
        questbrief.text = questSummary;
        if (callfromloadisfalse)
        {
            taskAlert.SetActive(true);
  
        }
    }
    /// <summary>
    /// call from load is false
    /// </summary>
    /// <param name="callfromloadisfalse"></param>
    public void EndQuest(bool callfromloadisfalse)
    {
        //theQM.ShowQuestText(endText[0]);
        //TODO:

        titletext.text = "";
        questbrief.text = "";
        theQM.questCompleted[questNumber] = true;
        gameObject.SetActive(false);

        if (callfromloadisfalse)
        {
            taskAlert2.SetActive(true);
       
        }

    }
  
}
