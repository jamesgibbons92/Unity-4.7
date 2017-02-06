using UnityEngine;
using System.Collections;

public class TopCollider : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(col.gameObject);
    }
}
