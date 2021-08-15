using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    private static ScoreSystem _instance;

    public static ScoreSystem Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ScoreSystem();
            }
            return _instance;
        }
    }

    private int _score = 0;
    public TMP_Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        _instance = this;
        scoreText.text = "0";
    }

    public void IncreaseScore(int amount)
    {
        _score += amount;
        scoreText.text = _score.ToString();
    }
}
