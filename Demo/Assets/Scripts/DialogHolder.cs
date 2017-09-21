using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogHolder : MonoBehaviour {

    public string[] dialogueLines;
    public int currentline;
    private DialogueManager dMAn;

	// Use this for initialization
	void Start () {
        dMAn = FindObjectOfType<DialogueManager>();
	}

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            { 
                for(int i=0; i<dialogueLines.Length;i++)
                {
                    dMAn.dialogueLines[i] = dialogueLines[i];
                }

                dMAn.ShowBox(dialogueLines[currentline]);
            }
        }
    }


}
/*
 if (other.gameObject.name == "Player")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    dMAn.ShowBox(dialogue);
                }
            }
 */
