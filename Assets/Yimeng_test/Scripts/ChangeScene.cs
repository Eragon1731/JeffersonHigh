using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class ChangeScene : MonoBehaviour
{
    private bool load_game = true;
    public TMP_InputField inputfield;
    public string Wordtest;
    public AudioSource bgm_source;

    protected List<string> loadscene_keys; 

    // Start is called before the first frame update
    void Start()
    {
        loadscene_keys = new List<string> { "start", "Get to broad window", "I hope I fit", "Crap"};
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(inputfeild.text);
        situationjudge();
    }

    void situationjudge()
    {
        string wordjudge = inputfield.text;
        if (Input.GetKey(KeyCode.Return) && load_game && (loadscene_keys.Contains(wordjudge) || wordjudge.Equals(Wordtest))) 
        {
            StartCoroutine(WaitToLoad());
            //WaitForSeconds(10);
           // StartCoroutine(WaitForVolume());
            load_game = false; 
        }
    }

    public IEnumerator WaitToLoad() {
        yield return StartCoroutine(StartFade(bgm_source, 4.0f, 0.0f));
        LoadNextLevel();
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

    void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
