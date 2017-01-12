using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    public PaddleScript paddle;
    private bool hasStarted = false; //Private for now, might want to use it elswhere?
    private Vector3 paddleToBallVector;
	// Use this for initialization
	void Start () {
        paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (!hasStarted)
        {
            //Lock position at start
            this.transform.position = paddleToBallVector + paddle.transform.position;
            if (Input.GetMouseButtonDown(0))
            {
                //Launch the ball and set hasStarted to true
                hasStarted = true;
                this.rigidbody2D.velocity = new Vector2(2f, 2f);
            }

        }
        
	}
}
