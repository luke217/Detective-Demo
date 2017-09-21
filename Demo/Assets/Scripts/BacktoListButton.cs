using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BacktoListButton : MonoBehaviour, IPointerClickHandler
{
    public GameObject Lists;
    public GameObject Scrow;
    public GameObject glowImage;
    private Text Title;

    // Use this for initialization
    void Start()
    {
        Title = GameObject.FindGameObjectWithTag("Title").GetComponent<Text>();

        //yourButton.onClick.AddListener(taskOnClick);
    }

    // Update is called once per frame
    void Update()
    {

    }



    public void OnPointerClick(PointerEventData data)
    {

        Lists.SetActive(true);
        Scrow.SetActive(false);
        Title.text = "Task List";
        glowImage.gameObject.SetActive(false);
    }
}

