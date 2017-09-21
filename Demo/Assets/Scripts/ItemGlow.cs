using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ItemGlow : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject image;
    public bool active=true;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (active)
        {
            image.gameObject.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
       
            image.gameObject.SetActive(false);
        
    }

    // Use this for initialization
    void Start () {
 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
 
}
