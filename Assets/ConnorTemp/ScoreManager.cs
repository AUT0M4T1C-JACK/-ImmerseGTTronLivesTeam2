using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;



public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text scoreTextP1;
    [SerializeField] private Text scoreTextP2;
    [SerializeField] private float scoreCooldown = .5f;
    private float nextScore;
    
    private int p1Score;
    private int p2Score;

    //private PunPlayerScores pps;

    
    // Start is called before the first frame update
    void Start()
    {
        p1Score = 0;
        p2Score = 0;

        //PunPlayerScores.PlayerList[0].SetScore(0);
        //PhotonNetwork.SetScore(PhotonNetwork.PlayerList[0], 0);
        //PhotonNetwork.SetScore(PhotonNetwork.PlayerList[1], 0);
        

        scoreTextP1 = GameObject.FindWithTag("Player1").GetComponentInChildren<Text>();
        scoreTextP2 = GameObject.FindWithTag("Player2").GetComponentInChildren<Text>();

        scoreTextP1.text = p1Score + " | " + p2Score;
        scoreTextP2.text = p1Score + " | " + p2Score;

        updateScoreText();

        scoreCooldown = .5f;
        nextScore = .1f;
    }

    public void increaseP1Score() {
        p1Score++;
        Hashtable hash = new Hashtable();
        hash.Add("Score", p1Score);
        PhotonNetwork.PlayerList[0].SetCustomProperties(hash);
        updateScoreText();
    }

    public void increaseP2Score() {
        p2Score++;
        Hashtable hash = new Hashtable();
        hash.Add("Score", p2Score);
        PhotonNetwork.PlayerList[1].SetCustomProperties(hash);
        updateScoreText();
    }

    public void resetScore() {
        //p1Score = 0;
        //p2Score = 0;
        //PhotonNetwork.SetScore(PhotonNetwork.PlayerList[0], 0);
        //PhotonNetwork.SetScore(PhotonNetwork.PlayerList[1], 0);

        p1Score = 0;
        Hashtable hash = new Hashtable();
        hash.Add("Score", p1Score);
        PhotonNetwork.PlayerList[0].SetCustomProperties(hash);

        p2Score = 0;
        Hashtable hash1 = new Hashtable();
        hash.Add("Score", p2Score);
        PhotonNetwork.PlayerList[1].SetCustomProperties(hash);

        updateScoreText();
    }

    private void updateScoreText() {
        scoreTextP1.text = p1Score + " | " + p2Score;
        scoreTextP2.text = p1Score + " | " + p2Score;

        //scoreTextP1.text = PhotonNetwork.GetScore(PhotonNetwork.PlayerList[0]) + " | " + PhotonNetwork.GetScore(PhotonNetwork.PlayerList[1]);
        //scoreTextP2.text = PhotonNetwork.GetScore(PhotonNetwork.PlayerList[0]) + " | " + PhotonNetwork.GetScore(PhotonNetwork.PlayerList[1]);
    }

    public float getCooldown() {
        return nextScore;
    }

    public void updateCooldown() {
        nextScore = Time.time + scoreCooldown;
    }
}
