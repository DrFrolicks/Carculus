using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public GameObject conclusionScreen; 
    private void Awake()
    {
        if (instance == null)
            instance = this; 
    }

    // Update is called once per frame
    void Update () {
		
	}
}
