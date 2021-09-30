using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inspecting : MonoBehaviour
{
    public Transform cam1;
    public Transform cam2;
    public Transform cam3;
    public Transform paper;
    public Transform whistle;
    public Transform window;
    public GameObject maincam;
    public GameObject gun2;
    public GameObject badge2;
    public GameObject bullet2;
    public GameObject Sounds;
    public GameObject Credits;
    public Transform badge3;
    //  public Camera maincam;
    float cam1flt = 50.8f;
    // float cam2flt = 12f;
    Vector3 trans;
    Vector3 rotat;
    public bool cam2move;
    bool cam3move;
    float timetomove;
    bool resetcam;
    bool Starttg;
    // Start is called before the first frame update
    void Start()
    {

        maincam.transform.position = cam1.position;
       // maincam.transform.LookAt();
        UnityEngine.Camera.main.fieldOfView = cam1flt;


    }

    // Update is called once per frame
    void Update()
    {
        timetomove = .1f * Time.deltaTime;
        if (cam2move)
        {
            // maincam.transform.position = trans; 
            maincam.transform.position = Vector3.MoveTowards(maincam.transform.position, cam2.transform.position, timetomove);

            maincam.transform.LookAt(paper);
        }
        if (cam3move)
        {
            // maincam.transform.position = trans; 
            maincam.transform.position = Vector3.MoveTowards(maincam.transform.position, cam3.transform.position, timetomove);

            maincam.transform.LookAt(whistle);
        }
        if (maincam.transform.position == cam2.position)
        {
            cam2move = false;
            // UnityEngine.Camera.main.fieldOfView = cam2flt;
            Sounds.SetActive(true);
        }
        else
        {
            Sounds.SetActive(false);
        }
        if (maincam.transform.position == cam3.position)
        {
            cam3move = false;
            // UnityEngine.Camera.main.fieldOfView = cam2flt;
            Credits.SetActive(true);
        }
        else
        {
            Credits.SetActive(false);
        }
        if (maincam.transform.position != cam1.position)
        {
            gun2.GetComponent<Collider>().enabled = false;
            badge2.GetComponent<Collider>().enabled = false;
            bullet2.GetComponent<Collider>().enabled = false;
            if (Input.GetKeyDown(KeyCode.Mouse1) && !cam2move && !cam3move)
            {
                resetcam = true;
                // cam2move = false;
                // cam3move = false;
            }
        }
        if (maincam.transform.position == cam1.position && !Starttg)
        {

            gun2.GetComponent<Collider>().enabled = true;
            badge2.GetComponent<Collider>().enabled = true;
            bullet2.GetComponent<Collider>().enabled = true;
            resetcam = false;
        }
        if (resetcam)
        {
            maincam.transform.position = Vector3.MoveTowards(maincam.transform.position, cam1.transform.position, timetomove);
            maincam.transform.LookAt(paper);
            UnityEngine.Camera.main.fieldOfView = cam1flt;
        }
        if (Starttg)
        {
            //UnityEngine.Camera.main.fieldOfView = cam2flt;
            maincam.transform.position = Vector3.MoveTowards(maincam.transform.position, badge3.transform.position, .07f * Time.deltaTime);
            maincam.transform.LookAt(badge3);
            Invoke("Startgame", 4f);
        }
    }
    public void Camera1()
    {
        //maincam.transform.position = cam1.position;
        //  maincam.transform.rotation = cam1.rotation;
        // UnityEngine.Camera.main.fieldOfView = cam1flt;

    }
    public void Camera2()
    {
        // maincam.transform.position = cam2.position;

        // trans = new Vector3(0.035f, 1.515f, -5.984f);
        // maincam.transform.position = trans;

        cam2move = true;
        //UnityEngine.Camera.main.fieldOfView = cam2flt;
    }
    public void Camera3()
    {
        cam3move = true;
    }

    //public void Gamestart()
    //{
    //    Starttg = true;

    //}
    //void Startgame()
    //{
    //    SceneManager.LoadScene("Tutorial");
    //}
}
