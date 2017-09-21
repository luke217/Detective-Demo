using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class BookDatabase : MonoBehaviour {
    private List<BookPage> database = new List<BookPage>();
    private JsonData bookData;

    void Start()
    {
        //pull in actual object from json object to c# object
        bookData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/books.json"));//file input, read all text from a certain file and place it in the asset folder
        for (int i = 0; i < bookData.Count; i++)
        {
            database.Add(new BookPage((string)bookData[i]["title"], (int)bookData[i]["pageNum"], 
                (string)bookData[i]["leftPage"], (string)bookData[i]["rightPage"],(string)bookData[i]["slug"]));
        }

        Debug.Log(database[0].Title);
    }

    public BookPage FetchBookByTitleandPageNum(string title,int pageNum)
    {
        for (int j = 0; j < database.Count; j++)
        {
            if (database[j].Title == title && database[j].PageNum==pageNum)
            {
                return database[j];
            }

        }
        return null;
    }
}


public class BookPage
{//book prototype
   
    public string Title { get; set; }
    public int PageNum { get; set; }
    public string LeftPage { get; set; }
    public string RightPage { get; set; }

    public string Slug { get; set; }
    public Sprite sprite { get; set; }

    public BookPage()
    {
        this.Title = null;
    }

    public BookPage(string title, int pageNum, string leftPage,string rightPage, string slug)
    {
       
        this.Title = title;
        this.PageNum = pageNum;
        this.LeftPage = leftPage;
        this.RightPage = rightPage;
        this.Slug = slug;
      //if(slug!=null)
       // this.sprite = Resources.Load<Sprite>(slug);
    }

}
