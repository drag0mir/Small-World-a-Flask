using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class joinholder : MonoBehaviour {

    GameControl Game;

    void Start()
    {
        Game = Camera.main.GetComponent<GameControl>();
    }
	

    void OnJointBreak2D(Joint2D brokenJoint)
    {
        ExecuteEvents.Execute<UIActions>(Game.gameObject, null, (x, y) => x.UIAction(new UIMessageAction() { TypeMessage = UIMessageAction.type.GAME_OVER}));
    }
}
