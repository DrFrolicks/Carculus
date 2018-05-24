using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDeath : MonoBehaviour {
    public bool safe;
    public GameObject corpse;  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Safe"))
            safe = true; 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Safe"))
            safe = false; 
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Death") && !safe)
            die(); 
    }
    void die()
    {
        Instantiate(corpse, transform.position, Quaternion.identity);
        PlayerManager.instance.players.Remove(gameObject);
        Destroy(gameObject);
    }
}
