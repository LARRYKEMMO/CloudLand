using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TruckScript : MonoBehaviour
{
    // Start is called before the first frame update
    private bool move = false;
    void Start()
    {
        Invoke("Space", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        if(move == true)
        {
            gameObject.transform.position += new Vector3(3f, 0f, 0f);
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
        else
        {
            gameObject.transform.position += new Vector3(0f, -300f * Time.deltaTime, 0f);
        }
    }


    private void Space()
    {
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        Invoke("StartMove", 0.5f);
        Invoke("EndMove", 2f);
        
    }

    private void EndMove()
    {
        move = false;
        SceneManager.LoadScene("FinalLevel");
    }

    private void StartMove()
    {
        move = true;
    }
}
