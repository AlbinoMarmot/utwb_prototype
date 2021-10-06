using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    public GameObject Orders, menu1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OrderUp()
    {
        menu1.SetActive(false);
        Orders.SetActive(true);
    }
    public void OrderOff()
    {
        menu1.SetActive(true);
        Orders.SetActive(false);
    }
}
