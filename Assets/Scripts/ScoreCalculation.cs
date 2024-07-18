using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCalculation : MonoBehaviour
{
    public float totalScore = 0;
    public int multipier = 1;
    public float baseScore;
    private float maxDecay = 9.0f;
    public float decay;
    private bool combo = false;
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

        Debug.Log("totalScore = " +  totalScore);

    }
}
