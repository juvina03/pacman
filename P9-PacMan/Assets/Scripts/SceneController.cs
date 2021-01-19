using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText = default; 
    [SerializeField] private List<Pacdot> pacdotList = new List<Pacdot>();

    private long currentScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScore();
        pacdotList.ForEach(pacdot =>
        {
            pacdot.OnDestroyed += OnPacdotEaten;
        });
    }

    void OnPacdotEaten(Pacdot pacdot)
    {
        currentScore += 10;
        UpdateScore();
        pacdot.OnDestroyed -= OnPacdotEaten;
    }

    void UpdateScore()
    {
        scoreText.text = "Score : " + currentScore.ToString();
    }
}
