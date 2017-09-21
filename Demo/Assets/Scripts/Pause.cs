using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour {

    public GameObject startmenu;
    private SFXManager theSFX;
    public StartNewGame button;
    public Text startToResume;
    private PlayerMovement thePlayer;
    // Use this for initialization
    void Start () {
        theSFX = FindObjectOfType<SFXManager>();
        thePlayer = FindObjectOfType<PlayerMovement>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (startmenu.activeSelf)
            {
                button.OnPointerClick(null);
            }
            else
            {
                StartCoroutine(Click());
                if(theSFX.bell.isPlaying)
                {
                    theSFX.bell.Stop();
                }
                thePlayer.canMove = false;
            }
        }
	}

    private IEnumerator Click()
    {
        //game.SetActive(true);
        ScreenFader sf = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();
        yield return StartCoroutine(sf.FadeToBlack());
        theSFX.bgm.Stop();
        theSFX.gamestartmenu.Play();
        startmenu.SetActive(true);
        startToResume.GetComponent<Text>().text = "Resume";
        yield return StartCoroutine(sf.FadeToClear());
    

    }
}
