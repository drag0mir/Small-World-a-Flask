using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsChangeTag : MonoBehaviour {

    private static string tagFall = "falled";

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "gradeLine" && other.tag != tagFall)
        {
        //    Debug.LogWarning(gameObject.name + " => collision on =>" + other.tag + " => " + other.gameObject.name);
        gameObject.transform.tag = "droppen";
        CircleCollider2D col = gameObject.GetComponent<CircleCollider2D>();
        col.isTrigger = false;

    }
    }
}
