using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PRoomDoors2 : MonoBehaviour
{
    public GameObject door1;

    public Camera getCamera;
    private RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        door1 = GameObject.Find("Door1");

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0)){
            Ray ray = getCamera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit)){
                string objectName = hit.collider.gameObject.name;
                if(objectName == "Door1"){
                    SceneManager.LoadScene("01_Goal");
                }
            }
        }
    }
}
