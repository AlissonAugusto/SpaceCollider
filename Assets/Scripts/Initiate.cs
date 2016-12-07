using UnityEngine;
using System.Collections;

public class Initiate : MonoBehaviour {

    public GameObject red;
    int i;

	// Use this for initialization
	void Start () {
        i = Random.Range(0, 100);
        {
            if (i >= 50)
            {
                Instantiate(red, new Vector3(10.0f, Random.Range(-10.0F, 10.0F)), Quaternion.identity);
            }
            else
            {
                Instantiate(red, new Vector3(-10.0f, Random.Range(-10.0F, 10.0F)), Quaternion.identity);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
