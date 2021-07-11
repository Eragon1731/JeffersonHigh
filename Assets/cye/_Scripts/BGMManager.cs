using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class BGMManager : MonoBehaviour {

    public AudioClip[] bmg_clips;

    AudioSource bgm_source;

    private void Start()
    {
        print("what is active scene" + SceneManager.GetActiveScene().name);
        var temp_name = SceneManager.GetActiveScene().name;

        
        bgm_source = this.GetComponent<AudioSource>();

        //check if there is scene change
        if (SceneManager.GetActiveScene().isLoaded)//(temp_name.Equals("")|| temp_name.Equals("Act2") || temp_name.Equals("Act3"))
        {
            //StartCoroutine(WaitForVolume());
        }
    }

    public IEnumerator WaitForVolume()
    {
        yield return StartCoroutine(StartFade(bgm_source, 5.0f, PlayerPrefs.GetFloat("bgm volume")));
    }


    public static IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = audioSource.volume;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        // yield break;
    }



    public void changeBGM(int index) {
        bgm_source.clip = bmg_clips[index];
        bgm_source.Play();
    }
}