using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AudioManage : MonoBehaviour
{
    public AudioSource sfx_source;
    public AudioSource bgm_source;
    public AudioSource input_source;

    public TextMeshPro textManagment;

    public TMP_InputField InputField;

    public GameObject settingScene;

    private string wordtest;

    private float bgmvolume;

    private float sfxvolume;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetFloat("bgm volume") == 0.0f)
        {
            PlayerPrefs.SetFloat("bgm volume", 0.5f);
            bgm_source.volume = 0.5f;
        }
        else {
            bgmvolume = Mathf.Round(PlayerPrefs.GetFloat("bgm volume") * 100.0f);
            bgm_source.volume = PlayerPrefs.GetFloat("bgm volume");
        }

        if (PlayerPrefs.GetFloat("sfx volume") == 0.0f)
        {
            PlayerPrefs.SetFloat("sfx volume", 0.5f);
            sfx_source.volume = 0.5f;
        }
        else {
            sfxvolume = Mathf.Round(PlayerPrefs.GetFloat("sfx volume") * 100.0f);
            sfx_source.volume = PlayerPrefs.GetFloat("sfx volume");
        }

        input_source.volume = sfx_source.volume * 0.05f;
        
        print("bgm" + bgmvolume);
        print("bgm source" + bgm_source.volume);
      
        SaveVolumePrefs();
    }

    // Update is called once per frame
    void Update()
    {
        Settext();
        ShowScene();
        check();
        //SaveVolumePrefs();
    }

    void ShowScene()
    {
        wordtest = InputField.text;
        if (wordtest.Equals("settings") && Input.GetKey(KeyCode.Return))
        {
            Debug.Log("open");
            settingScene.gameObject.SetActive(true);
            SaveVolumePrefs();
        }

        if (wordtest.Equals("close") && Input.GetKey(KeyCode.Return))
        {
            settingScene.gameObject.SetActive(false);
            SaveVolumePrefs();
        }
    }

    void Settext()
    {
        string description = "BGM VOLUME:" + bgmvolume + "\n" + "SFX VOLUME:" + sfxvolume + "\n" +"\n"+
                             ">type <sound_type> and <number> to adjust volume" + "\n" +
                             "Example:  <bgm 50>  or  <sfx 25>" + "\n" + "\n" + ">type \"close\" to exit settings view";
        textManagment.SetText(description);
    }

    public void ShowSetting()
    {
        settingScene.gameObject.SetActive(true);
    }

    public void CloseSetting()
    {
        settingScene.gameObject.SetActive(false);
    }

    public void adjustVolume(string type, float i)
    {
       //adjust sfx volume
        if (type == "sfx" )
        {
            if (i <= 100.0f)
            {
                sfx_source.volume = i / 100.0f;
            }

            if (i > 100.0f)
            {
                sfx_source.volume = 1.0f;
            }

            input_source.volume = sfx_source.volume * 0.2f;

            sfxvolume = Mathf.Round(sfx_source.volume * 100.0f);
            
            string description = "BGM VOLUME:" + bgmvolume + "\n" + "SFX VOLUME:" + sfxvolume + "\n" +"\n"+
                                 ">type <sound_type> and <number> to adjust volume" + "\n" +
                                 "Example:  <bgm 50>  or  <sfx 25>" + "\n" + "\n" + ">type \"close\" to exit settings view";
            textManagment.SetText(description);
        }
        
        //adjust bgm volume
        else if (type == "bgm" )
        {
            if (i <= 100.0f)
            {
                bgm_source.volume = i / 100.0f;
            }

            if (i > 100.0f)
            {
                bgm_source.volume = 1.0f;
            }

            bgmvolume = Mathf.Round(bgm_source.volume * 100.0f);
            
            string description = "BGM VOLUME:" + bgmvolume + "\n" + "SFX VOLUME:" + sfxvolume + "\n" +"\n"+
                                 ">type <sound_type> and <number> to adjust volume" + "\n" +
                                 "Example:  <bgm 50>  or  <sfx 25>" + "\n" + "\n" + ">type \"close\" to exit settings view";
            textManagment.SetText(description);
        }
        
    }

    void check()
    {
        if (settingScene.activeSelf)
        {
            if (InputField.text.Contains("bgm") && Input.GetKey(KeyCode.Return))
            {
                var info = InputField.text.Split(' ');
                adjustVolume(info[0], float.Parse(info[1]));
            }
            else if (InputField.text.Contains("sfx") && Input.GetKey(KeyCode.Return))
            {
                var info = InputField.text.Split(' ');
                adjustVolume(info[0], float.Parse(info[1]));
            }
            else {
                //error handling later
            }
        }
    }

    public void SaveVolumePrefs()
    {
        PlayerPrefs.SetFloat("bgm volume",bgm_source.volume);
        PlayerPrefs.SetFloat("sfx volume",sfx_source.volume);
        input_source.volume = sfx_source.volume * 0.2f;
    }

   
}
