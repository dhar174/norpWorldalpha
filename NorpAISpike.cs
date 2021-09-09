using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

using Unity.MLAgents;
using JacksonDunstanIterator;

//using System.Reflection;
//using System.Reflection.Emit;

public class NorpAISpike : MonoBehaviour {
    public float wanderRadius;

    public bool TargetTRAINING;

    public bool wanderLine=false;

    public GameObject wanderTargetPrefab;
    public GameObject wanderTarget;
    public float stopDist;

    private Calendar calendar;

    public RayPerceptionSpike rayPer;

    public int timeCounter1;
    public int timeCounter2;

    public bool angry;
    public bool scared;
    public bool moping;
    public bool hasPlayPartner;
    public bool hasMatingPartner;


    public ClanOrganizer clans;
    // public List<Transform> targetListref ;


    public string currentTargetTag;

    public float hunger;
    public float hungerTime;
    public float hungerThreshold;
    public float hungerIncrement;

    public float horniness;
    public float breedingThreshold1;
    public float breedingThreshold2;
    public float[] breedingTiming;
    public float[] hornyFactors;

    public float sadStart;
    public float sadness;
    public float sadThreshold;

    public float angerStart;
    public float anger;
    public float angerThreshold;

    public int poopCount;
    public int poopThreshold;
    public GameObject poopPrefab;
    public bool justPooped;
    public AudioClip poopSound;
    public bool poopyprints;

    public bool justFellAsleep;

    public GameObject currentTarget;
    public bool hasTarget = false;
    public enum State
    {
        IDLE,
        FORAGING,
        LONELY, //SEEKING FRIENDS
        PLAYFUL,
        SLEEPING,
        THIRSTY,
        RELAXING,
        HORNY,
        MOPING,
        ANGRY,
        FLEEING,
        EXPLORING
    }
    public State state;

    public string CurrentTargetType;

    public bool openToPlay;
    public bool isBored;
    public float boredom;
    public float boredomThreshhold;
    public bool isplaying;

    public bool testing;
    public bool alive;
    public bool moving;
    private GameObject storedTarget;

    private bool OKtoContinue;
    public GameObject hitbObject;
    private bool dontCheckRays;
    private bool check2;
    public bool noObstacle;
    public bool holdOnce;
    public bool canDetect = true;
    public bool isAddingFriendship;
    private bool cantTurn;
    private Vector2 direction;
    private int count2;
    private Vector2 sum2;
    private Vector2 avgVelocity;


    public Vector2 velocity;
    public float speed;
    public Rigidbody2D rb;
    public Animator anim;
    public List<GameObject> foods = new List<GameObject>();
    public float toSubtract;
    public AudioSource audiosource;

    int rando;

    public bool waiting;
    public bool gotRando;
    public bool canseek;

    public float SleepTime;
    public float SleepNeed;
    public float SleepIncrement;
    public float SleepThreshold;

    public float friendship;
    public float friendshipNeed;

    public List<GameObject> friends = new List<GameObject>(25);
    public float friendDistance;
    public float friendSatiety;
    public float friendsNearbyNum;
    public int friendshipTime;

    public Transform currentNearest;
    public float maxVelocity;

    public float thirst;
    public float thirstThreshold;
    public float thirstCounter;
    public float thirstTimer;
    public float thirstIncrement;
    public bool isThirsty;

    public Vector2 targetRelativePosition;
    public float targetDistance;
    public float[] distances;
    private Vector2[] tVectors;
    public Vector2[] tDirections;

    public int counterSleeping;

    public List<Collider2D> circleListCopy = new List<Collider2D>();

    public float pain;

    public float sadmadRatio;

    public float exploration;
    public float explorationThreshold;
    public Vector2 expStartPos;

    private float originalSleepThr;
    private float originalExpThr;
    private float originalSadThr;
    private float originalAngerThr;


    private FrontalLobeAgent flAgent;

