using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeText : MonoBehaviour {
    public bool fadeInAndOut, fadeIn, fadeOut, fadeInOnTrigger;  
    public float stayDuration, fadeSpeed, delay;  

    private void Start()
    {

        Text img = transform.GetComponent<Text>();
        img.color = new Color(img.color.r, img.color.g, img.color.b, 0);

        if(!fadeInOnTrigger)
            Invoke("startFade", delay); 
    }

    public void startFade(float p_delay)
    {
        Invoke("startFade", p_delay);

    }

    void startFade()
    {
        if (fadeInAndOut)
        {
            StartCoroutine(fadeTextInAndOut());
        }
        else if (fadeIn)
        {
            StartCoroutine(fadeText(transform.GetComponent<Text>(), false));
        }
        else if (fadeOut)
        {
            StartCoroutine(fadeText(transform.GetComponent<Text>(), true));
        }
    }

    private void OnDisable()
    {
        StopAllCoroutines(); 
    }

    public IEnumerator fadeTextInAndOut()
    {
        while (true)
        {
            StartCoroutine(fadeText(transform.GetComponent<Text>(), false));
            yield return new WaitForSeconds(fadeSpeed);
            yield return new WaitForSeconds(stayDuration);
            StartCoroutine(fadeText(transform.GetComponent<Text>(), true));
            yield return new WaitForSeconds(fadeSpeed);
            yield return new WaitForSeconds(stayDuration);

        }
    }

    public IEnumerator fadeText(Text img, bool fadeAway)
    {
        Color color = img.color; 
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= 1/fadeSpeed * Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(color.r, color.g, color.b, i);
                yield return null;
            }
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 1; i += 1/fadeSpeed * Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(color.r, color.g, color.b, i);
                yield return null;
            }
        }
    }
}
