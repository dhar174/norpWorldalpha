using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;
using System.Linq;
using JacksonDunstanIterator;
using UnityEngine.UI;

public class NorpAgent : Agent
{
    [HideInInspector]
    public bool alreadyReset = false;
    public bool firstlvl=false;

    public float rewardedsofar2;

    float id1;
    
    public NorpCounter norpcounter;

    public List<float> newrays = new List<float>();
    public bool lineSight;

    Vector2 dirToGo;
    public bool competitionLevel;

    public bool markedDone;
    public float turnSpeed = 300;
    

    //Speed of agent movement.
    public float moveSpeed;

    public float foodsEaten;

    private NorpAcademy norpAcademy;

   public bool hungry;
    int stepcount;
    bool gotStep;

    public GameObject area;
    public float currentReward;
    public bool useVectorObs;
    RayPerception rayPer;
    
    public Rigidbody2D agentRB;
    Material groundMaterial;
    NorpAcademy academy;

   public int counter;
    
    int selection;

    public bool contribute;
    private bool fullStop=false;
    public float bestScore;
    public int wallcounter=0;

  //  public Transform Target;
    //public string targetType;
    public Vector2 relativePositionToTarget;

    public NorpAI norpAI;

    public float speed;

    public float previousDistance;
    public float timeIndex = 0;
    public int closest=0;

    public bool banUp=false;
    public bool banDown = false;
    public bool banLeft = false;
    public bool banRight = false;

    public bool forceUp = false;
    public bool forceDown = false;
    public bool forceLeft = false;
    public bool forceRight = false;

    public float totalReward;

    Collider2D[] circ;// = Physics2D.OverlapCircleAll(transform.position, 15f);

    public int foodcount = 0;

    // public GameObject[] otherAgents;

    public int blag;
    Vector2 relativeNorpPos;

    public string targetTag;
   // public int isTargetTargetType;

    public float rewardedsofar;
    private fruitSpread fruitspread;
    //float rayDistance = 8f;
   // float[] rayAngles = { 0f, 45f, 90f, 135f, 180f, 110f, 70f };
   // string[] detectableObjects = { "Food", "NPC", "Wall", "Tree" };
   // int detectableObjectsLengt;
   // float[] currentState = new float[2];
    //float[] currentTargetType = new float[detectableObjects.Length];

    public override void InitializeAgent()
    {
        fruitspread = GameObject.Find("FruitSpreader").GetComponent<fruitSpread>();
        // norpAI.currentTarget = null;
        // norpAI.hasTarget = false;
        alreadyReset = false;
        norpAcademy = GameObject.Find("NorpAcademy").GetComponent<NorpAcademy>();
        if (!norpcounter)
        {
            norpcounter = GameObject.Find("ClanOrganizer").GetComponent<NorpCounter>();
        }
        markedDone = IsDone();
        
        base.InitializeAgent();

        id1 = Random.Range(1, 100);
        //foreach(NorpAgent a in transform.parent.GetComponentsInChildren<NorpAgent>())
        // {
        // otherAgents.Add(a);
        //}

        // otherAgents = GameObject.Find("NorpAcademy").GetComponent<NorpAcademy>().agents.ToArray();
        circ = Physics2D.OverlapCircleAll(transform.position, 15f);

        foodcount = 0;
        foreach (Collider2D c2d in circ)
        {
            if (c2d.CompareTag("Food"))
            {
                foodcount++;
                // print("this exists " + c2d.name);
               // if (c2d.transform.parent.name == "Level7")
              //  {
                    //fruitspread.level7fruits++;
               // }
              //  if (c2d.transform.parent.name == "Level8")
               // {
                    //fruitspread.level8fruits++;
               // }
                //if (c2d.transform.parent.name == "Level9")
                //{
                    //fruitspread.level9fruits++;
               // }
            }
            


        }
        if (foodcount == 0)
        {
            GameObject.Find("FruitSpreader").GetComponent<fruitSpread>().ArrangeFruit2();
           // print("manually activated fruit spreader");
        }
        circ = null;
        norpAI = gameObject.GetComponent<NorpAI>();
        norpAI.ClearTarget();
        academy = FindObjectOfType<NorpAcademy>();
        rayPer = GetComponent<RayPerception>();
        agentRB = GetComponent<Rigidbody2D>();
        if (norpAI.CurrentTargetType != null)
        {
            targetTag = norpAI.CurrentTargetType;
        }
        else
        {
            targetTag = "WanderTarget";
        }
        if (speed == 0)
        {
            speed = 1;
        }
        // RequestDecision();
      //  print("Agent initialized");
        //targetType=
        timeIndex = 0;
        RequestDecision();
    }

