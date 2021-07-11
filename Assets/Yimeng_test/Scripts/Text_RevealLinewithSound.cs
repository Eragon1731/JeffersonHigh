using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Text_RevealLinewithSound : MonoBehaviour
{
    private TextMeshPro m_textMeshPro;

    public AudioSource soundeffect;
    
    private float timer;
    public float timePerCharacter;
    private int counter = 0;

    private void Start()
    {
        m_textMeshPro = gameObject.GetComponent<TextMeshPro>() ;
        
        
    }

    public void resetTimer() {
        timer = 0.0f;
        counter = 0;
    }

    public void playTextAnimation() {

        int totalCharacter = m_textMeshPro.textInfo.lineCount;

        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            m_textMeshPro.maxVisibleLines = counter;
            timer += timePerCharacter;
            if (counter < totalCharacter)
            {
                counter += 1;
            }
        }
    }

    private void Update()
    {
        int totalCharacter = m_textMeshPro.textInfo.lineCount;


        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            m_textMeshPro.maxVisibleLines = counter;
            timer += timePerCharacter;
            if (counter < totalCharacter)
            {
                soundeffect.Play();
                counter += 1;
            }
            //Debug.Log(counter);
        }


    }
}

