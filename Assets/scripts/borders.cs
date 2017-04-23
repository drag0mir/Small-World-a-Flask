using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class borders : MonoBehaviour {

    public handControl.Direction direction;
    public handControl hand;
    void OnTriggerEnter2D(Collider2D other)
    {

        Debug.LogWarning("Border colision on " + other.tag + " => " + other.gameObject.name);
        if (other.gameObject.tag != "top" && other.gameObject.tag != "bottom")
        {
            hand.MoveHand10(direction);
            //    MoveHand(moving == Direction.LEFT ? Direction.RIGHT : Direction.LEFT);

        }
    }

   /* void OnTriggerStay2D(Collider2D other)
    {

        Debug.LogWarning("Border OnTriggerStay on " + other.tag + " => " + other.gameObject.name);
        if (other.gameObject.tag != "top" && other.gameObject.tag != "bottom")
        {
            hand.MoveHand(direction);
            //    MoveHand(moving == Direction.LEFT ? Direction.RIGHT : Direction.LEFT);

        }
    }*/
}
