using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class GameControl : MonoBehaviour, UIActions
{
    public Text ScoreLabel;

    public GameObject ModalWindow;
    public Text ModalText;
    public bool isGameStop = false;
    int score = 0;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UIAction(UIMessageAction arg)
    {
        if (arg == null)
            return;

        switch (arg.TypeMessage)
        {
            case UIMessageAction.type.ADD_SCORE:
                {
                    score += arg.paramInt;
                    ScoreLabel.text = score.ToString();
                }
                break;
            case UIMessageAction.type.GAME_OVER:
                {
                    if (!isGameStop)
                    {
                        isGameStop = true;
                        ModalText.text = ModalText.text + score.ToString();
                        ModalWindow.SetActive(true);
                    }
                }
                break;
        }
    }

    public void ShareTwitter()
    {
        const string Address = "http://twitter.com/intent/tweet";
        Application.OpenURL(Address +
    "?text=" + WWW.EscapeURL("My Score in Small World a flask (#LudumDare38) is: " + score) +
    "&amp;url=" + WWW.EscapeURL("\t") +
    "&amp;related=" + WWW.EscapeURL("\t") +
    "&amp;lang=" + WWW.EscapeURL("en"));
    }

    public void GoReset()
    {
        Application.LoadLevel("game");
    }
    public void GoHome()
    {
        Application.LoadLevel("title");
    }
}
