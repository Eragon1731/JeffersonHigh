using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class BlinkingText : MonoBehaviour
{

    public TextMeshProUGUI text;
    private bool blink = false;

    void Update()
    {
        blink = true;

        while (blink)
        {
            new WaitForSeconds(2.0f);
            text.alpha = 1.0f;
            //Debug.Log("Add cursor.  Text is now=" + text.text);
            new WaitForSeconds(2.0f);
            text.alpha = 0.0f;
            //text.text = text.text.Remove(text.text.Length - 2, 2);
            //Debug.Log("Remove cursor.  Text is now=" + text.text);
            new WaitForSeconds(2.0f);
        }

        //StartCoroutine(BlinkCursor());
    }

    private IEnumerator BlinkCursor()
    {
        while (blink)
        {
            yield return new WaitForSeconds(2.0f);
            text.alpha = 1.0f;
            //Debug.Log("Add cursor.  Text is now=" + text.text);
            yield return new WaitForSeconds(2.0f);
            text.alpha = 0.0f;
            //text.text = text.text.Remove(text.text.Length - 2, 2);
            //Debug.Log("Remove cursor.  Text is now=" + text.text);
            yield return new WaitForSeconds(2.0f);
        }
    }
}