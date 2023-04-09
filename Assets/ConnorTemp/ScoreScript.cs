using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using PhotonNetwork;
using Photon.Pun;
using Hashtable = ExitGames.Client.Photon.Hashtable;



public class ScoreScript : MonoBehaviour
{
    [SerializeField] private ParticleSystem particles;
    //[SerializeField] private ScoreManager sm;
    [SerializeField] private AudioManager am;

    [SerializeField] private Text scoreText;
    [SerializeField] private float scoreCooldown = .5f;
    private float nextScore;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //sm = GameObject.FindWithTag("ScoreManager").GetComponent<ScoreManager>();
        particles = GetComponentInChildren<ParticleSystem>();
        am = GetComponentInChildren<AudioManager>();
        scoreText = GetComponentInChildren<Text>();

        resetScore();

        //PhotonNetwork.LocalPlayer.SetScore(0);
    }


    public void increaseScore() {
        int pScore = (int) PhotonNetwork.LocalPlayer.CustomProperties["Score"];
        pScore++;
        Hashtable hash = new Hashtable();
        hash.Add("Score", pScore);
        PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
        //updateScoreText();
    }

    public void resetScore() {
        int pScore = 0;
        Hashtable hash = new Hashtable();
        hash.Add("Score", pScore);
        PhotonNetwork.LocalPlayer.SetCustomProperties(hash);

        //updateScoreText();
    }

    private void updateScoreText() {
        //scoreText.text = PhotonNetwork.LocalPlayer.customProperties.get("Score") + " | " + PhotonNetwork.LocalPlayer.customProperties("Score");
        //scoreText.text = PhotonNetwork.LocalPlayer.CustomProperties["Score"] + " | " + PhotonNetwork.LocalPlayer.customProperties("Score");
        if (PhotonNetwork.PlayerList[0] != null && PhotonNetwork.PlayerList[1] != null) {
            scoreText.text = PhotonNetwork.PlayerList[0].CustomProperties["Score"].ToString()  + " | " + PhotonNetwork.PlayerList[1].CustomProperties["Score"].ToString();
        }
    }

    public float getCooldown() {
        return nextScore;
    }

    public void updateCooldown() {
        nextScore = Time.time + scoreCooldown;
    }

    private void OnTriggerEnter(Collider other) {
        //Debug.Log("Hit");
        if (Time.time > getCooldown()) {
            //if (this.tag == "Player1" && hitbox.tag == "P2Hitbox") {
            if (!other.GetComponent<PhotonView>().IsMine) { // && PhotonNetwork.LocalPlayer.ActorNumber == 1) {
                particles.Play();
                increaseScore();
                updateCooldown();
                am.PlayHitSFX();
                //sm.increaseP1Score();
                //sm.updateCooldown();
                //PhotonNetwork.player.SetScore(int value);
                //PhotonNetwork.AddScore(player, int value);
            //} else if (this.tag == "Player2" && hitbox.tag == "P1Hitbox") {
            } //else if (!other.GetComponent<PhotonView>.isMine) { //} && PhotonNetwork.LocalPlayer.ActorNumber == 2) {
                //particles.Play();
                //sm.increaseP2Score();
                //sm.updateCooldown();
                //am.PlayHitSFX();
            //}
        }
    }

    private void FixedUpdate() {
        updateScoreText();
    }
}
