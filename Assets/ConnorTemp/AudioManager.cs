using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //[SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource[] audioSources;
    public AudioClip sfxHum, sfxHit, sfxCharge;
    //audioSource[0] == sfx
    //audioSource[1] == hum

    
    // Start is called before the first frame update
    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
        audioSources = GetComponents<AudioSource>();
        PlayChargeSFX(); //PLAY WHEN TAKEN OFF BACK
        PlayHumSFX(); //PLAY WHEN TAKEN OFF BACK
    }

    public void PlayHitSFX() {
        audioSources[0].clip = sfxHit;
        audioSources[0].Play();
    }

    public void PlayHumSFX() {
        audioSources[1].clip = sfxHum;
        audioSources[1].Play();
    }

    public void PlayChargeSFX() {
        audioSources[0].clip = sfxCharge;
        audioSources[0].Play();
    }


}
