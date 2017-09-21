using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour {


    private ItemDatabase database;
    //private InventoryManager inventory;
    public GameObject item;

    /// <summary>
    /// item list which is corresponded with the slots
    /// </summary>
    public List<Item> items= new List<Item>();

    public GameObject[] slot;
   
	// Use this for initialization
	void Start () {
        database = GetComponent<ItemDatabase>();
        //inventory = GetComponent<InventoryManager>();
       slot[0] = GameObject.Find("slot_0"); slot[1] = GameObject.Find("slot_1");
        slot[2] = GameObject.Find("slot_2"); slot[3] = GameObject.Find("slot_3");
        slot[4] = GameObject.Find("slot_4"); slot[5] = GameObject.Find("slot_5");
        slot[6] = GameObject.Find("slot_6"); slot[7] = GameObject.Find("slot_7");
        slot[8] = GameObject.Find("slot_8");

      

        for(int i=0; i<9;i++)
        {
            items.Add(new Item());
            slot[i].GetComponent<SlotManager>().id = i;
        }
        AddItem(0);
        AddItem(0);
        AddItem(1);
        AddItem(1);


    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddItem(int id)
    {
        Item itemToAdd = database.FetchItemByID(id);


        /*if (itemToAdd.Stackable && checkifitemisintheinventory(itemToAdd))
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ID == id)
                {
                    Items data = slot[i].transform.GetComponentInChildren<Items>();

                    if (data.amount == 0)
                    { data.amount = 2; }
                    else { data.amount++; }

                    Text text=data.transform.GetComponentInChildren<Text>();
                    text.text = data.amount.ToString();
                    break;
                }
            }
        }
        else
        {*/
            for (int j = 0; j < items.Count; j++)
            {
                if (items[j].ID == -1)
                {
                    items[j] = itemToAdd;

                    GameObject itemObj = Instantiate<GameObject>(item);
                    itemObj.transform.SetParent(slot[j].transform, false);
                    itemObj.GetComponent<Items>().slotNum = j;
                    itemObj.GetComponent<Image>().sprite = itemToAdd.sprite;
                    itemObj.name = itemToAdd.Title;
                    itemObj.transform.position = slot[j].transform.position;

                    break;
                }
            }
        //}
    }
    bool checkifitemisintheinventory(Item item)
    {
        for (int i = 0; i < items.Count; i++)
            if (items[i].ID == item.ID)
                return true;
        return false;
    }
}
