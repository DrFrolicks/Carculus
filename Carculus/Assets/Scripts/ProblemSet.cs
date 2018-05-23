using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safezone
{
    public string prompt;
    public GameObject[] safezones;  
}
public class ProblemSet : MonoBehaviour {
    public string[] safeZonePrompts;
    public GameObject[] safezoneSets;
    public float[] promptDuration;

    public TextMesh textMesh; 
    public float percentComplete; 

   
    public IEnumerator handlePrompt()
    {
        for(int i = 0; i < safeZonePrompts.Length; i++)
        {
            textMesh.text = safeZonePrompts[i];
            if (i > 0)
                safezoneSets[i - 1].SetActive(false);
            safezoneSets[i].SetActive(true);

            float timeAtStart = Time.time; 
            while(Time.time < timeAtStart + promptDuration[i])
            {
                percentComplete = (Time.time - timeAtStart) / promptDuration[i]; // to be used by text display 
                yield return new WaitForEndOfFrame();  
            }
            GameManager.instance.nextPrompt();  
        }
        GameManager.instance.nextGraph(); 
    }

    
}
