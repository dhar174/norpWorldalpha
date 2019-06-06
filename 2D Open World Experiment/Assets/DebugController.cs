using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugController : MonoBehaviour {
    public bool testing;
    public float speed;
    public float camsize;
    public GameObject[] norps;
    public bool mapbodyEnabled = false;
	// Use this for initialization
	void Start () {
        camsize = 4.2f;
        norps = GameObject.FindGameObjectsWithTag("NPC");
	}
    public void Move(Vector2 velocity, float speed)
    {
        gameObject.transform.Translate(velocity * speed * Time.deltaTime);

    }
    // Update is called once per frame
    void Update()
    {
        if (testing)
        {
            if (Input.GetKey(KeyCode.W))
            {
                Move(new Vector2(0, 1), speed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                Move(new Vector2(0, -1), speed);
            }
            if (Input.GetKey(KeyCode.A))
            {
                Move(new Vector2(-1, 0), speed);
            }
            if (Input.GetKey(KeyCode.D))
            {
                Move(new Vector2(1, 0), speed);
            }
            if (Input.GetKey(KeyCode.I))
            {

                camsize -= .03f;
                Camera.main.orthographicSize = camsize;
            }
            if (Input.GetKey(KeyCode.O))
            {

                camsize += .03f;
                Camera.main.orthographicSize = camsize;
            }
        }
        if (camsize >= 10)
        {
            if (!mapbodyEnabled)
            {
                foreach (GameObject go in norps)
                {
                    go.GetComponent<NPCAI>().EnableMapbody();
                }
                mapbodyEnabled = true;
                speed = 20;
            }
        }
        if (camsize <= 10)
        {
            if (mapbodyEnabled)
            {
                foreach (GameObject go in norps)
                {
                    go.GetComponent<NPCAI>().DisableMapbody();
                }
                mapbodyEnabled = false;
                speed = 10;
            }
        }
        if (camsize >= 20)
        {
            speed = 35;

        }
        if (camsize >= 32)
        {
            speed = 60;

        }
    }
}
