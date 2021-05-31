using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2021
* VERSION: 1.0
* SCRIPT: Game Manager Class 
*/

public class GameManager : MonoBehaviour {

    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }
    private UIControl uiControl;
    private int score = 0;
    
	void Awake () {

        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
	}

    private void Start()
    {
        //TODO refactor
        uiControl = FindObjectOfType<UIControl>();
    }

    public void UpdateScore()
    {
        score++;
        uiControl.UpdateScore(score);

    }
}
