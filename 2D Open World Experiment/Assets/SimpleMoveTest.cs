using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMoveTest : MonoBehaviour {
    int index;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        index++;
        if (index == 1000)
        {
            index = 0;
            Vector2 poop = gameObject.transform.position;
            gameObject.transform.position = poop + new Vector2(0, .1f);
        }
	}
}
