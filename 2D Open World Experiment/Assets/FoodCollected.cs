using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCollected : MonoBehaviour {
    public float foodvalue;
    public bool alive;
    public bool allowRot;
	// Use this for initialization
	void Start () {
        alive = true;
        if (allowRot)
        {
            StartCoroutine(RotTimer());
        }
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("NPC"))
        {
            if (collision.gameObject.GetComponent<NPCAI>())
            {
                collision.gameObject.GetComponent<NPCAI>().hunger += foodvalue;
                collision.gameObject.GetComponent<NPCAI>().RemoveFromList(gameObject);
                collision.gameObject.GetComponent<NPCAI>().FillFoodList();
                collision.gameObject.GetComponent<NPCAI>().poopCount++;
            }
            if (collision.gameObject.GetComponent<NorpAI>())
            {
                collision.gameObject.GetComponent<NorpAI>().hunger += foodvalue;
                //collision.gameObject.GetComponent<NorpAI>().RemoveFromList(gameObject);
                //collision.gameObject.GetComponent<NorpAI>().FillFoodList();
                //collision.gameObject.GetComponent<NorpAI>().poopCount++;
            }
            if (collision.gameObject.GetComponent<NorpAgent>())
            {
                if (collision.gameObject.GetComponent<NorpAI>().TargetTRAINING)
                {
                    collision.gameObject.GetComponent<NorpAgent>().AteFood(gameObject);
                }
            }
            Destroy(gameObject);
        }
    }

    public IEnumerator RotTimer()
    {
        while(alive)
        {
            yield return new WaitForSecondsRealtime(300);
            Destroy(gameObject, 1);
            //print("destroyed this fruit " + gameObject.name);
        }
        yield return null;
    }
    public void Grown()
    {
        gameObject.GetComponent<Animator>().SetBool("grown", true);
    }

    // Update is called once per frame
    
}
