using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using MLAgents;
using UnityEngine.UI;
using System.Linq;


public class NorpAcademy : Academy {
    
    public bool alreadyReset;

    public bool norpisZero;

    private List<Vector3> agentPos;
    public List<GameObject> startMarkers;
    public int totalScore;
    public static int highestScore=0;

    public List<float> points;

    public fruitSpread fruitSpreader;

    public static int pointTracker = 0;
    public static bool easyDone=false;

    public bool firstwin = false;


    public Brain[] braintoGive;

    public bool oneAtaTime;

    public bool normal;

    public int iwscheck;
    public GameObject agentPrefab;
    public static float level = 0;
    public static float level2 = 0;
    public List<GameObject> agents;
    public List<GameObject> currentAgents;
    public int agentsDestroyed =0;

    public GameObject level1;
    public GameObject leveltwo;
    public GameObject level3;
    public GameObject level4;

    public List<GameObject> testFoodCopies;
    public List<GameObject> fruitswithmarkers = new List<GameObject>();
    public GameObject[] tempFood;
    public List<GameObject> tempFood2 = new List<GameObject>();

    public List<Transform> fruitstarts = new List<Transform>();

    public int whichCheck; //Delete later

    public GameObject[] arenas;
    public List<GameObject> fruits = new List<GameObject>();
    public float range;
    public int epnum;
    public bool firstlvl;

    public NorpAI norpAI;

    public bool TargetTRAINING;

    public Transform[] markers1;
    public Transform[] markers2;
    public Transform[] markers3;
    public Transform[] markers4;
    public int cm = 0;

    public int agentCount;

    public GameObject simpleArena;
    public GameObject simpleArenaZero;
    public float prvlvl;
    public GameObject level8;
    public GameObject level9;

