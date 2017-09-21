using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookPanel : MonoBehaviour {

    public BookDatabase database;
    //public GameObject image;
    public GameObject leftpage;
    public GameObject rightpage;
    public string currentBooktitle;

    // Use this for initialization
    void Start()
    {
        //database = GetComponent<BookDatabase>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void loadBookPage(string title, int pageNum)
    {
        Debug.Log("loadBookPage");
        BookPage bookPagetoLoad = new BookPage();
            bookPagetoLoad=database.FetchBookByTitleandPageNum(title, pageNum);
        currentBooktitle = title;

        leftpage.GetComponent<Text>().text = bookPagetoLoad.LeftPage;
        rightpage.GetComponent<Text>().text = bookPagetoLoad.RightPage;

       /* if (bookPagetoLoad.Slug != null)
        {
            image.GetComponent<Image>().sprite = bookPagetoLoad.sprite;
            image.SetActive(true);
        }
        else
        {
            image.SetActive(false);
        }*/
        //image.setactive(false) after flip the page or close the book.
       
    }
    
}