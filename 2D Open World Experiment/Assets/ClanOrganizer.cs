using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ClanOrganizer : MonoBehaviour {
    public List<Transform> NorpsList;
    public Transform[] NorpArray;
    public float[,] bonds;
    private int counter;
    private int friendshipTimer;
    //public int[,] inRange;


    // Use this for initialization
    void Start () {
        GameObject[] temp1 = GameObject.FindGameObjectsWithTag("NPC");
        NorpsList = new List<Transform>();
        foreach(GameObject g in temp1)
        {
            if(g.name != "3dColl")
            {
                NorpsList.Add(g.GetComponent<Transform>());
            }
        }
        NorpArray = NorpsList.ToArray();
        bonds = new float[NorpArray.Length, NorpArray.Length];
        //inRange = new int[NorpArray.Length, NorpArray.Length];
    }

    public void Interaction(Transform tt, Transform tt2, float value) 
    {
        int tti = 0;
        int ti = 0;
        for(int t = 0; t < NorpArray.Length; t++)
        {
            if(NorpArray[t] == tt)
            {
                ti = t;
            }

            if (NorpArray[t] == tt2)
            {
                tti = t;
            }
        }
        bonds[ti,tti] += value;

    }

    public float CalculateFriendship(Transform norp, List<GameObject> friends)
    {
        int thisNorp = 0;
        List<int> friendIndexes = new List<int>();
        foreach(Transform h in NorpArray)
        {
            if (h == norp)
            {
                thisNorp = System.Array.IndexOf(NorpArray, h);
            }
            foreach (GameObject g in friends)
            {
                if (h == g.GetComponent<Transform>())
                {
                    friendIndexes.Add(System.Array.IndexOf(NorpArray, h));
                }
            }
        }
        float friendshipValue = 0;
        foreach(int i in friendIndexes)
        {
            friendshipValue += bonds[thisNorp, i];
        }
        return friendshipValue;
    }


    public void Census()
    {
        for(int t = 0; t < NorpArray.Length; t++)
        {
            List<int> closest25 = new List<int>(25);
            float bestFriend = Mathf.Infinity;
            for (int t2 = 0; t2 < NorpArray.Length; t2++)
            {
                
                if (NorpArray[t2] != NorpArray[t])
                {
                    float p = Vector2.Distance(NorpArray[t].position, NorpArray[t2].position);
                    if (p <= 25)
                    {
                        bonds[t, t2] += .1f;

                        
                           
                        
                    }
                    else
                    {
                        bonds[t, t2] -= .05f;
                    }

                    
                }
            }
            float lowest = Mathf.Infinity;
            float highest = Mathf.NegativeInfinity;
            for (int q = 0; q < NorpArray.Length; q++)
            {
                if (bonds[t, q] < lowest)
                {
                    lowest = bonds[t, q];


                }
                if (bonds[t, q] > highest)
                {
                    highest = bonds[t, q];
                    if (closest25.Count > 25)
                    {
                        closest25.Add(q);
                    }
                    else
                    {
                        int weakLink = q;
                        foreach (int i in closest25)
                        {
                            if (bonds[t, i] < bonds[t, weakLink])
                            {
                                weakLink = i;
                            }
                        }

                        if (weakLink != q)
                        {
                            closest25.Remove(weakLink);
                            closest25.Add(q);
                        }
                    }

                }
            }
            if (NorpArray[t].gameObject!=null)
            {
                if (NorpArray[t].gameObject.GetComponent<NorpAI>())
                {
                    NorpArray[t].gameObject.GetComponent<NorpAI>().friends.Clear();
                    foreach (int o in closest25)
                    {
                        NorpArray[t].gameObject.GetComponent<NorpAI>().friends.Add(NorpArray[o].gameObject);
                    }
                }
            }

        }

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        friendshipTimer++;
        if (friendshipTimer >= 1000)
        {
            Census();
        }
        counter++;
        if (counter >= 100)
        {
            counter = 0;
            Census();
        }
		
	}
}
