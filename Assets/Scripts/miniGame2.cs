using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Timers;
using UnityEngine.SceneManagement;

public class miniGame2 : MonoBehaviour
{
    private float time;   
    private int t;  
    private Text m;
    private Text c;
    // Start is called before the first frame update
    void Start()
    {
        m = GameObject.Find("mission").GetComponent<Text>();
        m = GameObject.Find("control").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        t = (int)time % 60;
        if (t >= 0 && t <= 5){
            m.text = "Survive During 30 Sec";
            c.text = "Jump: spacebar ";
        }
        else{
            m.text = "";
            c.text = "";
        }
        if(t == 30){
            SceneManager.LoadScene("PRoom2");
        }
    }
}
