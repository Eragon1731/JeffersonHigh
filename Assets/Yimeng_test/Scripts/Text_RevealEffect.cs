using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Text_RevealEffect : MonoBehaviour
{
    private TextMeshPro m_textMeshPro;

    private float timer;
    public float timePerCharacter;
    public TMP_InputField inputField; 
    private int counter = 0;

    protected List<string> loadscene_keys;

    private void Start()
    {
        loadscene_keys = new List<string> { "start", "Get to broad window", "Get into the vent!" };
        m_textMeshPro = gameObject.GetComponent<TextMeshPro>() ;
    }


    public void resetTimer()
    {
        if (!loadscene_keys.Contains(inputField.text))
        {
            timer = 0.0f;
            counter = 0;
        }
    }


    private void Update()
    {
        int totalCharacter = m_textMeshPro.textInfo.characterCount;


        timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                m_textMeshPro.maxVisibleCharacters = counter;
                timer += timePerCharacter;
                if (counter < totalCharacter)
                {
                    counter += 1;
                }
                //Debug.Log(counter);
            }
        

    }
}
 