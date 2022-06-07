using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour
{
    bool keyActive = false;
    private RaycastHit hit;
    GameObject key;
    public Camera getCamera;
    // Start is called before the first frame update
    void Start()
    {
        key = GameObject.Find("key");
    }

    // Update is called once per frame
    void Update()
    {
        if (keyActive == false)
            key.SetActive(false);
        else if (keyActive == true)
            key.SetActive(true);
        
        if (Input.GetMouseButtonDown(0)){
            Ray ray = getCamera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit)){
                string objectName = hit.collider.gameObject.name;
                if(objectName == "Box"){
                    keyActive = true;
                }
            }
        }
    }
}
