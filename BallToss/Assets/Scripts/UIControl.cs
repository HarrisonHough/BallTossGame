using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour {

    private Wind wind;
    [SerializeField]
    private Slider windSlider;

	// Use this for initialization
	void Start () {
        wind = FindObjectOfType<Wind>();
        wind.windSpeed = 0f;
	}


    public void SetWind(float value)
    {
        wind.windSpeed = value;
    }

    public void UpdateWindSlider()
    {
        windSlider.value = Mathf.Abs( wind.windSpeed);
    }

}
