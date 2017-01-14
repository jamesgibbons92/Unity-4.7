using UnityEngine;
using System.Collections;

public class PaddleScript : MonoBehaviour {

    public MusicPlayer music;

    // public GameObject Paddle;
    private float hits = 0.0f;
	// Use this for initialization
	void Start () {
        music = GameObject.FindObjectOfType<MusicPlayer>();
	
	}

    //Put in bricks script
/**    void OnCollisionEnter2D(Collision2D collision)
    {
       hits += 0.01f;
       music.audio.pitch = hits;
    } **/

    // Update is called once per frame
    void Update () {
         //  print(Input.mousePosition);
        Vector3 paddlePos = new Vector3 (0.0f,0.5f,0.0f);
        //float paddlePos.x = Input.mousePosition.x;
        //     Paddle.transform.Translate(Input.mousePosition);

        paddlePos.x = Mathf.Clamp((Input.mousePosition.x * 0.02f),0.5f,15.5f);

        
        this.transform.position = paddlePos; //Input.mousePosition;
	}
}
