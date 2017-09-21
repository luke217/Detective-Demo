using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongAnim : MonoBehaviour {
    private SFXManager sfx;
    private void Start()
    {
        sfx = FindObjectOfType<SFXManager>();
    }

    public void PlayAlarm()
    {
        sfx.alarm.Play();
    }


    public void WrongAnimCompleted()

    {
       
        this.GetComponent<Animator>().SetBool("wrong", false);
    }
}
