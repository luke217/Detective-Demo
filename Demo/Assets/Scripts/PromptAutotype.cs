using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PromptAutotype : MonoBehaviour {
    public float letterPause = 0f;
    //string message;
    public Text textComp;
    public Desk desk;

    public IEnumerator TypeText(string message)
    {
        desk.laptopcanclose = false;
        textComp.text = "";
        
        foreach (char letter in message.ToCharArray())
        {
            textComp.text += letter;
            //if (typeSound1 && typeSound2)
            // SoundManager.instance.RandomizeSfx(typeSound1, typeSound2);
            yield return 0;
            yield return new WaitForSeconds(letterPause);
        }

        desk.laptopcanclose = true;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnEnable()
    {
        StartCoroutine(TypeText(textComp.text));
    }
}
