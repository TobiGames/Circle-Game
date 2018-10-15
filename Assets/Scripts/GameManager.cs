using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour {

    public GameObject Player;
    public GameObject Circle;
    public Rotator rotator;
    public CircleManager circleManager;
    public TextMeshProUGUI ScoreText;

    public float Score = 0;
    public float ScoreIncrease = 1;

    public 

	// Use this for initialization
	void Start () {
        SetupGame();
    }
	
	// Update is called once per frame
	void Update () {
        Score += ScoreIncrease;
        ScoreText.text = Score.ToString();

    }

    void SetupGame()
    {
        Score = 0;
    }

}
