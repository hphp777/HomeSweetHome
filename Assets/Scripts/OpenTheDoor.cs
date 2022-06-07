using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenTheDoor : MonoBehaviour
{
    public GameObject RedBook;
    public GameObject Door;
    public bool ending;

    // Start is called before the first frame update
    void Start()
    {
        RedBook = GameObject.FindWithTag("RedBook");
        Door = GameObject.FindWithTag("Door");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Hammer가 RedBook에 충돌하면 철창 열림
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "RedBook"){
            Door.transform.rotation = Quaternion.Euler(0, 90, 0);
            ending = true;
        }
    }
}
