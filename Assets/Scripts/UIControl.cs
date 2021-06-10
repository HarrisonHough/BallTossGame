using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2021
* VERSION: 1.0
* SCRIPT: UI Control Class 
*/

public class UIControl : MonoBehaviour {

    [FormerlySerializedAs("wind")] [SerializeField]
    private WindZone windZone;
    [SerializeField]
    private Slider windSlider;
    [SerializeField]
    private Text scoreText;

    private const string ScorePrefix = "Score\n";
    void Start () {
        if (windZone != null)
        {
            windZone.WindSpeed = 0f;
        }
        GameManager.OnScoreUpdated += UpdateScore;
    }


    public void SetWind(float value)
    {
        windZone.WindSpeed = value;
    }

    public void UpdateWindSlider()
    {
        windSlider.value = Mathf.Abs( windZone.WindSpeed);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = ScorePrefix + score; 
    }
}
