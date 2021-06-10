using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2021
* VERSION: 1.0
* SCRIPT: Game Manager Class 
*/

public class GameManager : GenericSingleton<GameManager> {
    
    private UIControl uiControl;
    private int score = 0;
    
	public override void Awake () {
        base.Awake();
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
