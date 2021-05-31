using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2021
* VERSION: 1.0
* SCRIPT: UI Control Class 
*/

public class UIControl : MonoBehaviour {

    [SerializeField]
    private Wind wind;
    [SerializeField]
    private Slider windSlider;
    [SerializeField]
    private Text scoreText;

    private const string ScorePrefix = "Score\n";
    void Start () {
        if (wind != null)
        {
            wind.WindSpeed = 0f;
        }
    }


    public void SetWind(float value)
    {
        wind.WindSpeed = value;
    }

    public void UpdateWindSlider()
    {
        windSlider.value = Mathf.Abs( wind.WindSpeed);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = ScorePrefix + score; 
    }


}
