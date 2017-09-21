using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour {
    private Item item;
    private string data;
    public GameObject tooltip;

    public void Activate(Item item)
    {
        this.item = item;
        ConstructData();
        tooltip.transform.GetComponentInChildren<Text>().text = data;
        tooltip.SetActive(true);
     
    }

    public void Deactivate()
    {
        tooltip.SetActive(false);
    }

    public void ConstructData()
    {
        data = "<b>"+item.Title+"</b>";
        
    }

    void Start()
    {
       //tooltip =GameObject.Find("Tooltip");
    }

    void Update()
    {
        if(tooltip.activeSelf)
        {
            tooltip.transform.position = Input.mousePosition;
        }
    }

}
