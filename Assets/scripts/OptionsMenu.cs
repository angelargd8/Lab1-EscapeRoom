using UnityEngine;
using UnityEngine.UI;


public class OptionsMenu : MonoBehaviour
{
    [SerializeField] Slider MasterVolSlider;
    [SerializeField] Slider AmbienceVolSlider;
    [SerializeField] Slider SFXVolSlider;


    public void Start()
    {
        MasterVolSlider.value = AudioManager.Instance.MasterVolume;
        AmbienceVolSlider.value = AudioManager.Instance.AmbienceVolume;
        SFXVolSlider.value = AudioManager.Instance.SFXVolume;

    }

    public void BackToMenu()
    {
        GameManager.Instance.LoadGame("MainMenu");
    }

    public void SetMasterVolume()
    {
        AudioManager.Instance.SetMasterVolume(MasterVolSlider.value);
    }

    public void SetAmbienceVolume()
    {
        AudioManager.Instance.SetAmbienceVolume(AmbienceVolSlider.value);
    }

    public void SetSFXVolume()
    {
        AudioManager.Instance.SetSFXVolume(SFXVolSlider.value);
    }




}
