using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    //public Text timerText; // Reference to the Text UI element.
    

    public GameObject Player;
    private Material PlayerMaterial;
    private Color PlayerColor;
    private float PlayerFadeTime;
    private movement PlayerScript;
    private int score;
    private int TempScore;
    public GameObject Dog;
    private bool Down = false;
    private bool Up = false;
    public movement gavinmovement;
    private Vector3 DogOriginal;
    // Start is called before the first frame update
    void Start()
    {
        PlayerMaterial = Player.GetComponent<SpriteRenderer>().material;
        PlayerColor = PlayerMaterial.color;
        PlayerFadeTime = PlayerColor.a;
        PlayerScript = FindAnyObjectByType<movement>();
        //UpdateTimerDisplay();
        DogOriginal = Dog.transform.position;
        //PlayerPrefs.SetInt("PlayerScore1", 0);
        //PlayerPrefs.SetInt("PlayerScore2", 0);
        //PlayerPrefs.SetInt("PlayerScore3", 0);
        //PlayerPrefs.SetInt("PlayerScore4", 0);
        //PlayerPrefs.SetInt("PlayerScore5", 0);
        //Debug.Log("CurrentTime: " + currentTime);
    }

    // Update is called once per frame
    void Update()
    {        
        Doggy();
        
        //else
        //{
        //    // Timer has reached zero, you can implement what should happen here.
        //    // For example, you can disable the timer, show a message, or trigger an event.
        //    currentTime = 0;
        //}

    }

    private void Doggy()
    {
        if (Down == false)
        {
            if (Player.transform.position.x >= gameObject.transform.position.x - 1 && Player.transform.position.x <= gameObject.transform.position.x + 2f)
            {
                if (gavinmovement.goal > 0)
                {
                    Down = true;
                    //Doggy();

                }
                else
                {
                    if(PlayerFadeTime > 0)
                    {
                        PlayerFadeTime -= 0.01f;
                        PlayerColor.a = PlayerFadeTime;
                        PlayerMaterial.color = PlayerColor;
                    }
                    else
                    {
                        if(SceneManager.GetActiveScene().name == "level1")
                        {
                            TempScore = PlayerPrefs.GetInt("PlayerScore1");
                            score = PlayerScript.Second;
                            if(score > TempScore)
                            {
                                PlayerPrefs.SetInt("PlayerScore1", score);

                            }
                            else
                            {
                                PlayerPrefs.SetInt("PlayerScore1", TempScore);
                            }
                            SceneManager.LoadScene("SS1");
                        }
                        else if(SceneManager.GetActiveScene().name == "level2")
                        {
                            TempScore = PlayerPrefs.GetInt("PlayerScore2");
                            score = PlayerScript.Second;
                            if (score > TempScore)
                            {
                                PlayerPrefs.SetInt("PlayerScore2", score);

                            }
                            else
                            {
                                PlayerPrefs.SetInt("PlayerScore2", TempScore);
                            }
                            SceneManager.LoadScene("SS2");
                        }
                        else if (SceneManager.GetActiveScene().name == "level3")
                        {
                            TempScore = PlayerPrefs.GetInt("PlayerScore3");
                            score = PlayerScript.Second;
                            if (score > TempScore)
                            {
                                PlayerPrefs.SetInt("PlayerScore3", score);

                            }
                            else
                            {
                                PlayerPrefs.SetInt("PlayerScore3", TempScore);
                            }
                            SceneManager.LoadScene("SS3");
                        }
                        else if (SceneManager.GetActiveScene().name == "level4")
                        {
                            TempScore = PlayerPrefs.GetInt("PlayerScore4");
                            score = PlayerScript.Second;
                            if (score > TempScore)
                            {
                                PlayerPrefs.SetInt("PlayerScore4", score);

                            }
                            else
                            {
                                PlayerPrefs.SetInt("PlayerScore4", TempScore);
                            }
                            SceneManager.LoadScene("SS4");
                        }
                        else if (SceneManager.GetActiveScene().name == "level5")
                        {
                            TempScore = PlayerPrefs.GetInt("PlayerScore5");
                            score = PlayerScript.Second;
                            if (score > TempScore)
                            {
                                PlayerPrefs.SetInt("PlayerScore5", score);

                            }
                            else
                            {
                                PlayerPrefs.SetInt("PlayerScore5", TempScore);
                            }
                            SceneManager.LoadScene("SS5");
                        }

                    }
                }
            }
        }

        if (Down == true)
        {
            if (Dog.transform.position.y > gameObject.transform.position.y + 2 && Up == false)
            {
                Dog.transform.position += new Vector3(0, -5 * Time.deltaTime, 0);
            }

            if (Dog.transform.position.y <= gameObject.transform.position.y + 2)
            {
                Up = true;

            }

            if (Up == true)
            {
                Dog.transform.position += new Vector3(0, 2 * Time.deltaTime, 0);
                if (Dog.transform.position.y >= DogOriginal.y)
                {
                    Up = false;
                    Down = false;
                }
            }
        }
    }

    
}
