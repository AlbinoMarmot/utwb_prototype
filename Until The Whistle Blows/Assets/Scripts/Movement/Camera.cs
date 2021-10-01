using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public float cameraDrift = 0.2f;
    Transform playerBody;
    float xRotation = 0f;
    public float V, H, speed, x, y;
    public bool inspecting;

    void Start()
    {
        //  y = Mathf.Clamp(transform.rotation.y, 22, 106);
        playerBody = GameObject.Find("Player").transform;
    }
    void Update()
    {
        /*
        H = transform.eulerAngles.z;
        H = 0;
        if (!inspecting)
        {
         V = speed * Time.deltaTime;
         if (Input.GetKey(KeyCode.D)&& transform.eulerAngles.y <=106)
         {
            transform.Rotate(0f, V, 0f);
         }
         if (Input.GetKey(KeyCode.A) && transform.eulerAngles.y >=22 )
         {
            transform.Rotate(0f, -V, 0f);
         }
            if (Input.GetKey(KeyCode.S) && transform.eulerAngles.x <= 32)
            {
                transform.Rotate(V, 0f, 0f);
            }
            if (Input.GetKey(KeyCode.W) && transform.eulerAngles.x >= -19)
            {
                transform.Rotate(-V, 0f, 0f);
            }
        }
        */

        transform.position = new Vector3(Mathf.Lerp(transform.position.x, playerBody.position.x, cameraDrift), 13.0f, Mathf.Lerp(transform.position.z, playerBody.position.z - 5.0f, cameraDrift));

       

    }
}
