using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inputfield : MonoBehaviour {

    public GameObject lapTop;
    private InputField inputfieldText;
    
	// Use this for initialization
	void Start () {
       
        lapTop.GetComponent<Animator>().SetBool("wrong", false);
        inputfieldText = GetComponent<InputField>();
    }
	
	public void GetInput()
    {
        string key = inputfieldText.text;
        //inputfieldText.text = "";
        if(key=="4")
        {
            // Debug.Log(key);
            lapTop.GetComponent<Animator>().SetBool("correct", true);
        }
        else if(key=="")
        {

        }
        else
        {
            //Debug.Log(key);
            lapTop.GetComponent<Animator>().SetBool("wrong", true);
        }
        inputfieldText.text = "";
        Debug.Log(key);

    }

    
}
