using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    public static PlayerManager instance;
    public GameObject PlayerPrefab;
    public Transform[] spawnLocations; 

    public int numOfPlayers; 

    private void Awake()
    {
        if (instance == null)
            instance = this; 
    }

    public void spawnPlayer()
    {
        if (numOfPlayers >= spawnLocations.Length)
            return;

        Player p = Instantiate(PlayerPrefab, spawnLocations[numOfPlayers].position, Quaternion.identity).GetComponent<Player>();
        p.index = numOfPlayers;  
        numOfPlayers++;  
    }
}
