using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SuperJumpPowerUp : MonoBehaviour
{
    private movement MoveScript;
    private Rigidbody2D RigidbodyJump;
    // Start is called before the first frame update
    void Start()
    {
        MoveScript = FindAnyObjectByType<movement>();
        RigidbodyJump = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Platform")
        {
            RigidbodyJump.gravityScale = 0;
            gameObject.GetComponent<PolygonCollider2D>().isTrigger = true;
            RigidbodyJump.constraints = RigidbodyConstraints2D.FreezePosition;
            Destroy(gameObject, 5f);
        }

        if (collision.collider.tag == "Player")
        {
            RigidbodyJump.gravityScale = 0;
            gameObject.GetComponent<PolygonCollider2D>().isTrigger = true;
            RigidbodyJump.constraints = RigidbodyConstraints2D.FreezePosition;
            MoveScript.ActivateJump();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MoveScript.ActivateJump();
            Destroy(gameObject);
        }
    }
}
