using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Timers;
using UnityEngine.SceneManagement;

public class timer2 : MonoBehaviour
{
    public float time = 600;                            //화면에 보여줄 실수형 변수

    private Text min;
    private Text sec;

    private Text gameover;
    private GameObject panel;
    private GameObject button;

    public Button restart;


    private void Awake() {
        var obj = FindObjectsOfType<timer2>();

        if (obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    
    // Start is called before the first frame update
    void Start()
    {
        min = GameObject.Find("Min").GetComponent<Text>();
        sec = GameObject.Find("Sec").GetComponent<Text>();
        time = 600;
        gameover = GameObject.Find("gameOver").GetComponent<Text>();
        panel = GameObject.Find("Panel");
        button = GameObject.Find("Button");
        Button btn = GameObject.Find("Button").GetComponent<Button>();
		btn.onClick.AddListener(Restart);

        panel.SetActive(false);
        button.SetActive(false);

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

    private void Restart() {
        Destroy(gameObject);
        SceneManager.LoadScene("MyRoom");
    }
}
