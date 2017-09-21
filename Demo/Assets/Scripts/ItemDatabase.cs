using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class ItemDatabase : MonoBehaviour {
    private List<Item> database = new List<Item>();
    private JsonData itemData;

    void Start()
    {
        //pull in actual object from json object to c# object
        itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath+"/Items.json"));//file input, read all text from a certain file and place it in the asset folder
        for(int i=0; i<itemData.Count;i++)
        {
            database.Add(new Item((int)itemData[i]["id"],(string)itemData[i]["title"],(bool)itemData[i]["stackable"],(string)itemData[i]["slug"]));
        }

       Debug.Log(database[0].Slug);
    }

    public Item FetchItemByID(int id)
    {
        for(int j=0;j<database.Count;j++)
        {
            if(database[j].ID==id)
            {
                return database[j];
            }
            
        }
        return null;
    }

	
}

public class Item
{//item prototype
    public int ID { get; set; }
    public string Title { get; set; }
    public string Slug { get; set; }
    public bool Stackable { get; set; }
    public Sprite sprite { get; set; }

    public Item()
    {
        this.ID = -1;
    }

    public Item(int id, string title, bool stackable,string slug)
    {
        this.ID = id;
        this.Title = title;
        this.Stackable = stackable;
        this.Slug = slug;
        this.sprite = Resources.Load<Sprite>(slug);
    }
    
}
