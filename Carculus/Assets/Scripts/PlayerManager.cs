using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput; 

public class PlayerManager : MonoBehaviour {
    public static PlayerManager instance;
    public GameObject PlayerPrefab;
    public Transform[] spawnLocations; 

    public int numOfPlayers;

    List<GamePad.Index> GamepadIndexesActive;

    public List<GameObject> players; 
    public List<GameObject> refreshPlayers()
    {
        players = new List<GameObject> (GameObject.FindGameObjectsWithTag("Player"));
        return players; 
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;

       GamepadIndexesActive = new List<GamePad.Index>();
    }


    public void spawnPlayer(GamePad.Index index)
    {
        if (players.Count >= spawnLocations.Length)
            return;

        Player p = Instantiate(PlayerPrefab, spawnLocations[players.Count].position, Quaternion.identity).GetComponent<Player>();
        p.GamepadIndex = index;

        players.Add(p.gameObject);
    }
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

        if((GamePad.GetAxis(GamePad.Axis.LeftStick, index) != Vector2.zero || Input.GetAxisRaw("Vertical_" + (int)index) != 0) && !GamepadIndexesActive.Contains(index))
        {
            GamepadIndexesActive.Add(index);
            return true; 
        }
        return false;  
    }
}
