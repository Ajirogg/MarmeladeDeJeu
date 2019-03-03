using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    public AudioSource efxSonnerie;                   //Drag a reference to the audio source which will play the sound effects.
    public AudioSource efxDialogue;
    public AudioSource efxSirene;
    public AudioSource efxExterieur;
    public AudioSource musicSource;                 //Drag a reference to the audio source which will play the music.

    public float maxEfxSonnerie = 0.2f;
    public float maxEfxDialogue = 1;
    public float maxEfxSirene = 0.2f;
    public float maxEfxExterieur = 0.2f;
    public float maxMusicSource = 0.8f;

    public static SoundManager instance = null;     //Allows other scripts to call functions from SoundManager.             
    public float lowPitchRange = .95f;              //The lowest a sound effect will be randomly pitched.
    public float highPitchRange = 1.05f;            //The highest a sound effect will be randomly pitched.


    void Awake()
    {
        //Check if there is already an instance of SoundManager
        if (instance == null)
            //if not, set it to this.
            instance = this;
        //If instance already exists:
        else if (instance != this)
            //Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
            Destroy(gameObject);

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
    }
    public void initialiserVolume()
    {
        musicSource.volume = OptionsManager.Instance.GetVolumeMusic() * maxMusicSource;
        efxDialogue.volume = OptionsManager.Instance.GetVolumeFX() * maxEfxDialogue;
        efxSirene.volume = OptionsManager.Instance.GetVolumeFX() * maxEfxSirene;
        efxExterieur.volume = OptionsManager.Instance.GetVolumeFX() * maxEfxExterieur;
        efxSonnerie.volume = OptionsManager.Instance.GetVolumeFX() * maxEfxSonnerie;
    }
    public void muteVolume()
    {
        musicSource.volume = 0;
        efxDialogue.volume = 0;
        efxSirene.volume = 0;
        efxExterieur.volume = 0;
        efxSonnerie.volume = 0;
    }

}