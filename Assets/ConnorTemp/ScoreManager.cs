using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text scoreTextP1;
    [SerializeField] private Text scoreTextP2;
    [SerializeField] private float scoreCooldown = .5f;
    private float nextScore;
    
    private int p1Score;
    private int p2Score;

    
    // Start is called before the first frame update
    void Start()
    {
        p1Score = 0;
        p2Score = 0;

        scoreTextP1 = GameObject.FindWithTag("Player1").GetComponentInChildren<Text>();
        scoreTextP2 = GameObject.FindWithTag("Player2").GetComponentInChildren<Text>();

        scoreTextP1.text = p1Score + " | " + p2Score;
        scoreTextP2.text = p1Score + " | " + p2Score;

        scoreCooldown = .5f;
        nextScore = .1f;
    }

    public void increaseP1Score() {
        p1Score++;
        updateScoreText();
    }

    public void increaseP2Score() {
        p2Score++;
        updateScoreText();
    }

    public void resetScore() {
        p1Score = 0;
        p2Score = 0;
        updateScoreText();
    }

    private void updateScoreText() {
        scoreTextP1.text = p1Score + " | " + p2Score;
        scoreTextP2.text = p1Score + " | " + p2Score;
    }

    public float getCooldown() {
        return nextScore;
    }

    public void updateCooldown() {
        nextScore = Time.time + scoreCooldown;
    }
}
