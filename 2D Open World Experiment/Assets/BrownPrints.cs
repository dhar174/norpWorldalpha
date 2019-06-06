using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrownPrints : MonoBehaviour {
    List<GameObject> npcs = new List<GameObject>();
    public int time;
	// Use this for initialization
	void Start () {
        if (time == 0)
        {
            time = 20;
        }
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("NPC"))
        {
            collision.gameObject.GetComponent<NPCAI>().poopyprints = true;
            npcs.Add(collision.gameObject);
            StartCoroutine(TurnOff());
        }
    }

    IEnumerator TurnOff()
    {
        yield return new WaitForSecondsRealtime(time);
        foreach(GameObject g in npcs)
        {
            g.GetComponent<NPCAI>().poopyprints = false;
            
        }
        npcs.Clear();
    }


    // Update is called once per frame
    void Update () {
		
	}
}
