﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour {
    public Transform warpTarget;
    private IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        ///Debug.Log("An object Collided.");
        ScreenFader sf = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();
         yield return StartCoroutine(sf.FadeToBlack());
        other.gameObject.transform.position = warpTarget.position;
        Camera.main.transform.position = warpTarget.position;
        yield return StartCoroutine(sf.FadeToClear());
    }


}
