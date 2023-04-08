using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreScript : MonoBehaviour
{
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private ScoreManager sm;
    [SerializeField] private AudioManager am;
    
    // Start is called before the first frame update
    void Start()
    {
        sm = GameObject.FindWithTag("ScoreManager").GetComponent<ScoreManager>();
        particles = GetComponentInChildren<ParticleSystem>();
        am = GetComponentInChildren<AudioManager>();
    }

    private void OnTriggerEnter(Collider hitbox) {
        //Debug.Log("Hit");
        if (Time.time > sm.getCooldown()) {
            if (this.tag == "Player1" && hitbox.tag == "P2Hitbox") {
                particles.Play();
                sm.increaseP1Score();
                sm.updateCooldown();
                am.PlayHitSFX();
            } else if (this.tag == "Player2" && hitbox.tag == "P1Hitbox") {
                particles.Play();
                sm.increaseP2Score();
                sm.updateCooldown();
                am.PlayHitSFX();
            }
        }
    }
}