    private void FixedUpdate()
    {
        rewardedsofar2 += GetReward();
        totalReward = GetCumulativeReward();
         //print(rewardedsofar2);
        
       // if (previousDistance == norpAI.targetDistance)
        //{
         //   RequestDecision();
            //print("Prefart");
        //}
       // if (norpAI.targetDistance > .01 && norpAI.targetDistance < 20)
      //  {
       //     if (norpAI.targetDistance < (previousDistance - .1f))
        //    {
        //        AddReward(.001f);
                //print("fart");
         //       RequestDecision();
         //   }
        //    else
       //     {
        //        if (norpAI.targetDistance > previousDistance)
        //        {
                     //AddReward(-.001f);
        //            RequestDecision();
                   // print("fart");
      //          }
     //       }
     //       if (norpAI.targetDistance < (previousDistance - .01f))
     //       {
      //          if (GetReward() <= 0)
      //          {
      //              if (norpAI.currentNearest != null)
       //             {
       //                 AddReward(0.001f);
       //                 RequestDecision();
                        //print("fart");
        //            }

       //         }
         //   }
    //    }
     //   else
      //  {
        //    if (norpAI.targetDistance > 10)
         //   {
          //      if (norpAI.targetDistance > (previousDistance))
          //      {
                     //AddReward(-.01f);
          //          RequestDecision();
                    //print("fart");

            //    }
            //    else
            //    {
             //       RequestDecision();
                   // print("fart");
             //   }
          //  }
           // else
        //    {
         //       RequestDecision();
            //print("Farticus");
         //  }
       //}
    }

