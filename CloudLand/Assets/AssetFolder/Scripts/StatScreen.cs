using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public Text Stat1;
    public Text Stat2;
    public Text Stat3;
    public Text Stat4;
    public Text Stat5;
    private int txt;
    void Start()
    {
        InitStats();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitStats()
    {
        txt = PlayerPrefs.GetInt("PlayerScore1");
        Stat1.text = txt.ToString() + " Seconds";

        txt = PlayerPrefs.GetInt("PlayerScore2");
        Stat2.text = txt.ToString() + " Seconds";

        txt = PlayerPrefs.GetInt("PlayerScore3");
        Stat3.text = txt.ToString() + " Seconds";

        txt = PlayerPrefs.GetInt("PlayerScore4");
        Stat4.text = txt.ToString() + " Seconds";

        txt = PlayerPrefs.GetInt("PlayerScore5");
        Stat5.text = txt.ToString() + " Seconds";
    }
}
