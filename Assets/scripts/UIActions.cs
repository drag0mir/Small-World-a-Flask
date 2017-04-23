using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class UIMessageAction
{
    public enum type
    {
        ADD_SCORE,
        START_COLDDOWN,
        START_GAME,
        LEVEL_UP,
        GAME_OVER
    };

    public type TypeMessage;
    public int paramInt;
    public string paramString;
    GameObject paramObject;

}

public interface UIActions : IEventSystemHandler
{

    void UIAction(UIMessageAction arg);
}


