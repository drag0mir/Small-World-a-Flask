using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradeControl : MonoBehaviour {

    public handControl hand;
    public int level;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "falled")
        {
            
            hand.LevelUp(level);
            gameObject.active = false;

        }
    }
}
