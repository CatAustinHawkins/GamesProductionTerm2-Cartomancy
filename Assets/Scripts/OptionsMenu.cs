using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionsMenu : MonoBehaviour
{
    public TMP_Dropdown ResolutionSelection;
    public Button FullScreenButton;
    public Sprite SelectedImage;
    public Sprite UnSelectedImage;
    public Slider VolumeSlider;

    public bool FullScreenEnabled;


    void Start()
    {
        //Load Previous saved data for volume
        Load();
    }

    //On the Volume Slider 
    public void ChangeVolume()
    {
        AudioListener.volume = VolumeSlider.value;
        Save();
    }

    public void Load()
    {
        VolumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", VolumeSlider.value);
    }

    //On the TMP_Dropdown GameObject 
    public void SetGameResolution()
    {
        switch(ResolutionSelection.value)
        {
            case 0:
                Screen.SetResolution(1280, 720, FullScreenEnabled);
                break;
            
            case 1:
                Screen.SetResolution(1600, 900, FullScreenEnabled);
                   break;
            
            case 2:
                Screen.SetResolution(1920, 1080, FullScreenEnabled);
                break;

            case 3:
                Screen.SetResolution(2560, 1440, FullScreenEnabled);
                break;

            case 4:
                Screen.SetResolution(3840, 2160, FullScreenEnabled);
                break;
        }
    } 
    
    //On the Fullscreen Button
    public void FullScreenEnableDisable()
    {
        if(FullScreenEnabled)
        {
            Screen.fullScreen = false;
            FullScreenButton.GetComponent<Image>().sprite = UnSelectedImage;
            FullScreenEnabled = false;
        }
        else
        {
            Screen.fullScreen = true;
            FullScreenButton.GetComponent<Image>().sprite = SelectedImage;
            FullScreenEnabled = true;
        }
    }
}
