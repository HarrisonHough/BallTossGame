using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
