using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour {
    public Texture2D defaultPic;
    public CursorMode curMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

	// Use this for initialization
	void Start () {
        Cursor.SetCursor(defaultPic,hotSpot,curMode);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