    public int timetilcount;
    public List<Transform> targetList= new List<Transform>();
    private void Awake()
    {
        //targetList = FindNearestTenTransforms();
        rayPer = gameObject.GetComponent<RayPerceptionSpike>();

    }
    // Use this for initialization
    void Start () {
        expStartPos = this.gameObject.transform.position;
        exploration = 0;
        if (gameObject.GetComponent<FrontalLobeAgent>())
        {
            flAgent = gameObject.GetComponent<FrontalLobeAgent>();
        }
        if (thirstThreshold == 0)
        {
            thirstThreshold = Random.Range(1000, 6000);
        }
        if (thirstIncrement == 0)
        {
            thirstIncrement = Random.Range(.1f, 2);
        }
        if (thirstTimer == 0)
        {
            thirstTimer = Random.Range(100, 600);
        }
        if (explorationThreshold == 0)
        {
            explorationThreshold = Random.Range(50, 500);
        }
        if (!calendar)
        {
            calendar = GameObject.Find("Calendar").GetComponent<Calendar>();
        }
        sadmadRatio = Random.Range(.001f, .99f);
        breedingTiming = new float[] {Random.Range(1,12),Random.Range(1,30) };
        hornyFactors = new float[] { Random.Range(1, 60), Random.Range(60, 120) };

        if (SleepThreshold == 0)
        {
            SleepThreshold = Random.Range(800, 1400);
        }

        if (breedingThreshold1 == 0)
        {
            breedingThreshold1 = Random.Range(40, 100);
        }
        if (breedingThreshold2 == 0)
        {
            breedingThreshold1 = Random.Range(101, 120);
        }
        poopCount = 0;
        if (poopThreshold == 0)
        {
            poopThreshold = Random.Range(5, 15);
        }

        if (!clans)
        {
            clans = GameObject.Find("ClanOrganizer").GetComponent<ClanOrganizer>();
        }

        if (hungerIncrement == 0)
        {
            hungerIncrement = Random.Range(2.000f, 0.001f);
        }
        if (SleepIncrement == 0)
        {
            SleepIncrement = Random.Range(2.000f, 0.1f);
        }
        alive = true;
        gotRando = false;
        anim = gameObject.GetComponentInChildren<Animator>();
        //targetListref = rayPer.CurrentTargetTypeList;
        if (boredomThreshhold == 0)
        {
            boredomThreshhold = Random.Range(80, 200);
        }
        boredom = 0;
        if (hungerThreshold == 0)
        {
            hungerThreshold = Random.Range(40, 75);
        }
        if (friendshipNeed == 0)
        {
            friendshipNeed = Random.Range(100, 1001);
        }
        if (friendDistance == 0)
        {
            friendDistance = Random.Range(2, 9);
        }
        if (friendSatiety == 0)
        {
            friendSatiety = Random.Range(1, 8);
            if (friendSatiety > 5)
            {
                int randomindex = Random.Range(0, 2);
                if (randomindex == 1)
                {
                    int randomint = Random.Range(1, 6);
                    friendSatiety = friendSatiety - randomint;
                }
            }
        }
        if (friendshipTime == 0)
        {
            friendshipTime = Random.Range(500,2000);

        }
        
        if (wanderRadius == 0)
        {
            wanderRadius = Random.Range(5, 20);
        }
        audiosource = gameObject.GetComponent<AudioSource>();
        if (hunger == 0)
        {
            hunger = Random.Range(80, 150);
        }
       //FillFoodList();
       // FillFriendsList();
        if (maxVelocity == 0)
        {
            maxVelocity = 40;
        }
        if (hungerTime == 0)
        {
            hungerTime = 5;
        }

        StartCoroutine(HungerTimer());
        //agent = gameObject.GetComponent<NavMeshAgent>();

        rb = gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine("FSM");

       // StartCoroutine(FriendshipMeter());
       // StartCoroutine(CountFriends());
        if (friendship == 0)
        {
            friendship = friendshipNeed + Random.Range(10, 200);
        }
        //StartCoroutine(CheckDirection());
        if (SleepNeed == 0)
        {
            SleepNeed = Random.Range(30, 240);
        }
        if (SleepTime == 0)
        {
            SleepTime = Random.Range(240, 1200);
        }
        originalExpThr = explorationThreshold;
        originalSleepThr = SleepThreshold;
        originalSadThr = sadThreshold;
        originalAngerThr = angerThreshold;

        //StartCoroutine(SleepTimer());
       // StartCoroutine(BoredomTimer());
       // StartCoroutine(FootprintTimer());
    }
    IEnumerator FSM()
    {
        while (alive)
        {
            switch (state)
            {
                case State.IDLE:
                    Idle();
                    break;
                case State.FORAGING:
                    Foraging();
                    break;
                case State.LONELY:
                    Lonely();
                    break;
                case State.PLAYFUL:
                    Playful();
                    break;
                case State.SLEEPING:
                    Sleeping();
                    break;
                case State.THIRSTY:
                    Thirsty();
                    break;
                case State.RELAXING:
                    Relaxing();
                    break;
                case State.HORNY:
                    Horny();
                    break;
                case State.MOPING:
                    Moping();
                    break;
                case State.ANGRY:
                    Angry();
                    break;
                case State.FLEEING:
                    Fleeing();
                    break;
                case State.EXPLORING:
                    Exploring();
                    break;





                    //         IDLE,
                    //   FORAGING,
                    //      LONELY, //SEEKING FRIENDS
                    //  PLAYFUL,
                    //  SLEEPING,
                    // THIRSTY,
                    //  RELAXING,
                    // HORNY,
                    //  MOPING,
                    //  TANTRUM,
                    //  FLEEING,
                    // EXPLORING
            }
            yield return null;
        }

    }


