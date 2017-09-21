using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct GamePrototype
{
    /// <summary>
    /// data of the player position(vector3) and animator parameters
    /// </summary>
    public PlayerSavedData playerData;

    /// <summary>
    /// data of the quest completed list and object-active list
    /// </summary>
    public QuestCompletedSavedList questData;

}
