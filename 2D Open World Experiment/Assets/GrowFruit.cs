using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowFruit : MonoBehaviour {
    public GameObject fruit;
    public Transform[] growSpots;
    public float growTimer;
    private bool alive;
    public bool isTuber;

	// Use this for initialization
	void Start () {
        alive = true;
        if (growTimer == 0)
        {
            growTimer = Random.Range(200, 500);
        }
        GrowAnother();
	}


    public void GrowAnother()
    {
        int index = Random.Range(0, growSpots.Length);
       GameObject newfruit = Instantiate(fruit, growSpots[index].localPosition, fruit.transform.rotation, gameObject.transform) as GameObject;
        newfruit.transform.SetParent(growSpots[index]);
        if (index == 0)
        {
            newfruit.GetComponent<Animator>().SetTrigger("dropOne");
        }
        else
        {
            if (index == 1)
            {

                newfruit.GetComponent<Animator>().SetTrigger("dropTwo");
            }
            else
            {

                newfruit.GetComponent<Animator>().SetTrigger("dropThree");

            }
        }
        //newfruit.transform.SetParent(null);
        if (isTuber)
        {
            //newfruit.transform.position = growSpots[index].localPosition;
        }
        StartCoroutine(Timer());
        
    }
   
	
    public IEnumerator Timer()
    {
        while (alive)
        {
            yield return new WaitForSeconds(growTimer);
            GrowAnother();
        }
        yield return null;
    }
	// Update is called once per frame
	void Update () {
		
	}
}
