using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScoreButton : MonoBehaviour
{
    [SerializeField]
    private ScoreManager sm;

    void Start()
    {
        sm = GameObject.FindWithTag("ScoreManager").GetComponent<ScoreManager>();
    }

    public void OnResetScoreButtonPressed() {
        SampleController.Instance.Log("ResetScoreButtonPressed");

        sm.resetScore();
    }
}