    public void Relaxing()
    {

    }

    public void Moping()
    {
        angry = false;
        moping = true;
    }

    public void Angry()
    {

        
        angry = true;
        moping = false;
    }

    public void tantrum()
    {
        if (angry)
        {
            anger--;
            flAgent.tantrum();
        }
    }

    public void Horny()
    {

    }

    public void Fleeing()
    {

    }

    public void Exploring()
    {

    }

    public void Thirsty()
    {
        stopDist = 0;
        if (CurrentTargetType != "Water")
        {
            CurrentTargetType = "Water";
        }

       
            if (rayPer.currentNearest != null)
            {
                currentNearest = rayPer.currentNearest;
            }
            else
            {
                rayPer.currentTargetType = CurrentTargetType;

            }
        

        if (!hasTarget)
        {
            canseek = false;


            //print("Hunger Threshold Reached and Target Acquired");
            //currentNearest = FindNearest();
            if (currentNearest)
            {
                //print("current nearest exists");
                if (currentNearest.CompareTag(CurrentTargetType))
                {
                    currentTargetTag = CurrentTargetType;
                    currentTarget = currentNearest.gameObject;
                    hasTarget = true;
                   // print("salty wizard");
                }
                else
                {


                    //CurrentTargetType = "WanderTarget";
                    currentTarget = FindWanderSpot().gameObject;
                    currentTargetTag = currentTarget.tag;
                    print("cheesefarts water");
                }
            }
            else
            {
                //CurrentTargetType = "WanderTarget";
                currentTarget = FindWanderSpot().gameObject;
            }



        }
        else
        {
            if (currentNearest)
            {
                //print("current nearest exists");
                if (currentTarget == null)
                {
                    if (currentNearest.tag == CurrentTargetType)
                    {
                        currentTarget = currentNearest.gameObject;
                        currentTargetTag = currentNearest.tag;
                    }
                    else
                    {
                        // CurrentTargetType = "WanderTarget";
                        //currentTarget = FindWanderSpot().gameObject;
                        hasTarget = false;
                        ClearTarget();
                    }
                }
                else
                {
                    if (currentTarget.transform != currentNearest)
                    {
                        //currentNearest = rayPer.currentNearest;
                        currentTarget = currentNearest.gameObject;
                        currentTargetTag = currentNearest.tag;

                    }
                    if (currentTarget.tag != CurrentTargetType)
                    {
                        hasTarget = false;
                        ClearTarget();
                    }
                }

            }
            else
            {
                // CurrentTargetType = "WanderTarget";
                currentTarget = FindWanderSpot().gameObject;
            }
        }

        isThirsty = true;

        if (currentTarget)
        {
            currentTargetTag = currentTarget.tag;

            hasTarget = true;
            canseek = true;
            targetRelativePosition = currentTarget.transform.position - this.gameObject.transform.position;

            // print(targetRelativePosition.normalized);
            targetDistance = targetRelativePosition.sqrMagnitude;

            targetRelativePosition = targetRelativePosition.normalized;


            //FollowTargetWitouthRotation(currentNearest, 0, speed);
            //transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), currentNearest.position, speed * Time.deltaTime);
        }
        if (!currentTarget)
        {
            hasTarget = false;
        }
    }

    

   

