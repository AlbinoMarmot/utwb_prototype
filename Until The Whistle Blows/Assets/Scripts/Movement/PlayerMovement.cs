using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController c;

    // Start is called before the first frame update
    void Start()
    {
        c = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        c.Move(new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical")) * Time.deltaTime);
    }
}
