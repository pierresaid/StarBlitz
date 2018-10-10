using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    // Use this for initialization
    public Text ScoreText;
    int _score;
	void Start () {
        _score = 0;
        ScoreText.text = ((level_manager.bulleth) ? "BH " : "") + "Score: 0";	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void doubleup ()
    {
        _score *= 2;
        ScoreText.text = ((level_manager.bulleth) ? "BH " : "") + "Score: " + _score.ToString();
    }
    public void AddScore(int score)
    {
        _score += score;
        ScoreText.text = ((level_manager.bulleth) ? "BH " : "") + "Score: " + _score.ToString();
    }

}
