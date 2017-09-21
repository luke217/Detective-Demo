using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoType : MonoBehaviour {
    public float letterPause = 10f;
    //string message;
    public Text textComp;
    public DialogueManager theDM;

    // Use this for initialization
    void Start()
    {
        
       //message = textComp.text;
        //textComp.text = "";
       // StartCoroutine(TypeText("qweqweqweqweqweqweqweqwe"));
    }

    public IEnumerator TypeText(string message)
    {
        textComp.text ="";
        theDM.enableInput = false;
        foreach (char letter in message.ToCharArray())
        {
            textComp.text += letter;
            //if (typeSound1 && typeSound2)
               // SoundManager.instance.RandomizeSfx(typeSound1, typeSound2);
            yield return 0;
            yield return new WaitForSeconds(letterPause);
        }
        theDM.enableInput = true;
    }
}
