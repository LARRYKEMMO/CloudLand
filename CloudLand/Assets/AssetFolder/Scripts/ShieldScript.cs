using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    private movement MoveScript;
    private Rigidbody2D RigidbodyShield;

    // Start is called before the first frame update
    void Start()
    {
        MoveScript = FindAnyObjectByType<movement>();
        RigidbodyShield = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Platform")
        {
            RigidbodyShield.gravityScale = 0;
            gameObject.GetComponent<PolygonCollider2D>().isTrigger = true;
            RigidbodyShield.constraints = RigidbodyConstraints2D.FreezePosition;
            Destroy(gameObject, 5f);
        }

        if (collision.collider.tag == "Player")
        {
            RigidbodyShield.gravityScale = 0;
            gameObject.GetComponent<PolygonCollider2D>().isTrigger = true;
            RigidbodyShield.constraints = RigidbodyConstraints2D.FreezePosition;
            MoveScript.ActivateStars();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MoveScript.ActivateStars();
            Destroy(gameObject);
        }

    }
}
