using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Text_RevealWordwithSound : MonoBehaviour
{
    private TextMeshPro m_textMeshPro;
    public AudioSource soundeffect;
    // public GameObject hold_text; 

    private float timer = 0;
    public float timePerCharacter;
    private int counter = 0;
    private bool isLetter = true;

    private int totalCharacter; 
    private void Start()
    {
        m_textMeshPro = gameObject.GetComponent<TextMeshPro>() ;
        //totalCharacter = 21; 
        playsound();
    }


    public void resetTimer()
    {
        //Debug.Log("testing reset");
        timer = 0.0f;
        counter = 0;
        isLetter = true;
    }


    private void Update()
    {
        if (totalCharacter <= 0)
        {
            totalCharacter = 21; 
        }
        else {
            totalCharacter = m_textMeshPro.textInfo.characterCount;
        }
        playsound();

        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            m_textMeshPro.maxVisibleCharacters = counter;
            //  print("c" + counter);
            //  print("total char" + totalCharacter);
            timer += timePerCharacter;
            if (counter < totalCharacter)
            {
                counter += 1;
            }
            else
            {
                isLetter = false;
            }
            //Debug.Log(counter);
        }
    }

    void playsound()
    {
        if (isLetter)
        {
            soundeffect.Play();
            //Debug.Log("Play");
        }
        else if (isLetter==false)
        {
            soundeffect.Stop();
            //Debug.Log("Stop");
        }
    }
}