using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class questions : MonoBehaviour
{
    private RaycastHit hit;
    public Camera getCamera;
    private Text question1_0;
    private Text question1_1;
    private Text question1_2;
    private Text question1_3;
    private Text question1_4;
    private Text question1_5;
    private Text question1_6;
    private Text question2_0;
    private Text question2_1;
    private Text question2_2;
    private Text question2_3;
    private Text question2_4;
    private Text question2_5;
    private Text question2_6;
    private Text question2_7;
    private Text question2_8;
    private Text question2_9;
    bool isClick1 = false;
    bool isClick2_0 = false;
    bool isClick2_1 = false;
    bool isClick2_2 = false;
    bool isClick2_3 = false;
    bool flag1 = false;
    bool flag2 = false;

    // Start is called before the first frame update
    void Start()
    {
        question1_0 = GameObject.Find("Question1-0").GetComponent<Text>();
        question1_1 = GameObject.Find("Question1-1").GetComponent<Text>();
        question1_2 = GameObject.Find("Question1-2").GetComponent<Text>();
        question1_3 = GameObject.Find("Question1-3").GetComponent<Text>();
        question1_4 = GameObject.Find("Question1-4").GetComponent<Text>();
        question1_5 = GameObject.Find("Question1-5").GetComponent<Text>();
        question1_6 = GameObject.Find("Question1-6").GetComponent<Text>();

        question2_0 = GameObject.Find("Question2-0").GetComponent<Text>();
        question2_1 = GameObject.Find("Question2-1").GetComponent<Text>();
        question2_2 = GameObject.Find("Question2-2").GetComponent<Text>();
        question2_3 = GameObject.Find("Question2-3").GetComponent<Text>();
        question2_4 = GameObject.Find("Question2-4").GetComponent<Text>();
        question2_5 = GameObject.Find("Question2-5").GetComponent<Text>();
        question2_6 = GameObject.Find("Question2-6").GetComponent<Text>();
        question2_7 = GameObject.Find("Question2-7").GetComponent<Text>();
        question2_8 = GameObject.Find("Question2-8").GetComponent<Text>();
        question2_9 = GameObject.Find("Question2-9").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            Ray ray = getCamera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit)){
                string objectName = hit.collider.gameObject.name;
                if(objectName == "Diary"){
                    flag1 = true;
                    if (isClick1 == false)
                        isClick1 = true;
                    else
                        isClick1 = false;
                }
                if(objectName == "Bat1" && flag1 == true){
                    if (isClick2_0 == false)
                        isClick2_0 = true;
                    else
                        isClick2_0 = false;
                }
                if(objectName == "Bat2" && flag1 == true){
                    if (isClick2_1 == false)
                        isClick2_1 = true;
                    else
                        isClick2_1 = false;
                }
                if(objectName == "Bat3" && flag1 == true){
                    if (isClick2_2 == false)
                        isClick2_2 = true;
                    else
                        isClick2_2 = false;
                }
                if(objectName == "Bat4" && flag1 == true){
                    if (isClick2_3 == false)
                        isClick2_3 = true;
                    else
                        isClick2_3 = false;
                }                     
            }
            
        }
        if (isClick1 == true){
            question1_0.text = "5/14일 흐림";
            question1_1.text = "3일 내내 야구방망이로";
            question1_2.text = "맞았다.";
            question1_3.text = "온 몸이 아파.";
            question1_4.text = "도망치고싶어.";
        }
        else if (isClick1 == false){
            question1_0.text = "";
            question1_1.text = "";
            question1_2.text = "";
            question1_3.text = "";
            question1_4.text = "";    
        }
        if(isClick2_0 == true){
            question2_0.text = "중추 신경 붕괴";
            question2_1.text = "공황 장애";
            question2_2.text = "자해";
        }
        else if (isClick2_0 == false){
            question2_0.text = "";
            question2_1.text = "";
            question2_2.text = "";
        }
        if(isClick2_1 == true){
            question2_3.text = "과잉 행동 장애";
            question2_4.text = "우울증";
            question2_5.text = "대인 기피";
        }
        else if (isClick2_1 == false){
            question2_3.text = "";
            question2_4.text = "";
            question2_5.text = "";
        }
        if(isClick2_2 == true){
            question2_6.text = "BOX On The Table";
        }
        else if (isClick2_2 == false){
            question2_6.text = "";
        }
        if(isClick2_3 == true){
            question2_7.text = "불면증";
            question2_8.text = "정신 지체";
            question2_9.text = "자살";
        }
        else if (isClick2_3 == false){
            question2_7.text = "";
            question2_8.text = "";
            question2_9.text = "";
        }
    }
}
