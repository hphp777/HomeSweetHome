using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene2 : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.name == "key"){
            // Move to the next stage
            // Debug.Log("collision detected");
            SceneManager.LoadScene("PRoom");
        }
    }
}
