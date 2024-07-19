using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCalculation : MonoBehaviour
{
    public float totalScore = 0;
    public int multipier = 1;
    public float baseScore;
    private float maxDecay = 9.0f;
    public float decay;
    private bool combo = false;
    [SerializeField]
    private TextMeshProUGUI highscoreText;
    [SerializeField]
    private TextMeshProUGUI scoreText;

    public void MatchCalculation()
    {
       
        if(combo)
        {
            multipier += 1;
        }
        baseScore = 5.0f * (10.0f - decay);

        totalScore += multipier * baseScore;
        decay = 0.0f;
        if (!combo)
        {
            combo = true;
        }
        scoreText.text = "Score: " + totalScore.ToString("F0");

    }

    public void UnMatchCalculation()
    {
        multipier = 1;
        combo = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        decay = 0.0f;

        if (LevelSelector_Singleton.instance.level == 1)
        {
            highscoreText.text = "HighScore: " + PlayerPrefs.GetFloat("HighScore1").ToString("F0");

        }
        else if (LevelSelector_Singleton.instance.level == 2)
        {
            highscoreText.text = "HighScore: " + PlayerPrefs.GetFloat("HighScore2").ToString("F0");
        }
        else if (LevelSelector_Singleton.instance.level == 3)
        {
            highscoreText.text = "HighScore: " + PlayerPrefs.GetFloat("HighScore3").ToString("F0");
        }
        else if (LevelSelector_Singleton.instance.level == 4)
        {
            highscoreText.text = "HighScore: " + PlayerPrefs.GetFloat("HighScore4").ToString("F0");

            Debug.Log(PlayerPrefs.GetFloat("HighScore4").ToString("F0"));
        }
        else if (LevelSelector_Singleton.instance.level == 5)
        {
            highscoreText.text = "HighScore: " + PlayerPrefs.GetFloat("HighScore5").ToString("F0");
        }
        scoreText.text = "Score: 0";

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameStart)
        {
            if (decay < maxDecay)
            {
                decay += Time.deltaTime;
            }
        }

    }
}
