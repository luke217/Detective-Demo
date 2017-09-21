using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ListButton : MonoBehaviour, IPointerClickHandler
{
    public GameObject Lists;
    public GameObject Scrow;
    public GameObject itemGlow;
    public Text summary;
    private Text Title;
   // private GameObject button;
    private Text buttonText;
    public string text;


    // Use this for initialization
    void Start()
    {
        Title = GameObject.FindGameObjectWithTag("Title").GetComponent<Text>();
        buttonText = GetComponentInChildren<Text>();
       // button = GetComponent<GameObject>();
        //yourButton.onClick.AddListener(taskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        //if (buttonText.text != "")
          // button.transform.SetSiblingIndex(0);
    }



    public void OnPointerClick(PointerEventData data)
    {
        itemGlow.gameObject.SetActive(false);
        Lists.SetActive(false);
        Scrow.SetActive(true);
        Title.text = "Task";
        if (buttonText.text != "") 
        Title.text += ("-"+buttonText.text);
        summary.text = text;
    }
}