    public List<GameObject> copies;
    public GameObject[] foodies;
    //public Text scoreText;
    public override void AcademyReset()
    {
        norpAI = gameObject.GetComponent<NorpAI>();
        alreadyReset = false;
        norpisZero = false;
        firstwin = false;
        agentsDestroyed = 0;
        if (TargetTRAINING)
        {
            if (simpleArena == null)
            {
                simpleArena = GameObject.Find("SimpleArena");
                simpleArenaZero = GameObject.Find("SimpleArenaZero");
                level8 = GameObject.Find("Level8");
                level9 = GameObject.Find("Level9");
            }
            level = this.gameObject.GetComponent<NorpAcademy>().resetParameters["level"];

           // print("level=" + level);
            List<GameObject> wallLevels = new List<GameObject>();

            if (simpleArena.activeSelf)
            {
                //print("childcount = " + simpleArena.transform.childCount);


                for (int tt = 0; tt < simpleArena.transform.childCount; tt++)
                {
                    //print("Checking wall levels" + "childcount= " + simpleArena.transform.childCount);
                    if (simpleArena.transform.GetChild(tt).gameObject.GetComponent<WallSizeChanger>())
                    {
                        wallLevels.Add(simpleArena.transform.GetChild(tt).gameObject);
                        //print("Wall Level Added");
                    }
                }
            }

            //level2= this.gameObject.GetComponent<NorpAcademy>().resetParameters["level2"];
            //GameObject[] leftoverAgents = GameObject.FindGameObjectsWithTag("NPC");

            // foreach(GameObject l in leftoverAgents)
            // {
            //     l.GetComponent<NorpAgent>().Done();
            //  }

            //float lvl = 0;
            //if (level >= level2)
            //{
            // lvl = level;
            //}
            // else
            // {
            //     lvl = level2;
            // }

            if (level == 1)
            {
                simpleArena.SetActive(false);
                //print("WORKING");
                simpleArenaZero.SetActive(true);
                easyDone = false;
                pointTracker = 0;
                firstlvl = true;

            }
            else
            {
                if (level == 2)
                {
                    //print("Chaka chaka");
                    
                    if (prvlvl != 2)
                    {
                        easyDone = false;
                        pointTracker = 0;
                        firstlvl = false;
                    }
                    
                }
                else
                {
                    if (level == 3)
                    {
                        //print("Chaka chaka");
                        simpleArena.SetActive(true);
                        simpleArenaZero.SetActive(false);
                        level8.SetActive(false);
                        level9.SetActive(false);
                        easyDone = false;
                        if (prvlvl != 3)
                        {
                            if (simpleArena.activeSelf)
                            {
                                wallLevels.Clear();


                                for (int tt = 0; tt < simpleArena.transform.childCount; tt++)
                                {
                                    if (simpleArena.transform.GetChild(tt).gameObject.GetComponent<WallSizeChanger>())
                                    {
                                        wallLevels.Add(simpleArena.transform.GetChild(tt).gameObject);
                                    }
                                }
                            }

                            pointTracker = 0;
                            firstlvl = false;
                        }
                        foreach (GameObject wz in wallLevels)
                        {
                            wz.GetComponent<WallSizeChanger>().WallSizeSmall();
                        }
                    }
                    else
                    {
                        if (level == 4)
                        {
                            //level8.SetActive(true);
                            //level9.SetActive(true);
                            if (prvlvl != 4)
                            {
                                if (simpleArena.activeSelf)
                                {
                                    wallLevels.Clear();


                                    for (int tt = 0; tt < simpleArena.transform.childCount; tt++)
                                    {
                                        if (simpleArena.transform.GetChild(tt).gameObject.GetComponent<WallSizeChanger>())
                                        {
                                            wallLevels.Add(simpleArena.transform.GetChild(tt).gameObject);
                                        }
                                    }
                                }
                                easyDone = false;
                                pointTracker = 0;
                                firstlvl = false;
                            }
                            foreach (GameObject wz in wallLevels)
                            {
                                wz.GetComponent<WallSizeChanger>().WallSizeMed();
                            }
                        }
                        else
                        {
                            if (level == 5)
                            {

                                if (prvlvl != 5)
                                {
                                    if (simpleArena.activeSelf)
                                    {
                                        wallLevels.Clear();


                                        for (int tt = 0; tt < simpleArena.transform.childCount; tt++)
                                        {
                                            if (simpleArena.transform.GetChild(tt).gameObject.GetComponent<WallSizeChanger>())
                                            {
                                                wallLevels.Add(simpleArena.transform.GetChild(tt).gameObject);
                                            }
                                        }
                                        foreach (GameObject wz in wallLevels)
                                        {
                                            wz.GetComponent<WallSizeChanger>().WallSizeLong();
                                        }
                                    }

                                    easyDone = false;
                                    pointTracker = 0;
                                    firstlvl = false;
                                }
                            }
                            else
                            {
                                if (level == 6)
                                {

                                    if (prvlvl != 6)
                                    {
                                        if (simpleArena.activeSelf)
                                        {
                                            wallLevels.Clear();


                                            for (int tt = 0; tt < simpleArena.transform.childCount; tt++)
                                            {
                                                if (simpleArena.transform.GetChild(tt).gameObject.GetComponent<WallSizeChanger>())
                                                {
                                                    wallLevels.Add(simpleArena.transform.GetChild(tt).gameObject);
                                                }
                                            }
                                        }
                                        foreach (GameObject wz in wallLevels)
                                        {
                                            wz.GetComponent<WallSizeChanger>().WallSizeMax();
                                        }
                                        easyDone = false;
                                        pointTracker = 0;
                                        firstlvl = false;
                                    }
                                }
                            }
                        }
                    }
                }

            }
        }

        if (pointTracker >= 60)
        {
            easyDone = true;
        }

        if (oneAtaTime)
        {

            if (level1 == null)
            {
                level1 = GameObject.Find("Level1");
                leveltwo = GameObject.Find("Level2");
                level3 = GameObject.Find("Level3");
                level4 = GameObject.Find("Level4");
            }
            if (level == 0)
            {
                level = UnityEngine.Random.Range(1, 5);
                level1.SetActive(true);
                leveltwo.SetActive(false);
                level3.SetActive(false);
                level4.SetActive(false);

            }
            if (level == 1)
            {

                level1.SetActive(true);
                leveltwo.SetActive(false);
                level3.SetActive(false);
                level4.SetActive(false);

            }
            if (level == 2)
            {
                level1.SetActive(false);
                leveltwo.SetActive(true);
                level3.SetActive(false);
                level4.SetActive(false);
            }
            if (level == 3)
            {
                level1.SetActive(false);
                leveltwo.SetActive(false);
                level3.SetActive(true);
                level4.SetActive(false);
            }
            if (level == 4)
            {
                level1.SetActive(false);
                leveltwo.SetActive(false);
                level3.SetActive(false);
                level4.SetActive(true);
            }
            if (level == 5)
            {
                level = 0;
            }
        
        


        
            fruitSpreader = null;

            if (!fruitSpreader)
            {
            fruitSpreader = GameObject.Find("FruitSpreader").GetComponent<fruitSpread>();
            }

            fruitSpreader.fire1 = false;
            fruitSpreader.fire2 = false;
            fruitSpreader.fire3 = false;
            fruitSpreader.fire4 = false;
            fruitSpreader.fire5 = false;
        fruitSpreader.fire6 = false;
        fruitSpreader.fire7 = false;
        fruitSpreader.fire8 = false;
        fruitSpreader.fire9 = false;

            GameObject[] wanderleftovers = GameObject.FindGameObjectsWithTag("WanderTarget");
            foreach(GameObject w in wanderleftovers)
            {
                Destroy(w);
            }

        fruitSpreader.ArrangeFruit2();
        //print("Academy Reset");
        
        if (epnum == 0)
        {
            if (!normal)
            {
                foodies = GameObject.FindGameObjectsWithTag("Food");
                foreach (GameObject f in foodies)
                {
                    if (f.name != "3DColl")
                    {
                        if (cm == 0)
                        {

                            markers1 = (Transform[])f.GetComponent<fruitmarkerArray>().fruitMarkers.Clone();
                        }
                        if (cm == 1)
                        {
                            markers2 = (Transform[])f.GetComponent<fruitmarkerArray>().fruitMarkers.Clone();
                        }
                        if (cm == 2)
                        {
                            markers3 = (Transform[])f.GetComponent<fruitmarkerArray>().fruitMarkers.Clone();
                        }
                        if (cm == 3)
                        {
                            markers4 = (Transform[])f.GetComponent<fruitmarkerArray>().fruitMarkers.Clone();
                        }
                        cm++;
                    }
                }
            }
           
        }

        fruitswithmarkers.Clear();

            if (!normal)
            {
                if (tempFood.Length == 0)
                {

                    tempFood = GameObject.FindGameObjectsWithTag("Food");
                    foreach (GameObject go in tempFood)
                    {
                        if (go.name != "3DColl")
                        {
                            tempFood2.Add(go);
                        }
                    }

                }
                tempFood = tempFood2.ToArray();
                if (testFoodCopies.Count != 0)
                {


                    if (testFoodCopies.Count != tempFood.Length)
                    {
                        //var iws = 0;
                        for (int iws = 0; iws < tempFood2.Count; iws++)
                        {
                            if (tempFood[iws] == null)
                            {
                                if (tempFood2[iws].name != "3DColl")
                                {
                                    //GameObject newfood = Instantiate(testFoodCopies[iws], new Vector3(1000, 1000, 0), transform.rotation) as GameObject;
                                    //testFoodCopies.Add(newfood);
                                    // tempFood2.Insert(iws, newfood);
                                    iws++;
                                }
                            }
                            else
                            {

                            }
                        }
                        //testFoodCopies = tempFood;

                    }
                    else
                    {
                        //print("enough");
                    }

                }
                else
                {
                    for (int iws = 0; iws < tempFood2.Count; iws++)
                    {
                        if (tempFood2[iws].name != "3DColl")
                        {
                            //GameObject newfood = Instantiate(testFoodCopies[iws], new Vector3(1000, 1000, 0), transform.rotation) as GameObject;
                            testFoodCopies = new List<GameObject>(tempFood2.Count);
                            //testFoodCopies.Add(newfood);

                            //if (testFoodCopies.IndexOf(newfood) != iws)
                            // {
                            //testFoodCopies.Insert(iws, newfood);
                            // }
                            iws++;
                        }
                    }
                }
            }

            if (epnum == 0)
            {
                foreach (GameObject co in testFoodCopies)
                {
                    GameObject newfoods = Instantiate(co, new Vector3(1000, 1000, 0), new Quaternion(0, 0, 0, 0)) as GameObject;
                    copies.Add(newfoods);
                }
            }

            if (fruitswithmarkers.Count != tempFood2.Count)
            {
                fruitswithmarkers.Clear();
                fruitswithmarkers.AddRange(testFoodCopies);
            }
            //  int inta = 0;
            //   int che = 0;
            for (int iws = 0; iws < 3; iws++)
            {
                iwscheck = iws;
                //inta = tempFood2.ge;

                //inta =   tempFood2.FindIndex(d => d == tempFood2[iws].gameObject);
                //che = Array.IndexOf<GameObject>(tempFood, tempFood2[iws]);

                //Array.IndexOf<GameObject>(tempFood, tempFood2[iws]);
                //  if (inta == che)
                //  {
                // print("Inta Equaled che");
                //  }
                //  else
                //  {
                //  print("Inta did NOT equal che");
                //  }

                // print("Inta is " + inta);

                if (tempFood2.Count == copies.Count)
                {
                     print("aaa");
                    if (tempFood2[iws] != null)
                    {
                         print("bbb");
                        if (tempFood2[iws].gameObject.GetComponent<fruitmarkerArray>())
                        {
                             print("ccc");
                            fruitswithmarkers.Add(tempFood2[iws]);
                             print("Added fruitwithmarkers");
                            int which = UnityEngine.Random.Range(0, tempFood2[iws].gameObject.GetComponent<fruitmarkerArray>().fruitMarkers.Length);
                            whichCheck = which;
                            tempFood2[iws].transform.position = tempFood2[iws].gameObject.GetComponent<fruitmarkerArray>().fruitMarkers[which].transform.position;
                            if (copies[iws] != null)
                            {
                                if (copies[iws].GetComponent<fruitmarkerArray>().fruitMarkers.Length == 0)
                                {
                                    // print("ddd");
                                    copies[iws].GetComponent<fruitmarkerArray>().fruitMarkers = (Transform[])tempFood2[iws].GetComponent<fruitmarkerArray>().fruitMarkers.Clone();
                                }
                                else
                                {
                                    copies[iws].GetComponent<fruitmarkerArray>().fruitMarkers = (Transform[])tempFood2[iws].GetComponent<fruitmarkerArray>().fruitMarkers.Clone();
                                }
                            }
                            else
                            {

                                GameObject newfoods = Instantiate(testFoodCopies[iws], new Vector3(1000, 1000, 0), new Quaternion(0, 0, 0, 0)) as GameObject;
                                copies.Add(newfoods);
                                newfoods.GetComponent<fruitmarkerArray>().fruitMarkers = (Transform[])tempFood2[iws].GetComponent<fruitmarkerArray>().fruitMarkers.Clone();
                                //testFoodCopies[iws].GetComponent<fruitmarkerArray>().fruitMarkers = (Transform[])tempFood2[iws].GetComponent<fruitmarkerArray>().fruitMarkers.Clone();
                                float closestfruit = GetClosestNorp(newfoods.GetComponent<fruitmarkerArray>().fruitMarkers[which].gameObject.transform.position);
                                if (closestfruit > 8)
                                {
                                    newfoods.transform.position = newfoods.GetComponent<fruitmarkerArray>().fruitMarkers[which].gameObject.transform.position;
                                }


                            }
                        }
                    }
                    else
                    {
                        // print("eee");
                        int which = 0;
                        //print("inta is " + inta);
                        if (copies[iws] != null)
                        {
                            if (copies[iws].GetComponent<fruitmarkerArray>().fruitMarkers.Length != 0)
                            {
                                //  print("fff");
                                which = UnityEngine.Random.Range(0, copies[iws].GetComponent<fruitmarkerArray>().fruitMarkers.Length);
                            }
                            else
                            {
                                // print("ggg");
                                if (iws == 0)
                                {
                                    copies[iws].GetComponent<fruitmarkerArray>().fruitMarkers = (Transform[])markers1.Clone();
                                }
                                if (iws == 1)
                                {
                                    copies[iws].GetComponent<fruitmarkerArray>().fruitMarkers = (Transform[])markers1.Clone();
                                }
                                if (iws == 2)
                                {
                                    copies[iws].GetComponent<fruitmarkerArray>().fruitMarkers = (Transform[])markers1.Clone();

                                }
                                if (iws == 3)
                                {
                                    copies[iws].GetComponent<fruitmarkerArray>().fruitMarkers = (Transform[])markers1.Clone();
                                }
                                which = UnityEngine.Random.Range(0, 7);
                            }
                            // Instantiate(testFoodCopies[inta], testFoodCopies[inta].GetComponent<fruitmarkerArray>().fruitMarkers[which].transform.position, testFoodCopies[inta].transform.rotation);
                            copies[iws].transform.position = copies[iws].GetComponent<fruitmarkerArray>().fruitMarkers[which].gameObject.transform.position;
                            //print("copy moved");
                        }
                        else
                        {

                            GameObject newfoods = Instantiate(testFoodCopies[iws], new Vector3(1000, 1000, 0), new Quaternion(0, 0, 0, 0)) as GameObject;
                            copies.Add(newfoods);
                            if (newfoods.GetComponent<fruitmarkerArray>().fruitMarkers.Length != 0)
                            {
                                //  print("fff");
                                which = UnityEngine.Random.Range(0, newfoods.GetComponent<fruitmarkerArray>().fruitMarkers.Length);
                            }
                            else
                            {
                                // print("ggg");
                                which = UnityEngine.Random.Range(0, 7);
                            }
                            //  newfoods.GetComponent<fruitmarkerArray>().fruitMarkers = (Transform[])tempFood2[iws].GetComponent<fruitmarkerArray>().fruitMarkers.Clone();



                            if (iws == 0)
                            {
                                //newfoods.transform.position = markers1[which].transform.position;
                                newfoods.GetComponent<fruitmarkerArray>().fruitMarkers = (Transform[])markers1.Clone();
                                //float closestfruit = GetClosestNorp(newfoods.GetComponent<fruitmarkerArray>().fruitMarkers[which].gameObject.transform.position);
                                float closestfruit = GetClosestNorp(newfoods.GetComponent<fruitmarkerArray>().fruitMarkers[which].gameObject.transform.position);
                                if (closestfruit > 8)
                                {

                                    newfoods.transform.position = markers1[which].transform.position;
                                }
                            }
                            if (iws == 1)
                            {
                                // newfoods.transform.position = markers1[which].transform.position;
                                newfoods.GetComponent<fruitmarkerArray>().fruitMarkers = (Transform[])markers2.Clone();
                                //float closestfruit = GetClosestNorp(newfoods.GetComponent<fruitmarkerArray>().fruitMarkers[which].gameObject.transform.position);
                                float closestfruit = GetClosestNorp(newfoods.GetComponent<fruitmarkerArray>().fruitMarkers[which].gameObject.transform.position);
                                if (closestfruit > 8)
                                {

                                    newfoods.transform.position = markers2[which].transform.position;
                                }
                            }
                            if (iws == 2)
                            {
                                // newfoods.transform.position = markers1[which].transform.position;
                                newfoods.GetComponent<fruitmarkerArray>().fruitMarkers = (Transform[])markers3.Clone();
                                // float closestfruit = GetClosestNorp(newfoods.GetComponent<fruitmarkerArray>().fruitMarkers[which].gameObject.transform.position);
                                float closestfruit = GetClosestNorp(newfoods.GetComponent<fruitmarkerArray>().fruitMarkers[which].gameObject.transform.position);
                                if (closestfruit > 8)
                                {

                                    newfoods.transform.position = markers3[which].transform.position;
                                }

                            }
                            if (iws == 3)
                            {
                                // newfoods.transform.position = markers1[which].transform.position;
                                newfoods.GetComponent<fruitmarkerArray>().fruitMarkers = (Transform[])markers4.Clone();
                                // float closestfruit = GetClosestNorp(newfoods.GetComponent<fruitmarkerArray>().fruitMarkers[which].gameObject.transform.position);
                                float closestfruit = GetClosestNorp(newfoods.GetComponent<fruitmarkerArray>().fruitMarkers[which].gameObject.transform.position);
                                if (closestfruit > 8)
                                {

                                    newfoods.transform.position = markers4[which].transform.position;
                                }
                            }



                        }
                    }
                }
                else
                {
                    // print("hhh");
                    if (copies[iws] != null)
                    {
                        int which = 0;
                        //print("inta is " + inta);
                        if (copies[iws].GetComponent<fruitmarkerArray>().fruitMarkers.Length != 0)
                        {
                            // print("iii");
                            which = UnityEngine.Random.Range(0, copies[iws].GetComponent<fruitmarkerArray>().fruitMarkers.Length);
                        }
                        else
                        {
                            // print("jjj");
                            which = UnityEngine.Random.Range(0, 7);
                        }

                        // Instantiate(testFoodCopies[inta], testFoodCopies[inta].GetComponent<fruitmarkerArray>().fruitMarkers[which].transform.position, testFoodCopies[inta].transform.rotation);
                        if (copies[iws].GetComponent<fruitmarkerArray>().fruitMarkers[which] != null)
                        {
                            float closestfruit = GetClosestNorp(copies[iws].GetComponent<fruitmarkerArray>().fruitMarkers[which].gameObject.transform.position);
                            if (closestfruit > 8)
                            {
                                copies[iws].transform.position = copies[iws].GetComponent<fruitmarkerArray>().fruitMarkers[which].gameObject.transform.position;
                            }
                        }
                        else
                        {
                            //  newfoods.GetComponent<fruitmarkerArray>().fruitMarkers = (Transform[])tempFood2[iws].GetComponent<fruitmarkerArray>().fruitMarkers.Clone();
                            if (iws == 0)
                            {
                                //copies[iws].transform.position = markers1[which].transform.position;
                                copies[iws].GetComponent<fruitmarkerArray>().fruitMarkers = (Transform[])markers1.Clone();
                                float closestfruit = GetClosestNorp(copies[iws].GetComponent<fruitmarkerArray>().fruitMarkers[which].gameObject.transform.position);
                                if (closestfruit > 8)
                                {
                                    copies[iws].transform.position = markers1[which].transform.position;
                                }
                            }
                            if (iws == 1)
                            {
                                //copies[iws].transform.position = markers1[which].transform.position;
                                copies[iws].GetComponent<fruitmarkerArray>().fruitMarkers = (Transform[])markers2.Clone();
                                float closestfruit = GetClosestNorp(copies[iws].GetComponent<fruitmarkerArray>().fruitMarkers[which].gameObject.transform.position);
                                if (closestfruit > 8)
                                {
                                    copies[iws].transform.position = markers2[which].transform.position;
                                }
                            }
                            if (iws == 2)
                            {
                                //copies[iws].transform.position = markers1[which].transform.position;
                                copies[iws].GetComponent<fruitmarkerArray>().fruitMarkers = (Transform[])markers3.Clone();
                                float closestfruit = GetClosestNorp(copies[iws].GetComponent<fruitmarkerArray>().fruitMarkers[which].gameObject.transform.position);
                                if (closestfruit > 8)
                                {
                                    copies[iws].transform.position = markers3[which].transform.position;
                                }

                            }
                            if (iws == 3)
                            {
                                // copies[iws].transform.position = markers1[which].transform.position;
                                copies[iws].GetComponent<fruitmarkerArray>().fruitMarkers = (Transform[])markers4.Clone();
                                float closestfruit = GetClosestNorp(copies[iws].GetComponent<fruitmarkerArray>().fruitMarkers[which].gameObject.transform.position);
                                if (closestfruit > 8)
                                {
                                    copies[iws].transform.position = markers4[which].transform.position;
                                }
                            }
                        }
                        // print("Instantiated new fruit");

                        //tempFood2.Insert(iws,copies[iws]);
                    }
                    else
                    {
                        GameObject newfoods = Instantiate(testFoodCopies[1], new Vector3(1000, 1000, 0), new Quaternion(0, 0, 0, 0)) as GameObject;
                        copies.Add(newfoods);
                        int which = 0;



                        if (newfoods.GetComponent<fruitmarkerArray>().fruitMarkers[UnityEngine.Random.Range(0, 6)] != null)
                        {
                            //  print("fff");
                            which = UnityEngine.Random.Range(0, newfoods.GetComponent<fruitmarkerArray>().fruitMarkers.Length);
                        }
                        else
                        {
                            // print("ggg");
                            which = UnityEngine.Random.Range(0, 7);
                        }
                        newfoods.GetComponent<fruitmarkerArray>().fruitMarkers = (Transform[])markers1.Clone();
                        if (iws == 0)
                        {
                            newfoods.GetComponent<fruitmarkerArray>().fruitMarkers = (Transform[])markers1.Clone();
                        }
                        if (iws == 1)
                        {
                            newfoods.GetComponent<fruitmarkerArray>().fruitMarkers = (Transform[])markers2.Clone();
                        }
                        if (iws == 2)
                        {
                            newfoods.GetComponent<fruitmarkerArray>().fruitMarkers = (Transform[])markers3.Clone();

                        }
                        if (iws == 3)
                        {
                            newfoods.GetComponent<fruitmarkerArray>().fruitMarkers = (Transform[])markers4.Clone();
                        }

                        //  newfoods.GetComponent<fruitmarkerArray>().fruitMarkers = (Transform[])tempFood2[iws].GetComponent<fruitmarkerArray>().fruitMarkers.Clone();
                        float closestfruit = GetClosestNorp(newfoods.GetComponent<fruitmarkerArray>().fruitMarkers[which].gameObject.transform.position);
                        if (iws == 0)
                        {

                            //newfoods.transform.position = markers1[which].transform.position;
                            newfoods.GetComponent<fruitmarkerArray>().fruitMarkers = (Transform[])markers1.Clone();
                            if (closestfruit > 8)
                            {
                                newfoods.transform.position = markers1[which].transform.position;

                            }
                        }
                        if (iws == 1)
                        {

                            // newfoods.transform.position = markers1[which].transform.position;
                            newfoods.GetComponent<fruitmarkerArray>().fruitMarkers = (Transform[])markers2.Clone();
                            if (closestfruit > 8)
                            {
                                newfoods.transform.position = markers2[which].transform.position;

                            }
                        }
                        if (iws == 2)
                        {
                            // newfoods.transform.position = markers1[which].transform.position;
                            newfoods.GetComponent<fruitmarkerArray>().fruitMarkers = (Transform[])markers3.Clone();
                            if (closestfruit > 8)
                            {
                                newfoods.transform.position = markers3[which].transform.position;

                            }

                        }
                        if (iws == 3)
                        {
                            // newfoods.transform.position = markers1[which].transform.position;
                            newfoods.GetComponent<fruitmarkerArray>().fruitMarkers = (Transform[])markers4.Clone();
                            if (closestfruit > 8)
                            {
                                newfoods.transform.position = markers4[which].transform.position;

                            }

                        }


                    }
                    // inta++;
                }
            }
        }
      //  foreach (GameObject a in agents)
       // {
      //      a.GetComponent<Agent>().Done();
      //  }
        agents.Clear();
        startMarkers.Clear();
        fruits.Clear();
        
        
        fruitstarts.Clear();
        foreach(GameObject t in GameObject.FindGameObjectsWithTag("FruitMarker") )
        {
            fruitstarts.Add(t.gameObject.GetComponent<Transform>());
        }
        foreach(GameObject g in GameObject.FindGameObjectsWithTag("Food"))
        {
            //  if (g.GetComponent<fruitmarkerArray>())
            // {
            //g.transform.position = fruitstarts[UnityEngine.Random.Range(0, fruitstarts.Count)].transform.position;
            if (g.name != "3DColl"){
                fruits.Add(g);
            }
                
           // }
            
        }

        if (range == 0)
        {
            range = 15;
        }
        arenas = GameObject.FindGameObjectsWithTag("Arena");

        

        int randomInt = UnityEngine.Random.Range(20, fruitstarts.Count);
        int soo = 0;
        for (int h = 0; h < fruitstarts.Count; h++)
        {
            if (fruits.Count >= 100)
            {
                if (h > randomInt)
                {
                    Instantiate(testFoodCopies[1], new Vector2(fruitstarts[randomInt].transform.position.x + UnityEngine.Random.Range(-.2f, .2f), fruitstarts[randomInt].position.y + UnityEngine.Random.Range(-.2f, .2f)), testFoodCopies[1].transform.rotation);
                }
                else
                {
                    break;
                }
            }
            else
            {
                
                //disabled this for sake of Simplest test
                if (fruits.Count < 4)
                {
                    // Instantiate(testFoodCopies[1], new Vector2(fruitstarts[soo].transform.position.x + UnityEngine.Random.Range(-.1f, .1f), fruitstarts[soo].position.y + UnityEngine.Random.Range(-.1f, .1f)), testFoodCopies[1].transform.rotation);
                    soo++;
                }
            }
           // break;
        }
        

        if (epnum != 0)
        {


            foreach (GameObject g in arenas)
            {
                g.GetComponent<Obstacles>().Arrange();
            }
        }
        epnum++;
       // print("epnum= " + epnum);
        int i = 0;
        GameObject[] temp;
        if (GameObject.FindGameObjectWithTag("NPC"))
        {
            temp = GameObject.FindGameObjectsWithTag("NPC");
        }
        else
        {
            temp = null;
        }
        if (temp != null)
        {
            foreach (GameObject g in temp)
            {
                if (g.GetComponent<NorpAgent>())
                {
                    if (g.name != "3dColl")
                    {
                        agents.Add(g);
                        g.GetComponent<NorpAI>().hunger = UnityEngine.Random.Range(5, 30);
                    }
                    //g.GetComponent<NorpAgent>().AgentReset();
                }
            }
        }
        foreach(GameObject aa in agents)
        {
            int poop = 0;
            if (aa == null)
            {
                poop++;
                agents.Remove(aa);
            }
            if (poop == agents.Count)
            {
                agents.Clear();
            }
        }

        
        //agents.Clear();
        points = new List<float>(agents.Count);
        // for(int l=0;l < agents.Count; l++)
        // {
        //      points[l] = agents[l].GetComponent<NorpAgent>().currentReward;
        //  }
        highestScore = totalScore;
        totalScore = 0;
        //print("This is happening this often");
        if (agents.Count == 0)
        {
           int newInt = 0;
            GameObject[] temp2 = GameObject.FindGameObjectsWithTag("StartMarker");
            foreach (GameObject g2 in temp2)
            {
                if (newInt > 1)
                {
                    newInt = 0;
                }
                startMarkers.Add(g2);
                Vector2 bob;
                bob = new Vector2(startMarkers[i].transform.position.x+UnityEngine.Random.Range(.1f,-.1f), startMarkers[i].transform.position.y + UnityEngine.Random.Range(.1f, -.1f));
                ///print(bob + " and " + i);
                GameObject newAgent = Instantiate(agentPrefab, bob, agentPrefab.transform.rotation) as GameObject;
                newAgent.GetComponent<NorpAgent>().GiveBrain(braintoGive[newInt]);
                i++;
                newInt++;

            }
             
            
            
        }
        else
        {


            if (highestScore == 0)
            {
                GameObject[] temp2 = GameObject.FindGameObjectsWithTag("StartMarker");
                foreach (GameObject g2 in temp2)
                {
                    
                        startMarkers.Add(g2);
                    
                }
                if (epnum != 0)
                {
                    foreach (GameObject g3 in agents)
                    {
                        if (g3 != null)
                        {
                            g3.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                            g3.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

                            //reemoved random range- add again

                            //line below temp. removed- do restore
                            g3.transform.position = new Vector3(startMarkers[i].transform.position.x, startMarkers[i].transform.position.y);
                            //g3.GetComponent<NorpAgent>().AgentReset();
                            //print("I resetteded");
                            //g3.GetComponent<NorpAgent>().RequestDecision();
                            //g3.GetComponent<NorpAgent>().InitializeAgent();
                            g3.GetComponent<NorpAI>().ClearTarget();
                            i++;
                        }
                    }
                }

            }

            else
            {
                GameObject[] temp3 = GameObject.FindGameObjectsWithTag("StartMarker");
                foreach (GameObject g2 in temp3)
                {
                    startMarkers.Add(g2);
                }
                foreach (GameObject g3 in agents)
                {
                    if (g3 != null)
                    {
                        g3.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                        g3.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

                        //reemoved random range- add again


                        g3.transform.position = new Vector3(startMarkers[i].transform.position.x, startMarkers[i].transform.position.y);
                        //g3.GetComponent<NorpAgent>().AgentReset();
                        //print("I resetteded");
                        //g3.GetComponent<NorpAgent>().InitializeAgent();
                        g3.GetComponent<NorpAI>().ClearTarget();
                        i++;
                    }
                }
            }
        }
        //temp = null;
        //agents.Clear();
        if (GameObject.FindGameObjectWithTag("NPC"))
        {
            //agentCount = agents.Count();
            temp = GameObject.FindGameObjectsWithTag("NPC");
        }
        else
        {
            //agentCount = agents.Count();
            temp = null;
        }
        if (temp != null)
        {
            //print("temp wasnt null");
            foreach (GameObject g in temp)
            {
                if (g.GetComponent<NorpAgent>())
                {
                    if (g.name != "3dColl")
                    {
                        agents.Add(g);
                    }
                   // g.GetComponent<NorpAI>().hunger = UnityEngine.Random.Range(5, 30);
                    //g.GetComponent<NorpAgent>().AgentReset();
                }
            }
        }
        currentAgents = new List<GameObject>();
        currentAgents.AddRange(agents);
        // print("Agent number: " +agents.Count);
        agentCount = agents.Count();
        prvlvl = level;

        
    }