    public override void CollectObservations()
    {
        //print("fart");

        //RequestDecision();
        //RequestAction();
        //System.GC.Collect();
        // using (rayPer)
        //{


        float rayDistance = 8f;
        float[] rayAngles = { 0f, 45f, 90f, 135f, 180f, 110f, 70f };
        string[] detectableObjects = { "Food", "NPC", "Wall", "Tree","Water","Toy","Player","Danger" };
        int detectableObjectsLength;
        float[] currentState = new float[2];
        if (useVectorObs)
            {

                rayDistance = 15f;

           //newrays= gameObject.GetComponent<NewRays>().Perceive(rayDistance, rayAngles, detectableObjects, 0f, 0f);


                detectableObjectsLength = detectableObjects.Length;
                currentState = new float[2];
                float[] currentTargetType = new float[detectableObjectsLength];
               for (int i = 0; i < detectableObjectsLength; i++)
                {
                    currentTargetType[i] = 0;





                    if (targetTag == detectableObjects[i])
                    {
                        currentTargetType[i] = 1;


                    }
                    else
                    {
                        currentTargetType[i] = 0;
                    }

                    if (targetTag == "WanderTarget")
                    {
                        currentTargetType[i] = 0f;
                    }
                }

                //ArrayIterator<float> yup2 = currentTargetType.Begin();
               // float now2 = yup2.GetCurrent();
               // ArrayIterator<float> tecond2 = yup2.GetNext();
              //  ArrayIterator<float> fwinal2 = currentTargetType.End();
              //  tecond2.Reverse(fwinal2);

              //  yup2.ForEach(fwinal2, AddVectorObs);

                //AddVectorObs(currentTargetType);
                





                //currentState[0] = 0;
                //currentState[1] = 0;
                //if (norpAI.state == NorpAI.State.IDLE)
                //{
                    //currentState[0] = 1;
                    //currentState[1] = 0;
                //}

                //if (norpAI.state == NorpAI.State.FORAGING)
                //{
                //    currentState[0] = 0;
               //     currentState[1] = 1;
               // }

              //  ArrayIterator<float> yup3 = currentState.Begin();
             //   float now3 = yup3.GetCurrent();
             //   ArrayIterator<float> tecond3 = yup3.GetNext();
            //    ArrayIterator<float> fwinal3 = currentState.End();
             //   tecond3.Reverse(fwinal3);

            //MAKE SURE TO RE-ENABLE BELOW
            //yup3.ForEach(fwinal3, AddVectorObs);
            // AddVectorObs(currentState);


            Vector2 localVelocity = transform.InverseTransformDirection(agentRB.velocity);
                AddVectorObs(localVelocity.normalized);
            //print(localVelocity.normalized);



            //MAKE SURE TO RE-ENABLE BELOW
            AddVectorObs(rayPer.Perceive(rayDistance, rayAngles, detectableObjects, 0f, 0f));
           



            //print(fart[Random.Range(0,fart.Count-1)]);

            //rayPer.Perceive(rayDistance, rayAngles, detectableObjects, 0f, 0f);
                //print("localVelocity= "+localVelocity+" "+id);
                //currentReward = GetReward();
                //rewardedsofar = GetCumulativeReward();
                //if (this.brain.name == "NorpBrain2")
                //  {
                //AddVectorObs(Mathf.InverseLerp(0, 1, currentReward));
                //AddVectorObs(Mathf.InverseLerp(0, 1, bestScore));
           
                // }

                if (norpAI.currentTarget != null)
                {
                    relativeNorpPos = gameObject.transform.position - norpAI.currentTarget.transform.position;

            }
                else
                {
                    closest = getClosest();
                    if (norpAI.circleListCopy != null)
                    {
                        relativeNorpPos =
                            new Vector2(gameObject.transform.position.x, gameObject.transform.position.y) -
                            new Vector2(norpAI.circleListCopy[closest].transform.position.x,
                                norpAI.circleListCopy[closest].transform.position.y);
                        norpAI.currentTarget = norpAI.circleListCopy[closest].gameObject;
                    }
                    else
                    {
                        relativeNorpPos =
                            new Vector2(gameObject.transform.position.x, gameObject.transform.position.y) -
                            new Vector2(norpAI.wanderTarget.transform.position.x,
                                norpAI.wanderTarget.transform.position.y);
                        //print("oh no cheese");
                    }
                }

                if (norpAI.currentTarget != null)
                {
                    //is closest object used in relative position of the same object type as current target type?
                    blag = 1;

                }
                else
                {
                    if (norpAI.circleListCopy[closest].CompareTag(norpAI.CurrentTargetType))
                    {
                        blag = 1;
                    }
                    else
                    {
                        blag = 0;
                    }
                }

                AddVectorObs(relativeNorpPos.normalized.x);
            AddVectorObs(relativeNorpPos.normalized.y);

            //print("relNorpPos= "+relativeNorpPos.normalized+" "+id1);

            //float targetDirectionX = norpAI.currentTarget.transform.position.x - gameObject.transform.position.x;


            //float targetDirectionY = norpAI.currentTarget.transform.position.y - gameObject.transform.position.y;

            //print(id+" X="+Mathf.InverseLerp(-1, 1, targetDirectionX / 10));
            //print(id+" Y="+Mathf.InverseLerp(-1, 1, targetDirectionY / 10));



            //print(Mathf.Clamp(targetDirectionX/10,-1,1));
            // print(Mathf.Clamp(targetDirectionY / 10, -1, 1));

            //AddVectorObs(Mathf.InverseLerp(-1,1, targetDirectionX / 10));
            //AddVectorObs(Mathf.InverseLerp( -1, 1, targetDirectionY / 10));


            //print(relativeNorpPos.normalized);
            AddVectorObs(blag);
                if (norpAI.currentTarget != null)
                {
                    AddVectorObs(norpAI.targetRelativePosition.normalized);
                    relativePositionToTarget = norpAI.targetRelativePosition;
                    targetTag = norpAI.currentTarget.tag;
                    //print("targetRelPos= "+norpAI.targetRelativePosition.normalized+ " " + "" + id);
                    //AddVectorObs(norpAI.targetRelativePosition.y);
                }
                else
                {
                    closest = getClosest();
                    if (norpAI.circleListCopy != null)
                    {
                        if (targetTag != null)
                        {
                            if (norpAI.circleListCopy[closest].CompareTag(targetTag))
                            {
                                Vector2 closestRelativePosition =
                                    new Vector2(norpAI.circleListCopy[closest].transform.position.x,
                                        norpAI.circleListCopy[closest].transform.position.y) -
                                    new Vector2(this.gameObject.transform.position.x,
                                        this.gameObject.transform.position.y);
                                AddVectorObs(closestRelativePosition.normalized);
                                //AddVectorObs(closestRelativePosition.y);
                                //print(closestRelativePosition+" " + "" +id);
                                norpAI.currentTarget = norpAI.circleListCopy[closest].gameObject;
                                    relativePositionToTarget= closestRelativePosition;
                        }
                            else
                            {
                                Vector2 wanderspot = norpAI.circleListCopy[closest].transform.position - gameObject.transform.position;
                                AddVectorObs(wanderspot.normalized);
                                // targetTag = "WanderTarget";
                                norpAI.currentTarget = norpAI.wanderTarget.gameObject;
                                relativePositionToTarget = wanderspot;
                            }
                        }
                        else
                        {
                            Vector2 wanderspot = norpAI.circleListCopy[closest].transform.position-gameObject.transform.position;
                            AddVectorObs(wanderspot.normalized);
                            // targetTag = "WanderTarget";
                            norpAI.currentTarget = norpAI.wanderTarget.gameObject;
                        relativePositionToTarget = wanderspot;


                        }
                    }
                    else
                    {
                        //targetTag = "WanderTarget";

                        Vector2 wanderspot = norpAI.circleListCopy[closest].transform.position;
                        AddVectorObs(wanderspot.normalized);
                        norpAI.currentTarget = norpAI.wanderTarget.gameObject;
                        relativePositionToTarget = wanderspot;


                    }

                }

                closest = getClosest();
            if (norpAI.circleListCopy[closest].CompareTag(targetTag))
            {
                AddVectorObs(1);

            }
            else
            {
                if(norpAI.circleListCopy[closest].CompareTag("Wall") || norpAI.circleListCopy[closest].CompareTag("Danger"))
                {
                    AddVectorObs(-1);
                }
                else
                {
                    AddVectorObs(0);
                }
            }

            //if (norpAI.currentTarget != null)
            //{
            //    if (norpAI.currentTargetTag == targetTag)
            //    {
            //        isTargetTargetType = 1;
            //        AddVectorObs(isTargetTargetType);
            //    }
            //     else
            //     {

            //         isTargetTargetType = 0;
            //         AddVectorObs(isTargetTargetType);
            //     }
            // }
            // else
            //   {
            //       isTargetTargetType = 0;
            //       AddVectorObs(isTargetTargetType);

            //   }

            

                
                norpAI.TargetDistances();

            AddVectorObs(Mathf.InverseLerp(0, 1, previousDistance / 10));
            //print(Mathf.InverseLerp(0, 1, norpAI.targetDistance / 10));
            AddVectorObs(Mathf.InverseLerp(0, 1, norpAI.targetDistance / 10));
            Vector2 direction = relativePositionToTarget / norpAI.targetDistance;
            AddVectorObs(direction.normalized.x);
            AddVectorObs(direction.normalized.y);
            //print(direction.normalized);

            // ArrayIterator<Vector2> yup4 = norpAI.tVectors.Begin();
            //  Vector2 now4 = yup4.GetCurrent();
            // ArrayIterator<Vector2> tecond4 = yup4.GetNext();
            //  ArrayIterator<Vector2> fwinal4 = norpAI.tVectors.End();
            //  tecond4.Reverse(fwinal4);

            //yup4.ForEach(fwinal4, AddVectorObs);

            // foreach (Vector2 v2 in norpAI.tVectors)
            // {
            //    AddVectorObs(v2.normalized);
            //print(v2.normalized);
            //  }

            // ArrayIterator<float> yup5 = norpAI.distances.Begin();
            // float now5 = yup5.GetCurrent();
            // ArrayIterator<float> tecond5 = yup5.GetNext();
            // ArrayIterator<float> fwinal5 = norpAI.distances.End();
            // tecond5.Reverse(fwinal5);

            //MAKE SURE TO RE-ENABLE BELOW
            //yup5.ForEach(fwinal5, AddVectorObs);



            //    ArrayIterator<Vector2> yup6 = norpAI.tDirections.Begin();
            //       Vector2 now6 = yup6.GetCurrent();
            //        ArrayIterator<Vector2> tecond6 = yup6.GetNext();
            //       ArrayIterator<Vector2> fwinal6 = norpAI.tDirections.End();
            //      tecond6.Reverse(fwinal6);

            //yup6.ForEach(fwinal6, AddVectorObs);

            // foreach (Vector2 v in norpAI.tDirections)
            // {
            //   AddVectorObs(v.normalized);
            // print(v.normalized);
            //}
            //firstlvl = norpAcademy.firstlvl;

            // if (firstlvl)
            // {
            //  if (timeIndex >= 600)
            //  {
            //this.Done();
            // }
            // }

            AddVectorObs(timeIndex / 2500);
            //print(timeIndex/2500);
                //AddVectorObs(0f);

            }

        
    }

