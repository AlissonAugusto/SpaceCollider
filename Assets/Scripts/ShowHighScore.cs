using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowHighScore : MonoBehaviour {

    public Text highScore;
	// Use this for initialization
	void Start () {
        highScore.text = "HIGHSCORE " + PlayerPrefs.GetInt("Best Score").ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
