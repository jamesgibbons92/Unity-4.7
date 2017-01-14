using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    void OnCollisionEnter2D(Collision2D collision)
    {

            Debug.Log("bleuerh");
        //velocity = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), 0);
        this.rigidbody2D.velocity = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), 0);
        //this.rigidbody2D.velocity = new Vector3((this.rigidbody2D.velocity.x * -1), (this.rigidbody2D.velocity.y * -1), 0);
    }

    // Update is called once per frame
    void Update () {
	
	}
}
