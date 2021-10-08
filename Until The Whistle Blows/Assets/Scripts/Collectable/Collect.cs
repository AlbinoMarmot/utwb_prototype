using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collect : MonoBehaviour
{
   // public Text score;
   //public int sc;
    public Display Dis;
    bool collected;
    // Start is called before the first frame update
    void Start()
    {
        //score.text = GetComponent<Text>().text;
    }

    // Update is called once per frame
    void Update()
    {
      // score.GetComponent<Text>().text = sc.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player" && !collected)
        {
            Dis.ct++;
            collected = true;
            GetComponent<Renderer>().enabled = false;
        }
    }
}
