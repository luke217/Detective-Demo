using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Items : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler ,IPointerEnterHandler,IPointerExitHandler,IPointerClickHandler{
    public Item item;
    public int amount;
    public int slotNum;
    public Tooltip tooltip;
    private InventoryManager inv;

    public SplitButton split;
    //public Transform originalParent;

    void Start()
    {
        inv = FindObjectOfType<InventoryManager>();
        tooltip = FindObjectOfType<Tooltip>();
        split = FindObjectOfType<SplitButton>();
        item = inv.items[slotNum];
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            //originalParent = this.transform.parent;
            this.transform.SetParent(this.transform.parent.parent);
            this.transform.position = eventData.position;
            GetComponent<CanvasGroup>().blocksRaycasts = false;
            inv.items[slotNum] = new Item();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
       if (eventData.button == PointerEventData.InputButton.Left)
       {
            this.transform.position = eventData.position;
        }
        split.Deactivate();
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        if (eventData.button == PointerEventData.InputButton.Left)
        {
            // Debug.Log("Yes");
            this.transform.SetParent(inv.slot[slotNum].transform);
            this.transform.position = inv.slot[slotNum].transform.position;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            inv.items[slotNum] = item;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltip.Activate(item);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.Deactivate();
        //split.Deactivate();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if(this.GetComponentInChildren<Text>().text!="")
            if(int.Parse(this.GetComponentInChildren<Text>().text)>=2)
            {
                    // Debug.Log(this.GetComponentInChildren<Text>().text);
                    split.Activate(item,slotNum);
                    tooltip.Deactivate();
            }
        }

    }
}
