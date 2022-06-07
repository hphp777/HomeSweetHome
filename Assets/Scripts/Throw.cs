using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    public GameObject Hammer;
    public GameObject myHand;
    bool inHands = false;
    Collider HammerCol;
    Rigidbody HammerRb;
    public float handPower=50;
    public Camera getCamera;
    private RaycastHit hit;
    bool throws = false;

    bool ending = false;

    // Start is called before the first frame update
    void Start()
    {
        Hammer = GameObject.FindWithTag("Hammer");
        HammerCol = Hammer.GetComponent<BoxCollider>();
        HammerRb = Hammer.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            Ray ray = getCamera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit)){
                string objectName = hit.collider.gameObject.name;
                if(objectName == "Hammer" && inHands == false){
                    {
                        inHands = true;
                        Hammer.transform.SetParent(myHand.transform);
                        Hammer.transform.localPosition = new Vector3(0.0f,0.0f,0.0f);
                        HammerCol.isTrigger = true;
                        HammerRb.useGravity = false;
                        HammerRb.velocity = Vector3.zero;
                    }
                }
            }
        }
        if (Input.GetMouseButtonDown(1)){
            if(inHands == true){
                inHands = false;
                Hammer.transform.SetParent(null);
                HammerCol.isTrigger = false;
                HammerRb.useGravity = true;
                //HammerRb.velocity = getCamera.transform.rotation*Vector3.forward * handPower;
                HammerRb.velocity = getCamera.transform.rotation * Vector3.forward * handPower;
                //Vector3 throwAngle = hit.point - myHand.transform.position;
                //HammerRb.AddForce(throwAngle * handPower, ForceMode.Impulse);
            }
            else if(inHands == false){
                inHands = true;
                Hammer.transform.SetParent(myHand.transform);
                Hammer.transform.localPosition = new Vector3(0.0f,0.0f,0.0f);
                HammerCol.isTrigger = true;
                HammerRb.useGravity = false;
                HammerRb.velocity = Vector3.zero;
            }
        }
    }
}
