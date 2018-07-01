using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2018
* VERSION: 1.0
* SCRIPT: Goal Control Class 
*/

public class GoalControl : MonoBehaviour {

    [SerializeField]
    private GameObject[] positions;

    private int positionIndex;

	// Use this for initialization
	void Start () {

        CheckPositions();
        SetInitialPosition();

	}

    void SetInitialPosition()
    {
        transform.position = positions[positionIndex].transform.position;
    }

    void CheckPositions()
    {
        if (positions.Length < 0)
        {
            Debug.LogError("Goal Positions not set");
        }
    }
    public void GoalScored()
    {
        // TODO: Add to score
        Debug.Log("Goal Scored");
        // Move to next position
        NextPosition();
    }

    void NextPosition()
    {
        if (positionIndex < positions.Length - 1)
        {
            positionIndex++;
            transform.position = positions[positionIndex].transform.position;
        }
        else
        {
            //reached last position
            LastGoalScored();
        }
    }

    void LastGoalScored()
    {
        Debug.Log("Last goal scored");
    }
}
