using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desk : MonoBehaviour {

    //public string[] dialogueLines;
    //public int currentline;
    //private DialogueManager dMAn;

    public GameObject laptopandNote;
    private PlayerMovement thePlayer;
    private Animator thePlayerAnim;

    public bool laptopcanclose=true;

    /// <summary>
    /// Turn on the glowing effects when the gameobject is deactivated.
    /// </summary>
    public GameObject A;
    public GameObject B;

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
                laptopandNote.SetActive(true);
                A.GetComponent<ItemGlow>().active = true;
                B.GetComponent<ItemGlow>().active = true;
            }
            if (Input.GetKeyDown(KeyCode.Space)&&laptopcanclose)
            {
                //for (int i = 0; i < dialogueLines.Length; i++)
                //{
                // dMAn.dialogueLines[i] = dialogueLines[i];
                //}

                // dMAn.ShowBox(dialogueLines[currentline]);

                thePlayer.canMove = true;
                
                laptopandNote.SetActive(false);

            }
        }
    }
}
