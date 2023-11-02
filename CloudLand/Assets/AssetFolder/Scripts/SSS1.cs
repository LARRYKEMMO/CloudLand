using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR;

public class SSS1 : MonoBehaviour
{
    public Transform target;
    private float movementSpeed = 5f;

    private Image SPLetter;
    private Image SPButton;
    public Sprite spriteVoid;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;
    public Sprite sprite5;
    public Sprite sprite6;

    public Button BL1;
    public Button BL2;
    public Button BL3;
    public Button BL4;
    public Button BL5;
    public Button BL6;

    public Button B1;
    public Button B2;
    public Button B3;
    public Button B4;
    public Button B5;
    public Button B6;
    private int correctCounter = 0;
    private int TempIndexLetter = 0;
    private int TempIndexbutton = -1;
    private int PlayCounter = 0;
    public GameObject Spawn1;
    public GameObject Spawn2;
    public GameObject Spawn3;
    public GameObject Spawn4;
    public GameObject Spawn5;
    public GameObject Spawn6;
    private GameObject SpawnObject;
    public GameObject StarPrefab;
    private GameObject Star;
    private List<GameObject> Stars;
    public float moveSpeed = 3f;
    public int numberOfObjects = 10;
    public float radius = 0.5f;
    public GameObject Truck;
    public GameObject Dog;
    private Animator Anim;
    private GameObject Bone;
    public GameObject BonePrefab;
    private Vector3 BoneRestPosition;
    // Start is called before the first frame update
    void Start()
    {
        Stars = new List<GameObject> ();
        Anim = Dog.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("CorrectCounter: " + correctCounter);

        if (SceneManager.GetActiveScene().name == "SS1")
        {
            if (correctCounter == 5)
            {
                Invoke("LoadScene2", 3f);
            }
        }

        else if (SceneManager.GetActiveScene().name == "SS2")
        {
            if (correctCounter == 5)
            {
                Invoke("LoadScene3", 3f);
            }
        }

        else if (SceneManager.GetActiveScene().name == "SS3")
        {
            if (correctCounter == 5)
            {
                Invoke("LoadScene4", 3f);
            }
        }

        else if (SceneManager.GetActiveScene().name == "SS4")
        {
            if (correctCounter == 5)
            {
                Invoke("LoadScene5", 3f);
            }
        }
        else if (SceneManager.GetActiveScene().name == "SS5")
        {
            if (correctCounter == 6)
            {
                PlayerPrefs.SetInt("UNLOCK", 1);
                Invoke("LoadSceneFinal", 3f);
            }
        }

        if(PlayCounter == 2)
        {
            if(TempIndexbutton == TempIndexLetter)
            {
                Debug.Log("Correct");
                PlayCounter = -100;
                correctCounter++;
                DisableButton(TempIndexbutton);
                
            }
            else
            {
                Debug.Log("InCorrect");
                PlayCounter = 0;
            }
        
        
        }

        if (Bone != null)
        {
            Debug.Log("Here");
            Vector2 targetPosition = target.position;

            // Move towards the target position
            Bone.transform.position = Vector2.MoveTowards(Bone.transform.position, targetPosition, movementSpeed * Time.deltaTime);
            if(Bone.transform.position.x >= targetPosition.x && Bone.transform.position.y >= targetPosition.y)
            {
                Destroy(Bone, 1f);
                Anim.SetBool("Eat", true);
                Invoke("ResetAnimation", 1f);

            }
        }
    }

    public void ClickLetter1()
    {
        if(PlayCounter < 1)
        {
            TempIndexLetter = 1;
            PlayCounter++;
        }
    }

    public void ClickLetter2()
    {
        if(PlayCounter < 1)
        {
            TempIndexLetter = 2;
            PlayCounter++;
        }
    }

    public void ClickLetter3()
    {
        if(PlayCounter < 1)
        {
            TempIndexLetter = 3;
            PlayCounter++;
        }
    }

    public void ClickLetter4()
    {
        if(PlayCounter < 1)
        {
            TempIndexLetter = 4;
            PlayCounter++;
        }
    }

    public void ClickLetter5()
    {
        if(PlayCounter < 1)
        {
            TempIndexLetter = 5;
            PlayCounter++;
        }
    }

    public void ClickLetter6()
    {
        if (PlayCounter < 1)
        {
            TempIndexLetter = 6;
            PlayCounter++;
        }
    }

    //////////////////////////////

    public void Click1()
    {
        if(PlayCounter > 0)
        {
            TempIndexbutton = 1;
            PlayCounter++;
        }
    }

    public void Click2()
    {
        if(PlayCounter > 0)
        {
            TempIndexbutton = 2;
            PlayCounter++;
        }
    }

    public void Click3()
    {
        if(PlayCounter > 0)
        {
            TempIndexbutton = 3;
            PlayCounter++;
        }

    }

