using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI volumeTxt;
    [SerializeField] Toggle muteToggle;
    [SerializeField] Toggle windowToggle;
    [SerializeField] Slider volumeSlider;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Mute"))
        {
            PlayerPrefs.SetInt("Mute", 0);

        }
        else
        {
            LoadMuteToggle();
        }
        if (!PlayerPrefs.HasKey("Windowed"))
        {
            PlayerPrefs.SetInt("Windowed", 0);

        }
        else
        {
            LoadWindowedToggle();
        }

    }

    private void Update()
    {
        LoadVolume();
    }
    public void Mute()
    {
        PlayerPrefs.SetInt("Mute", muteToggle.isOn ? 1 : 0);
        if (muteToggle.isOn)
        {
            AudioListener.pause = true;
        }
        else
        {
            AudioListener.pause = false;

        }
    }

    public void Windowed()
    {
        PlayerPrefs.SetInt("Windowed", windowToggle.isOn ? 1 : 0);
        if (windowToggle.isOn)
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }
        else
        {
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        }
        Debug.Log("Windowed");
    }
    public void LoadMuteToggle()
    {
        muteToggle.isOn = PlayerPrefs.GetInt("Mute") == 1;
    }

    public void LoadWindowedToggle()
    {
        windowToggle.isOn = PlayerPrefs.GetInt("Windowed") == 1;
    }
    public void LoadVolume()
    {
        float volumeValue = PlayerPrefs.GetFloat("Volume");
        volumeSlider.value = volumeValue;
        AudioListener.volume = volumeValue;

    }

    public void VolumeControlSlider(float volume) 
    {
        volumeTxt.text = "Volume " + volume.ToString("0"); 
        float volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("Volume", volumeValue);
    }
   
}
