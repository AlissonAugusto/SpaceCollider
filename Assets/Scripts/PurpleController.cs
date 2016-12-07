using UnityEngine;
using System.Collections;

public class PurpleController : MonoBehaviour
{
    public GameObject red;
    public GameObject green;
    public GameObject purple;
    public GameObject purpleParticle;
    float velocity;
    bool v;
    int i;
    int life;
    int j;
    int k;

    // Use this for initialization
    void Start()
    {
        life = 3;
        v = true;
        purpleParticle.GetComponent<ParticleSystem>().transform.rotation = Quaternion.Euler(new Vector3(Random.Range(0.0f, 360.0f), 90.0f, 0.0f));
        velocity = (float)(Mathf.Log(CircleController.score + 1) * 2.617) + 1;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (CircleController.gameState == 1 && v == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(0, 0), velocity / 3 * Time.deltaTime);
        }
    }
    void OnMouseDown()
    {
        if (CircleController.gameState == 1)
        {
            life--;
            Sounds.shield = 1;
            if (life <= 0)
            {
                CircleController.score++;
                j = Random.Range(0, 100);
                k = Random.Range(0, 100);
                if (j <= 80)
                {
                    if (k >= 50)
                    {
                        Instantiate(red, new Vector3(10.0f, Random.Range(-10.0F, 10.0F)), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(red, new Vector3(-10.0f, Random.Range(-10.0F, 10.0F)), Quaternion.identity);
                    }
                }
                else if (j <= 90)
                {
                    if (k >= 50)
                    {
                        Instantiate(green, new Vector3(10.0f, Random.Range(-10.0F, 10.0F)), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(green, new Vector3(-10.0f, Random.Range(-10.0F, 10.0F)), Quaternion.identity);
                    }
                }
                else
                {
                    if (k >= 50)
                    {
                        Instantiate(purple, new Vector3(10.0f, Random.Range(-10.0F, 10.0F)), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(purple, new Vector3(-10.0f, Random.Range(-10.0F, 10.0F)), Quaternion.identity);
                    }
                }
                Handheld.Vibrate();
                Sounds.explosion = 1;
                v = false;
                purpleParticle.GetComponent<ParticleSystem>().Play();
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                Invoke("Stoping", 1.0f);
                Invoke("Destroy", 1.1f);
            }
        }
    }
    void Stoping()
    {
        purpleParticle.GetComponent<ParticleSystem>().Stop();
    }
    void Destroy()
    {
        Destroy(gameObject);
    }
}