    public void Click4()
    {
        if(PlayCounter > 0)
        {
            TempIndexbutton = 4;
            PlayCounter++;
        }
    }

    public void Click5()
    {
        if(PlayCounter > 0)
        {
            TempIndexbutton = 5;
            PlayCounter++;
        }
    }

    public void Click6()
    {
        if (PlayCounter > 0)
        {
            TempIndexbutton = 6;
            PlayCounter++;
        }
    }

    public void ClickTotalFail()
    {
        TempIndexbutton = -100;
        PlayCounter++;
    }

    private void DisableButton(int Index)
    {
        if(Index == 1)
        {
            SPLetter = BL1.GetComponent<Image>();
            SPLetter.sprite = spriteVoid;
            SPButton = B1.GetComponent<Image>();
            SPButton.sprite = sprite1;
            B1.enabled = false;
            BL1.enabled = false;
            SpawnObject = Spawn1;
            Bone = Instantiate(BonePrefab, SpawnObject.transform.position, Quaternion.identity);
            
        }
        else if (Index == 2)
        {
            SPLetter = BL2.GetComponent<Image>();
            SPLetter.sprite = spriteVoid;
            SPButton = B2.GetComponent<Image>();
            SPButton.sprite = sprite2;
            B2.enabled = false;
            BL2.enabled = false;
            SpawnObject = Spawn2;
            Bone = Instantiate(BonePrefab, SpawnObject.transform.position, Quaternion.identity);
            
        }
        else if (Index == 3)
        {
            SPLetter = BL3.GetComponent<Image>();
            SPLetter.sprite = spriteVoid;
            SPButton = B3.GetComponent<Image>();
            SPButton.sprite = sprite3;
            B3.enabled = false;
            BL3.enabled = false;
            SpawnObject = Spawn3;
            Bone = Instantiate(BonePrefab, SpawnObject.transform.position, Quaternion.identity);
            
        }
        else if (Index == 4)
        {
            SPLetter = BL4.GetComponent<Image>();
            SPLetter.sprite = spriteVoid;
            SPButton = B4.GetComponent<Image>();
            SPButton.sprite = sprite4;
            B4.enabled = false;
            BL4.enabled = false;
            SpawnObject = Spawn4;
            Bone = Instantiate(BonePrefab, SpawnObject.transform.position, Quaternion.identity);
            
        }
        else if (Index == 5)
        {
            SPLetter = BL5.GetComponent<Image>();
            SPLetter.sprite = spriteVoid;
            SPButton = B5.GetComponent<Image>();
            SPButton.sprite = sprite5;
            B5.enabled = false;
            BL5.enabled = false;
            SpawnObject = Spawn5;
            Bone = Instantiate(BonePrefab, SpawnObject.transform.position, Quaternion.identity);
            
        }

        else if (Index == 6)
        {
            SPLetter = BL6.GetComponent<Image>();
            SPLetter.sprite = spriteVoid;
            SPButton = B6.GetComponent<Image>();
            SPButton.sprite = sprite6;
            B6.enabled = false;
            BL6.enabled = false;
            SpawnObject = Spawn6;
            Bone = Instantiate(BonePrefab, SpawnObject.transform.position, Quaternion.identity);

        }

        float angleIncrement = 360f / numberOfObjects;

        for (int i = 0; i < numberOfObjects; i++)
        {
            
            float angle = i * angleIncrement;
            Vector2 spawnPosition = GetCirclePosition(angle, SpawnObject);
            Star = Instantiate(StarPrefab, spawnPosition, Quaternion.identity);
            Stars.Add(Star);
            SetMovementDirection(Star, angle);
            gameObject.GetComponent<AudioSource>().Play();
            Destroy(Stars[i], 2f);
            if(i == numberOfObjects - 1)
            {
                Invoke("DeleteObject", 2f);
            }
        }
    }

    private Vector2 GetCirclePosition(float angle, GameObject Button)
    {
        float radian = angle * Mathf.Deg2Rad;
        float x = Button.transform.position.x + radius * Mathf.Cos(radian);
        float y = Button.transform.position.y + radius * Mathf.Sin(radian);
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

    

    private void DeleteObject()
    {
        //Debug.Log(Counter);
        Stars.Clear();
      
    }

    private void ResetAnimation()
    {
        //Debug.Log(Counter);
        Anim.SetBool("Eat", false);
        PlayCounter = 0;

    }

    private void LoadSceneFinal()
    {
        Dog.SetActive(false);
        Truck.SetActive(true);
        //SceneManager.LoadScene("FinalLevel");
    }

    private void LoadScene2()
    {
        SceneManager.LoadScene("2LoadingScene");
    }

    private void LoadScene3()
    {
        SceneManager.LoadScene("3LoadingScene");
    }

    private void LoadScene4()
    {
        SceneManager.LoadScene("4LoadingScene");
    }

    private void LoadScene5()
    {
        SceneManager.LoadScene("5LoadingScene");
    }
}
