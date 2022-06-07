using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour
{
    public Text childTexts;
    public Button cbutton;
    public GameObject Child;
    public int count = 0;
    public GameObject Door;

    // Start is called before the first frame update
    void Start()
    {
        childTexts = GameObject.FindWithTag("childTexts").GetComponent<Text>();
        cbutton = GameObject.FindWithTag("button").GetComponent<Button>();
        Child = GameObject.FindWithTag("Child");
        Door = GameObject.FindWithTag("Door");
        cbutton.onClick.AddListener(BClicks);
        childTexts.gameObject.SetActive(false);
        cbutton.gameObject.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }

    // Update is called once per frame
    void Update()
    {
        if (Child.gameObject.activeSelf==true)
        {
            childTexts.gameObject.SetActive(true);
            cbutton.gameObject.SetActive(true);
            
        }
    }

    public void BClicks()
    {
        if (Child.gameObject.activeSelf==true)
        {
            
            switch(count)
            {
                case 0:

                    childTexts.text = "안녕?";
                    count += 1;
                    break;
                case 1:
                    childTexts.text = "어어 놀라지마!\n널 도와주고 싶어서 나왔어..";
                    count += 1;
                    break;
                case 2:
                    childTexts.text = "난 이 곳에 갇혀있다 죽었어\n시간이 어떻게 가는지도 모른채로..\n이젠 이름도 기억나지 않아";
                    count += 1;
                    break;
                case 3:
                    childTexts.text = "지금 감옥 안에 있는 열쇠가 필요하지 않아?\n 그 열쇠를 얻으려면 감옥 문을 열어야 할 텐데..";
                    count += 1;
                    break;
                case 4:
                    childTexts.text = "너가 날 도와주면 감옥 문을 열 수 있는 열쇠를 줄게";
                    count += 1;
                    break;
                case 5:
                    childTexts.text = "책장 속 책에서 내 이름을 찾아와줘\n도와줄거지?";
                    count += 1;
                    break;
                case 6:
                    Child.gameObject.SetActive(false);
                    childTexts.gameObject.SetActive(false);
                    Door.transform.rotation = Quaternion.Euler(0, 90, 0);
                    cbutton.gameObject.SetActive(false);
                    SceneManager.LoadScene("dot_eater");
                    break;
            }
        }
    }
}
