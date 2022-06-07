using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ThrowKey : MonoBehaviour
{
    public GameObject key;
    public GameObject myHand;
    bool inHands = false;
    Collider keyCol;
    Rigidbody keyRb;
    public float handPower=5;
    public Camera getCamera;
    private RaycastHit hit;
    bool throws = false;

    // Start is called before the first frame update
    void Start()
    {
        key = GameObject.Find("key");
        keyCol = key.GetComponent<SphereCollider>();
        keyRb = key.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            Ray ray = getCamera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit)){
                string objectName = hit.collider.gameObject.name;
                if(objectName == "key" && inHands == false){
                    {
                        inHands = true;
                        key.transform.SetParent(myHand.transform);
                        key.transform.localPosition = new Vector3(-0.04000002f,-0.3f,0.5299999f);
                        keyCol.isTrigger = true;
                        keyRb.useGravity = false;
                        keyRb.velocity = Vector3.zero;
                    }
                }
            }
        }
        if (Input.GetMouseButtonDown(1)){
            if(inHands == true){
                inHands = false;
                key.transform.SetParent(null);
                keyCol.isTrigger = false;
                keyRb.useGravity = false;
                keyRb.velocity = Vector3.forward * handPower;
            }
            else if(inHands == false){
                inHands = true;
                key.transform.SetParent(myHand.transform);
                key.transform.localPosition = new Vector3(-0.04000002f,-0.3f,0.5299999f);
                keyCol.isTrigger = true;
                keyRb.useGravity = false;
                keyRb.velocity = Vector3.zero;
            }
        }
    }

}