    public void Drink()
    {
        if (thirst > 0)
        {
            thirst--;

            //play animation here

        }
    }

    public void TargetList(Transform[] targets)
    {
        targetList = new List<Transform>();
       // targetList = targets.ToArray();
        //targetList = ArrayUtil.ListToArray(targets);
       // targetList = ArrayUtil.ResizableToArray(targets);
        //targetList = targets.InternalArray;

        //targetList = targets;
        //print("target list count =" + targetList.Count);


        foreach(Transform tr in targets)
        {
            AddIt(tr);
        }
    }

   public void AddIt(Transform gg)
    {
        targetList.Add(gg);
    }

    public void TargetDistances()
    {
        //var i = 0;
        List<Transform> tlist = rayPer.CurrentTargetTypeListCopy1;
        //tVectors = new List<Vector2>();
        for(int i = 0; i < tlist.Count; i++)
        {
            tVectors = new Vector2[tlist.Count];
            distances = new float[tlist.Count];
            tDirections = new Vector2[tlist.Count];
            //i = System.Array.IndexOf(targetList, ti);
            //print(tlist.Count);
             
            tVectors[i] = tlist[i].position - this.gameObject.transform.position;
            
           
            distances[i] = tVectors[i].sqrMagnitude;
            tVectors[i] = tVectors[i].normalized;
            //print(distances[i]);
            tDirections[i] = tVectors[i] / distances[i];
            //tDirections[i] = tDirections[i].normalized;
            //i++;
            
            
        }
       
    }

