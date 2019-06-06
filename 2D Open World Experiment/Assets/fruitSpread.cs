using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class fruitSpread : MonoBehaviour {
    //public GameObject[] fruitStarts;
    public GameObject fruitprefab;
    public GameObject fireprefab;
    public List<GameObject>existingFruits = new List<GameObject>();

    private GameObject norpacademy;
    public int level7fruits = 0;
    public int level8fruits = 0;
    public int level9fruits = 0;
    public bool fire1 = false;
    public bool fire2 = false;
    public bool fire3 = false;
    public bool fire4 = false;
    public bool fire5 = false;
    public bool fire6 = false;
    public bool fire7 = false;
    public bool fire8 = false;
    public bool fire9 = false;

    public bool level1 = false;
    public bool level2 = false;
    public bool level3 = false;
    public bool level4 = false;
    public bool level5 = false;
    public bool level6 = false;
    public bool level7 = false;
    public bool level8 = false;
    public bool level9 = false;
    // public List<GameObject> fruit2 = new List<GameObject>();
    //Collider2D[] results;
    // Use this for initialization
    void Start () {
        norpacademy = GameObject.FindObjectOfType<NorpAcademy>().gameObject;
		foreach(GameObject g in GameObject.FindGameObjectsWithTag("Food"))
        {
            if (g.transform.parent == transform.parent)
            {
                if (g.gameObject.name != "3DColl")
                {
                    existingFruits.Add(g);
                }
            }
        }
	}

    public void ArrangeFruit()
    {
        
        

        
        GameObject[] fruitstarts2 = GameObject.FindGameObjectsWithTag("FruitMarker");
        int i = 0;
        int g = 0;
        
        for(i= 0;i < fruitstarts2.Length; i++)
        {
            Collider2D[] results = Physics2D.OverlapCircleAll(fruitstarts2[i].transform.position, 1f);

                if (results.Length>0)
                {



                 //print("said nope");
           
                
                    
                }
                else
                {
                   
                    GameObject newfruit = Instantiate(fruitprefab, fruitstarts2[i].transform.position+ new Vector3(Random.Range(-.6f,.6f), Random.Range(-.4f, .4f)), fruitprefab.transform.rotation, gameObject.transform.parent) as GameObject;
                    existingFruits.Add(newfruit);
               // if (i != 4)
              //  {
                    //GameObject[] fruitstarts2 = GameObject.FindGameObjectsWithTag("FruitMarker");
                   // newfruit.transform.position = fruitstarts2[UnityEngine.Random.Range(0, fruitstarts2.Length)].transform.position;
              //  }
                   
                }
                
            
            //break;
        }
    }

    void reshuffle(GameObject[] texts)
    {
        // Knuth shuffle algorithm :: courtesy of Wikipedia :)
        for (int t = 0; t < texts.Length; t++)
        {
            GameObject tmp = texts[t];
            int r = Random.Range(t, texts.Length);
            texts[t] = texts[r];
            texts[r] = tmp;
        }
    }

    public void ArrangeFruit2()
    {
         level1=false;
         level2=false;
         level3=false;
         level4=false;
         level5 = false;
         level6 = false;
         level7 = false;
         level8 = false;
         level9 = false;
       

        fire1 = false;
        fire2 = false;
        fire3 = false;
        fire4 = false;
        fire5 = false;
        fire6 = false;
        fire7 = false;
        fire8 = false;
        fire9 = false;


        int f = 0;
        for(f = 0; f < existingFruits.Count; f++)
        {
            if (existingFruits[f] != null)
            {
                Destroy(existingFruits[f].gameObject);
            }
        }
        existingFruits.Clear();
        GameObject[] fruitstarts2 = GameObject.FindGameObjectsWithTag("FruitMarker");
        
        reshuffle(fruitstarts2);
        int i = 0;
        int g = 0;
        for (i = 0; i < fruitstarts2.Length; i++)
        {
            if (fruitstarts2[i].transform.parent.name == "Level1" && level1 == false)
            {
                Collider2D[] results = Physics2D.OverlapCircleAll(fruitstarts2[i].transform.position, .3f);

                if (results.Length > 0)
                {



                    //print("said nope");



                }
                else
                {
                    if (!NorpAcademy.easyDone && fruitstarts2[i].name == "fruitmarkereasy")
                    {
                        GameObject newfruit = Instantiate(fruitprefab, fruitstarts2[i].transform.position + new Vector3(Random.Range(-.6f, .6f), Random.Range(-.4f, .4f)), fruitprefab.transform.rotation, gameObject.transform.parent) as GameObject;


                        existingFruits.Add(newfruit);
                        
                        level1 = true;
                    }
                    else
                    {
                        if (NorpAcademy.easyDone && fruitstarts2[i].name != "fruitmarkereasy")
                        {

                            GameObject newfruit = Instantiate(fruitprefab, fruitstarts2[i].transform.position + new Vector3(Random.Range(-.6f, .6f), Random.Range(-.4f, .4f)), fruitprefab.transform.rotation, gameObject.transform.parent) as GameObject;


                            existingFruits.Add(newfruit);
                            level1 = true;
                        }

                    }
                    // if (i != 4)
                    //  {
                    //GameObject[] fruitstarts2 = GameObject.FindGameObjectsWithTag("FruitMarker");
                    // newfruit.transform.position = fruitstarts2[UnityEngine.Random.Range(0, fruitstarts2.Length)].transform.position;
                    //  }

                }
            }
            else
            {
                if (fruitstarts2[i].transform.parent.name == "Level2" && level2 == false)
                {
                    Collider2D[] results = Physics2D.OverlapCircleAll(fruitstarts2[i].transform.position, .3f);

                    if (results.Length > 0)
                    {



                       // print("said nope");



                    }
                    else
                    {

                        if (!NorpAcademy.easyDone && fruitstarts2[i].name == "fruitmarkereasy")
                        {
                            GameObject newfruit = Instantiate(fruitprefab, fruitstarts2[i].transform.position + new Vector3(Random.Range(-.6f, .6f), Random.Range(-.4f, .4f)), fruitprefab.transform.rotation, gameObject.transform.parent) as GameObject;


                            existingFruits.Add(newfruit);
                            level2 = true;
                        }
                        else
                        {
                            if (NorpAcademy.easyDone && fruitstarts2[i].name != "fruitmarkereasy")
                            {

                                GameObject newfruit = Instantiate(fruitprefab, fruitstarts2[i].transform.position + new Vector3(Random.Range(-.6f, .6f), Random.Range(-.4f, .4f)), fruitprefab.transform.rotation, gameObject.transform.parent) as GameObject;


                                existingFruits.Add(newfruit);
                                level2 = true;
                            }

                        }
                        // if (i != 4)
                        //  {
                        //GameObject[] fruitstarts2 = GameObject.FindGameObjectsWithTag("FruitMarker");
                        // newfruit.transform.position = fruitstarts2[UnityEngine.Random.Range(0, fruitstarts2.Length)].transform.position;
                        //  }

                    }
                }
                else
                {
                    if (fruitstarts2[i].transform.parent.name == "Level3" && level3 == false)
                    {
                        Collider2D[] results = Physics2D.OverlapCircleAll(fruitstarts2[i].transform.position, .3f);

                        if (results.Length > 0)
                        {



                           // print("said nope");



                        }
                        else
                        {

                            if (!NorpAcademy.easyDone && fruitstarts2[i].name == "fruitmarkereasy")
                            {
                                GameObject newfruit = Instantiate(fruitprefab, fruitstarts2[i].transform.position + new Vector3(Random.Range(-.6f, .6f), Random.Range(-.4f, .4f)), fruitprefab.transform.rotation, gameObject.transform.parent) as GameObject;


                                existingFruits.Add(newfruit);
                                level3 = true;
                            }
                            else
                            {
                                if (NorpAcademy.easyDone && fruitstarts2[i].name != "fruitmarkereasy")
                                {

                                    GameObject newfruit = Instantiate(fruitprefab, fruitstarts2[i].transform.position + new Vector3(Random.Range(-.6f, .6f), Random.Range(-.4f, .4f)), fruitprefab.transform.rotation, gameObject.transform.parent) as GameObject;


                                    existingFruits.Add(newfruit);
                                    level3 = true;
                                }

                            }
                            // if (i != 4)
                            //  {
                            //GameObject[] fruitstarts2 = GameObject.FindGameObjectsWithTag("FruitMarker");
                            // newfruit.transform.position = fruitstarts2[UnityEngine.Random.Range(0, fruitstarts2.Length)].transform.position;
                            //  }

                        }
                    }
                    else
                    {
                        if (fruitstarts2[i].transform.parent.name == "Level4" && level4 == false)
                        {
                            Collider2D[] results = Physics2D.OverlapCircleAll(fruitstarts2[i].transform.position, .3f);

                            if (results.Length > 0)
                            {



                               // print("said nope");



                            }
                            else
                            {

                                if (!NorpAcademy.easyDone && fruitstarts2[i].name == "fruitmarkereasy")
                                {
                                    GameObject newfruit = Instantiate(fruitprefab, fruitstarts2[i].transform.position + new Vector3(Random.Range(-.6f, .6f), Random.Range(-.4f, .4f)), fruitprefab.transform.rotation, gameObject.transform.parent) as GameObject;


                                    existingFruits.Add(newfruit);
                                    level4 = true;
                                }
                                else
                                {
                                    if (NorpAcademy.easyDone && fruitstarts2[i].name != "fruitmarkereasy")
                                    {

                                        GameObject newfruit = Instantiate(fruitprefab, fruitstarts2[i].transform.position + new Vector3(Random.Range(-.6f, .6f), Random.Range(-.4f, .4f)), fruitprefab.transform.rotation, gameObject.transform.parent) as GameObject;


                                        existingFruits.Add(newfruit);
                                        level4 = true;
                                    }

                                }
                                // if (i != 4)
                                //  {
                                //GameObject[] fruitstarts2 = GameObject.FindGameObjectsWithTag("FruitMarker");
                                // newfruit.transform.position = fruitstarts2[UnityEngine.Random.Range(0, fruitstarts2.Length)].transform.position;
                                //  }

                            }
                        }
                        else
                        {
                            if (fruitstarts2[i].transform.parent.name == "Level5" && level5 == false)
                            {
                                Collider2D[] results = Physics2D.OverlapCircleAll(fruitstarts2[i].transform.position, .3f);

                                if (results.Length > 0)
                                {



                                    //print("said nope");



                                }
                                else
                                {

                                    if (!NorpAcademy.easyDone && fruitstarts2[i].name == "fruitmarkereasy")
                                    {
                                        GameObject newfruit = Instantiate(fruitprefab, fruitstarts2[i].transform.position + new Vector3(Random.Range(-.2f, .2f), Random.Range(-.2f, .2f)), fruitprefab.transform.rotation, gameObject.transform.parent) as GameObject;


                                        existingFruits.Add(newfruit);
                                        level5 = true;
                                    }
                                    else
                                    {
                                        if (NorpAcademy.easyDone && fruitstarts2[i].name != "fruitmarkereasy")
                                        {

                                            GameObject newfruit = Instantiate(fruitprefab, fruitstarts2[i].transform.position + new Vector3(Random.Range(-.2f, .2f), Random.Range(-.2f, .2f)), fruitprefab.transform.rotation, gameObject.transform.parent) as GameObject;


                                            existingFruits.Add(newfruit);
                                            level5 = true;
                                        }

                                    }
                                    // if (i != 4)
                                    //  {
                                    //GameObject[] fruitstarts2 = GameObject.FindGameObjectsWithTag("FruitMarker");
                                    // newfruit.transform.position = fruitstarts2[UnityEngine.Random.Range(0, fruitstarts2.Length)].transform.position;
                                    //  }

                                }
                            }
                            else
                            {
                                if (fruitstarts2[i].transform.parent.name == "Level6" && level6 == false)
                                {
                                    Collider2D[] results = Physics2D.OverlapCircleAll(fruitstarts2[i].transform.position, .3f);

                                    if (results.Length > 0)
                                    {



                                        //print("said nope");



                                    }
                                    else
                                    {

                                        if (!NorpAcademy.easyDone && fruitstarts2[i].name == "fruitmarkereasy")
                                        {
                                            GameObject newfruit = Instantiate(fruitprefab, fruitstarts2[i].transform.position + new Vector3(Random.Range(-.2f, .2f), Random.Range(-.2f, .2f)), fruitprefab.transform.rotation, gameObject.transform.parent) as GameObject;


                                            existingFruits.Add(newfruit);
                                            level6 = true;
                                        }
                                        else
                                        {
                                            if (NorpAcademy.easyDone && fruitstarts2[i].name != "fruitmarkereasy")
                                            {

                                                GameObject newfruit = Instantiate(fruitprefab, fruitstarts2[i].transform.position + new Vector3(Random.Range(-.2f, .2f), Random.Range(-.2f, .2f)), fruitprefab.transform.rotation, gameObject.transform.parent) as GameObject;


                                                existingFruits.Add(newfruit);
                                                level6 = true;
                                            }

                                        }
                                        // if (i != 4)
                                        //  {
                                        //GameObject[] fruitstarts2 = GameObject.FindGameObjectsWithTag("FruitMarker");
                                        // newfruit.transform.position = fruitstarts2[UnityEngine.Random.Range(0, fruitstarts2.Length)].transform.position;
                                        //  }

                                    }
                                }
                                else
                                {
                                    if (fruitstarts2[i].transform.parent.name == "Level7" && level7 == false)
                                    {
                                        Collider2D[] results = Physics2D.OverlapCircleAll(fruitstarts2[i].transform.position, .3f);

                                        if (results.Length > 0)
                                        {



                                           // print("said nope");



                                        }
                                        else
                                        {

                                            if (!NorpAcademy.easyDone && fruitstarts2[i].name == "fruitmarkereasy")
                                            {
                                                GameObject newfruit = Instantiate(fruitprefab, fruitstarts2[i].transform.position + new Vector3(Random.Range(-.2f, .2f), Random.Range(-.2f, .2f)), fruitprefab.transform.rotation, gameObject.transform.parent) as GameObject;


                                                existingFruits.Add(newfruit);
                                                level7fruits++;
                                                if (level7fruits >= 4)
                                                {
                                                    level7fruits = 0;

                                                    level7 = true;
                                                }
                                            }
                                            else
                                            {
                                                if (NorpAcademy.easyDone && fruitstarts2[i].name != "fruitmarkereasy")
                                                {

                                                    GameObject newfruit = Instantiate(fruitprefab, fruitstarts2[i].transform.position + new Vector3(Random.Range(-.2f, .2f), Random.Range(-.2f, .2f)), fruitprefab.transform.rotation, gameObject.transform.parent) as GameObject;


                                                    existingFruits.Add(newfruit);
                                                    level7fruits++;
                                                    if (level7fruits >= 4)
                                                    {
                                                        level7fruits = 0;
                                                        level7 = true;
                                                    }
                                                }

                                            }
                                            // if (i != 4)
                                            //  {
                                            //GameObject[] fruitstarts2 = GameObject.FindGameObjectsWithTag("FruitMarker");
                                            // newfruit.transform.position = fruitstarts2[UnityEngine.Random.Range(0, fruitstarts2.Length)].transform.position;
                                            //  }

                                        }
                                    }
                                    else
                                    {
                                        if (fruitstarts2[i].transform.parent.name == "Level8" && level8 == false)
                                        {
                                            Collider2D[] results = Physics2D.OverlapCircleAll(fruitstarts2[i].transform.position, 1f);

                                            if (results.Length > 0)
                                            {



                                               // print("said nope");



                                            }
                                            else
                                            {

                                                if (!NorpAcademy.easyDone && fruitstarts2[i].name == "fruitmarkereasy")
                                                {
                                                    GameObject newfruit = Instantiate(fruitprefab, fruitstarts2[i].transform.position + new Vector3(Random.Range(-.2f, .2f), Random.Range(-.2f, .2f)), fruitprefab.transform.rotation, gameObject.transform.parent) as GameObject;


                                                    existingFruits.Add(newfruit);
                                                    level8fruits++;
                                                    if (level8fruits >= 4)
                                                    {
                                                        level8fruits = 0;

                                                        level8 = true;
                                                    }
                                                }
                                                else
                                                {
                                                    if (NorpAcademy.easyDone && fruitstarts2[i].name != "fruitmarkereasy")
                                                    {

                                                        GameObject newfruit = Instantiate(fruitprefab, fruitstarts2[i].transform.position + new Vector3(Random.Range(-.2f, .2f), Random.Range(-.2f, .2f)), fruitprefab.transform.rotation, gameObject.transform.parent) as GameObject;


                                                        existingFruits.Add(newfruit);
                                                        level8fruits++;
                                                        if (level8fruits >= 4)
                                                        {
                                                            level8fruits = 0;

                                                            level8 = true;
                                                        }
                                                    }

                                                }
                                                // if (i != 4)
                                                //  {
                                                //GameObject[] fruitstarts2 = GameObject.FindGameObjectsWithTag("FruitMarker");
                                                // newfruit.transform.position = fruitstarts2[UnityEngine.Random.Range(0, fruitstarts2.Length)].transform.position;
                                                //  }

                                            }
                                        }
                                        else
                                        {
                                            if (fruitstarts2[i].transform.parent.name == "Level9" && level9 == false)
                                            {
                                                Collider2D[] results = Physics2D.OverlapCircleAll(fruitstarts2[i].transform.position, 1f);

                                                if (results.Length > 0)
                                                {



                                                   // print("said nope");



                                                }
                                                else
                                                {

                                                    if (!NorpAcademy.easyDone && fruitstarts2[i].name == "fruitmarkereasy")
                                                    {
                                                        GameObject newfruit = Instantiate(fruitprefab, fruitstarts2[i].transform.position + new Vector3(Random.Range(-.2f, .2f), Random.Range(-.2f, .2f)), fruitprefab.transform.rotation, gameObject.transform.parent) as GameObject;


                                                        existingFruits.Add(newfruit);
                                                        level9fruits++;
                                                        if (level9fruits >= 4)
                                                        {
                                                            level8fruits = 0;

                                                            level9 = true;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (NorpAcademy.easyDone && fruitstarts2[i].name != "fruitmarkereasy")
                                                        {

                                                            GameObject newfruit = Instantiate(fruitprefab, fruitstarts2[i].transform.position + new Vector3(Random.Range(-.2f, .2f), Random.Range(-.2f, .2f)), fruitprefab.transform.rotation, gameObject.transform.parent) as GameObject;


                                                            existingFruits.Add(newfruit);
                                                            level9fruits++;
                                                            if (level9fruits >= 4)
                                                            {
                                                                level9fruits = 0;

                                                                level9 = true;
                                                            }
                                                        }

                                                    }
                                                    // if (i != 4)
                                                    //  {
                                                    //GameObject[] fruitstarts2 = GameObject.FindGameObjectsWithTag("FruitMarker");
                                                    // newfruit.transform.position = fruitstarts2[UnityEngine.Random.Range(0, fruitstarts2.Length)].transform.position;
                                                    //  }

                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            //List<GameObject> levels = new List<GameObject>();
            // levels.Add(GameObject.Find("Level1"));
           

           

           // levels.Add(GameObject.Find("Level2"));
           // levels.Add(GameObject.Find("Level3"));
            //levels.Add(GameObject.Find("Level4"));
            
            
            //break;
        }

        GameObject[] firestarts = GameObject.FindGameObjectsWithTag("FireStart");

        GameObject[] fires = GameObject.FindGameObjectsWithTag("Danger");
        foreach (GameObject fb in fires)
        {
            Destroy(fb);
        }

        GameObject fireball1;
        GameObject fireball2;
        GameObject fireball3;
        GameObject fireball4;
        GameObject fireball5;
        GameObject fireball6;
        GameObject fireball7;
        GameObject fireball8;
        GameObject fireball9;


        for (int gu = 0; gu < firestarts.Length; gu++)
        {
            if (firestarts[gu].transform.parent.gameObject.name == "Level1")
            {
                if (!fire1)
                {
                    fireball1 = Instantiate(fireprefab, firestarts[gu].transform.position + new Vector3(Random.Range(-.1f, .1f), Random.Range(-.1f, .1f)), fireprefab.transform.rotation, gameObject.transform.parent) as GameObject;
                    fireball1.gameObject.name = "fireball1";
                    fire1 = true;

                }
                else
                {
                    if (Random.Range(1, 4) == 2)
                    {
                        fireball1 = GameObject.Find("fireball1");
                        if (fireball1 != null && firestarts[gu] != null)
                        {
                            fireball1.transform.position = firestarts[gu].transform.position;

                        }
                        else
                        {
                            fire1 = false;
                        }
                    }
                }
            }
            if (firestarts[gu].transform.parent.gameObject.name == "Level2")
            {
                if (!fire2)
                {
                    fireball2 = Instantiate(fireprefab, firestarts[gu].transform.position + new Vector3(Random.Range(-.1f, .1f), Random.Range(-.1f, .1f)), fireprefab.transform.rotation, gameObject.transform.parent) as GameObject;
                    fire2 = true;
                    fireball2.gameObject.name = "fireball2";


                }
                else
                {
                    if (Random.Range(1, 4) == 2)
                    {
                        fireball2 = GameObject.Find("fireball2");

                        if (fireball2 != null && firestarts[gu] != null)
                        {
                            fireball2.transform.position = firestarts[gu].transform.position;
                        }
                        else
                        {
                            fire2 = false;
                        }
                    }
                }
            }
            if (firestarts[gu].transform.parent.gameObject.name == "Level3")
            {
                if (!fire3)
                {
                    fireball3 = Instantiate(fireprefab, firestarts[gu].transform.position + new Vector3(Random.Range(-.1f, .1f), Random.Range(-.1f, .1f)), fireprefab.transform.rotation, gameObject.transform.parent) as GameObject;
                    fire3 = true;
                    fireball3.gameObject.name = "fireball3";


                }
                else
                {
                    if (Random.Range(1, 4) == 2)
                    {
                        fireball3 = GameObject.Find("fireball3");
                        if (fireball3 != null && firestarts[gu] != null)
                        {
                            fireball3.transform.position = firestarts[gu].transform.position;
                        }
                        else
                        {
                            fire3 = false;
                        }
                    }
                }
            }
            if (firestarts[gu].transform.parent.gameObject.name == "Level4")
            {
                if (!fire4)
                {
                    fireball4 = Instantiate(fireprefab, firestarts[gu].transform.position + new Vector3(Random.Range(-.1f, .1f), Random.Range(-.1f, .1f)), fireprefab.transform.rotation, gameObject.transform.parent) as GameObject;
                    fire4 = true;
                    fireball4.gameObject.name = "fireball4";


                }
                else
                {
                    if (Random.Range(1, 4) == 2)
                    {
                        fireball4 = GameObject.Find("fireball4");
                        if (fireball4 != null && firestarts[gu] != null)
                        {
                            fireball4.transform.position = firestarts[gu].transform.position;
                        }
                        else
                        {
                            fire4 = false;
                        }
                    }
                }
            }
            else
            {
                if (firestarts[gu].transform.parent.gameObject.name == "Level5")
                {
                    if (!fire5)
                    {
                        fireball5 = Instantiate(fireprefab, firestarts[gu].transform.position + new Vector3(Random.Range(-.1f, .1f), Random.Range(-.1f, .1f)), fireprefab.transform.rotation, gameObject.transform.parent) as GameObject;
                        fire5 = true;
                        fireball5.gameObject.name = "fireball5";


                    }
                    else
                    {
                        if (Random.Range(1, 4) == 2)
                        {
                            fireball5 = GameObject.Find("fireball5");

                            if (fireball5 != null && firestarts[gu] != null)
                            {
                                fireball5.transform.position = firestarts[gu].transform.position;
                            }
                            else
                            {
                                fire5 = false;
                            }
                        }
                    }
                }
                else
                {
                    if (firestarts[gu].transform.parent.gameObject.name == "Level6")
                    {
                        if (!fire6)
                        {
                            fireball6 = Instantiate(fireprefab, firestarts[gu].transform.position + new Vector3(Random.Range(-.1f, .1f), Random.Range(-.1f, .1f)), fireprefab.transform.rotation, gameObject.transform.parent) as GameObject;
                            fire6 = true;

                            fireball6.gameObject.name = "fireball6";



                        }
                        else
                        {
                            if (Random.Range(1, 4) == 2)
                            {
                                fireball6 = GameObject.Find("fireball6");
                                if (fireball6 != null && firestarts[gu] != null)
                                {
                                    fireball6.transform.position = firestarts[gu].transform.position;
                                }
                                else
                                {
                                    fire6 = false;
                                }
                            }

                        }
                    }
                    else
                    {
                        if (firestarts[gu].transform.parent.gameObject.name == "Level7")
                        {
                            if (!fire7)
                            {
                                fireball7 = Instantiate(fireprefab, firestarts[gu].transform.position + new Vector3(Random.Range(-.1f, .1f), Random.Range(-.1f, .1f)), fireprefab.transform.rotation, gameObject.transform.parent) as GameObject;
                                fire7 = true;
                                fireball7.gameObject.name = "fireball7";


                            }
                            else
                            {
                                if (Random.Range(1, 4) == 2)
                                {
                                    fireball7 = GameObject.Find("fireball7");
                                    if (fireball7 != null && firestarts[gu] != null)
                                    {
                                        fireball7.transform.position = firestarts[gu].transform.position;
                                    }
                                    else
                                    {
                                        fire7 = false;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (firestarts[gu].transform.parent.gameObject.name == "Level8")
                            {
                                if (!fire8)
                                {
                                    fireball8 = Instantiate(fireprefab, firestarts[gu].transform.position + new Vector3(Random.Range(-.1f, .1f), Random.Range(-.1f, .1f)), fireprefab.transform.rotation, gameObject.transform.parent) as GameObject;
                                    fire8 = true;
                                    fireball8.gameObject.name = "fireball8";


                                }
                                else
                                {
                                    if (Random.Range(1, 4) == 2)
                                    {
                                        fireball8 = GameObject.Find("fireball8");

                                        fireball8.transform.position = firestarts[gu].transform.position;
                                    }
                                }
                            }
                            else
                            {
                                if (firestarts[gu].transform.parent.gameObject.name == "Level9")
                                {
                                    if (!fire9)
                                    {
                                        fireball9 = Instantiate(fireprefab, firestarts[gu].transform.position + new Vector3(Random.Range(-.1f, .1f), Random.Range(-.1f, .1f)), fireprefab.transform.rotation, gameObject.transform.parent) as GameObject;
                                        fire9 = true;
                                        fireball9.gameObject.name = "fireball9";


                                    }
                                    else
                                    {
                                        if (Random.Range(1, 4) == 2)
                                        {
                                            fireball9 = GameObject.Find("fireball4");

                                            fireball9.transform.position = firestarts[gu].transform.position;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
