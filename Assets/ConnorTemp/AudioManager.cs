using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //[SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource[] audioSources;
    public AudioClip sfxDerezz, sfxBounce, sfxIdle, sfxOn, sfxThrow;
    //audioSource[0] == sfx
    //audioSource[1] == hum

    
    // Start is called before the first frame update
    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
        audioSources = GetComponents<AudioSource>();
        //PlayChargeSFX(); //PLAY WHEN TAKEN OFF BACK
        //PlayHumSFX(); //PLAY WHEN TAKEN OFF BACK
    }

    public void PlayDerezzSFX() {
        audioSources[0].clip = sfxDerezz;
        audioSources[0].Play();
    }

    public void PlayBounceSFX() {
        audioSources[0].clip = sfxBounce;
        audioSources[0].Play();
    }

    public void PlayIdleSFX() {
        audioSources[1].clip = sfxIdle;
        audioSources[1].Play();
    }

    public void PlayOnSFX() {
        audioSources[0].clip = sfxOn;
        audioSources[0].Play();
    }

    public void PlayThrowSFX() {
        audioSources[0].clip = sfxOn;
        audioSources[0].Play();
    }


}
