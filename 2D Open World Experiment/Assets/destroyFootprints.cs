using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyFootprints : MonoBehaviour {

    public int time;

	// Use this for initialization
	void Start () {
        if (time == 0)
        {
            time = 20;
        }
        StartCoroutine(Timer());
	}
	public IEnumerator Timer()
    {
        yield return new WaitForSecondsRealtime(time);
        Destroy(gameObject);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
