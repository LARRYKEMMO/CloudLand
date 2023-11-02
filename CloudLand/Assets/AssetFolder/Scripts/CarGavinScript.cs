using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarGavinScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Feather;
    public static movement instance;
    private float dirX = 0f;
    public int goal = 50;
    public TMP_Text cointText;
    private float speed = 5f;
    [SerializeField] private int starcount = 0;
    private MovementState state;
    private float jumpforce = 10;
    [SerializeField] private float airspeed = 3f;
    [SerializeField] private LayerMask layer;
    [SerializeField] private LayerMask currency;
    private BoxCollider2D box;
    private CircleCollider2D circle;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;
    private Vector3 SpawnPoint;
    private bool OnTrigger = false;
    public GameObject MainMenuButton;
    private Vector3 OriginalPos;
    private string FinalText = "Congratulations for completing all levels of Cloud Land !!!, You now unlocked the ability to play any level of the game at your convinience. ENJOY !!!";
    private int LoopCounter = 0;
    private string TempText = "";
    private char[] characterList;

    //public GameObject Star1;
    //public GameObject Star2;
    //public GameObject Star3;
    //public GameObject Star4;
    //public GameObject Star5;
    //public GameObject Star6;
    //public GameObject Star7;
    private enum MovementState { IDLE, RUNNING, JUMPING, FALLING, }
    private SoundManager soundManager;

    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }
    void Start()
    {
        characterList = FinalText.ToCharArray();
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        circle = GetComponent<CircleCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        SpawnPoint = rb.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("DisplayTextNow", 1.5f);
        if (OnTrigger == true)
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            gameObject.GetComponent<CircleCollider2D>().isTrigger = true;
        }

        dirX = Input.GetAxisRaw("Horizontal");
        if (IsGrounded())
        {
            rb.velocity = new Vector2(dirX * speed, rb.velocity.y); //sets the movements speed to normal speed while on ground
        }
        else
        {
            rb.velocity = new Vector2(dirX * airspeed, rb.velocity.y); //slows the movement speed while in the air

        }

        if (gameObject.GetComponent<BoxCollider2D>().isTrigger == false || gameObject.GetComponent<CircleCollider2D>().isTrigger == false)
        {
            if (Input.GetButtonDown("Jump") && IsGrounded()) //jumps only while on ground to prevent doube jumping
            {

                rb.velocity = new Vector2(rb.velocity.x, jumpforce);
                if (soundManager != null)
                {
                    soundManager.SelectAudio(0, 0.5f);

                }

            }

        }

        animstate();
        Flip();
        //Death();
        //Debug.Log(starcount);
    }

    private void Flip() //flips sprite
    {
        if (dirX > 0f)
        {

            gameObject.transform.localScale = new Vector3(1f, 1f, 1f);

        }
        else if (dirX < 0f)
        {
            gameObject.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
    private bool IsGrounded() //raycast method to check wether sprite is on ground
    {
        RaycastHit2D rayhit = Physics2D.Raycast(box.bounds.center, Vector2.down, box.bounds.extents.y + 0.15f, layer);
        Color color;
        if (rayhit.collider != null)
        {
            color = Color.green;

        }
        else { color = Color.red; }
        Debug.DrawRay(box.bounds.center, Vector2.down * (box.bounds.extents.y + 0.1f), color);
        //Debug.Log(rayhit.collider);
        return rayhit.collider != null;
    }

    private void animstate()
    {

        if (dirX > 0f)
        {
            state = MovementState.RUNNING;

            //sprite.flipX = false;

        }
        else if (dirX < 0f)
        {
            state = MovementState.RUNNING;
            //sprite.flipX = true;

        }
        else
        {
            state = MovementState.IDLE;


        }
        anim.SetInteger("state", (int)state);

    }
    //public void Death()
    //{


    //    if (rb.position.y < -1f)
    //    {
    //        anim.SetTrigger("Death");
    //        soundManager.SelectAudio(4, 0.1f);


    //    }
    //    if (rb.position.y < -5f)
    //    {

    //        rb.position = new Vector3(SpawnPoint.x, SpawnPoint.y + 3f, SpawnPoint.z);
    //        gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
    //        gameObject.GetComponent<CircleCollider2D>().isTrigger = false;
    //        OnTrigger = false;
    //        //Debug.Log(SpawnPoint);
    //    }

    //}
    //public void collect(int val)
    //{
    //    starcount += val;

    //    goal -= 1;
    //    if (goal <= 0)
    //    {
    //        goal = 0;
    //    }
    //    cointText.text = goal.ToString();


    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "SavePosition")
        {
            SpawnPoint = collision.transform.position;
        }

        if (collision.collider.tag == "RedDummy")
        {
            collision.collider.GetComponent<BoxCollider2D>().isTrigger = true;
            collision.collider.GetComponentInChildren<PolygonCollider2D>().isTrigger = true;
            //if (collision.collider.GetComponent<BoxCollider2D>().isTrigger == false)
            //{
            //    if (collision.collider.Equals(collision.collider.GetComponent<BoxCollider2D>()))
            //    {
            //        ActivateTrigger2();
            //    }

            }
        }

    private void DisplayTextNow()
    {
        if (LoopCounter < characterList.Length - 1)
        {
            TempText += characterList[LoopCounter];
            cointText.text = TempText;
            LoopCounter++;
        }
        else
        {
            MainMenuButton.SetActive(true);
        }
    }

    public void MoveToMenu()
    {
        SceneManager.LoadScene("MainMenu");
        //Debug.Log("ButtonPressed");
    }

    ////private void OnTriggerEnter2D(Collider2D collision)
    ////{
    ////    if(collision.CompareTag("PowerUp"))
    ////    {

    ////    }
    ////}

    //public void ActivateTrigger()
    //{
    //    Invoke("SetTrigger", 0.5f);
    //}

    //public void ActivateTrigger2()
    //{
    //    SetTrigger();
    //}

    //public void DeActivateTrigger()
    //{
    //    Invoke("SetTriggerFalse", 0.5f);
    //}

    //public void SetTrigger()
    //{
    //    OnTrigger = true;
    //}

    //public void SetTriggerFalse()
    //{
    //    gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
    //    gameObject.GetComponent<CircleCollider2D>().isTrigger = false;
    //}

    //public void ActivateStars()
    //{
    //    Star1.SetActive(true);
    //    Star2.SetActive(true);
    //    Star3.SetActive(true);
    //    Star4.SetActive(true);
    //    Star5.SetActive(true);
    //    Star6.SetActive(true);
    //    Star7.SetActive(true);
    //    Invoke("DeActivateStars", 20f);
    //}

    //public void DeActivateStars()
    //{
    //    Star1.SetActive(false);
    //    Star2.SetActive(false);
    //    Star3.SetActive(false);
    //    Star4.SetActive(false);
    //    Star5.SetActive(false);
    //    Star6.SetActive(false);
    //    Star7.SetActive(false);
    //}


    //public void ActivateJump()
    //{
    //    jumpforce = 13f;
    //    Feather.SetActive(true);
    //    Invoke("DeActivateJump", 21f);
    //}

    //public void DeActivateJump()
    //{
    //    jumpforce = 10f;
    //    Feather.SetActive(false);
    //}
}
