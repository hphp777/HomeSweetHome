using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class changeScene1 : MonoBehaviour
{
    public Button restart;

    void Start () {
		Button btn = GameObject.Find("Button").GetComponent<Button>();;
		btn.onClick.AddListener(Restart);
	}

    private void Restart() {
        Destroy(gameObject);
        SceneManager.LoadScene("MyRoom");
    }
}
