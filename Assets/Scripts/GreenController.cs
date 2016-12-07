using UnityEngine;
using System.Collections;

public class GreenController : MonoBehaviour
{
    public GameObject red;
    public GameObject green;
    public GameObject purple;
    public GameObject greenParticle;
    float velocity, y;
    bool z, v;
    int i;
    int j;
    int k;

    // Use this for initialization
    void Start()
    {
        z = true;
        v = true;
        greenParticle.GetComponent<ParticleSystem>().transform.rotation = Quaternion.Euler(new Vector3(Random.Range(0.0f, 360.0f), 90.0f, 0.0f));
        y = Random.Range(1, 5);
        velocity = (float)(Mathf.Log(CircleController.score + 1) * 2.617) + 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (CircleController.gameState == 1 && v == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(0, 0), velocity / 2 * Time.deltaTime);
            Move();
        }
    }

    void Move()
    {
        if (z == true)
        {
            if (transform.position.y <= y)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, 6.0f), 4.235f * Time.deltaTime);
            }
            else z = false;
        }
        else
        {
            if (transform.position.y >= -y)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, -6.0f), 4.235f * Time.deltaTime);
            }
            else
            {
                z = true;
            }
        }
    }

    void OnMouseDown()
    {
        if (CircleController.gameState == 1)
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
            greenParticle.GetComponent<ParticleSystem>().Play();
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            Invoke("Stoping", 1.0f);
            Invoke("Destroy", 1.1f);
        }
    }
    void Stoping()
    {
        greenParticle.GetComponent<ParticleSystem>().Stop();
    }
    void Destroy()
    {
        Destroy(gameObject);
    }
}
