using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flaskControl : MonoBehaviour {

    List<FixedJoint2D> bottomsFixed;
    List<FixedJoint2D> topsFixed;

    public float TopBreakForce = 450.0f;
    public float BottomBreakForce = 2000.0f;
	// Use this for initialization
	void Start () {
        bottomsFixed = new List<FixedJoint2D>();
        topsFixed = new List<FixedJoint2D>();

        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("bottom"))
        {
            bottomsFixed.Add(obj.GetComponent<FixedJoint2D>());
        }
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("top"))
        {
            topsFixed.Add(obj.GetComponent<FixedJoint2D>());
        }
        setForce();

	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void setForce()
    {
        foreach(FixedJoint2D join in bottomsFixed)
        {
            join.breakForce = BottomBreakForce;
        }

        foreach (FixedJoint2D join in topsFixed)
        {
            join.breakForce = TopBreakForce;
        }
    }

}
