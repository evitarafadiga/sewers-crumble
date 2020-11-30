using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData {

    public int currentSkinIndex;
    public int currency;
    public int skinAvailability;
    public int emeralds;
    public int currentSaveState;
    public string currentPlayerName;
    public int hitPoints;
    public int shieldPoints;
    public float[] position;

    public PlayerData (GameManager player)
    {
        currentSkinIndex = player.currentSkinIndex;
        currency = player.currency;
        skinAvailability = player.skinAvailability;
        emeralds = player.emeralds;
        currentSaveState = player.currentSaveState;
        currentPlayerName = player.currentPlayerName;
        hitPoints = player.hitPoints;
        shieldPoints = player.shieldPoints;

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }


}
