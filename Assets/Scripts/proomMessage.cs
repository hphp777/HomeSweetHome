using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Timers;

public class proomMessage : MonoBehaviour
{
    private float time;   
    private int t;  
    private Text m0;
    private Text m1;
    private Text m2;
    private Text m3;
    private Text m4;
    private Text m5;
    private Text m6;

    // Start is called before the first frame update
    void Start()
    {
        m0 = GameObject.Find("Message0").GetComponent<Text>();
        m1 = GameObject.Find("Message1").GetComponent<Text>();
        m2 = GameObject.Find("Message2").GetComponent<Text>();
        m3 = GameObject.Find("Message3").GetComponent<Text>();
        m4 = GameObject.Find("Message4").GetComponent<Text>();
        m5 = GameObject.Find("Message5").GetComponent<Text>();
        m6 = GameObject.Find("Message6").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        t = (int)time % 600;
        if (t >= 0 && t <= 5){
            m0.text = "Mission";
            m1.text = "집을 탈출하기 위한";
            m2.text = "열쇠는";
            m3.text = "지하실에 있다.";
            m4.text = "지하실 문을 부시기 위한 ";
            m5.text = "총은 다른 문을 통해";
            m6.text = "얻을 수 있다.";
        }
        else{
            m0.text = "";
            m1.text = "";
            m2.text = "";
            m3.text = "";
            m4.text = "";
            m5.text = "";
            m6.text = "";
        }
    }
}
