using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskListManager : MonoBehaviour {

    private Text[] text=new Text[7];
    private GameObject[] button = new GameObject[7];
    private Image[] image=new Image[7];


    // Use this for initialization
    void Start () {
        text[0] = GameObject.FindGameObjectWithTag("text0").GetComponent<Text>();
        text[1] = GameObject.FindGameObjectWithTag("text1").GetComponent<Text>();
        text[2] = GameObject.FindGameObjectWithTag("text2").GetComponent<Text>();
        text[3] = GameObject.FindGameObjectWithTag("text3").GetComponent<Text>();
        text[4] = GameObject.FindGameObjectWithTag("text4").GetComponent<Text>();
        text[5] = GameObject.FindGameObjectWithTag("text5").GetComponent<Text>();
        text[6] = GameObject.FindGameObjectWithTag("text6").GetComponent<Text>();

        button[0] = GameObject.FindGameObjectWithTag("button0");
        button[1] = GameObject.FindGameObjectWithTag("button1");
        button[2] = GameObject.FindGameObjectWithTag("button2");
        button[3] = GameObject.FindGameObjectWithTag("button3");
        button[4] = GameObject.FindGameObjectWithTag("button4");
        button[5] = GameObject.FindGameObjectWithTag("button5");
        button[6] = GameObject.FindGameObjectWithTag("button6");

        image[0] = GameObject.FindGameObjectWithTag("button0").GetComponent<Image>();
        image[1] = GameObject.FindGameObjectWithTag("button1").GetComponent<Image>();
        image[2] = GameObject.FindGameObjectWithTag("button2").GetComponent<Image>();
        image[3] = GameObject.FindGameObjectWithTag("button3").GetComponent<Image>();
        image[4] = GameObject.FindGameObjectWithTag("button4").GetComponent<Image>(); 
        image[5] = GameObject.FindGameObjectWithTag("button5").GetComponent<Image>(); 
        image[6] = GameObject.FindGameObjectWithTag("button6").GetComponent<Image>();

    }
	
	// Update is called once per frame
	void Update () {
		sort();
	}
 void sort()
    {
        
        int[] array= new int[7];
       

        int[] a = { -1,-1, -1, -1, -1, -1, -1 };
        int[] b = { -1, -1, -1, -1, -1, -1, -1 };
        ///mark the button
        for(int k=0;k<7;k++)
        if (text[k].text =="")
        {
                image[k].color = new Color(255, 255, 255, 0);
                button[k].GetComponentInChildren<ItemGlow>().active = false;
                array[k] = 0;
            }
        else
        {
                array[k] = 1;
                image[k].color = new Color(255, 255, 255, 200);
                button[k].GetComponentInChildren<ItemGlow>().active = true;
        }


        //distribute button for sort
        int aIndex=0, bIndex=0;
        for(int k=0;k<7;k++)
        {
            if(array[k]==1)
            {
                a[aIndex] = k;
                aIndex++;
            }
            else
            {
                b[bIndex] = k;
                bIndex++;
            }
        }
        //merge the result
        int[] merge = new int[7];
        for (int k = 0; k < aIndex; k++)
        {
            merge[k] = a[k];
        }
        for (int k = 0; k < bIndex; k++)
        {
            merge[k+aIndex] = b[k];
        }

        //change position of the button;
        for(int k=0;k<7;k++)
        {
            button[merge[k]].transform.SetSiblingIndex(k);
           
        }
        


        int q = 100 * merge[0] + 10 * merge[1] + merge[2];
        Debug.Log(q);
    
        Debug.Log("sort");

    }
}
