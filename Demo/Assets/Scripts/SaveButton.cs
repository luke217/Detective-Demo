using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveButton : MonoBehaviour {
    public PlayerMovement player;
    public GamePanel gamePanel;
    public QuestManager theQM;

    public void click()
    {
        player.save();
        theQM.save();
        gamePanel.save();
        SaveLoad.Save();
    }
    
}



