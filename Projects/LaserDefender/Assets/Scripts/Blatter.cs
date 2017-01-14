using UnityEngine;
using System.Collections;

public class Blatter : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(this.transform.position);
	  /*  if (this.transform.position.y > 20f)
        {
            Destroy(this.gameObject);
        }*/
	}
}
