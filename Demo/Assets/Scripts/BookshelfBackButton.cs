using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookshelfBackButton : MonoBehaviour {

    public BookFlip bookFlip;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void click()
    {
        bookFlip.currentPageNumber = 0;
    }
}
