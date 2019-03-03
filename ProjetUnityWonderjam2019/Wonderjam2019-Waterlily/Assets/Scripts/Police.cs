using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Police : MonoBehaviour
{

    public int etatPolice;         // Enum de l'etat de la police de 1 à 5
    public int agressivitePolice;  // Barre de progression de l'agressivité de la police 100 = défaite
    public int frequenceAppel = 60; // Fréquence en seconde d'appel de la police
    public int frequenceAppelMinimum = 60; // Fréquence en seconde d'appel de la police
    public AudioClip sirène;
    public AudioClip voiture;
    public List<AudioClip> MusicThemes;
    public int transition = 0 ;
    public int songPlaying = -1;
    public float volumeMin = 0.1f;
    public float volumeMax ;
    public int numeropo;

    // Start is called before the first frame update
    void Start()
    {
        etatPolice = 1;
       // barreEtatPolice = 0;
        agressivitePolice = 0;
        volumeMax = SoundManager.instance.maxMusicSource *  OptionsManager.Instance.GetVolumeMusic();
    }

    // Update is called once per frame
    void Update()
    {
        if (transition == 1)
        {
            if (SoundManager.instance.musicSource.volume > volumeMin)
            {
                SoundManager.instance.musicSource.volume -= 0.005f;
            }
            else
            {
                if (SoundManager.instance.musicSource.clip != MusicThemes[3])
                {
                    songPlaying++;
                    SoundManager.instance.musicSource.clip = MusicThemes[songPlaying];
                    SoundManager.instance.musicSource.Play();
                    transition++;
                }
            }
        }
        else if (transition == 2)
        {
            if (SoundManager.instance.musicSource.volume < volumeMax)
            {
                SoundManager.instance.musicSource.volume += 0.005f;
            }
            else
            {
                SoundManager.instance.musicSource.volume = volumeMax ;
                transition = 0 ;
            }
        }
    }

    public void PrintPoliceTest()
    {
        Debug.Log(agressivitePolice);
        Debug.Log(etatPolice);
        Debug.Log(frequenceAppel);

    }

    public void AugmenterAgressivite(int value)
    {
        agressivitePolice += value;
       
        if (agressivitePolice < (etatPolice - 1) * 20)
        { 
            agressivitePolice = (etatPolice - 1) * 20;

        }
        else if (agressivitePolice >= etatPolice * 20)
        {
            ++etatPolice;
            transition = 1;
        }
            


        if (etatPolice == 2)
        {
            SoundManager.instance.efxExterieur.clip = voiture;
            SoundManager.instance.efxExterieur.Play();
        }
        if (etatPolice == 3)
        {
            SoundManager.instance.efxSirene.Play();
        }

        frequenceAppel = frequenceAppelMinimum - (frequenceAppelMinimum * etatPolice * 10 / 100);

    }

    public void DiminuerAgressivite(int value)
    {
        agressivitePolice -= value;
        if (agressivitePolice < 0)
            agressivitePolice = 0;

    }

    public int GetFrequenceAppel()
    {
        return frequenceAppel;
    }

  /*  public void AugmenterBarreEtat(int value)
    {
        barreEtatPolice += value;
        if (barreEtatPolice == etatPolice * 10 && etatPolice <5)
            etatPolice++;
    }

    public void DiminuerBarreEtat(int value)
    {
        barreEtatPolice -= value;
        if (barreEtatPolice < 0)
            barreEtatPolice = 0;
    }*/





}
