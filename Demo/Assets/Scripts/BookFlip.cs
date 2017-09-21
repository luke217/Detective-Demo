using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BookFlip : MonoBehaviour {

    public Animator book;
    public int PageNum=6;
    public int currentPageNumber=0;
    private SFXManager sfx;
    private BookPanel bookpanel;

    // Use this for initialization
    void Start()
    {
        book = GetComponent<Animator>();
        sfx = FindObjectOfType<SFXManager>();
        bookpanel = GetComponent<BookPanel>();
        sfx.openbook.Play();
    }

    
    public void leftFlip()
    {
        if (currentPageNumber <= (PageNum-1))
        {
            book.SetTrigger("leftflip");
            currentPageNumber++;
            bookpanel.loadBookPage(bookpanel.currentBooktitle, currentPageNumber);
          
            sfx.flippage.Play();
        }
        if(currentPageNumber==PageNum)
        {
            book.SetTrigger("putaway");
            //currentPageNumber++;
            sfx.flippage.Play();

        }
    }

    public void rightFlip()
    {
        if (currentPageNumber > 0)
        {
            book.SetTrigger("rightflip");
            currentPageNumber--;
            bookpanel.loadBookPage(bookpanel.currentBooktitle, currentPageNumber);
           
            sfx.flippage.Play();
        }
    }


}
