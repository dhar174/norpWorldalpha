using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class orthofollow : MonoBehaviour {
    public GameObject playerObject;
    public string tag1=null;
    public float cameraOffsetz = -5.0F;
    public float cameraOffsetx = 0F;
    public float cameraOffsety = 0F;
    //public float camRotOffsetx = 0f;
    //public float camRotOffsety = 0f;
    //public float camRotOffsetz = 0f;
    //public Quaternion cameraRotation = Quaternion.identity;

    void Update()
    {
        if (playerObject!=null)
        {
            if (tag1 == ""|| tag1==null)
            {
                tag1 = playerObject.tag;
            
            }
            Vector3 cameraPosition = new Vector3(playerObject.transform.position.x + cameraOffsetx, playerObject.transform.position.y + cameraOffsety, playerObject.transform.position.z + cameraOffsetz);
            GetComponent<Camera>().transform.position = cameraPosition;
        }
        else
        {
            if (tag1 != "" || tag1 != null)
            {
                playerObject = GameObject.FindGameObjectWithTag(tag1);
            }
            if (playerObject!=null)
            {
                if (playerObject.GetComponent<NorpAgent>())
                {
                    if (playerObject.GetComponent<NorpAgent>().brain == null)
                    {
                        //playerObject.GetComponent<NorpAgent>().GiveBrain(GameObject.Find("NorpAcademy").transform.Find("NorpBrain2").gameObject.GetComponent<MLAgents.Brain>());
                        //print("brain exchanged");
                    }
                }
            }
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            GameObject[] array = GameObject.FindGameObjectsWithTag(tag1);
            int rando = Random.Range(0, array.Length);
            if (array[rando] != playerObject)
            {
                playerObject = array[rando];
            }
            else
            {
                rando++;
                if(rando <= array.Length)
                {
                    playerObject = array[rando];
                }
                else
                {
                    rando--;
                    rando--;
                    playerObject = array[rando];

                }
            }
            Vector3 cameraPosition = new Vector3(playerObject.transform.position.x + cameraOffsetx, playerObject.transform.position.y + cameraOffsety, playerObject.transform.position.z + cameraOffsetz);
            GetComponent<Camera>().transform.position = cameraPosition;

        }
        //cameraRotation.eulerAngles = new Vector3(playerObject.transform.eulerAngles.x + camRotOffsetx, playerObject.transform.eulerAngles.y + camRotOffsety, playerObject.transform.eulerAngles.z + camRotOffsetz);
        //GetComponent<Camera>().transform.rotation = cameraRotation;
        
    }


    
}
