using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseBook : MonoBehaviour {

    public BookPanel bookPanel;
    public BookFlip bookFlip;
    public int pageNum;
    private Text title;

	// Use this for initialization
	void Start () {
        //bookPanel = GetComponent<BookPanel>();
        title = GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void click()
    {
        bookPanel.loadBookPage(title.text, 0);
        bookFlip.PageNum = pageNum;
    }

}
