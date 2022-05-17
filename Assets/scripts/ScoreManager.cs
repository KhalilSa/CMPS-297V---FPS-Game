using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{


    public TextMeshProUGUI scoreText;
    
  


    public void IncrementScore(int score)
    {
        scoreText.text = "" + score;
    }
}
