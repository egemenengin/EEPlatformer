// Egemen Engin 
// https://github.com/egemenengin

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreDisplayer : MonoBehaviour
{
    int score = 0;
    TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        UpdateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
