using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }
    private UIControl uiControl;
    int score = 0;
	// Use this for initialization
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
        uiControl = FindObjectOfType<UIControl>();
    }

    public void UpdateScore()
    {
        score++;
        uiControl.UpdateScore(score);

    }
}
