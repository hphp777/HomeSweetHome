using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameIntro : MonoBehaviour
{

    public Button cbutton;
    // Start is called before the first frame update
    void Start()
    {
        cbutton = GameObject.FindWithTag("button").GetComponent<Button>();
        cbutton.onClick.AddListener(BClicks);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BClicks(){
        SceneManager.LoadScene("MyRoom");
    }
}
