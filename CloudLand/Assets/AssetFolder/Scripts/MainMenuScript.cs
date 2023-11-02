using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using Unity.VisualScripting;

public class MainMenuScript : MonoBehaviour
{
    public GameObject Bound;
    public GameObject GoButton;
    public GameObject GoPrefab;
    private GameObject GoObject;
    private bool StartMoving = false;
    private float fadeTime = 1;
    private float fadeTimer = 0;
    public Image FadeImage;
    private Color FadeColor;
    private int UnlockIndex;
    public GameObject StatButton;
    // Start is called before the first frame update
    void Start()
    {
        FadeColor = Color.black;
        UnlockIndex = PlayerPrefs.GetInt("UNLOCK");
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            if (UnlockIndex == 1)
            {
                StatButton.SetActive(true);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(StartMoving == true)
        {
            GoObject.transform.position += new Vector3(5f * Time.deltaTime, 0f, 0f);
        }
        if (GoObject != null)
        {
            if (GoObject.transform.position.x >= Bound.transform.position.x)
            {
                StartMoving = false;
                if (fadeTimer < fadeTime)
                {
                    fadeTimer += Time.deltaTime;
                    float progress = Mathf.Min(fadeTimer / fadeTime, 1f);
                    FadeColor.a = progress;
                    FadeImage.color = FadeColor;

                }
                else
                {
                    SceneManager.LoadScene("LoadingScene");

                }
            }
        }

    }

    public void ClickGo()
    {
        GoButton.SetActive(false);
        GoObject = Instantiate(GoPrefab, gameObject.transform.position, Quaternion.identity);
        StartMoving = true;
        FadeImage.gameObject.SetActive(true);
    }

    public void MoveToMenu()
    {
        SceneManager.LoadScene("MainMenu");
        //Debug.Log("ButtonPressed");
    }

    public void MoveToStats()
    {
        SceneManager.LoadScene("StatsScene");
        //Debug.Log("ButtonPressed");
    }
}
