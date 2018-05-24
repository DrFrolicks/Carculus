using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class Safezone
{
    public string prompt;
    public GameObject[] safezones;  
}
public class ProblemSet : MonoBehaviour {
    public string[] safeZonePrompts;
    public GameObject[] safezoneSets;
    public float[] promptDuration;

    public Text promptText; 
    public float percentComplete;

    private void Start()
    {
        StartCoroutine(handlePrompt()); 
    }

    public IEnumerator handlePrompt()
    {
        for(int i = 0; i < safeZonePrompts.Length; i++)
        {
            promptText.text = safeZonePrompts[i];
            if (i > 0)
                safezoneSets[i - 1].SetActive(false);
            safezoneSets[i].SetActive(true);

            GameObject titleScreen = GameObject.Find("Title Screen"); 

            while(titleScreen != null)
            {
                titleScreen = GameObject.Find("Title Screen");
                yield return new WaitForSeconds(2f);
            }

            float timeAtStart = Time.time; 
            while(Time.time < timeAtStart + promptDuration[i])
            {
                percentComplete = (Time.time - timeAtStart) / promptDuration[i]; // to be used by text display 
                yield return new WaitForEndOfFrame();  
            }
            GameManager.instance.nextPrompt();
            yield return new WaitForSeconds(GameManager.instance.firewallDuration); 
        }
        GameManager.instance.nextGraph(); 
    }

    
}
