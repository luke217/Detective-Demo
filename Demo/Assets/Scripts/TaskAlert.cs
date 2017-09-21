using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskAlert : MonoBehaviour {
    public GameObject taskAlert;
    public void TaskAlertComplete()
    {

        taskAlert.SetActive(false);

    }

    
}
