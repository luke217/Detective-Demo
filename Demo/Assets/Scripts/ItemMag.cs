using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemMag : MonoBehaviour, IPointerClickHandler{

    public GameObject A;
    public GameObject AGlow;
    public GameObject B;
   

    public void OnPointerClick(PointerEventData eventData)
    {
       
        if (A.activeSelf)
        {
            AGlow.gameObject.SetActive(false);
            A.GetComponent<ItemGlow>().active = false;
            A.GetComponent<Animator>().SetBool("Mag", true);
            A.GetComponent<Animator>().SetBool("Nar", false);
        }
        if (B.activeSelf)
        {
            B.GetComponent<Animator>().SetBool("Nar", true);
            B.GetComponent<Animator>().SetBool("Mag", false);
            B.GetComponent<ItemGlow>().active = true;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
