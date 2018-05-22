using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput; 

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

    public void spawnPlayer(GamePad.Index index)
    {
        if (numOfPlayers >= spawnLocations.Length)
            return;

        Player p = Instantiate(PlayerPrefab, spawnLocations[numOfPlayers].position, Quaternion.identity).GetComponent<Player>();
        p.GamepadIndex = index;  

        numOfPlayers++;  
    }

    List<GamePad.Index> GamepadIndexesActive = new List<GamePad.Index>(); 
    private void Update()
    {
        for (int i = 1; i < 5; i++)
            spawnOnGamepadInput((GamePad.Index)i); 

    }

    void spawnOnGamepadInput(GamePad.Index index)
    {
        if (leftStickFirstMoved(index))
        {
            spawnPlayer(index);
        }
    }

    bool leftStickFirstMoved(GamePad.Index index)
    {
        if(GamePad.GetAxis(GamePad.Axis.LeftStick, index) != Vector2.zero && !GamepadIndexesActive.Contains(index))
        {
            GamepadIndexesActive.Add(index);
            return true; 
        }
        return false;  
    }
}
