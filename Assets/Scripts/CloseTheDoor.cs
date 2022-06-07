using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class CloseTheDoor : MonoBehaviour
{
    public GameObject Door;
    public GameObject RoomKey;
    public GameObject myLeftHand;
    public bool inHandsa = false;
    Rigidbody RoomKeyRb;
    public Camera getCameraa;
    private RaycastHit hita;
    bool throwsa = false;
    int kk = 0;
    timer2 time;
    Text min;

    // Start is called before the first frame update
    void Start()
    {
        Door = GameObject.FindWithTag("Door");
        RoomKey = GameObject.FindWithTag("RoomKey");
        RoomKeyRb = RoomKey.GetComponent<Rigidbody>();
        min = GameObject.Find("Min").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            Ray raya = getCameraa.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(raya, out hita)){
                string objectNamea = hita.collider.gameObject.name;
                if(objectNamea == "RoomKey" && inHandsa == false){
                    {
                        inHandsa = true;
                        RoomKey.transform.SetParent(myLeftHand.transform);
                        RoomKey.transform.localPosition = new Vector3(0.0f,0.0f,0.0f);
                        RoomKeyRb.useGravity = false;
                        RoomKeyRb.velocity = Vector3.zero;
                        if (kk == 0){
                            Door.transform.rotation = Quaternion.Euler(0, 0, 0);
                            kk += 1;
                        }
                    }
                }
            }
        }
    }
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "End" && inHandsa == true){
            if (Int32.Parse(min.text) >= 5)
                SceneManager.LoadScene("endingHappy");
            else
                SceneManager.LoadScene("endingDark");
        }
    }
}

