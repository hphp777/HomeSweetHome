using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disapear : MonoBehaviour
{
    public GameObject Child;

    // Start is called before the first frame update
    void Start()
    {
        Child = GameObject.FindWithTag("Child");
        Child.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.name == "Bed"){
            Child.SetActive(true);
        }
    }
}
