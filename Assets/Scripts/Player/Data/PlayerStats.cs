using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public PlayerAbilities playerAbilities;
    public Transform playerPosition;
    public int health = 100;
    public int stamina = 80;
    public int level = 7;

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        level = data.level;
        health = data.health;

        playerPosition.SetPositionAndRotation(new Vector3(data.position[0], data.position[1], data.position[2]), playerPosition.rotation);

        playerPosition.localScale = new Vector3(data.scale, playerPosition.localScale.y, playerPosition.localScale.z);

        playerAbilities.DASHACQUIRED = data.dashAcquired;
        playerAbilities.DBLJUMPACQUIRED = data.dblJumpAcquired;
    
    }
}