    public int getClosest()
    {
        Vector2 tMin;
        float minDist = Mathf.Infinity;
        Vector2 currentPos = transform.position;
        int index=-1;
        foreach (Collider2D f in norpAI.circleListCopy)
        {


            index++;
            if (f != null)
            {
                float dist = Vector2.Distance(f.transform.position, currentPos);
                if (dist < minDist)
                {
                    tMin = f.transform.position;
                    minDist = f.gameObject.transform.position.sqrMagnitude;
                }
            }
            
            
            //directionAvg = intDirection;
            //StartCoroutine(WaitForDirection());

            // print("Found nearest");
            return index;
        }
       

            return index;
    }

    public void MoveAgent(float[] act)
    {
        //print(act[0]);
        //print(act[1]);
        //print(act[2]);
        //print(act[3]);
        //print(act[4]);
        //print(act[5]);

        if (norpAI.CurrentTargetType != null)
        {
            targetTag = norpAI.CurrentTargetType;
        }
        else
        {
            targetTag = "WanderTarget";
        }
        if (banUp)
        {
            //SetActionMask(0,0);

        }
        if (banRight)
        {
            //SetActionMask(0,3);
           // print("ban right");
        }
        if (banLeft)
        {
            //SetActionMask(0,2);
        }
        if (banDown)
        {
            //SetActionMask(0,1);
            //print("banned down");
        }
        if (forceUp)
        {
            //SetActionMask(0, 2);
            //SetActionMask(0, 4);
        }
        if (forceRight)
        {
            //SetActionMask(0,2);
            //SetActionMask(0, 4);

            //print("force right");
        }
        if (forceLeft)
        {
            //SetActionMask(0,3);
            //SetActionMask(0, 4);

        }
        if (forceDown)
        {
            //SetActionMask(0,0);
            //SetActionMask(0, 4);

        }
       
        //Vector2 rotateDir = Vector3.zero;
        agentRB.constraints = RigidbodyConstraints2D.None;
        
          
                switch ((int)act[0])
                {
                    case 1:
                        dirToGo = Vector2.up;
                     moveSpeed = speed;
                    fullStop = false;
                //print("Moved up");
                    //  moved();

                    break;
                    case 2:
                    dirToGo = -Vector2.up;
                    moveSpeed = speed;
                    fullStop = false;
                //print("Moved down");

                //  moved();

                break;
                    case 3:
                    dirToGo = -Vector2.right;
                    moveSpeed = speed;
                    fullStop = false;
                // moved();
                //print("Moved left");


                break;
                    case 4:
                    dirToGo = Vector2.right;
                    moveSpeed = speed;
                    //moved();
                    fullStop = false;
                //print("Moved right");


                break;
                    case 5:
                    dirToGo = Vector2.zero;
                    moveSpeed = 0;
                    //stopped();
                    fullStop = true;
                //print("Stopped momentarily");


                break;

                    
                    
            
                }

        switch ((int)act[1])
        {
            
            case 1:
                speed = .1f;
                break;
            case 2:
                speed = .5f;
                break;
            case 3:
                speed = 1f;
                break;
            case 4:
                speed = 1.5f;
                break;
            case 5:
                speed = 2f;
                break;
            
            


        }


        if (!fullStop)
        {
            agentRB.constraints = RigidbodyConstraints2D.None;
            agentRB.constraints = RigidbodyConstraints2D.FreezeRotation;

            agentRB.AddForce(dirToGo * moveSpeed, ForceMode2D.Force);
            

        }
        else
        {
            agentRB.constraints = RigidbodyConstraints2D.FreezeAll;
            agentRB.velocity.Set(0, 0);
            

        }

        //transform.Rotate(rotateDir, Time.fixedDeltaTime * turnSpeed);


        if (agentRB.velocity.sqrMagnitude > 2f) // slow it down
        {
            agentRB.velocity *= 1.98f;
        }
        norpAI.velocity = agentRB.velocity;
        if (counter == 0)
        {
            previousDistance = norpAI.targetDistance;
        }

        if (norpAI.velocity.sqrMagnitude > 10)
        {
            
            agentRB.velocity *= .5f;
            //this.Done();
        }

        counter++;


        timeIndex++;
        if (norpAI.currentTarget != null)
        {
            if (counter == 100)
            {
                //print(norpAI.targetDistance);
                // if (norpAI.targetDistance > .001f && norpAI.targetDistance < 20)
                //{
           
                if (lineSight) {
                    if (norpAI.targetDistance < (previousDistance - 10f))
                    {
                        AddReward(.1f);
                        previousDistance = norpAI.targetDistance;
                    // print("10 closer to prv");
                     //print(id+"Rewarded " + GetReward()+" "+rewardedsofar2);
                    }
                    else
                    {
                        if (norpAI.targetDistance > previousDistance + 9f)
                        {
                            AddReward(-.15f);
                            previousDistance = norpAI.targetDistance;
                            //print("10 away from prv");
                            //print(id+"Punished" + GetReward()+" " + rewardedsofar2);
                            //RequestDecision();
                        }
                        else
                        {
                            if (norpAI.targetDistance < (previousDistance - 5f))
                            {
                                AddReward(.01f);
                                previousDistance = norpAI.targetDistance;
                                //print("5 closer to prv");
                                //print(id + "Rewarded " + GetReward() + " " + rewardedsofar2);
                            }
                            else
                            {
                                if (norpAI.targetDistance > previousDistance + 4f)
                                {
                                    AddReward(-.02f);
                                    previousDistance = norpAI.targetDistance;
                                    //print("5 away from prv");
                                    // print(id + "Punished" + GetReward()+" " + rewardedsofar2);

                                    //RequestDecision();
                                }
                                else
                                {
                                    if (norpAI.targetDistance < (previousDistance - 1.2f))
                                    {
                                        AddReward(.001f);
                                        previousDistance = norpAI.targetDistance;
                                        //print("1 closer to prv");
                                        // print(id + "Rewarded " + GetReward()+" " + rewardedsofar2);
                                    }
                                    else
                                    {
                                        if (norpAI.targetDistance > previousDistance + .8f)
                                        {
                                            AddReward(-.002f);
                                            previousDistance = norpAI.targetDistance;
                                            //print("1 away from prv");
                                            //print(id + "Punished" + GetReward()+" " + rewardedsofar2);
                                            //RequestDecision();
                                        }
                                        else
                                        {

                                            //  if (norpAI.targetDistance < (previousDistance))
                                            //  {
                                            //     AddReward(.0001f);
                                            //  previousDistance = norpAI.targetDistance;
                                            //print(id + "Rewarded " + GetReward());

                                            //  }
                                            // else
                                            // {
                                            if (norpAI.targetDistance > previousDistance)
                                            {
                                                AddReward(-.0001f);
                                                previousDistance = norpAI.targetDistance;

                                                //print(id + "Punished" + GetReward());
                                                //RequestDecision();
                                            }

                                            // }

                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            

            
            //var heading = norpAI.currentTarget.transform.position - gameObject.transform.position;
            //var distance = heading.magnitude;
            //var direction = heading / distance; // This is now the normalized direction.

            //print(distance);
            if (norpAI.targetDistance< (previousDistance - 1f))
                    {
                        if (GetReward() < 0)
                        {
                            AddReward(0.001f);
                   // print(id + "Rewarded " + GetReward());
                    //print("farts");
                    // RequestDecision();

                        }
            }
               
              //  else
              //  {
               //     if (norpAI.targetDistance > 20)
                //    {
                  //     if (norpAI.targetDistance > (previousDistance))
                  //     {
                    //        previousDistance = norpAI.targetDistance;

                    //       AddReward(-.001f);
                          // print("More than 20 away and moving farther");
                        //RequestDecision();

                    //    }
                   // }
               // }
            //print(gameObject.name + " rew= " + GetReward() + " cumRew= " + GetCumulativeReward());
            //timeIndex = 0;
             //}
        }
        else
        {
            //RequestDecision();
            if (wallcounter < 2)
            {
                if (!fullStop)
                {
                   // AddReward(+.0006f);
                }
            }
        }

        if (counter >= 10)
        {
            // RequestDecision();   
            //banUp = false;
            //banRight = false;
            //banLeft = false;
            //banRight = false;
            //forceDown = false;
            //forceLeft = false;
            //forceRight = false;
            //forceUp = false;


            circ = Physics2D.OverlapCircleAll(transform.position, 15f);

            foodcount = 0;
            foreach (Collider2D c2d in circ)
            {
                if (c2d.CompareTag("Food"))
                {
                    foodcount++;
                    // print("this exists " + c2d.name);
                    // if (c2d.transform.parent.name == "Level7")
                    //  {
                    //fruitspread.level7fruits++;
                    // }
                    //  if (c2d.transform.parent.name == "Level8")
                    // {
                    //fruitspread.level8fruits++;
                    // }
                    //if (c2d.transform.parent.name == "Level9")
                    //{
                    //fruitspread.level9fruits++;
                    // }
                }



            }
            counter = 0;
            if (foodcount == 0)
            {
                if (norpAI.TargetTRAINING)
                {
                    print("done cuz food=0");
                    this.Done();
                }
            }
        }
    }

   public void WanderReward()
    {
        //AddReward(.001f);
    }

    public void moved()
    {
        //AddReward(.1f);
    }

    public void stopped()
    {
        //AddReward(.2f);
    }

    public void Level4Lost()
    {
        //AddReward(-1f);
        //this.Done();
    }

    public void AteFood(GameObject food)
    {
        NorpAcademy.pointTracker++;
        
        AddReward(.1f);
        //print(gameObject.name + " ate Food");
        norpAI.poopCount++;
        foodcount--;
        foodsEaten++;
        
        if (competitionLevel)
        {
            string thisname = gameObject.name;
            GameObject.Find("Canvas").transform.Find(thisname).GetComponent<Text>().text = thisname +": " + foodsEaten;
        }
        
        //if (currentReward <= 0)
        // {
        //SetReward(.1f);
        // }

        

        if (food==norpAI.currentTarget)
        {
            AddReward(3f);
            AddReward(1 * (timeIndex * -.001f));
            //print("Got 1 point for getting target" + GetCumulativeReward());
            if (contribute)
            {
                academy.totalScore += 1;
            }
        }

        AddReward(Mathf.InverseLerp(0, 1, timeIndex) + (.1f * foodsEaten));
        
        //AddReward(Mathf.Lerp(0, 200, timeIndex) + (1 * foodsEaten));
        //print(Mathf.InverseLerp(0, 200, timeIndex) + (1 * NorpAcademy.level));
        //
        //SetReward(foodsEaten);
        //print("Received " + (Mathf.InverseLerp(0, 1, timeIndex) + (.1 * foodsEaten)) + "for eating fruit with time index "+timeIndex+" cum rew="+GetCumulativeReward());
        
       
       // print(gameObject.name+ Mathf.InverseLerp(0, 200, timeIndex));
        //print(gameObject.name + " rew= " + GetReward() + " cumRew= " + GetCumulativeReward());
        if (contribute)
        {
            academy.totalScore += Mathf.RoundToInt(GetReward());
        }

        if (norpAI.TargetTRAINING)
        {
            if (norpAcademy.resetParameters["level"] == 4)
            {
                if (norpAcademy.firstwin == false)
                {
                    AddReward(10f);

                    norpAcademy.firstwin = true;
                }
                // foreach(GameObject g in norpAcademy.currentAgents)
                // {
                // if (g != this.gameObject)
                // {
                // g.GetComponent<NorpAgent>().Level4Lost();
                //}
                // }
                //this.Done();
            }

            //AddReward(-.1f * foodcount);
            //print("agent done, received punishment of "+ -.1f * foodcount+"for fruits missed");

            if (foodcount == 0)
            {
                //NorpAcademy.level++;
                AddReward(1000 / (timeIndex + 10) * (foodsEaten));
                 //print("Received " + (30 / (timeIndex + 10) + (foodsEaten)) + "for eating last fruit");
                // print("No Food Left");

                

                // print("finished at timeindex= " + timeIndex);
                


                
                    //AddReward(10);
                // print(id1+"Won! " + rewardedsofar2 + " " + totalReward);

                    this.Done();
                //Fin();
            }
        }

        timeIndex = 0;
        //this.Done();

    }

    public void GetData()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(targetTag))
        {
            
            print("Got 1 point for getting object with target tag");
            AddReward(.1f);
        }
        

        if (other.gameObject == norpAI.currentTarget)
        {
            AddReward(1f);
            print("Got 1 point for getting target");
            if (contribute)
            {
                academy.totalScore += 1;
            }
        }
    }



    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {

           AddReward(.01f);

            print("Got .01 point for getting food");
            if (contribute)
           {
               //academy.totalScore += 1;
           }
        }

        if (collision.gameObject.CompareTag(targetTag))
        {
            print("Got .01 point for getting object with target tag");
            AddReward(.01f);
        }
        else
        {
            //AddReward(-.001f);
        }

        if (collision.gameObject == norpAI.currentTarget)
        {
            AddReward(1f);
            print("Got 1 point for getting target");
            if (contribute)
            {
                academy.totalScore += 1;
            }
        }
        

        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Danger"))
        {

            wallcounter++;
            if (GetCumulativeReward() > 0)
            {
                //SetReward(0);
            }
            //AddReward(wallcounter * -.1f);
            //AddReward(-1f);
           //AddReward(-1*NorpAcademy.level);
            if (contribute)
            {
                academy.totalScore -= 1;
            }
            //print("hit wall "+GetCumulativeReward());
            // NorpAcademy.level = 0;
            //if (wallcounter > 10)
            //{
           
                AddReward(-1f * (1000/timeIndex));

            if (norpAI.TargetTRAINING)
            {
                this.Done();
            }
            
            
            //}
            //Fin();

        }
        if (collision.gameObject.CompareTag("NPC"))
        {


            AddReward(-.001f);
            if (contribute)
            {
               // academy.totalScore -= 1;
            }
        }
        if (collision.gameObject.CompareTag("Tree"))
        {


            //AddReward(-.01f);
            if (contribute)
            {
                //academy.totalScore -= 1;
            }
            //print("hit wall");
            //this.Done();
        }
    }
    
    public override void AgentAction(float[] vectorAction, string textAction)
    {
        //print(vectorAction[0]);
        MoveAgent(vectorAction);
       // var bested = 0;
        
        if (bestScore <= 0)
        {
            if (GetCumulativeReward() >= bestScore+1)
            {
                bestScore = GetCumulativeReward();
                //this.Done();
            }
        }
        
        if (norpAI.CurrentTargetType != null)
        {
            targetTag = norpAI.CurrentTargetType;
        }
        else
        {
            targetTag = "WanderTarget";
        }
        if (GetCumulativeReward() >= bestScore+1)
        {
            //AddReward(.1f);
            if (contribute)
            {
                //academy.totalScore += 1;
            }
            bestScore = GetCumulativeReward();
          //  print("best score gotten "+ GetCumulativeReward());
           // print("best was " + bestScore);
            //this.Done();
        }
        else
        {
            
        }
        if(norpAI.hunger <=0)
        {
            hungry = true;

            
        }
        if (norpAI.hunger > 0)
        {
            hungry = false;
        }
        if (norpAI.hunger >= norpAI.hungerThreshold)
        {
            //AddReward(+1);
            timeIndex = 0;
            //this.Done();
        }
        if (hungry)
        {
            if (previousDistance < norpAI.targetDistance)
            {
                stepcount++;
            }
            //gotStep = true;
        }
        if (!hungry)
        {
            stepcount = 0;
            
        }
        if (stepcount > 200)
        {
            AddReward(-.001f);
            stepcount = 1;
            //print("stepcount punished");
            //this.Done();
        }
       // if (GetCumulativeReward() == GetValueEstimate())
       // {
       //     AddReward(.001f);
       // }
      //  if (GetCumulativeReward() > GetValueEstimate() + 1)
      //  {
      //      AddReward(.001f);
      //  }
      //  if (GetCumulativeReward() < GetValueEstimate() - 2)
     //   {
      //      AddReward(-.001f);
      //  }
        //print("Acted" + vectorAction);
        if (wallcounter == 5)
        {
            
            AddReward(-1f);
            if (contribute)
            {
                //academy.totalScore -= 1;
            }
            //wallcounter = 0;
           // this.Done();

        }
        
        
       // print(gameObject.name+" Cumulative= "+GetCumulativeReward());
       // print(gameObject.name + " Current= " +GetReward());
        
    }

    public void Fin()
    {
        currentReward = GetCumulativeReward();
        //int dd = 0;
        for( int g=0;g < norpAcademy.agents.Count;g++)
        {
            if (norpAcademy.agents[g] == this.gameObject)
            {
                norpAcademy.points.Add(currentReward);
                
            }
            //dd++;
        }

        //print("Fin ran");

        
        markedDone = true;
        timeIndex = 0;
        //base.AgentReset();
        //InitializeAgent();
        norpAcademy.FinishAgentAndWait(this.gameObject);
       
        
    }
    

  public override void AgentReset()
   {
       //print("Agent reset");
        timeIndex = 0;
        wallcounter = 0;
        markedDone = IsDone();
        norpAI.ClearTarget();
       base.AgentReset();
        //GameObject.Find("NorpAcademy").GetComponent<NorpAcademy>().Done();
        //InitializeAgent();
    }

    

    public override void AgentOnDone()
    {
        //Fin();
        wallcounter = 0;
        

       // print("finished at timeindex= " + timeIndex);
        //print("agent done, received punishment of "+ -.1f * foodcount+"for fruits missed");

       

        norpAcademy.agentsDestroyed++;
        
       // Destroy(this.gameObject);
        //print("destroyed" + gameObject.name);

        if (norpAcademy.currentAgents.Contains(this.gameObject))
        {
           norpAcademy.currentAgents.Remove(this.gameObject);
            norpAcademy.agents.Remove(this.gameObject);
        }

        // norpAcademy.agentsDestroyed++;





        if (norpAcademy.agentCount != 0 && norpAcademy.agentsDestroyed != 0)
        {
            if (norpAcademy.agentsDestroyed == norpAcademy.agentCount)
            {
                // print("norpnum is 0");
                if (!alreadyReset)
                {
                    if (!norpAcademy.norpisZero)
                    {
                        if (!norpAcademy.alreadyReset)
                        {
                            //norpAcademy.norpisZero = true;
                            norpAcademy.Done();
                            alreadyReset = true;

                            // print("reset from Agent with destroyed=" + norpAcademy.agentsDestroyed + " and count=" + norpAcademy.agents.Count);
                            //print("finished at timeindex= " + timeIndex);
                        }
                    }
                }
            }
        }

       

            //Destroy(this.gameObject);
         
        Destroy(this.gameObject);
    }
}
