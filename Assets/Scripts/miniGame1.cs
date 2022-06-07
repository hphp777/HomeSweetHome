using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class miniGame1 : MonoBehaviour
{

    private RaycastHit hit;
    public Camera getCamera;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            Ray ray = getCamera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit)){
                string objectName = hit.collider.gameObject.name;
                if(objectName == "Door0"){
                    SceneManager.LoadScene("Jump");
                }
                if(objectName == "Door1"){
                    SceneManager.LoadScene("01_Goal");
                }
                }
        }
    }
}
