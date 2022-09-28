using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateTheScore();
    }
    private void UpdateTheScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
