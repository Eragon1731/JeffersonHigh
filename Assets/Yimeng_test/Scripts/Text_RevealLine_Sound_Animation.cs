using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using TMPro;

public class Text_RevealLine_Sound_Animation : MonoBehaviour
{
    private TextMeshPro m_textMeshPro;

    private float timer;
    public float timePerCharacter;
    private int counter = 0;
    private float animationcounter = 0;
    public float animationTime = 0.1f;
    private float a = 1;
    private string normaltext;
    public string textManagement;

    private void Start()
    {
        m_textMeshPro = gameObject.GetComponent<TextMeshPro>() ;
        normaltext = m_textMeshPro.text;

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
                gameObject.GetComponent<AudioSource>().Play();
                counter += 1;
            }
            //Debug.Log(counter);
        }

        if (counter >= totalCharacter)
        {
            
            string text2 = "<mspace=0.7em>         --- ---" + "\n" + "\n" + "<o> <o>            (O)-(O)" + "\n" +"\n"+
                           "               '." + "\n" + "    ._________[|~|__." + "\n" + "   /           |_|_  \\ " +
                           "\n" + "  /                   \\";
            string text3 = "<mspace=0.7em>         <0> <0>" + "\n" + "\n" + "<o> <o>            (-)-(-)" + "\n" +"\n"+
                           "               '." + "\n" + "    ._________[|~|__." + "\n" + "   /           |_|_  \\ " +
                           "\n" + "  /                   \\";
            string text4 = "<mspace=0.7em>         <0> <0>" + "\n" + "\n" + "--- ---            (O)-(O)" + "\n" +"\n"+
                           "               '." + "\n" + "    ._________[|~|__." + "\n" + "   /           |_|_  \\ " +
                           "\n" + "  /                   \\";
            string[] text = {normaltext, text2, text3, text4};
            animationcounter -= Time.deltaTime;
            if (animationcounter <= 0f)
            {
                //Debug.Log("anime");
                animationcounter += animationTime;
                
                
                if (a == 1)
                {
                    m_textMeshPro.SetText(text2);
                    
                    //Debug.Log(m_textMeshPro.text);
                }

                if (a == -1)
                {
                    m_textMeshPro.SetText(normaltext);
                    
                    //Debug.Log(m_textMeshPro.text);
                }

                a = -a;



            }
            
        }


    }
}
