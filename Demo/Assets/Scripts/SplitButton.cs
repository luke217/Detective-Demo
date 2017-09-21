using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SplitButton : MonoBehaviour {

    private Item item;
    public int slotNum;
    public GameObject split;
    private InventoryManager theIM;

    public void Activate(Item item,int slotNum)
    {
        this.item = item;
        this.slotNum = slotNum;
        split.SetActive(true);

        split.transform.position = Input.mousePosition;
    }

    public void Deactivate()
    {
        split.SetActive(false);
    }

     public void splitItem()
    {
        theIM.AddItem(item.ID);
        Items data = theIM.slot[slotNum].transform.GetComponentInChildren<Items>();
        data.amount--;
        Text text = data.transform.GetComponentInChildren<Text>();
        if (data.amount != 1)
        {
            text.text = data.amount.ToString();
        }
        else
        {
            text.text = "";
        }

        split.SetActive(false);
    }

    void Start()
    {
        theIM = this.GetComponentInChildren<InventoryManager>();
    }

    void Update()
    {
     
    }
}
