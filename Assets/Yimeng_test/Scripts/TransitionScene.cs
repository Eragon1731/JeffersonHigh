using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TransitionScene : MonoBehaviour
{
    public Animator transition;
    public AudioSource bgm_source; 
    public float trasitionTime = 1f;

    public TMP_InputField inputWords;

    public string Wordtest;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        situationjudge();
    }
    
    void situationjudge()
    {
        string wordjusge = inputWords.text;
        if (Input.GetKey(KeyCode.Return) && wordjusge.Equals(Wordtest))
        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        //Play Animation
        transition.SetTrigger("Start");
        
        
        //Wait Animation
        yield return new WaitForSeconds(trasitionTime);
        
        //LoadScene
        SceneManager.LoadScene(levelIndex);
    }
}
