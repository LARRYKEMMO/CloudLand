using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetleMovement : MonoBehaviour
{
    private Animator animator;
    public bool Dead = false;
    public Sprite DeadSprite;
    private SpriteRenderer spriteRenderer;
    private movement MoveScript;
    private PolygonCollider2D ChildCollider;
    // Start is called before the first frame update
    void Start()
    {
        ChildCollider = GetComponentInChildren<PolygonCollider2D>();
        MoveScript = FindAnyObjectByType<movement>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Dead == false)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3 (-1f, 0f, 0f);

        }

        else if(Dead == true)
        {
            //MoveScript.DeActivateTrigger();
            animator.enabled = false;
            spriteRenderer.sprite = DeadSprite;
            //Debug.Log("SpriteChanged");
            //    Time.timeScale = 0;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0f, -2f, 0f);
            Destroy(gameObject, 10f);
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" && Dead == false)
        {
            MoveScript.ActivateTrigger();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Shield"))
        {
            KillBeetle();
        }
    }
    private void KillBeetle()
    {
        Dead = true;
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        ChildCollider.isTrigger = true;
        
    }
}
