using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene3 : MonoBehaviour
{
    int hp = 5;

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.name == "flareround(Clone)"){
            hp -= 1;
            Debug.Log("collision detected");
        }
    }
    private void Update() {
        if(hp == 0)
            SceneManager.LoadScene("basement");
    }
}
