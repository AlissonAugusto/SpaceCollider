using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SplashScreen.Hide();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Play()
    {
        Application.LoadLevel(2);
    }
}
