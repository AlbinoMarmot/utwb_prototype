using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Display : MonoBehaviour
{
    public Collect col;
    public int ct, max;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = ct.ToString();
        if(ct == max)
        {
            GetComponent<Text>().text = "You grabbed the resources";
            Invoke("BTM", 2);
        }
    }
    void BTM()
    {
        SceneManager.LoadScene("Level1");
    }
}
