using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class Respawn : MonoBehaviour {
    public bool respawn=false;
	// Use this for initialization
	void Start () {
		
	}


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tree") || collision.gameObject.CompareTag("NPC"))
        {
            respawn = true;
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tree") || collision.gameObject.CompareTag("NPC"))
        {
            respawn = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tree") || collision.gameObject.CompareTag("NPC"))
        {
            respawn = false ;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
