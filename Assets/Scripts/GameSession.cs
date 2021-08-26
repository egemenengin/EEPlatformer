// Egemen Engin 
// https://github.com/egemenengin

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameSession : MonoBehaviour
{
    int score = 0;
    TextMeshProUGUI scoreText;
    private void Awake()
    {
        int numGameSession = FindObjectsOfType<GameSession>().Length;
        if (numGameSession > 1)
        {

            Destroy(gameObject);
        }
        else
        {

            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreText = FindObjectOfType<TextMeshProUGUI>();
        if (scoreText.transform.name == "ScoreText")
        {
            UpdateDisplay();

        }
    }
    private void Update()
    {
        if(scoreText == null)
        {
            findNewScoreText();

        }
     
    }
    public void addScore(int coinVal)
    {
        score += coinVal;
        UpdateDisplay();
    }
    public void UpdateDisplay()
    {
        scoreText.text = score.ToString();
    }
    public void findNewScoreText()
    {
        scoreText = FindObjectOfType<TextMeshProUGUI>();
        if (scoreText.transform.name == "ScoreText")
        {
            UpdateDisplay();

        }
    }
}
