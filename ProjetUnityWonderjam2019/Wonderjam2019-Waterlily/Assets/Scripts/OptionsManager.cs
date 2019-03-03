using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsManager : Singleton<OptionsManager>
{
    public enum keyboard_type
    {
        qwerty = 0,
        azerty = 1,
    }

    private float m_volumeFX;
    private float m_volumeMusic;
    private keyboard_type m_keyboardType;

    void Awake()
    {
        m_volumeFX = 0.75f;
        m_volumeMusic = 0.75f;
        m_keyboardType = keyboard_type.qwerty;
    }

    //Getters
    public float GetVolumeFX() { return m_volumeFX; }
    public float GetVolumeMusic() { return m_volumeMusic; }
    public keyboard_type GetKeyboardType() { return m_keyboardType; }

    //Setters
    public void SetVolumeFX(float volumeFX) { m_volumeFX = volumeFX; }
    public void SetVolumeMusic(float volumeMusic) { m_volumeMusic = volumeMusic; }
    public void SetKeyboardType(keyboard_type keyboardType) { m_keyboardType = keyboardType; }
}
