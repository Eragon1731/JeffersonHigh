using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicKeepSame : MonoBehaviour
{
    public AudioSource bgm_source;

    public AudioSource sfx_source;

    public AudioSource input_source;

    // Start is called before the first frame update
    void Start()
    {
        bgm_source.volume = PlayerPrefs.GetFloat("bgm volume");
        sfx_source.volume = PlayerPrefs.GetFloat("sfx volume");
        input_source.volume = sfx_source.volume * 0.05f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
