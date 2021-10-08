using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class testchange : MonoBehaviour
{
    public Resources food, supplies, ammo;
    public int Sfood, Ssupplies, Sammo;
    public Text f1, s1, a1, f2, s2, a2;

    // Start is called before the first frame update
    void Start()
    {
        food =food.GetComponent<Resources>();
        supplies = supplies.GetComponent<Resources>();
        ammo = ammo.GetComponent<Resources>();
    }

    // Update is called once per frame
    void Update()
    {
        f2.GetComponent<Text>().text = Sfood.ToString();
        s2.GetComponent<Text>().text = Ssupplies.ToString();
        a2.GetComponent<Text>().text = Sammo.ToString();
    }
    public void AddStash()
    {
        food.amount = Sfood + food.amount;
        supplies.amount = Ssupplies + supplies.amount;
        ammo.amount = Sammo + ammo.amount;

        Invoke("Clean", .1f);
        
    }
    public void Clean()
    {
        Sfood = 0;
        Ssupplies = 0;
        Sammo = 0;
    }
    public void Value()
    {

        f1.GetComponent<Text>().text = food.amount.ToString();
        s1.GetComponent<Text>().text = supplies.amount.ToString();
        a1.GetComponent<Text>().text = ammo.amount.ToString();

      
    }
    public void Nextlvl()
    {
        SceneManager.LoadScene("MovementTest");
    }
}
