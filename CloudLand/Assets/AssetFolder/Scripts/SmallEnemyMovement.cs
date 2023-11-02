using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnemyMovement : MonoBehaviour
{
    // public GameObject eyes;
    private movement MoveScript;
    public GameObject Left;
    public GameObject Right;
    private Vector3 left;
    private Vector3 right;
    private bool Move = false;
    private int SwitchCounter = 0;
    private int trueCounter = 0;
    private Animator animator;
    public bool Dead = false;
    private bool Walk = false;
    private PolygonCollider2D childCollider;
    private int KillCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        MoveScript = FindAnyObjectByType<movement>();
        animator = GetComponent<Animator>();
        left = Left.transform.position;
        right = Right.transform.position;   
        childCollider = GetComponentInChildren<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Dead == false && Walk == true)
        {
            if (Move == true && gameObject.transform.position.x >= left.x)
            {
                gameObject.transform.localScale = new Vector3(2, 2, 2);
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(-5, 0, 0);
            }
            else if(Move == true && gameObject.transform.position.x <= left.x)
            {
                Move = false;
            }
            
            if (Move == false && gameObject.transform.position.x <= right.x)
            {
                gameObject.transform.localScale = new Vector3(-2, 2, 2);
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(5, 0, 0);
            }
            else if(Move == false && gameObject.transform.position.x >= right.x)
            {
                Move = true;
            }
            //Debug.Log("SwitchCounter " + SwitchCounter);
            //Debug.Log("SwitchCounterRem " + SwitchCounter % 2);

        }
        else 
        if (Dead == true)
        {
            animator.enabled = false;
//            gameObject.transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0f, -2f, 0f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Platform")
        {
            if(trueCounter < 1)
            {
                Move = true;
                Walk = true;
                trueCounter ++;
            }
        }

        if(collision.collider.tag == "Player")
        {
            //Debug.Log("KILL GAVIN entered");
            //Debug.Log(gameObject.GetComponent<BoxCollider2D>().isTrigger);

            //if (Dead == false)
            //{
            //    MoveScript.ActivateTrigger2();
            //    Debug.Log("KILL GAVIN");
            //}
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Shield"))
        {
            KillDummy();
        }
    }

    public void KillDummy()
    {
        if(KillCounter < 1)
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            childCollider.isTrigger = true;
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, -gameObject.transform.localScale.y, gameObject.transform.localScale.z);
            Dead = true;
            KillCounter++;
        }
        
    }

}
