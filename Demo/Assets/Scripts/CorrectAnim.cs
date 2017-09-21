using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectAnim : MonoBehaviour {
    public GameObject paperNote;
    public GameObject lapTop;
    private SFXManager sfx;
    public static bool complete=false;

    private void Start()
    {
        sfx = FindObjectOfType<SFXManager>();
    }

    public void CorrectAnimCompleted()
    {

        paperNote.GetComponent<Animator>().SetBool("complete",true);
        lapTop.GetComponent<Animator>().SetBool("complete",true);
        complete = true;
        //this.GetComponent<Animator>().SetBool("correct", false);
    }

    public void ChechWhetherPasswordComplete()
    {
        lapTop.GetComponent<Animator>().SetBool("complete", complete);
    }
    public void PlayCorrectSound()
    {
        sfx.success.Play();
    }
}
