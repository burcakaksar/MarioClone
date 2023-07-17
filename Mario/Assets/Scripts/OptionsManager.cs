using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;




public class OptionsManager : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private TextMeshProUGUI volumeText;
    [SerializeField] private Toggle muteToggle;
    [SerializeField] private Toggle windowedToggle;

    [SerializeField] private Slider inGamevolumeSlider;
    [SerializeField] private TextMeshProUGUI inGamevolumeText;
    [SerializeField] private Toggle inGamemuteToggle;
    [SerializeField] private Toggle inGamewindowedToggle;


    private void Update()
    {
        
        LoadVolume();
        InGameLoadVolume();
    }
    private void Awake()
    {
        //if (!PlayerPrefs.HasKey("Mute"))
        //{
        //    PlayerPrefs.SetInt("Mute", 0);
        //    Debug.Log("ses kapandý");
           
        //}
        //else
        //{

     
            
        //}
       
       
    }

    //private void LoadMuteToggle()
    //{
    //   
    //}

    public void MuteToogle() // ses komutunun on off komutuna gelmesi için kulllandýðýmýz metod.
    {
        muteToggle.isOn = PlayerPrefs.GetInt("Mute") == 0;
        //Debug.Log("ses açýk");
        PlayerPrefs.SetInt("Mute", muteToggle.isOn ? 1 : 0);
        if (muteToggle.isOn)
        {
            AudioListener.pause = true;
            Debug.Log("ses kapandý");
            
        }
        else if (!muteToggle.isOn)
        
        {
            AudioListener.pause = false;
            Debug.Log("ses açýldý");
        }
       
    }
    public void LoadWindowedToggle() // ekraný fullscreen veya windowed moduna almak için kullandýðýmýz metod.
    {
        windowedToggle.isOn = PlayerPrefs.GetInt("Windowed") == 0;
        PlayerPrefs.SetInt("Windowed", windowedToggle.isOn ? 1 : 0);
        if (!windowedToggle.isOn)
        {
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
            Debug.Log("fullscreen modu");

        }
        else if (windowedToggle.isOn)
        {
            
            Screen.fullScreenMode = FullScreenMode.Windowed;
            Debug.Log("pencere modu");
        }
    }
    private void LoadVolume()
    {
        float volumeValue = PlayerPrefs.GetFloat("Volume");
        volumeSlider.value = volumeValue;
        AudioListener.volume = volumeValue;
    }
    public void VolumeControl(float volume)
    {
        volumeText.text = "Volume : " + volume.ToString("0");
        float volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("Volume", volumeValue);
    }

    public void InGameMuteToogle() // ses komutunun on off komutuna gelmesi için kulllandýðýmýz metod.
    {
        inGamemuteToggle.isOn = PlayerPrefs.GetInt("Mute") == 0;
        //Debug.Log("ses açýk");
        PlayerPrefs.SetInt("Mute", inGamemuteToggle.isOn ? 1 : 0);
        if (inGamemuteToggle.isOn)
        {
            AudioListener.pause = true;
            Debug.Log("ses kapandý");

        }
        else if (!inGamemuteToggle.isOn)

        {
            AudioListener.pause = false;
            Debug.Log("ses açýldý");
        }

    }
    public void LoadInGameWindowedToggle() // ekraný fullscreen veya windowed moduna almak için kullandýðýmýz metod.
    {
        inGamewindowedToggle.isOn = PlayerPrefs.GetInt("Windowed") == 0;
        PlayerPrefs.SetInt("Windowed", inGamewindowedToggle.isOn ? 1 : 0);
        if (!inGamewindowedToggle.isOn)
        {
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
            Debug.Log("fullscreen modu");

        }
        else if (inGamewindowedToggle.isOn)
        {

            Screen.fullScreenMode = FullScreenMode.Windowed;
            Debug.Log("pencere modu");
        }
    }
    private void InGameLoadVolume()
    {
        float volumeValue = PlayerPrefs.GetFloat("Volume");
        inGamevolumeSlider.value = volumeValue;
        AudioListener.volume = volumeValue;
    }
    public void InGameVolumeControl(float volume)
    {
        inGamevolumeText.text = "Volume : " + volume.ToString("0");
        float volumeValue = inGamevolumeSlider.value;
        PlayerPrefs.SetFloat("Volume", volumeValue);
    }
}
