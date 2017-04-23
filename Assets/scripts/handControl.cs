using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class handControl : MonoBehaviour {

    public enum Direction
    {
        LEFT,
        RIGHT
    }

    public GameObject point;
    public GameControl Game;
    GameObject ball;

    GameObject BallPrefab;
    AudioSource audio;
    public AudioClip MovingAudio;
    public AudioClip DropingAudio;
    public AudioClip SetNewAudio;
    public AudioClip ChangeAudio;
    public AudioClip LevelUpAudio;
    public Image ColdDown;
    public float CodldownTime = 2.0f;
    public float BackTime = 5.0f;
    public GameObject BallPrefab1;
    public GameObject BallPrefab2;
    public GameObject BallPrefab3;
    public GameObject BallPrefab4;

    public float mass1 = 4.0f;
    public float mass2 = 2.0f;
    public float mass3 = 8.0f;
    public float mass4 = 1.0f;

    Transform transform;
    public float step = 1.0f;
    float timer = 0;

    bool onDrop = false;
    bool onBackTimer = false;
    bool ballNotChanges = true;
    int i = 0;
    float timerChanges = 0.0f;

	// Use this for initialization
	void Start () {
        audio = this.GetComponent<AudioSource>();
        transform = gameObject.transform;
        BallPrefab = BallPrefab1;
        SetNewBall();
        timer = 0f;
	}

    void Update()
    {
        if (Game.isGameStop)
        {
            ColdDown.enabled = false;
            return;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            DropBall();
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            MoveHand(Direction.RIGHT);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            MoveHand(Direction.LEFT);
        }

        if (Input.GetButtonDown("Num1"))
        {
           // Debug.LogWarning(" => key press =>" + ballNotChanges);
            
            ChangeBall(BallPrefab1);
        }
        if (Input.GetButtonDown("Num2"))
        {
            ChangeBall(BallPrefab2);
        }
        if (Input.GetButtonDown("Num3"))
        {
            ChangeBall(BallPrefab3);
        }
        if (Input.GetButtonDown("Num4"))
        {
            ChangeBall(BallPrefab4);
        }
    }
	// Update is called once per frame
	void FixedUpdate () {
        if (Game.isGameStop)
        {
            ColdDown.enabled = false;
            return;
        }
        onTimer();
    }
    /*void*/
    void  ChangeBall(GameObject prefab)
    {

        if (ball == null)
            return;

        if (ballNotChanges/* && timerChanges <= 0.0f*/)
        {
            audio.PlayOneShot(ChangeAudio);
          //  timerChanges = 0.3f;
            ballNotChanges = false;
            BallPrefab = prefab;
            DestroyBall();
            SetNewBall();
            ballNotChanges = true;
        }

    }


    void DropBall()
    {
        if (ball == null)
            return;
        if (onDrop == false)
            return;

        Rigidbody2D rigid = ball.GetComponentInChildren<Rigidbody2D>();
        if (rigid != null)
        {
            rigid.bodyType = RigidbodyType2D.Dynamic;

            ball.transform.SetParent(null);
            AddScore();
            ball = null; // TODO: next ball
            SetNewBall();
        }
        onDrop = false;
        onBackTimer = false;
        timer = 0;
    }

    void AddScore()
    {
        int score = 10;//TODO: переключить на маппинг из Game
        ExecuteEvents.Execute<UIActions>(Game.gameObject, null, (x, y) => x.UIAction(new UIMessageAction() { TypeMessage = UIMessageAction.type.ADD_SCORE,paramInt=score }));
    }

    void MoveHand(Direction dir)
    {
        audio.PlayOneShot(MovingAudio);
        Vector3 newPosition = transform.position + (dir==Direction.LEFT ? Vector3.left : Vector3.right)*step;
        transform.position=newPosition;
    }
    void DestroyBall()
    {
        if (ball == null)
            return;
        GameObject.Destroy(ball.gameObject);
        ball = null;
    }
    void SetNewBall()
    {
        if (ball != null)
            return;
        audio.PlayOneShot(SetNewAudio);
        GameObject b =  GameObject.Instantiate(BallPrefab);
        b.transform.tag = "falled";
        b.transform.name = "ball_" + i;
        i++;
        CircleCollider2D col = b.GetComponent<CircleCollider2D>();
        col.isTrigger = true;
        b.transform.position = Vector3.zero;
        b.transform.SetParent(point.transform); //TODO: попробовать FixedJoin2d
        b.transform.localPosition = Vector3.zero;
        ball = b;
        
    }

   public  void LevelUp(int level)
    {
        audio.PlayOneShot(LevelUpAudio);
        ball.transform.tag = "falled";
        Vector3 newPosition = transform.position + Vector3.up * 0.6f;
        transform.position = newPosition;
        int score = level * 100;//TODO: переключить на маппинг из Game
        ExecuteEvents.Execute<UIActions>(Game.gameObject, null, (x, y) => x.UIAction(new UIMessageAction() { TypeMessage = UIMessageAction.type.ADD_SCORE, paramInt = score }));
    }
    void onTimer()
    {
        if (!onBackTimer)
        {
            timer += 0.035f;
            if (timer/CodldownTime >=0.99f)
            {
                onDrop = true;
                onBackTimer = true;
               timer = BackTime;
            }
            ColdDown.fillAmount = timer / CodldownTime;
            
        }
        else
        {
             timer -= 0.035f;
            if (timer <= 0)
            {
                onBackTimer = false;
                DropBall();
            }

            ColdDown.enabled = true;
            ColdDown.fillAmount = timer / BackTime;
        }
    }
}
