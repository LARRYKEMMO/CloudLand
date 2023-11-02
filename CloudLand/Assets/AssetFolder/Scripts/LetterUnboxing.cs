using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterUnboxing : MonoBehaviour
{
    public Image spriteA;
    public Image spriteB;
    public Image spriteC;
    public Image spriteD;
    public Image spriteE;
    public Image spriteF;
    private Image MainSprite;
    private Color MainColor;
    public float moveSpeed = 0.5f;
    public int numberOfObjects = 10;
    public float radius = 0.5f;
    public GameObject StarPrefab;
    private GameObject Star;
    public FollowPlayerScript FollowPlayer;
    private List<GameObject> Stars;
    private SoundManager soundManager;
    // Start is called before the first frame update
    void Start()
    {
        //FollowPlayer = FindAnyObjectByType<FollowPlayerScript>();
        Stars = new List<GameObject>();
        soundManager = FindObjectOfType<SoundManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            if(gameObject.tag == "LetterA")
            {
                MainSprite = spriteA.GetComponent<Image>();
                MainColor = MainSprite.color;
                MainColor.a = 1f;
                MainSprite.color = MainColor;
            }
            else if (gameObject.tag == "LetterB")
            {
                MainSprite = spriteB.GetComponent<Image>();
                MainColor = MainSprite.color;
                MainColor.a = 1f;
                MainSprite.color = MainColor;
            }
            else if (gameObject.tag == "LetterC")
            {
                MainSprite = spriteC.GetComponent<Image>();
                MainColor = MainSprite.color;
                MainColor.a = 1f;
                MainSprite.color = MainColor;
            }
            else if (gameObject.tag == "LetterD")
            {
                MainSprite = spriteD.GetComponent<Image>();
                MainColor = MainSprite.color;
                MainColor.a = 1f;
                MainSprite.color = MainColor;
            }
            else if (gameObject.tag == "LetterE")
            {
                MainSprite = spriteE.GetComponent<Image>();
                MainColor = MainSprite.color;
                MainColor.a = 1f;
                MainSprite.color = MainColor;
            }
            else if (gameObject.tag == "LetterF")
            {
                MainSprite = spriteF.GetComponent<Image>();
                MainColor = MainSprite.color;
                MainColor.a = 1f;
                MainSprite.color = MainColor;
            }

            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;

            float angleIncrement = 360f / numberOfObjects;

            for (int i = 0; i < numberOfObjects; i++)
            {
                float angle = i * angleIncrement;
                Vector2 spawnPosition = GetCirclePosition(angle);
                Star = Instantiate(StarPrefab, spawnPosition, Quaternion.identity);
                Stars.Add(Star);
                SetMovementDirection(Star, angle);
                Destroy(Stars[i], 2f);
            }

            FollowPlayer.Begin = true;
        }
    }

    private Vector2 GetCirclePosition(float angle)
    {
        float radian = angle * Mathf.Deg2Rad;
        float x = transform.position.x + radius * Mathf.Cos(radian);
        float y = transform.position.y + radius * Mathf.Sin(radian);
        return new Vector2(x, y);
    }

    private void SetMovementDirection(GameObject obj, float angle)
    {
        float radian = angle * Mathf.Deg2Rad;
        float dirX = Mathf.Cos(radian);
        float dirY = Mathf.Sin(radian);
        Vector2 direction = new Vector2(dirX, dirY);
        obj.GetComponent<Rigidbody2D>().velocity = direction * moveSpeed;
    }
}
