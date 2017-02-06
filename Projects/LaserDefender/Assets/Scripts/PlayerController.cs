using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour {

    public float speed = 15.0f;
    public float padding = 0.7f;
    public float playerHealth = 1000f;

    public Text healthRemainingText;


    public GameObject projectilePrefab01;
    public float projectileSpeed = 0f;
    public float fireRate = 0.2f;

    float xmin;
    float xmax;

    public bool mouseControl = false;

    Vector3 projectilePositionRight = new Vector3(1.8f, 1f, 0);
    Vector3 projectilePositionLeft = new Vector3(-1.8f, 1f, 0);

    // Use this for initialization
    void Start () {

        healthRemainingText.text = "Health: " + playerHealth.ToString();
        //healthRemainingText.text = "Health: " + playerHealth.ToString();

        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0,0, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xmin = leftmost.x + padding;
        xmax = rightmost.x - padding;
    }

    // Update is called once per frame
    void Update() {

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
            if (Input.GetMouseButtonDown(0))
            {
                InvokeRepeating("Fire", 0.000001f, fireRate);
            }
            if (Input.GetMouseButtonUp(0))
            {
                CancelInvoke("Fire");
            }
        }



        else //Key Board Control
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                // this.transform.position += new Vector3(-speed * Time.deltaTime, 0f, 0);  
                this.transform.position += Vector3.left * speed * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                this.transform.position += Vector3.right * speed * Time.deltaTime;
            }

            //Restrict movement to gamespace
            float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);

            if (mouseControl == false)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    InvokeRepeating("Fire", 0.000001f, fireRate);
                }
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    CancelInvoke("Fire");
                }
            } 
    
        }

    }

    void Fire()
    { 
        GameObject projectile1 = Instantiate(projectilePrefab01, (transform.position + projectilePositionLeft), Quaternion.identity) as GameObject;
        GameObject projectile2 = Instantiate(projectilePrefab01, (transform.position + projectilePositionRight), Quaternion.identity) as GameObject;
        projectile1.rigidbody2D.velocity = new Vector3(0, projectileSpeed, 0);
        projectile2.rigidbody2D.velocity = new Vector3(0, projectileSpeed, 0);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Projectile enemyMissile = collider.gameObject.GetComponent<Projectile>();
        if (enemyMissile)
        {
          //  healthRemainingText = GetComponent<Text>();
            playerHealth -= enemyMissile.getDamage();
            enemyMissile.Hit();
            healthRemainingText.text = "Health: " + playerHealth.ToString();
            if (playerHealth <= 0)
            {

                Destroy(gameObject);
            }
            //Enemy enemyHit = collider.gameObject.GetComponent<Enemy>();
            //     Destroy(enemyHit.gameObject);
        }
    }
}
