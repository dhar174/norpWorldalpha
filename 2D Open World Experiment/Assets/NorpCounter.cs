using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NorpCounter : MonoBehaviour {
    List<GameObject> ListONorps;
   public int NorpNum;
    public NorpAcademy norpacademy;

	// Use this for initialization
	void Start () {
        norpacademy = GameObject.Find("NorpAcademy").GetComponent<NorpAcademy>();
	}
	
	// Update is called once per frame
	void Update () {

        GameObject[] norps = GameObject.FindGameObjectsWithTag("NPC");

        //ListONorps.Clear();
        // foreach(GameObject g in norps)
        // {
        //     if (gameObject.name != "3dColl")
        //      {
        //          ListONorps.Add(g);
        //      }
        //  }
       
           
            NorpNum = norps.Length;
            //print(NorpNum);
        if (NorpNum == 0)
        {
           // print("norpnum is now zero ");
            if (!norpacademy.alreadyReset)
            {
                if (!norpacademy.norpisZero)
                {
                    //norpacademy.Done();
                    norpacademy.norpisZero = true;
                    //norpacademy.alreadyReset = true;
                    //print("reset from Counter with destroyed=" + norpacademy.agentsDestroyed + " and count=" + norpacademy.agents.Count);
                }
            }
        }
	}
}
