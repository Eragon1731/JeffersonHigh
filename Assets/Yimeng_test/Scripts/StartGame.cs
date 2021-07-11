using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public float turnoffwhite = 1f;

    public GameObject Whitescreen;

    public GameObject[] objectonscene;

    public float[] timeForObjects;

    public AudioSource soundeffect;
    
    int a = 0;
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator startgame()
    {
        //inactivate whitescreen
        yield return new WaitForSeconds(turnoffwhite);
        Whitescreen.SetActive(false);
        while(a<objectonscene.Length)
        {
//            Debug.Log(a);
            yield return new WaitForSeconds(timeForObjects[a]);
            objectonscene[a].SetActive(true);
            soundeffect.Play();
            a++;
        }
    }
    void Start()
    {
        StartCoroutine(startgame());
    }

}