    public void Sleeping()
    {
        counterSleeping++;
        if (counterSleeping == SleepTime)
        {
            SleepNeed = SleepNeed - SleepIncrement * (Random.Range(2,4));
            counterSleeping = 0;
            pain -= .5f;
        }
        if (!justFellAsleep)
        {
            exploration = Vector2.Distance(expStartPos, this.gameObject.transform.position);
            justFellAsleep = true;
            if (exploration > explorationThreshold)
            {
                //reward here
                flAgent.ExplorationReward();
            }
        }

        rb.velocity = Vector2.zero;
        gameObject.GetComponentInChildren<SpriteRenderer>().flipX = false;
        noObstacle = true;
       // infront = false;
       // nextto = false;
        anim.SetBool("Asleep", true);

    }
    public Transform FindWanderSpot()
    {

       // gameObject.GetComponent<NorpAgent>().Done();
        Transform tMin = null;
        //print("Changed Target");

        
               if (!wanderLine)
              {
                if (wanderTarget == null)
                {
                   wanderTarget = Instantiate(wanderTargetPrefab, Random.insideUnitSphere * wanderRadius + transform.position, gameObject.transform.rotation) as GameObject;
                }
                 gameObject.layer = 2; //IgnoreRaycast Layer
                 wanderTarget.gameObject.layer = 2;
                 RaycastHit2D lineosight = Physics2D.Linecast(gameObject.transform.position, wanderTarget.transform.position);

                Debug.DrawLine(gameObject.transform.position, wanderTarget.transform.position);
                wanderTarget.transform.SetParent(null);
                if (lineosight.collider != null)
                {
                    wanderLine = false;
                    wanderTarget.transform.position = Random.insideUnitSphere * wanderRadius + transform.position;
                }
                else
                {
                    wanderLine = true;
                }
                  gameObject.layer = 0; //Normal Layer
                  wanderTarget.gameObject.layer = 0;
              }




        // directionAvg = intDirection;
        //StartCoroutine(WaitForDirection());
        if (wanderTarget != null)
        {
            tMin = wanderTarget.transform;
        }
        else
        {
            tMin = null;
        }


        return tMin;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("WanderTarget"))
        {
            if (collision.gameObject== wanderTarget)
            {
                wanderTarget.transform.position = Random.insideUnitSphere * wanderRadius + transform.position;
                wanderLine = false;
                if (wanderTarget == currentTarget)
                {
                    //gameObject.GetComponent<NorpAgent>().WanderReward();
                }
                ClearTarget();
            }
        }
    }

    public void Idle()
    {
        //gameObject.GetComponent<NorpAgent>().Done();
        stopDist = 0;
        CurrentTargetType = "WanderTarget";
        if (!hasTarget)
        {
            canseek = false;

            //Took out FindWanderSpot to keep agents in Foraging for duration of training
            //currentNearest = FindWanderSpot();
            currentNearest = rayPer.currentNearest;
            
            if (currentNearest)
            {
                currentTarget = currentNearest.gameObject;
                hasTarget = true;
            }
        }
        if (currentTarget)
        {

            hasTarget = true;
            canseek = true;
            //  Below was taken out for training, yo, reinstate it!
            //if (Vector2.Distance(wanderTarget.transform.position, transform.position) < 1)
            //{
           //     currentNearest = null;
           //     currentTarget = null;
           // }
            //FollowTargetWitouthRotation(currentNearest, 0, speed);
            //transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), currentNearest.position, speed * Time.deltaTime);
        }
        if (!currentTarget)
        {
            hasTarget = false;
        }



    }

    public Transform[] FindNearestTenTransforms()
    {
        //print("findnearestTen");
        Transform[] tMin = new Transform[100];
        Transform[] objects = GameObject.FindObjectsOfType<Transform>();
        float minDist = Mathf.Infinity;
        Vector2 currentPos = transform.position;
        foreach (Transform t in objects)
        {

            if (t != null)
            {
                float dist = Vector2.Distance(t.transform.position, currentPos);
                if (dist < minDist)
                {
                    
                    tMin[1] = tMin[0];
                    tMin[2] = tMin[1];
                    tMin[3] = tMin[2];
                    tMin[4] = tMin[3];
                    tMin[5] = tMin[4];
                    tMin[6] = tMin[5];
                    tMin[6] = tMin[5];

                    tMin[7] = tMin[6];
                    tMin[8] = tMin[7];
                    tMin[9] = tMin[8];
                    tMin[99] = null;
                    tMin[0] = t.transform;
                    minDist = dist;
                }
            }
        }
        //directionAvg = intDirection;
        //StartCoroutine(WaitForDirection());

        // ResizableArray<Transform> tmin2 = ArrayUtil.toResizableArray(tMin);

        //ArrayUtil.ArrayToList(tMin);
        return tMin;
    }


    public void Lonely()
    {
        stopDist = friendDistance;
        if (!hasTarget)
        {
            canseek = false;
            
                //print("Loneliness Threshold Reached and Target Acquired" + gameObject.name);
                //FillFriendsList();


               // currentNearest = FindFriends();

               // if (currentNearest)
               // {
                   // currentNearest = FindGroup();
               // }
               // if (currentNearest)
              //  {
                //    currentTarget = currentNearest.gameObject;
                //    hasTarget = true;
               // }
           
                

            
        }
        if (currentTarget)
        {

            hasTarget = true;
            canseek = true;
            //FollowTargetWitouthRotation(currentNearest, 0, speed);
            //transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), currentNearest.position, speed * Time.deltaTime);
        }
        if (!currentTarget)
        {
            hasTarget = false;
        }
        foreach (GameObject g in friends)  //dont forget to also do a foreach for toys in vicinity
        {
            if (g != this.gameObject)
            {
                if (Vector2.Distance(g.transform.position, transform.position) <= stopDist)
                {
                    if (g.gameObject.GetComponent<NPCAI>().openToPlay)
                    {
                        if (gameObject.GetComponent<NPCAI>().openToPlay)
                        {
                            currentNearest = g.transform;
                            currentTarget = g;
                            g.gameObject.GetComponent<NorpAISpike>().state = State.PLAYFUL;
                            g.gameObject.GetComponent<NorpAISpike>().currentNearest = this.gameObject.transform;
                            g.gameObject.GetComponent<NorpAISpike>().currentTarget = this.gameObject;
                            hasTarget = true;
                            openToPlay = true;
                            state = State.PLAYFUL;

                        }
                    }
                }
            }

        }
    }
    public void Playful()
    {
        stopDist = 0;
        canDetect = false;
        if (!hasTarget)
        {

           // currentNearest = FindPlayFriend();
            if (currentNearest)
            {
                currentTarget = currentNearest.gameObject;
                hasTarget = true;
            }
        }
        if (currentNearest)
        {
            if (Vector2.Distance(currentNearest.transform.position, transform.position) < 1)
            {
               // StartCoroutine(Play());

            }
            else
            {
                foreach (GameObject pf in friends)
                {
                    if (Vector2.Distance(pf.transform.position, transform.position) < 3)
                    {
                        if (pf.GetComponent<NPCAI>().isplaying)
                        {
                            //StartCoroutine(Play());
                        }
                    }
                }
            }
        }
        if (currentTarget)
        {

            hasTarget = true;
            canseek = true;
            //FollowTargetWitouthRotation(currentNearest, 0, speed);
            //transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), currentNearest.position, speed * Time.deltaTime);
        }
        if (!currentTarget)
        {
            hasTarget = false;
        }



    }
    public IEnumerator WaitBool()
    {
        waiting = true;
        yield return new WaitForSeconds(.5f);
        //rb.isKinematic = false;
        //rb.constraints = RigidbodyConstraints2D.None;
        waiting = false;
        StopCoroutine(WaitBool());
    }

    public IEnumerator WaitForDirection()
    {
        //directionAvg = intDirection;
        cantTurn = true;

      //  count = 0;
       // sum = 0;
        count2 = 0;
        sum2 = new Vector2(0, 0);
        yield return new WaitForSeconds(.1f);
        //directionAvg = intDirection;
        cantTurn = false;
       // count = 0;
       // sum = 0;
        yield return new WaitForFixedUpdate();
        cantTurn = false;
        yield return new WaitForSeconds(0);
        //cantTurn = false;

    }

    public void AddCurrentNearest(Transform fromRayP)
    {
        currentNearest = fromRayP;
    }

    
    public void Foraging()
    {
        stopDist = 0;
        if (CurrentTargetType != "Food")
        {
            CurrentTargetType = "Food";
        }

        if (currentNearest == null || currentTarget.transform != currentNearest)
        {
            if (rayPer.currentNearest != null)
            {
                currentNearest = rayPer.currentNearest;
            }
            else
            {
                rayPer.currentTargetType = CurrentTargetType;
               
            }
        }

        if (!hasTarget)
        {
            canseek = false;
           

                //print("Hunger Threshold Reached and Target Acquired");
                //currentNearest = FindNearest();
                if (currentNearest)
                {
                //print("current nearest exists");
                   if (currentNearest.CompareTag(CurrentTargetType))
                   {
                    currentTargetTag = CurrentTargetType;
                    currentTarget = currentNearest.gameObject;
                    hasTarget = true;
                    //print("salty wizard");
                   }
                   else
                   {
                    
                    
                    //CurrentTargetType = "WanderTarget";
                    currentTarget = FindWanderSpot().gameObject;
                    currentTargetTag = currentTarget.tag;
                    print("cheesefarts");
                   }
                }
            else
            {
                //CurrentTargetType = "WanderTarget";
                currentTarget = FindWanderSpot().gameObject;
            }
           
               
            
        }
        else
        {
            if (currentNearest)
            {
                //print("current nearest exists");
                if (currentTarget==null)
                {
                    if (currentNearest.tag == CurrentTargetType)
                    {
                        currentTarget = currentNearest.gameObject;
                        currentTargetTag = currentNearest.tag;
                    }
                    else
                    {
                        // CurrentTargetType = "WanderTarget";
                        //currentTarget = FindWanderSpot().gameObject;
                        hasTarget = false;
                        ClearTarget();
                    }
                }
                else
                {
                    if (currentTarget.transform != currentNearest)
                    {
                        //currentNearest = rayPer.currentNearest;
                        currentTarget = currentNearest.gameObject;
                        currentTargetTag = currentNearest.tag;

                    }
                    if (currentTarget.tag != CurrentTargetType)
                    {
                        hasTarget = false;
                        ClearTarget();
                    }
                }
               
            }
            else
            {
               // CurrentTargetType = "WanderTarget";
                currentTarget = FindWanderSpot().gameObject;
            }
        }

        

        if (currentTarget)
        {
            currentTargetTag = currentTarget.tag;

            hasTarget = true;
            canseek = true;
            targetRelativePosition = currentTarget.transform.position - this.gameObject.transform.position;
           
           // print(targetRelativePosition.normalized);
            targetDistance = targetRelativePosition.sqrMagnitude;

            //targetRelativePosition = targetRelativePosition.normalized;
            

            //FollowTargetWitouthRotation(currentNearest, 0, speed);
            //transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), currentNearest.position, speed * Time.deltaTime);
        }
        if (!currentTarget)
        {
            hasTarget = false;
        }
    }

    public IEnumerator NewTarget()
    {
        yield return new WaitForSeconds(2);
        hasTarget = false;
        StopCoroutine(NewTarget());
    }
    public IEnumerator HungerTimer()
    {
        while (alive)
        {
            yield return new WaitForSeconds(hungerTime);
            if (hunger > 0)
            {
                hunger = hunger - hungerIncrement;
            }
        }
        yield return null;
    }

    public void ClearTarget()
    {
        currentNearest = null;
        currentTarget = null;
        rayPer.currentNearest = null;
        //CurrentTargetType = null;
       // currentTargetTag = null;
    }

    public void Poop()
    {
        if (!justPooped)
        {
            Instantiate(poopPrefab, gameObject.transform.position, transform.rotation);
            audiosource.PlayOneShot(poopSound, .0042f);
            justPooped = true;
           
            sadness -= poopCount * sadmadRatio;
            anger -= poopCount * (1 - sadmadRatio);
            poopCount = 0;
            flAgent.PoopReward(1);
            flAgent.PoopReward(poopCount * .001f);
        }
    }

    public void Pain(float value)
    {
        pain += value;
        sadness += (value * 10) * sadmadRatio;
        anger += (value * 10) * (1-sadmadRatio);
        if (angry)
        {
            anger += value * 10;
        }
        flAgent.Pain();
    }

    // Update is called once per frame
    void Update () {
        if (TargetTRAINING)
        {
            if (hunger > hungerThreshold)
            {
                hunger = 5;
            }
        }

        if (!TargetTRAINING)
        {

            if (calendar.monthCounter == breedingTiming[0])
            {
                if (calendar.dayCounter == breedingTiming[1])
                {
                    horniness = Random.Range(hornyFactors[0], hornyFactors[1]);
                }
            }

            if (calendar.secondsCounter == 0)
            {
                pain -= .1f;
            }



            if (poopCount >= poopThreshold)
            {
                if (calendar.secondsCounter == 0)
                {
                    anger += (poopCount - poopThreshold) * .01f;
                    if (angry)
                    {
                        anger++;
                    }
                }
            }
            if(poopCount >= (poopThreshold * 2))
            {
                if (calendar.secondsCounter == 0)
                {
                    flAgent.PoopReward(poopCount * -.01f);
                }
            }
            if (poopCount == 0)
            {
                justPooped = false;
            }

            // timeCounter1++;
            if (calendar.MinuteCounter == 59)
            {
                if (calendar.secondsCounter == 30)
                {
                    friendship = clans.CalculateFriendship(gameObject.transform, friends);
                    sadness -= friendship * sadmadRatio;
                    anger -= friendship * (1 - sadmadRatio);
                    sadThreshold = originalSadThr + friendship;
                    angerThreshold = originalAngerThr + friendship;
                    //timeCounter1 = 0;
                }
            }

            if (alive)
            {
                //yield return new WaitForSeconds(SleepTime);

                thirstCounter++;
                if (thirstCounter == thirstTimer)
                {

                    if (thirst > 0)
                    {
                        thirst = thirst + thirstIncrement;
                    }


                    if (thirst == 0 || thirst < thirstThreshold)
                    {

                        sadness -= 1 * sadmadRatio;
                        anger -= 1 * (1 - sadmadRatio);


                        isThirsty = false;
                    }

                    if (thirst > thirstThreshold)
                    {

                        sadness += 1 * sadmadRatio;
                        anger += 1 * (1 - sadmadRatio);
                        if (angry)
                        {
                            anger += 2;
                        }

                        isThirsty = true;
                    }
                    thirstCounter = 0;
                }
            }
        }
        if (state != State.SLEEPING)
        {
            anim.SetBool("Asleep", false);
        }
        if (isBored)
        {
            if (state != State.FORAGING)
            {
                //don't forget to add requirements for pain, anger, and sadness

                openToPlay = true;
            }
        }

        if (pain < 0)
        {
            pain = 0;
        }

        if (state == State.LONELY)
        {
            canDetect = true;
            openToPlay = true;
        }

        if (state == State.FORAGING)
        {
            openToPlay = false;
            canDetect = true;
        }
        if (state == State.SLEEPING)
        {
            openToPlay = false;
        }
        if (state == State.IDLE)
        {
            canDetect = true;
        }

        if (boredom < 0)
        {
            boredom = 0;
        }
        if (calendar.MinuteCounter == 0)
        {
            if (calendar.secondsCounter == 0)
            {
                boredom++;
            }
        }
        if (boredom > boredomThreshhold)
        {

            SleepThreshold = originalSleepThr / 2;
            explorationThreshold = originalExpThr * 2;

        }
        if (boredom < boredomThreshhold)
        {

            SleepThreshold = originalSleepThr * 2;
            explorationThreshold = originalExpThr/ 2;

        }
        if (!TargetTRAINING)
        {
            if (alive)
            {
                if (calendar.MinuteCounter == 16 || calendar.MinuteCounter == 32 || calendar.MinuteCounter == 48 || calendar.MinuteCounter == 0)
                {
                    if (SleepNeed > 0)
                    {
                        SleepNeed = SleepNeed + SleepIncrement;

                    }
                    else
                    {
                        if (SleepNeed == 0)
                        {
                            exploration = 0;
                            expStartPos = this.gameObject.transform.position;
                            state = State.IDLE;
                            justFellAsleep = false;
                            SleepNeed = SleepNeed + SleepIncrement;
                        }

                    }
                    if (SleepNeed < SleepThreshold)
                    {
                        sadness -= 1 * sadmadRatio;
                        anger -= 1 * (1 - sadmadRatio);
                    }
                    if (SleepNeed > SleepThreshold)
                    {
                        //state = State.SLEEPING;

                        sadness += 1 * sadmadRatio;
                        anger += 1 * (1 - sadmadRatio);
                        if (angry)
                        {
                            anger++;
                        }

                    }
                }
            }




            if (friendship < friendshipNeed)
            {
                if (state != State.SLEEPING)
                {
                    if (state != State.FORAGING)
                    {
                        if (state != State.LONELY)
                        {
                            if (state != State.PLAYFUL)
                            {

                                ClearTarget();
                                // state = State.LONELY;
                            }
                        }
                    }
                }
            }
        }
        timeCounter2++;
        if (hunger < hungerThreshold)
        {
            if (timeCounter2 >= 60)
            {
                sadness += 1 * sadmadRatio;
                anger += 1 * (1 - sadmadRatio);
                if (angry)
                {
                    anger += 2;
                }
                timeCounter2 = 0;
            }
            if (state != State.SLEEPING)
            {
                if (state != State.FORAGING)
                {
                    ClearTarget();

                    state = State.FORAGING;
                }
            }
        }
        if (hunger >= hungerThreshold)
        {
            if (timeCounter2 >= 60)
            {
                sadness -= 1 * sadmadRatio;
                anger -= 1 * (1 - sadmadRatio);
                timeCounter2 = 0;
            }
            if (state != State.SLEEPING)
            {
                //idle state is here as a placeholder until advanced state priority management is in place
                if (state != State.LONELY)
                {
                    if (state != State.IDLE)
                    {
                        if (state != State.PLAYFUL)
                        {
                            ClearTarget();

                            state = State.IDLE;
                        }
                    }
                }
            }
        }


        
        if (!currentNearest)
        {
            if (currentTarget == null)
            {
                hasTarget = false;
            }
        }
    }
   
}
