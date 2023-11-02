using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MysteryBox : MonoBehaviour
{
    private SpriteRenderer SR;
    public Sprite TouchedSprite;
    private GameObject Mystery;
    public GameObject MysteryStarPrefab;
    public GameObject MysteryFeatherPrefab;
    private GameObject MysteryPrefab;
    private float launchAngle = 45;
    private float launchSpeed = 4f;
    private int LaunchCounter = 0;
    private Vector3 SpawnPosition;
    // Start is called before the first frame update
    private SoundManager soundManager;
    void Start()
    {
        SpawnPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1.5f, gameObject.transform.position.z);
        SR = GetComponent<SpriteRenderer>();
        soundManager = FindObjectOfType<SoundManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int Choice;
        if(collision.collider.tag == "Player")
        {
            if (soundManager != null)
            {
                soundManager.SelectAudio(3, 0.5f);
            }

            if (LaunchCounter < 1)
            {
                //Debug.Log("Instantiate");
                SR.sprite = TouchedSprite;

                Choice = Random.Range(0, 2);
                if(Choice == 0)
                {
                    Mystery = Instantiate(MysteryStarPrefab, SpawnPosition, Quaternion.identity);

                }
                else if(Choice == 1)
                {
                    Mystery = Instantiate(MysteryFeatherPrefab, SpawnPosition, Quaternion.identity);
                }
                Mystery.GetComponent<Rigidbody2D>().gravityScale = 0f;

                float radian = launchAngle * Mathf.Deg2Rad;
                Vector2 launchDirection = new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
                Mystery.GetComponent<Rigidbody2D>().velocity = launchDirection * launchSpeed;

                // Enable gravity after launching
                Mystery.GetComponent<Rigidbody2D>().gravityScale = 1f;
                LaunchCounter++;
                //Destroy(Mystery, 5f);
            }
        }
    }
}
