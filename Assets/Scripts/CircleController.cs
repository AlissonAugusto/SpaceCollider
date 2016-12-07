using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CircleController : MonoBehaviour
{
    public GameObject circleParticle;
    public static int score;
    public static int gameState;
    public Text scoreText;
    public Text scoreName;
    public Text BestName;
    public Text bestText;
    public Text score2;
    public Image border;
    public Image gameOver;
    public Image ButtonRestart;
    public Text Restart;
    public Image highScore;
    public Image SoundOn;
    public Button SoundButton;

    // Use this for initialization
    void Start()
    {
        score = 0;
        gameState = 1;
        scoreName.enabled = false;
        score2.enabled = false;
        BestName.enabled = false;
        bestText.enabled = false;
        border.enabled = false;
        gameOver.enabled = false;
        ButtonRestart.enabled = false;
        Restart.enabled = false;
        highScore.enabled = false;
        SoundOn.enabled = false;
        SoundButton.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
        if (score > PlayerPrefs.GetInt("Best Score"))
        {
            highScore.enabled = true;
        }
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        Sounds.CircleExplosion = 1;
        gameState = 0;
        GameOver();
        Handheld.Vibrate();
        circleParticle.GetComponent<ParticleSystem>().Play();
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        Invoke("Stoping", 1.0f);
    }

    void GameOver()
    {
        highScore.enabled = false;
        border.enabled = true;
        gameOver.enabled = true;
        scoreName.enabled = true;
        BestName.enabled = true;
        ButtonRestart.enabled = true;
        Restart.enabled = true;
        SoundOn.enabled = true;
        SoundButton.enabled = true;
        scoreText.enabled = false;
        score2.enabled = true;
        score2.text = score.ToString();
        if (score > PlayerPrefs.GetInt("Best Score"))
        {
            PlayerPrefs.SetInt("Best Score", score);

        }
        bestText.text = PlayerPrefs.GetInt("Best Score").ToString();
        bestText.enabled = true;
    }
    void Stoping()
    {
        circleParticle.GetComponent<ParticleSystem>().Stop();
    }
}

























































































