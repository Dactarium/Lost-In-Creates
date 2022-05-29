using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _howToPlay;
    [SerializeField] private GameObject _settings;
    [SerializeField] private GameObject _credits;

    [SerializeField] private Slider _masterVolume;
    [SerializeField] private Slider _musicVolume;
    [SerializeField] private Slider _sfxVolume;

    [SerializeField] private AudioMixer _mixer;

    private MenuType _currentMenu = MenuType.HowToPlay;

    public float MasterVolume
    {
        set
        {
            PlayerPrefs.SetFloat("MasterVolume", value);
            _mixer.SetFloat("Master", value);
        }
    }
    public float MusicVolume
    {
        set
        {
            PlayerPrefs.SetFloat("MusicVolume", value);
            _mixer.SetFloat("Music", value);
        }
    }
    public float SFXVolume
    {
        set
        {
            PlayerPrefs.SetFloat("SFXVolume", value);
            _mixer.SetFloat("SFX", value);
        }
    }

    private void Start()
    {
        _masterVolume.value = PlayerPrefs.GetFloat("MasterVolume", 0f);
        _musicVolume.value = PlayerPrefs.GetFloat("MusicVolume", 0f);
        _sfxVolume.value = PlayerPrefs.GetFloat("SFXVolume", 0f);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ToggleSettings()
    {
        OpenMenu(MenuType.Settings);
    }

    public void ToggleCredits()
    {
        OpenMenu(MenuType.Credits);
    }

    private void OpenMenu(MenuType menuType)
    {
        if (_currentMenu == menuType) _currentMenu = MenuType.HowToPlay;
        else _currentMenu = menuType;

        _howToPlay.SetActive(false);
        _settings.SetActive(false);
        _credits.SetActive(false);

        switch (_currentMenu)
        {
            case MenuType.HowToPlay:
                _howToPlay.SetActive(true);
                break;
            case MenuType.Settings:
                _settings.SetActive(true);
                break;
            case MenuType.Credits:
                _credits.SetActive(true);
                break;
        }
    }

    private enum MenuType
    {
        HowToPlay,
        Settings,
        Credits
    }
}