    public float GetClosestNorp(Vector2 targetPos)
    {
        //print("And this is happening this often");
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector2 currentPos = targetPos;
        GameObject[] poop;
        poop = GameObject.FindGameObjectsWithTag("Food");
       // List<Transform> poopy = new List<Transform>();

        for (int i = 0; i < poop.Length; i++)
        {
            
            if (poop[i] != null)
            {
                float dist = Vector2.Distance(poop[i].transform.position, currentPos);
                if (dist < minDist)
                {
                    tMin = poop[i].transform;
                    minDist = dist;
                }
            }
        }
        //directionAvg = intDirection;
        //StartCoroutine(WaitForDirection());

        //print("Found nearest");
        return minDist;
    }

    void ClearObjects(GameObject[] objects)
    {
        foreach (GameObject bana in objects)
        {
            Destroy(bana);
        }
    }

    public void FinishAgentAndWait(GameObject agent)
    {
        agent.gameObject.SetActive(false);

        if (currentAgents.Contains(agent))
        {
            currentAgents.Remove(agent);
        }
        
        if (currentAgents.Count == 0)
        {
            if (!alreadyReset)
            {
                print("what the fuck!?!?");
                FinalReckoning();
                alreadyReset = true;
            }
                    



        }
    }

    public void FinalReckoning()
    {
       float mostPoints = -10;
        // foreach(float f in points)
        //  {
        //    if (f > mostPoints)
        //    {
        //       mostPoints = f;
        //       print("Most Points: " + mostPoints);
        //  }
        // }
        foreach (GameObject a in agents)
        {
            if (!a.gameObject.activeSelf)
            {
                a.gameObject.SetActive(true);


            }
            if (a.GetComponent<NorpAgent>().currentReward>mostPoints)
            {
                mostPoints = a.GetComponent<NorpAgent>().currentReward;
            }

        }
       // print("Most Points: " + mostPoints);
        foreach (GameObject a in agents)
        {
            if (!a.gameObject.activeSelf)
            {
                a.gameObject.SetActive(true);


            }
            if (a.GetComponent<NorpAgent>().currentReward >= mostPoints)
            {
                if (a.GetComponent<NorpAgent>().foodsEaten > mostPoints)
                {
                    a.GetComponent<NorpAgent>().SetReward(a.GetComponent<NorpAgent>().foodsEaten);
                }
                else
                {
                    a.GetComponent<NorpAgent>().SetReward(mostPoints);
                }
            }
            else
            {
                a.GetComponent<NorpAgent>().SetReward(0);

            }
           // print(a.gameObject.name + " is done with " + a.GetComponent<NorpAgent>().GetReward());
            a.GetComponent<NorpAgent>().Done();
            
        }






        //yield return new WaitForSeconds(1);
        
    }

    public override void AcademyStep()
    {
        if (agentCount != 0 && agentsDestroyed != 0)
        {
            if (agentsDestroyed == agentCount)
            {
                norpisZero = true;
                //print("Done called from Academy " + agentsDestroyed + " " + agentCount);
            }
        }
        //print("farts");
        if (norpisZero)
        {
            if (!alreadyReset)
            {
               // print("Academy done called. Norpnum= " + GameObject.Find("ClanOrganizer").GetComponent<NorpCounter>().NorpNum);
                this.Done();

                
                alreadyReset = true;
            }
            //norpisZero = false;
        }
        //print("Academy step");
        //scoreText.text = string.Format(@"Score: {0}", totalScore);
        //if (totalScore <= -10)
        // {
        //print("academy score sucked");
        //this.Done();
        // }
        //if (pointTracker >= 60)
       //{
        //    easyDone = true;
        //}

    }

    
}
