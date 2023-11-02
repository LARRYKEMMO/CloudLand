using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class movement : MonoBehaviour
{
    // Start is called before the first frame update
    private float totalTime = 0f; // Total time in seconds.

    private float currentTime;

    public GameObject Feather;
    public static movement instance;
    private float dirX = 0f;
    public int goal = 50;
    public TMP_Text cointText;
    public TMP_Text TimeText;
    private float speed = 5f;
    [SerializeField] private int starcount = 0;
    private MovementState state;
    private float jumpforce = 10;
    [SerializeField] private float airspeed = 3f;
    [SerializeField] private LayerMask layer;
    [SerializeField] private LayerMask currency;
    [SerializeField] private Transform groundCheck;
    private BoxCollider2D box;
    private CircleCollider2D circle;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;
    private Vector3 SpawnPoint;
    private bool OnTrigger = false;
    public int Second = 0;
    public GameObject Star1;
    public GameObject Star2;
    public GameObject Star3;
    public GameObject Star4;
    public GameObject Star5;
    public GameObject Star6;
    public GameObject Star7;
    public GameObject Star8;
    public GameObject Star9;
    public GameObject Star10;
    public GameObject Star11;
    public GameObject Star12;
    public GameObject Star13;
    public GameObject Star14;
    public GameObject Star15;
    public GameObject Star16;
    public GameObject Star17;
    public GameObject Star18;
    public GameObject Star19;
    public GameObject Star20;
    public GameObject Star21;
    public GameObject Star22;
    public GameObject Star23;
    public GameObject Star24;
    public GameObject Star25;
    
    private enum MovementState { IDLE, RUNNING, JUMPING, FALLING, }
    private SoundManager soundManager;

    private void Awake()
    {
        instance = this;
        soundManager = FindObjectOfType<SoundManager>();    
    }
    void Start()
    {
        currentTime = totalTime;
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
        if(OnTrigger == true)
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
            rb.velocity = new Vector2(dirX * speed, rb.velocity.y); //slows the movement speed while in the air

        }

        if (gameObject.GetComponent<BoxCollider2D>().isTrigger == false || gameObject.GetComponent<CircleCollider2D>().isTrigger == false)
        {
            if (Input.GetButtonDown("Jump") && IsGrounded2()) //jumps only while on ground to prevent doube jumping
            {

                rb.velocity = new Vector2(rb.velocity.x, jumpforce);
                if(soundManager != null)
                {
                    soundManager.SelectAudio(0, 0.5f);

                }

            }

        }

        currentTime += Time.deltaTime; // Subtract the time passed since the last frame.
        //Debug.Log("CurrentTime: " + currentTime);
        // Update the timer display.
        UpdateTimerDisplay();
        

        animstate();
        Flip();
        Death();
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

    private bool IsGrounded2()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, layer);
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
    public void Death() 
    {
      
        
        if (rb.position.y < -1f)
        {
            anim.SetTrigger("Death");
            soundManager.SelectAudio(4, 0.1f);


        }
        if (rb.position.y < -5f) 
        {
            
            rb.position = new Vector3(SpawnPoint.x, SpawnPoint.y + 3f, SpawnPoint.z);
            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
            gameObject.GetComponent<CircleCollider2D>().isTrigger = false;
            OnTrigger = false;
            //Debug.Log(SpawnPoint);
        }
    
    }
    public void collect(int val) 
    {
        starcount += val;
        
        goal -= 1;
        if(goal<= 0) 
        {
         goal = 0;
        }
        cointText.text =  goal.ToString();


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "SavePosition")
        {
            SpawnPoint = collision.transform.position;
        }

        if (collision.collider.tag == "RedDummy")
        {
            if (collision.collider.GetComponent<BoxCollider2D>().isTrigger == false)
            {
                if(collision.collider.Equals(collision.collider.GetComponent<BoxCollider2D>()))
                {
                    ActivateTrigger2();
                }

            }
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.CompareTag("PowerUp"))
    //    {

    //    }
    //}

    public void ActivateTrigger()
    {
        Invoke("SetTrigger", 0.5f);
    }

    public void ActivateTrigger2()
    {
        SetTrigger();
    }

    public void DeActivateTrigger()
    {
        Invoke("SetTriggerFalse", 0.5f);
    }

    public void SetTrigger()
    {
        OnTrigger = true;
    }

    public void SetTriggerFalse()
    {
        gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        gameObject.GetComponent<CircleCollider2D>().isTrigger = false;
    }

    public void ActivateStars()
    {
        Star1.SetActive(true);
        Star2.SetActive(true);
        Star3.SetActive(true);
        Star4.SetActive(true);
        Star5.SetActive(true);
        Star6.SetActive(true);
        Star7.SetActive(true);
        Star8.SetActive(true);
        Star9.SetActive(true);
        Star10.SetActive(true);
        Star11.SetActive(true);
        Star12.SetActive(true);
        Star13.SetActive(true);
        Star14.SetActive(true);
        Star15.SetActive(true);
        Star16.SetActive(true);
        Star17.SetActive(true);
        Star18.SetActive(true);
        Star19.SetActive(true);
        Star20.SetActive(true);
        Star21.SetActive(true);
        Star22.SetActive(true);
        Star23.SetActive(true);
        Star24.SetActive(true);
        Star25.SetActive(true);
        Invoke("DeActivateStars", 20f);
    }

    public void DeActivateStars()
    {
        Star1.SetActive(false);
        Star2.SetActive(false);
        Star3.SetActive(false);
        Star4.SetActive(false);
        Star5.SetActive(false);
        Star6.SetActive(false);
        Star7.SetActive(false);
        Star8.SetActive(false);
        Star9.SetActive(false);
        Star10.SetActive(false);
        Star11.SetActive(false);
        Star12.SetActive(false);
        Star13.SetActive(false);
        Star14.SetActive(false);
        Star15.SetActive(false);
        Star16.SetActive(false);
        Star17.SetActive(false);
        Star18.SetActive(false);
        Star19.SetActive(false);
        Star20.SetActive(false);
        Star21.SetActive(false);
        Star22.SetActive(false);
        Star23.SetActive(false);
        Star24.SetActive(false);
        Star25.SetActive(false);
    }


    public void ActivateJump()
    {
        jumpforce = 13f;
        Feather.SetActive(true);
        Invoke("DeActivateJump", 21f);
    }

    public void DeActivateJump()
    {
        jumpforce = 10f;
        Feather.SetActive(false);
    }

    void UpdateTimerDisplay()
    {
        //// Convert currentTime to minutes and seconds.
        //int hours = Mathf.FloorToInt(currentTime / 14400);
        //int minutes = Mathf.FloorToInt(currentTime / 120);
        int seconds = (int)currentTime;
        Second = seconds;
        TimeText.text = "Time: " + seconds.ToString() + " Seconds";

        // Update the Text UI with the timer value.
        //Debug.Log("Time: " + seconds + " Seconds");
    }
}
