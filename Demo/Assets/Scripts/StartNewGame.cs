using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using System;

public class StartNewGame : MonoBehaviour, IPointerClickHandler{

    public GameObject startmenu;
    private SFXManager theSFX;
    public Animator panel;
    private PlayerMovement thePlayer;

    private void Start()
    {
        theSFX = FindObjectOfType<SFXManager>();
        thePlayer = FindObjectOfType<PlayerMovement>();
    }

   

     private IEnumerator Click()
    {
        //game.SetActive(true);
        ScreenFader sf = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();
         yield return StartCoroutine(sf.FadeToBlack());
        theSFX.gamestartmenu.Stop();
        theSFX.bgm.PlayDelayed(1.5f);
        panel.GetComponent<Animator>().SetTrigger("fadeout");
       // startmenu.SetActive(false);
        yield return StartCoroutine(sf.FadeToClear());
        startmenu.SetActive(false);

    }

    public void OnPointerClick(PointerEventData eventData)
    {

        StartCoroutine(Click());
        thePlayer.canMove = true;
       
    }
}
