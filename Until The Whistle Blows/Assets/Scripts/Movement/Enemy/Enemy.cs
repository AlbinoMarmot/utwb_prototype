using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public Transform Pdest, Sdest;
    NavMeshAgent agent;
   public bool reached;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
       // Sdest = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (reached)
        {
            agent.destination = Sdest.position;
            if(transform.position == Sdest.position)
            {
                Invoke("PatrolOngoing", 2);
            }
        }
        else
        {
            agent.destination = Pdest.position;
        }
        if(transform.position == Pdest.position)
        {
            Invoke("PatrolFinished", 2);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameOver();
        }
    }
    void PatrolFinished()
    {
        reached = true;
    }
    void PatrolOngoing()
    {
        reached = false;
    }
    void GameOver()
    {
        SceneManager.LoadScene("Level1");
    }
}
