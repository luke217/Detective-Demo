using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotManager : MonoBehaviour ,IDropHandler{



    public int id;
    private InventoryManager inv;






    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Items dropedItem = eventData.pointerDrag.GetComponent<Items>();
            if (inv.items[id].ID == -1)
            {

                dropedItem.slotNum = id;
            }
            else if (inv.items[id].ID == dropedItem.item.ID)
            {
                Items data = inv.slot[id].transform.GetComponentInChildren<Items>();

                if (data.amount == 0 && dropedItem.amount == 0)
                { data.amount = 2; }
                else if (data.amount == 0 && dropedItem.amount != 0)
                { data.amount = dropedItem.amount + 1; }
                else if (data.amount != 0 && dropedItem.amount == 0)
                { data.amount++; }
                else
                {
                    data.amount += dropedItem.amount;
                }

                Text text = data.transform.GetComponentInChildren<Text>();
                text.text = data.amount.ToString();

                Destroy(dropedItem.transform.gameObject);
            }
        }
    }

    // Use this for initialization
    void Start () {
        inv = FindObjectOfType<InventoryManager>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
  
    
    // trigger = true;
    //transform.GetComponentInParent<InventoryManager>().selectedSlot = this.transform;

}
