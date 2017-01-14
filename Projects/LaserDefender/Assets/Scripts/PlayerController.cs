using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed = 15.0f;
    public float padding = 0.7f;

    float xmin;
    float xmax;

    public bool mouseControl = false;

    // Use this for initialization
    void Start () {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0,0, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xmin = leftmost.x + padding;
        xmax = rightmost.x - padding;
    }
	
	// Update is called once per frame
	void Update () {

        //Mouse control
        if (mouseControl == true)
        {
            Vector3 shipPos = new Vector3(0.0f, 0.0f, 0.0f);
            //shipPos = Input.mousePosition;
            shipPos.x = Mathf.Clamp(((Input.mousePosition.x * 0.03f) - 12.0f), -11.0f, 11.0f);
            shipPos.y = Mathf.Clamp(((Input.mousePosition.y * 0.03f) - 12.0f), -11f, 11.0f);
            this.transform.position = shipPos; //Input.mousePosition;
                                               //Debug.Log("sddsdsd");
                                               //  if (Input.GetKeyDown("LeftArrow"))
            transform.eulerAngles = new Vector3(0.0f, (shipPos.x) * 5, 0.0f);

            // Debug.Log(this.rigidbody2D.velocity);

        } else //Key Board Control
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                // this.transform.position += new Vector3(-speed * Time.deltaTime, 0f, 0);  
                this.transform.position += Vector3.left * speed * Time.deltaTime;
            } else if (Input.GetKey(KeyCode.RightArrow))
            {
                this.transform.position += Vector3.right * speed * Time.deltaTime;
            }

            //Restrict movement to gamespace
            float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        }

    }
}
