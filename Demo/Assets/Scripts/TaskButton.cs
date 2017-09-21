using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TaskButton : MonoBehaviour , IPointerClickHandler{
    public GameObject paper;
    

    // Use this for initialization
    void Start () {
      
        //yourButton.onClick.AddListener(taskOnClick);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
  

  
    public void OnPointerClick(PointerEventData data)
    {
        
        paper.SetActive(true);
        GetComponent<ItemGlow>().active = false;

    }








}
