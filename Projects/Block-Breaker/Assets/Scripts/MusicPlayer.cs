using UnityEngine;
using System.Collections;


public class MusicPlayer : MonoBehaviour
{
    static MusicPlayer instance = null;

    void Awake()
    {
        Debug.Log("Music Player Awake " + GetInstanceID());

        
        if (instance != null)
        {
            Destroy(gameObject);
            Debug.Log("Destroying dupe music player");
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

    //public static int musicPlayer = 0; // No, this is set every time this class is instantiated!

    // Use this for initialization
    void Start()
    {
        Debug.Log("Music Player Start " + GetInstanceID());


    }

    // Update is called once per frame
    void Update()
    {

    }
}
