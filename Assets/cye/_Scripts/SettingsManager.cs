using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{

    public AudioSource sfx_source;
    public AudioSource bgm_source;

    public GameObject settings_view; 
    public Slider sfx_slider;
    public Slider bgm_slider;


    // Start is called before the first frame update
    void Start()
    {
        bgm_slider.value = 0.5f;
        sfx_slider.value = 0.5f;
        bgm_source.volume = bgm_slider.value;
        sfx_source.volume = sfx_slider.value;
        settings_view.SetActive(false); 
    }

    public void openSettingsView() {
        settings_view.SetActive(true);
    }

    public void closeSettingsView() {
        settings_view.SetActive(false); 
    }

    public void adjustVolume(string type, float i) {
        if (type == "sfx")
        {
            sfx_source.volume = i / 100;
            sfx_slider.value = i / 100;
        }
        else if (type == "bgm")
        {
            print("bgm number" + i);
            bgm_source.volume = i / 100;
            bgm_slider.value = i / 100;
        }
        else {
            print("ERROR: Invalid input"); 
        }
    }

    public void setVolumeInSlider() {
        sfx_source.volume = sfx_slider.value;

        bgm_source.volume = bgm_slider.value;
        print("bgm" + bgm_source.volume);
    }

}
