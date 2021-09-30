using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resources : MonoBehaviour
{
    Text textob;
    public int amount = 0;
    // Start is called before the first frame update
    void Start()
    {
        textob = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        textob.text = amount.ToString();
    }

    public void UpdateResource()
    {

    }
}
