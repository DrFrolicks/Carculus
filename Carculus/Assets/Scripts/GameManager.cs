using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public enum GameMode {singleplayer, multiplayer}; 
    
    public GameObject conclusionScreen;
    public GameObject titleScreen;

    public float firewallDuration;
    public ActiveTemporary firewall;

    public GameObject[] graphs;
    List<GameObject> graphsAvailable;
    GameObject activeGraph;

    
    private void Awake()
    {
        if (instance == null)
            instance = this;

        refreshGraphs(); 
    }

    private void Start()
    {
        nextGraph();
    }
    
    private void Update()
    {
        if (PlayerManager.instance.players.Count > 0 && !IsInvoking("startGame") && titleScreen.activeSelf)
            Invoke("startGame", 3f); 
    }

    void startGame()
    {
        titleScreen.SetActive(false); 
    }

    public void nextPrompt()
    {
        firewall.activate(firewallDuration);

        Invoke("checkWinner", firewallDuration / 2); 
    }

    public void nextGraph()
    {
        if (graphsAvailable.Count <= 0)
            refreshGraphs(); 
        GameObject instantiatedGraph = graphsAvailable[Random.Range(0, graphsAvailable.Count)];
        if(activeGraph != null)
            Destroy(activeGraph); 
        activeGraph = Instantiate(instantiatedGraph).gameObject;
        graphsAvailable.Remove(activeGraph); 
    }

    void refreshGraphs()
    {
        graphsAvailable = new List<GameObject>(graphs); 
    }

    void checkWinner()
    {
        if (PlayerManager.instance.players.Count == 1)
        {
            win(PlayerManager.instance.players[0]); 
        }
    }

    void win(GameObject winner)
    {

    }
}
