using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Sounds : MonoBehaviour {

	// Use this for initialization
    public static int explosion;
    public static int CircleExplosion;
    public static int shield;
    public Button button;
    public AudioSource sound1;
    public AudioSource sound2;
    public AudioSource sound3;

	void Start () {
        explosion = 0;
        CircleExplosion = 0;
        shield = 0;
        if (PlayerPrefs.GetInt("SoundOn") == 1)
        {
            button.image.color = new Color(1f, 1f, 1f, .5f);
        }
        else
        {
            button.image.color = new Color(1f, 1f, 1f, 1f);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (PlayerPrefs.GetInt("SoundOn") == 0)
        {
            if (explosion == 1)
            {
                sound1.Play();
            }
            explosion = 0;
            if (CircleExplosion == 1)
            {
                sound2.Play();
            }
            CircleExplosion = 0;
            if (shield == 1)
            {
                sound3.Play();
            }
            shield = 0;
        }
	}
    public void SoundOnButton()
    {
        if (PlayerPrefs.GetInt("SoundOn") == 0)
        {
            PlayerPrefs.SetInt("SoundOn", 1);
            button.image.color = new Color(1f,1f,1f,.5f);
        }else
        {
            PlayerPrefs.SetInt("SoundOn", 0);
            button.image.color = new Color(1f, 1f, 1f, 1f);
        }
    }
}
