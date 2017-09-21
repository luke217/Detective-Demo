using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {
    public GameObject dBox;
    public Text dText;
    public AutoType autoType;
    public bool dialogActive;

    public string[] dialogueLines=new string[10];
    public int currentline;
  

    private PlayerMovement thePlayer;
    private Animator thePlayerAnim;
    private PhoneEnding qE;
    private SFXManager sfx;
    // public string[] introduction=new string[3];
    //  public int currentline;


    public bool enableInput = true;
    public bool loading = false;




	// Use this for initialization
	void Start () {
        thePlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        thePlayerAnim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        qE = FindObjectOfType<PhoneEnding>();
        sfx = FindObjectOfType<SFXManager>();
        dialogActive = false;
        dBox.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (dialogActive&&enableInput)
        {
            if (loading)
            {
                for (int i = 0; dialogueLines[i] != "0"; i++)
                {
                    dialogueLines[i] = "0";
                }
                dBox.SetActive(false);
                thePlayer.canMove = true;
                currentline = 0;
                dialogActive = false;
                loading = false;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // dBox.SetActive(false);
                //thePlayer.canMove = true;
                currentline++;
            
              if (dialogueLines[currentline] == "0")
                {
                    for (int i = 0; dialogueLines[i] != "0"; i++)
                    {
                        dialogueLines[i] = "0";
                    }
                    dBox.SetActive(false);
                    thePlayer.canMove = true;
                    currentline = 0;
                    dialogActive = false;

                }
                else
                {
                    dText.text = "";
                    StartCoroutine(autoType.TypeText(dialogueLines[currentline]));
                    //dText.text = dialogueLines[currentline];
                    if (qE.sfxset)
                    {
                        switch (currentline)
                        {
                            case 1:
                                if (!sfx.d1.isPlaying)
                                    sfx.d1.Play();


                                break;
                            case 2:
                                if (!sfx.n2.isPlaying)
                                    sfx.n2.Play();

                                break;
                            case 3:
                                if (!sfx.d2.isPlaying)
                                    sfx.d2.Play();

                                break;
                            case 4:
                                if (!sfx.d3.isPlaying)
                                    sfx.d3.Play();

                                qE.sfxset = false;
                                break;


                        }
                    }

                }
            }
        }
    }
    public void ShowBox(string dialogue)
    {
        dialogActive = true;
        dBox.SetActive(true);
        //dText.text = dialogue;
        dText.text = "";
        StartCoroutine(autoType.TypeText(dialogue));

        thePlayer.canMove = false;
        thePlayerAnim.SetBool("iswalking", false);
    }
}
