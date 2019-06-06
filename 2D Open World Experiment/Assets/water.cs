using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("NPC"))
        {
            other.gameObject.GetComponent<NorpAI>().Drink();
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
