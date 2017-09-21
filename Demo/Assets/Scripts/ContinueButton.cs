using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ContinueButton : MonoBehaviour, IPointerClickHandler
{
    public GameObject paper;
    public GameObject Lists;
    public GameObject Scrow;
    public GameObject TaskButton;
    public GameObject GlowImage;
    private Text Title;

    // Use this for initialization
    void Start()
    {
        Title = GameObject.FindGameObjectWithTag("Title").GetComponent<Text>();
        //TaskButton.GetComponent<ItemGlow>().active = false;
        
        //yourButton.onClick.AddListener(taskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void OnPointerClick(PointerEventData data)
    {
        paper.SetActive(false);
        if(!Lists.activeSelf)
        {
            Lists.SetActive(true);
            Scrow.SetActive(false);
            Title.text = "Task List";
        }
        TaskButton.GetComponent<ItemGlow>().active = true;
        GlowImage.gameObject.SetActive(false);
    }
}
