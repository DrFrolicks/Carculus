using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveTemporary : MonoBehaviour {

	public void activate(float seconds)
    {
        gameObject.SetActive(true);
        Invoke("deactivate", seconds); 
    }

    void deactivate()
    {
        gameObject.SetActive(false); 
    }
}
