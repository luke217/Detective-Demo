using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadButton : MonoBehaviour {
    public PlayerMovement player;
    public GamePanel gamePanel;
    public QuestManager theQM;
    public StartNewGame button;
    public GameObject panelforalert;

    public void click()
    {

        if (SaveLoad.Load())
        {
            gamePanel.load();
            theQM.load();
            player.load();

            ///using start(resume) function
            button.OnPointerClick(null);
        }
        else
        {
            panelforalert.SetActive(true);
        }
    }
}
