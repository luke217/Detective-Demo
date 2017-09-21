using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelf : MonoBehaviour {

    //public string[] dialogueLines;
    //public int currentline;
    //private DialogueManager dMAn;

    public GameObject books;
    private PlayerMovement thePlayer;
    private Animator thePlayerAnim;

    // Use this for initialization
    void Start()
    {
        //dMAn = FindObjectOfType<DialogueManager>();
        thePlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        thePlayerAnim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
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
                //for (int i = 0; i < dialogueLines.Length; i++)
                //{
                // dMAn.dialogueLines[i] = dialogueLines[i];
                //}

                // dMAn.ShowBox(dialogueLines[currentline]);

                thePlayer.canMove = false;
                thePlayerAnim.SetBool("iswalking", false);
                books.SetActive(true);

            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //for (int i = 0; i < dialogueLines.Length; i++)
                //{
                // dMAn.dialogueLines[i] = dialogueLines[i];
                //}

                // dMAn.ShowBox(dialogueLines[currentline]);

                thePlayer.canMove = true;

                books.SetActive(false);

            }
        }
    }
}
