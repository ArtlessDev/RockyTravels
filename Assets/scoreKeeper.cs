using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class scoreKeeper : MonoBehaviour
{
    public static int score;
    public TextMeshProUGUI textMeshPro;
    
    void Start()
    {
        score = 0;
        textMeshPro.text = "score: " + score;

    }

    void FixedUpdate()
    {
        textMeshPro.text = "score: " + score;
    }

    public int UpdateScore()
    {
        return score++;
    }
    
    public int UpdateScore(int five)
    {
        return score += five;
    }

    public int FinalizeScore()
    {
        return score;
    }
}
