using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2018
* VERSION: 1.0
* SCRIPT: UI Control Class 
*/

public class UIControl : MonoBehaviour {

    private Wind wind;
    [SerializeField]
    private Slider windSlider;
    [SerializeField]
    private Text scoreText;
	// Use this for initialization
	void Start () {
        //wind = FindObjectOfType<Wind>();
       // wind.windSpeed = 0f;
	}


    public void SetWind(float value)
    {
        wind.windSpeed = value;
    }

    public void UpdateWindSlider()
    {
        windSlider.value = Mathf.Abs( wind.windSpeed);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = "Score\n" + score; 
    }


}
