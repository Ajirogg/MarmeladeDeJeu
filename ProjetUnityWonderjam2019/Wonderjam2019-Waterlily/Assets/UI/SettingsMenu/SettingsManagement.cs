using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManagement : MonoBehaviour
{
    private OptionsManager opM;

    private Slider sliderVFX;
    private Slider sliderMusic;
    private Dropdown dropDownKeyboardType;

    void Awake()
    {
        opM = OptionsManager.Instance;
        sliderMusic = gameObject.transform.Find("MainFrame").Find("ContentPanel").Find("SoundSettingsPanel").Find("ContentPanel").Find("MusicVolumePanel").Find("Slider").gameObject.GetComponent<Slider>();
        sliderVFX =   gameObject.transform.Find("MainFrame").Find("ContentPanel").Find("SoundSettingsPanel").Find("ContentPanel").Find("SoundEffectsPanel").Find("Slider").gameObject.GetComponent<Slider>();
        //dropDownKeyboardType = gameObject.transform.Find("MainFrame").Find("ContentPanel").Find("ControlSettingsPanel").Find("ContentPanel").Find("KeyboardTypePanel").Find("Dropdown").gameObject.GetComponent<Dropdown>();
    }

    public void DisplayCurrentSettings()
    {
        sliderVFX.value = opM.GetVolumeFX();
        sliderMusic.value = opM.GetVolumeMusic();
        //dropDownKeyboardType.value = (int) opM.GetKeyboardType();
    }

    public void SaveMenuSettings()
    {
        opM.SetVolumeFX(sliderVFX.value);
        opM.SetVolumeMusic(sliderMusic.value);
        SoundManager.instance.initialiserVolume();
        //opM.SetKeyboardType((OptionsManager.keyboard_type)dropDownKeyboardType.value);
    }
}
