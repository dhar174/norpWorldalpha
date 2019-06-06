using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSizeChanger : MonoBehaviour {
    public GameObject[] walls;


	// Use this for initialization
	void Start () {
		
	}


   public void WallSizeSmall()
    {
        print("Wall Size Small Activated");
        foreach(GameObject go in walls)
        {
            if (go.transform.localScale.x > go.transform.localScale.y)
            {
                if (go.transform.localRotation.z == 0)
                {
                    //horizontal
                    go.transform.localScale = new Vector2(.2f, go.transform.localScale.y);
                    //print("Scaled HZ");
                }
                else
                {
                   
                        //vertical
                        go.transform.localScale = new Vector2(.2f, go.transform.localScale.y);
                        //print("Scaled rotated VZ");

                    
                }

            }
            else
            {
                if (go.transform.localScale.x < go.transform.localScale.y)
                {

                    if (go.transform.localRotation.z == 0)
                    {
                        //print("Scaled VZ");

                        //vertical
                        go.transform.localScale = new Vector2(go.transform.localScale.x,.2f);
                    }
                    else
                    {
                        
                            //horizontal
                            go.transform.localScale = new Vector2(go.transform.localScale.x, .2f);
                            //print("Scaled rotated HZ");

                        
                    }
                    
                }
            }
        }
    }

    public void WallSizeMed()
    {
        foreach (GameObject go in walls)
        {
            if (go.transform.localScale.x > go.transform.localScale.y)
            {
                if (go.transform.rotation.z == 0)
                {
                    //horizontal
                    go.transform.localScale = new Vector2(.4f, go.transform.localScale.y);
                }
                else
                {
                    
                        //vertical
                        go.transform.localScale = new Vector2(.4f, go.transform.localScale.y);

                    
                }

            }
            else
            {
                if (go.transform.localScale.x < go.transform.localScale.y)
                {

                    if (go.transform.rotation.z == 0)
                    {

                        //vertical
                        go.transform.localScale = new Vector2(go.transform.localScale.x, .4f);
                    }
                    else
                    {
                        
                            //horizontal
                            go.transform.localScale = new Vector2(go.transform.localScale.x, .4f);
                        
                    }

                }
            }
        }
    }

   public void WallSizeLong()
    {
        foreach (GameObject go in walls)
        {
            if (go.transform.localScale.x > go.transform.localScale.y)
            {
                if (go.transform.rotation.z == 0)
                {
                    //horizontal
                    go.transform.localScale = new Vector2(.7f, go.transform.localScale.y);
                }
                else
                {
                    
                        //vertical
                        go.transform.localScale = new Vector2(.7f, go.transform.localScale.y);

                    
                }

            }
            else
            {
                if (go.transform.localScale.x < go.transform.localScale.y)
                {

                    if (go.transform.localScale.x < go.transform.localScale.y)
                    {

                        if (go.transform.rotation.z == 0)
                        {

                            //vertical
                            go.transform.localScale = new Vector2(go.transform.localScale.x, .7f);
                        }
                        else
                        {
                           
                                //horizontal
                                go.transform.localScale = new Vector2(go.transform.localScale.x, .7f);
                            
                        }

                    }

                }
            }
        }
    }

   public void WallSizeMax()
    {
        foreach (GameObject go in walls)
        {
            if (go.transform.localScale.x > go.transform.localScale.y)
            {
                if (go.transform.rotation.z == 0)
                {
                    //horizontal
                    go.transform.localScale = new Vector2(1f, go.transform.localScale.y);
                }
                else
                {
                    
                        //vertical
                        go.transform.localScale = new Vector2(1f, go.transform.localScale.y);

                    
                }

            }
            else
            {
                if (go.transform.localScale.x < go.transform.localScale.y)
                {

                    if (go.transform.localScale.x < go.transform.localScale.y)
                    {

                        if (go.transform.rotation.z == 0)
                        {

                            //vertical
                            go.transform.localScale = new Vector2(go.transform.localScale.x, 1f);
                        }
                        else
                        {
                           
                                //horizontal
                                go.transform.localScale = new Vector2(go.transform.localScale.x, 1f);
                            
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
