using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public GameObject conclusionScreen;

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
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        if (players.Length == 1)
        {
            win(players[0]); 
        }
    }

    void win(GameObject winner)
    {

    }
}
