using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gunLoad : MonoBehaviour
{

    public gun newGun;
    public GameObject gun;


    public bool clearMinigame1 = false;
    public bool clearMinigame2 = false;

    public bool gunActive = true;

    public Camera getCamera;
    private RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        newGun.BulletMax = 30;
        newGun.BulletNow = 30;
        newGun.BetweenShots = 100f;
        newGun.ReloadTime = 2f;
        newGun.muzzleVelocity = 35f;
        newGun.ReloadValue = false;
        gun = GameObject.Find("flaregun");
        getCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(1) && gunActive == true)
            Shoot();
        if (Input.GetMouseButtonDown(2) && gunActive == true)
            Reload();
        

        if (newGun.ReloadValue == true && Time.time >= newGun.nextReloadTime) {
            newGun.ReloadValue = false;
            newGun.BulletNow = newGun.BulletMax;

            Debug.Log ("RELOAD GUN!");
        }


    }

    public void  Shoot() {
        newGun.Shoot ();
    }

    public void Reload() {
        newGun.Reload ();
    }
}
