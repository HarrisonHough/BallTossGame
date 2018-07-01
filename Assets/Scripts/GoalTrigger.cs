using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2018
* VERSION: 1.0
* SCRIPT: Goal Trigger Class 
*/

public class GoalTrigger : MonoBehaviour {

    private GoalControl goalControl;

	// Use this for initialization
	void Start () {
        goalControl = GameObject.FindObjectOfType<GoalControl>();
	}

    private void OnTriggerEnter(Collider other)
    {
        goalControl.GoalScored();
    }

}
