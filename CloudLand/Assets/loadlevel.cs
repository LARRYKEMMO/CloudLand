using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadlevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "LoadingScene")
        {
            Invoke("load1", 0.5f);
        }
        else if(SceneManager.GetActiveScene().name == "2LoadingScene")
        {
            Invoke("load2", 0.5f);
        }
        else if (SceneManager.GetActiveScene().name == "3LoadingScene")
        {
            Invoke("load3", 0.5f);
        }
        else if (SceneManager.GetActiveScene().name == "4LoadingScene")
        {
            Invoke("load4", 0.5f);
        }
        else if (SceneManager.GetActiveScene().name == "5LoadingScene")
        {
            Invoke("load5", 0.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void load1() 
    {
        SceneManager.LoadScene("level1");

    }

    private void load2()
    {
        SceneManager.LoadScene("level2");

    }

    private void load3()
    {
        SceneManager.LoadScene("level3");

    }

    private void load4()
    {
        SceneManager.LoadScene("level4");

    }

    private void load5()
    {
        SceneManager.LoadScene("level5");

    }
}
