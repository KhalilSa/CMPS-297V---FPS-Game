using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] TMP_Dropdown resolutionsDropDown;

    private Resolution[] resolutions;

    private void Start()
    {
        resolutions = Screen.resolutions;
        resolutionsDropDown.ClearOptions();

        int currentResolutionIndex = 0;
        // converting options into string format
        List<string> options = new List<string>();
        for (int i = 0; i < resolutions.Length; i++) {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
                currentResolutionIndex = i;
        }
        resolutionsDropDown.AddOptions(options);
        resolutionsDropDown.value = currentResolutionIndex;
        resolutionsDropDown.RefreshShownValue();
    }

    public void setMasterVolume(float volume)
    {
        setVolume("masterVolume", volume);
    }

    public void setMusicVolume(float volume)
    {
        setVolume("musicVolume", volume);
    }

    public void setFxVolume(float volume)
    {
        setVolume("fxVolume", volume);
    }

    private void setVolume(string parName, float volume) {
        if (volume <= -60)
            audioMixer.SetFloat(parName, -80);
        else audioMixer.SetFloat(parName, volume);
    }

    public void setQuality(int qualityLevel) {
        QualitySettings.SetQualityLevel(qualityLevel);
    }

    public void changeScreenMode(bool isFullScreen) {
        Screen.fullScreen = isFullScreen;
    }

    public void changeScreenResolution(int resolutionIndex) {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
