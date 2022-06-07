using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ButtonClickAfter : MonoBehaviour
{
    public Text childTexts;
    public Button cbutton;
    public int count = 0;
    public GameObject Door;

    // Start is called before the first frame update
    void Start()
    {
        childTexts = GameObject.FindWithTag("childTexts").GetComponent<Text>();
        cbutton = GameObject.FindWithTag("button").GetComponent<Button>();
        Door = GameObject.FindWithTag("Door");
        cbutton.onClick.AddListener(BClicks);
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BClicks()
    {
        switch(count)
        {   
            case 0:
                count += 1;
                break;
            case 1:
                childTexts.text = "";
                count += 1;
                childTexts.gameObject.SetActive(false);
                Door.transform.rotation = Quaternion.Euler(0, 90, 0);
                cbutton.gameObject.SetActive(false);
                break;
        }
    }
}
