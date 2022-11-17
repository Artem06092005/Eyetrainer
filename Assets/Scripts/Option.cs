using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Option : MonoBehaviour
{
    [SerializeField]
    private Dropdown Dropdown;
    
    private void DropD()
    {
        switch(Dropdown.value)
        {
            case 0:
            Screen.SetResolution(3440,1440,true);
            break;
            case 1:
            Screen.SetResolution(2560,1440,true);
            break;
            case 2:
            Screen.SetResolution(2560,1080,true);
            break;
            case 3:
            Screen.SetResolution(1920,1440,true);
            break;
            case 4:
            Screen.SetResolution(1920,1200,true);
            break;
            case 5:
            Screen.SetResolution(1920,1080,true);
            break;
            case 6:
            Screen.SetResolution(1720,1440,true);
            break;
            case 7:
            Screen.SetResolution(1680,1050,true);
            break;
            case 8:
            Screen.SetResolution(1440,900,true);
            break;
            case 9:
            Screen.SetResolution(1280,1024,true);
            break;
            case 10:
            Screen.SetResolution(1024,768,true);
            break;
        }
    }
    private void Start()
    {
        LoadSetting();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ExitOption();
        }
    }
    private void ExitOption()
    {
        SceneManager.LoadScene("MainMenu");
    }
    private void SetFullScreen(bool isFullscreen)
    {
        Screen.fullScreen=isFullscreen;
    }
    private void SaveSettings()
    {
        PlayerPrefs.SetInt("ResolutionPreference",Dropdown.value);
        PlayerPrefs.SetInt("FullscreenPreference",System.Convert.ToInt32(Screen.fullScreen));
    }
    private void LoadSetting()
    {
        if(PlayerPrefs.HasKey("ResolutionPreference")) Dropdown.value=PlayerPrefs.GetInt("ResolutionPreference");

        if(PlayerPrefs.HasKey("FullscreenPreference")) Screen.fullScreen=System.Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPreference"));
        else Screen.fullScreen=true;
    }
}
