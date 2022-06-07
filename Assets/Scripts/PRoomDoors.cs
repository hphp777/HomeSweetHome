using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PRoomDoors : MonoBehaviour
{
    public GameObject door0;

    public bool clearMinigame1 = true;
    public bool clearMinigame2 = true;
    public Camera getCamera;
    private RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        door0 = GameObject.Find("Door0");

    }

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
            }
        }
    }
}
