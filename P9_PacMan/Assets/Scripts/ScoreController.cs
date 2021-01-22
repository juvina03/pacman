using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public TextMeshProUGUI scoreText = default;
    public List<pacdot> pacdotList = new List<pacdot>();

    private long score = 0;
    private void Start()
    {
        for(int i = 0; i < pacdotList.Count; i++)
        {
            pacdotList[i].Onpacdoteaten += UpdateScore;
        }
    }
    private void UpdateScore()
    {
        score += 1;
        scoreText.text = "Score = " + score.ToString();
    }
}
