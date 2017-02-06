using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public int enemyMax = 4;
    public GameObject enemyPrefab;
    float enemyStartingPosition;
    public GameObject[] enemyArray;
    public Quaternion noRotate = new Quaternion(0, 0, 0,0);

    // Use this for initialization
    void Start()
    {

        //     Debug.Log(enemyStartingPosition);
        spawnEnemies();
       // this.rigidbody2D.fixedAngle = true;
        Debug.Log(transform);
            
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collider.GetComponent<Collider2D>().name == "enemy0")
        {
            Debug.Log("bleuerh");
            //velocity = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), 0);
        }
    }
    /*    {
            if (collider.GetComponent<Collider2D>().name == "enemy0")
            {
                Debug.Log("bleuerh");
                //velocity = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), 0);
            }

        } */



    // Update is called once per frame
    void Update()
    {
        //Debug.Log(this.transform.childCount);
        if (this.transform.childCount <= 0)
        {
            spawnEnemies();
        }
        //  transform.position += new Vector3(-1f, 0, 0);
        /*   for (int i = 0; i < enemyArray.Length; i++)
           {
               enemyArray[i].transform.position = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), 0);
           }
          */
        
    }

    void spawnEnemies()
    {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        float playSpace = rightmost.x - leftmost.x;
        Debug.Log(playSpace);
        float divisor;
        int enemyCount = 0;
        //     rigidbody2D.fixedAngle = true;
        //    Debug.Log(playSpace);
        enemyStartingPosition = playSpace / (enemyMax + 1);
        Debug.Log(enemyStartingPosition);
        divisor = enemyStartingPosition;
        enemyArray = new GameObject[enemyMax];

        for (int enemies = 1; enemies <= enemyMax; enemies++)
        {




            Debug.Log(enemyArray);
            GameObject enemy = Instantiate(enemyPrefab, new Vector3(leftmost.x + enemyStartingPosition, 0, 0), Quaternion.identity) as GameObject;
            enemy.name = "enemy" + enemyCount;

            // Stop it spinning lol
            enemy.rigidbody2D.fixedAngle = true;

            // Set velocity, random??
            enemy.rigidbody2D.velocity = new Vector3(Random.Range(-3.0f, 3.0f), Random.Range(1.0f, 0));

            enemyArray[enemyCount] = enemy;
            enemy.transform.parent = transform;
            enemyStartingPosition += divisor;
            //    Debug.Log(enemyArray[enemies]);
            enemyCount++;

        }
    }


    void sporadicMovement()
    {
        //Create some random movement for the fighters. /w collision detection so they bounce away from
        //each other, remember to clamp axis.



    }




}
