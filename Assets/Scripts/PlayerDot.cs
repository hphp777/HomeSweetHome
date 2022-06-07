using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerDot : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float rotationSpeed = 360f;
    CharacterController characterController;
    private Text message;
    private Text message0;
    private Text message1;
    private Text message2;
    private Text message3;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        message = GameObject.Find("Text").GetComponent<Text>();
        message0 = GameObject.Find("Text0").GetComponent<Text>();
        message1 = GameObject.Find("Text1").GetComponent<Text>();
        message2 = GameObject.Find("Text2").GetComponent<Text>();
        message3 = GameObject.Find("Text3").GetComponent<Text>();
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (direction.sqrMagnitude > 0.01f) 
        {
                Vector3 forward = Vector3.Slerp(
                transform.forward, 
                direction, 
                rotationSpeed * Time.deltaTime / Vector3.Angle(transform.forward, direction)
                );
            transform.LookAt(transform.position + forward); 
        }
        
        characterController.Move(direction * moveSpeed * Time.deltaTime);

        
        if (GameObject.FindGameObjectsWithTag("Dot").Length == 2){
            message.text = "2010년 8월 2일(이민아 10세)";
            message0.text = "진단명: 골절, 내장파열";
        }
        if (GameObject.FindGameObjectsWithTag("Dot").Length == 1){
            message.text = "";
            message0.text = "";
            message1.text = "위험에 처한 아이들을";
            message2.text = "지켜주세요.";
        }
        if (GameObject.FindGameObjectsWithTag("Dot").Length == 0)
        {
            //Application.LoadLevel(Application.loadedLevel);
            message1.text = "";
            message2.text = "";
            message3.text = "아동학대 신고는 112";
            SceneManager.LoadScene("basementOpened");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Dot"){
            Destroy(other.gameObject);
        }

        if (other.tag == "Enemy")
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
