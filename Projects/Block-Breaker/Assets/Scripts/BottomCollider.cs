using UnityEngine;
using System.Collections;

public class BottomCollider : MonoBehaviour {

    public LevelManager levelManager;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D trigger)
    {
        print("Trigger");
        levelManager.LoadLevel("Win Screen");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        print("Collision");
    }

}
