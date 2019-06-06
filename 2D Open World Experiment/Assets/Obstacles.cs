using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour {
    public GameObject[] obstacles;
    public float range;

    // Use this for initialization
    void Start () {
        if (range == 0)
        {
            range = 15;
        }
       
    }

    public void Arrange()
    {
        foreach (GameObject g in obstacles)
        {
            g.transform.localPosition = new Vector3(Random.Range(-range, range), Random.Range(-range + 5, range - 5));
            if (g.GetComponent<Respawn>().respawn)
            {
                //print("respawned");
                g.GetComponent<Respawn>().respawn = false;
                g.transform.position = new Vector3(Random.Range(-range, range), Random.Range(-range + 5, range - 5));
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
