using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public float health = 150;
    public float speed = 5.0f;
    public GameObject projectilePrefabEnemy01;
    private float projectileSpeed = -5f;
    public float enemySPS = 0.5f;





    // Use this for initialization
    void Start () {
	
	}

    void OnCollisionEnter2D(Collision2D collision)
    {

     
        //velocity = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), 0);
        this.rigidbody2D.velocity = new Vector3(Random.Range(speed, -speed), Random.Range(speed, -speed), 0);
        //this.rigidbody2D.velocity = new Vector3((this.rigidbody2D.velocity.x * -1), (this.rigidbody2D.velocity.y * -1), 0);
    }

    // Bullet trigger collision
    void OnTriggerEnter2D(Collider2D collider)
    {
        Projectile missile = collider.gameObject.GetComponent<Projectile>();
        if (missile)
        {
            health -= missile.getDamage();
            missile.Hit();
            if (health <= 0)
            {
                
                Destroy(gameObject);

               

                Debug.Log(this.transform.childCount);
            }
            //Enemy enemyHit = collider.gameObject.GetComponent<Enemy>();
       //     Destroy(enemyHit.gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
        // EnemyFire();
        float p = Time.deltaTime * enemySPS;
        if (Random.value < p)
        {
            EnemyFire();
        }
    }

    void EnemyFire()
    {
        Vector3 startingPosition = transform.position + new Vector3(0, -2f, 0);
        GameObject projectile1 = Instantiate(projectilePrefabEnemy01, (startingPosition), Quaternion.identity) as GameObject;
        projectile1.rigidbody2D.velocity = new Vector3(0, projectileSpeed, 0);
       
    }
}
