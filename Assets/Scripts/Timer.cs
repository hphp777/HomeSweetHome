using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Timers;

public class timer : MonoBehaviour
{
    private float time = 300;                            //화면에 보여줄 실수형 변수

    private Text min;
    private Text sec;

    private Text gameover;
    private GameObject panel;
    private GameObject button;

    // Start is called before the first frame update
    void Start()
    {
        min = GameObject.Find("Min").GetComponent<Text>();
        sec = GameObject.Find("Sec").GetComponent<Text>();
        gameover = GameObject.Find("gameOver").GetComponent<Text>();
        panel = GameObject.Find("Panel");
        button = GameObject.Find("Button");

        panel.SetActive(false);
        button.SetActive(false);
        time = 300;
    }

    // Update is called once per frame
    void Update()
    {
        
        time -= Time.deltaTime;

        if(time <= 0)
            time = 0;

        min.text = ((int)time / 60 % 60).ToString(); //min
        sec.text = ((int)time % 60).ToString(); // sec

        if(time == 0){
            gameover.text = "Game Over";
            panel.SetActive(true);
            button.SetActive(true);
        }
    }
}
