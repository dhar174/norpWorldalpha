using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCAI : MonoBehaviour {


    public int intDirection;
    public bool testing;
    public bool alive;
    public bool moving;
    private NavMeshAgent agent;
    private GameObject storedTarget;
    private bool bounced1;
    private bool bounced2;
    private bool bounced3;
    private bool bounced4;
    private bool bounced5;
    private bool bounced6;
    private bool bounced7;
    private bool bounced8;
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

    public bool openToPlay;
    public bool isBored;
    public float boredom;
    public float boredomThreshhold;
    public bool isplaying;

    public int poopCount;
    public int poopThreshold;
    public GameObject poopPrefab;
    public bool justPooped;
    public AudioClip poopSound;


    public AudioSource audiosource;

    public GameObject currentObstacle;
    public Vector2 testofDirection;

    private int count;
    public int directionAvg;
    private int sum;

    public float xstart;
    public float ystart;
    public float xend;
    public float yend;
    public float xstart2;
    public float ystart2;
    public float xend2;
    public float yend2;
    public float xstart3;
    public float ystart3;
    public float xend3;
    public float yend3;
    public float xstart4;
    public float ystart4;
    public float xend4;
    public float yend4;

    public float turdcheck;

    private Transform body;

    public bool bouncedout;

    public float stopDist;

    public float maxVelocity;
    public bool infront;
    public bool hasObstacle1;
    public bool hasObstacle2;
    public bool hasObstacle3;
    public bool hasObstacle4;

    public bool nextto;
    int rando;
    //Vector2 direction;
    public bool waiting;
    public bool gotRando;
    public bool canseek;
    public Vector2 start;
    public Vector2 end;
    public Vector2 start2;
    public Vector2 end2;
    public Vector2 start3;
    public Vector2 end3;
    public Vector2 start4;
    public Vector2 end4;
    const int maxReturnedIntersections = 1;
    private RaycastHit2D[] hits = new RaycastHit2D[maxReturnedIntersections];
    public int foundIntersections;

    public Vector2 velocity;
    public float speed;
    public Rigidbody2D rb;
    public Animator anim;
    public List<GameObject> foods = new List<GameObject>();
    public float toSubtract;


    //public RaycastHit2D hit;

    public float SleepTime;
    public float SleepNeed;

    public float friendship;
    public float friendshipNeed;
    public List<GameObject> friends = new List<GameObject>();
    public float friendDistance;
    public float friendSatiety;
    public float friendsNearbyNum;
    public int friendshipTime;

    public int timetilcount;

    public Vector2 lastPos;
    public GameObject footprints;
    public GameObject footprints2;
    public GameObject brownprints;
    public GameObject brownprints2;
    public bool poopyprints;


    public float wanderRadius;

    public GameObject wanderTargetPrefab;
    private GameObject wanderTarget;

    public float hunger;
    public float hungerTime;
    public float hungerThreshold;
    public GameObject currentTarget;
    public bool hasTarget = false;
    public enum State
    {
        IDLE,
        FORAGING,
        LONELY,
        PLAYFUL,
        SLEEPING,
    }
    public State state;

    public float bounciness;

    public Transform currentNearest;

    public SpriteRenderer[] mapbodySR;

	// Use this for initialization
	void Start () {
        //rb = gameObject.GetComponent<Rigidbody2D>();
        poopCount = 0;
        if (poopThreshold == 0)
        {
            poopThreshold = Random.Range(5 , 15);
        }
        if (bounciness == 0)
        {
            bounciness = Random.Range(1, 5);
        }
        if (gameObject.transform.Find("MapBody"))
        {
            mapbodySR = gameObject.transform.Find("MapBody").GetComponentsInChildren<SpriteRenderer>();
        }
        foreach(SpriteRenderer sr in mapbodySR)
        {
            sr.enabled = false;
        }
        alive = true;
        gotRando = false;
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
            friendDistance = Random.Range(2,9);
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
            friendshipTime = Random.Range(3, 10);
        }
        if (wanderRadius == 0)
        {
            wanderRadius = Random.Range(5, 20);
        }
        audiosource = gameObject.GetComponent<AudioSource>();
        
        int foundIntersections = Physics2D.LinecastNonAlloc(start, end, hits);
        //direction = Vector2.zero;
        anim = gameObject.GetComponentInChildren<Animator>();
        if (hunger == 0)
        {
            hunger = Random.Range(80, 150);
        }
        FillFoodList();
        FillFriendsList();

        if (hungerTime == 0)
        {
            hungerTime = 5;
        }

        StartCoroutine(HungerTimer());
        //agent = gameObject.GetComponent<NavMeshAgent>();
        
        rb = gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine("FSM");
        if (maxVelocity == 0)
        {
            maxVelocity = 40;
        }
        if (yend == 0)
        {
            yend = 2;
        }
        if (ystart == 0)
        {
            ystart = 1.5f;
        }
        if (yend2 == 0)
        {
            yend2 = .75f;
        }
        if (ystart2 == 0)
        {
            ystart2 = .75f;
        }
        if (xstart2 == 0)
        {
            xstart2 = .5f;
        }
        if (xend2 == 0)
        {
            xend2 = 1.5f;
        }
        if (yend3 == 0)
        {
            yend3 = .75f;
        }
        if (ystart3 == 0)
        {
            ystart3 = .75f;
        }
        if (xstart3 == 0)
        {
            xstart3=-.5f;
        }
        if (xend3 == 0)
        {
            xend3 = -1.5f;
        }
        if (yend4 == 0)
        {
            yend4 = -.5f;
        }
        if (ystart4 == 0)
        {
            ystart4 = -.2f;
        }
        body = gameObject.transform.GetChild(0).GetComponent<Transform>();
        StartCoroutine(FriendshipMeter());
        StartCoroutine(CountFriends());
        if (friendship == 0)
        {
            friendship = friendshipNeed + Random.Range(10,200);
        }
        StartCoroutine(CheckDirection());
        if (SleepNeed == 0)
        {
            SleepNeed = Random.Range(30, 240);
        }
        if (SleepTime == 0)
        {
            SleepTime = Random.Range(240, 1200);
        }
        StartCoroutine(SleepTimer());
        StartCoroutine(BoredomTimer());
        StartCoroutine(FootprintTimer());

    }

    public IEnumerator FootprintTimer()
    {
        var which = 0;
        while (alive)
        {
            
            lastPos = transform.position;
            yield return new WaitForSeconds(2);
            if (Vector2.Distance(lastPos, transform.position) > .5f)
            {
                which++;
                var these = footprints;
                if (poopyprints)
                {

                    if (which >= 1)
                    {
                        these = brownprints;
                    }
                    else
                    {
                        these = brownprints2;

                    }
                    GameObject prints = Instantiate(these, transform.position, transform.rotation) as GameObject;
                    if (directionAvg == 0)
                    {
                        prints.transform.Rotate(0, 0, 90);
                    }
                    if (directionAvg == 1)
                    {
                        //up
                        prints.transform.Rotate(0, 0, -90);

                    }
                    if (directionAvg == 2)
                    {
                        //right
                        prints.transform.Rotate(0, 0, 180);

                    }
                    if (which == 2)
                    {
                        which = 0;
                    }
                }
                else
                {
                    if (which >= 1)
                    {
                        these = footprints;
                    }
                    else
                    {
                        these = footprints2;

                    }
                    GameObject prints = Instantiate(these, transform.position, transform.rotation) as GameObject;
                    if (directionAvg == 0)
                    {
                        prints.transform.Rotate(0, 0, 90);
                    }
                    if (directionAvg == 1)
                    {
                        //up
                        prints.transform.Rotate(0, 0, -90);

                    }
                    if (directionAvg == 2)
                    {
                        //right
                        prints.transform.Rotate(0, 0, 180);

                    }
                    if (which == 2)
                    {
                        which = 0;
                    }
                }
            }
        }

    }

    IEnumerator BoredomTimer()
    {
        while (alive)
        {
            yield return new WaitForSecondsRealtime(2);
            boredom++;
            if (boredom > boredomThreshhold)
            {
                isBored = true;
            }
            if (boredom < boredomThreshhold)
            {
                isBored = false;
                if(state != State.LONELY)
                {
                    openToPlay = false;
                }
            }

        }
        yield return null;

    }

    IEnumerator SleepTimer()
    {
        yield return new WaitForSecondsRealtime(SleepTime);
        gameObject.GetComponentInChildren<SpriteRenderer>().flipX = false;

        state = State.SLEEPING;
        waiting = true;
        canseek = false;
        yield return new WaitForSecondsRealtime(SleepNeed);
        waiting = false;
        canseek = true;
        state = State.IDLE;
        StartCoroutine(SleepTimer());
    }


    IEnumerator CheckDirection()
    {
        cantTurn = true;
        yield return new WaitForSeconds(1);
        cantTurn = false;
        yield return new WaitForSeconds(1);
        StartCoroutine(CheckDirection());
        yield return null;
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
                    
            }
            yield return null;
        }
        
    }
    public void Sleeping()
    {
        rb.velocity = Vector2.zero;
        gameObject.GetComponentInChildren<SpriteRenderer>().flipX = false;
        noObstacle = true;
        infront = false;
        nextto = false;
        anim.SetBool("Asleep", true);
        
    }

    public void Idle()
    {
        stopDist = 0;

        if (!hasTarget)
        {
            canseek = false;
            if (!bounced6)
            {
                //print("Hunger Threshold Reached and Target Acquired");
                currentNearest = FindWanderSpot();
                if (currentNearest)
                {
                    currentTarget = currentNearest.gameObject;
                    hasTarget = true;
                }
            }
            if (bounced6)
            {
                FillFoodList();
                //print("Bounced");
                currentNearest = FindWanderSpot();
                if (currentNearest)
                {
                    currentTarget = currentNearest.gameObject;
                    hasTarget = true;
                }
            }
        }
        if (currentTarget)
        {

            hasTarget = true;
            canseek = true;
            if (Vector2.Distance(wanderTarget.transform.position, transform.position) < 1)
            {
                currentNearest = null;
                currentTarget = null;
            }
            //FollowTargetWitouthRotation(currentNearest, 0, speed);
            //transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), currentNearest.position, speed * Time.deltaTime);
        }
        if (!currentTarget)
        {
            hasTarget = false;
        }
        
        

    }

    public Transform FindWanderSpot()
    {
        
       
        Transform tMin = null;
        //print("Changed Target");
        
        if (wanderTarget)
        {
            wanderTarget.transform.position = Random.insideUnitSphere * wanderRadius + transform.position;
        }
        if (!wanderTarget)
        {
            wanderTarget = Instantiate(wanderTargetPrefab, Random.insideUnitSphere * wanderRadius + transform.position, gameObject.transform.rotation) as GameObject;
            wanderTarget.transform.SetParent(null);

        }
        // directionAvg = intDirection;
        StartCoroutine(WaitForDirection());

        tMin = wanderTarget.transform;
        

        return tMin;
    }

    public void EnableMapbody()
    {

        
            foreach (SpriteRenderer sr in mapbodySR)
            {
                sr.enabled = true;
            }

        anim.enabled = false;
            body.localScale = new Vector2(3,3);
        


    }
    public void DisableMapbody()
    {
        foreach (SpriteRenderer sr in mapbodySR)
        {
            sr.enabled = false;
        }
        anim.enabled = true;
        body.localScale = new Vector2(1, 1);
    }

    public Transform FindGroup()
    {
        if (currentNearest.gameObject.GetComponent<NPCAI>().friendsNearbyNum >= friendSatiety)
        {
            Transform tMin = currentNearest;
            // directionAvg = intDirection;
            StartCoroutine(WaitForDirection());


            return tMin;
        }
        else
        {
            Transform tMin = null;
            float minDist = Mathf.Infinity;
            Vector2 currentPos = transform.position;
            foreach (GameObject fr in friends)
            {
                if (fr)
                {
                    if (fr != gameObject)
                    {
                        if (fr != currentNearest)
                        {
                            float dist = Vector2.Distance(fr.transform.position, currentPos);
                            if (dist < minDist)
                            {
                                if (fr.GetComponent<NPCAI>().friendsNearbyNum >= friendSatiety)
                                {
                                    tMin = fr.transform;
                                    minDist = dist;
                                }
                                else
                                {
                                    tMin = fr.transform;
                                    float highestFriends = fr.GetComponent<NPCAI>().friendsNearbyNum;

                                    foreach (GameObject fd in friends)
                                    {
                                        if (fd)
                                        {
                                            if (fd != gameObject)
                                            {
                                                if (fd != currentNearest)
                                                {
                                                    if (fd != fr)
                                                    {
                                                        float thisFriendNum = fd.GetComponent<NPCAI>().friendsNearbyNum;
                                                        if (thisFriendNum > highestFriends)
                                                        {
                                                            highestFriends = thisFriendNum;
                                                            tMin = fd.transform;
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
                }
            }
            //print("Found tMin for Lonely");
            StartCoroutine(WaitForDirection());

            return tMin;
        }
    }

    public void Lonely()
    {
        stopDist = friendDistance;
        if (!hasTarget)
        {
            canseek = false;
            if (!bounced6)
            {
                //print("Loneliness Threshold Reached and Target Acquired" + gameObject.name);
                FillFriendsList();


                currentNearest = FindFriends();

                if (currentNearest)
                {
                    currentNearest = FindGroup();
                }
                if (currentNearest)
                {
                    currentTarget = currentNearest.gameObject;
                    hasTarget = true;
                }
            }
            if (bounced6)
            {
                FillFriendsList();
                //print("Bounced");
                currentNearest = FindFriends();
                currentNearest = FindGroup();

                if (currentNearest)
                {
                    currentTarget = currentNearest.gameObject;
                    hasTarget = true;
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
        foreach(GameObject g in friends)  //dont forget to also do a foreach for toys in vicinity
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
                            g.gameObject.GetComponent<NPCAI>().state = State.PLAYFUL;
                            g.gameObject.GetComponent<NPCAI>().currentNearest = this.gameObject.transform;
                            g.gameObject.GetComponent<NPCAI>().currentTarget = this.gameObject;
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

            currentNearest = FindPlayFriend();
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
                StartCoroutine(Play());

            }
            else
            {
                foreach (GameObject pf in friends)
                {
                    if (Vector2.Distance(pf.transform.position, transform.position) < 3)
                    {
                        if (pf.GetComponent<NPCAI>().isplaying)
                        {
                            StartCoroutine(Play());
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

    public Transform FindPlayFriend()
    {
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector2 currentPos = transform.position;
        foreach (GameObject fr in friends)
        {
            if (fr)
            {
                if (fr.GetComponent<NPCAI>().openToPlay)
                {
                    if (fr != gameObject)
                    {
                        float dist = Vector2.Distance(fr.transform.position, currentPos);
                        if (dist < minDist)
                        {
                            tMin = fr.transform;
                            minDist = dist;
                        }
                    }
                }
            }
        }
        // directionAvg = intDirection;
        StartCoroutine(WaitForDirection());


        return tMin;
    }

    public IEnumerator Play()
    {
        if (!isplaying)
        {
            isplaying = true;
            waiting = true;
            rb.velocity = Vector2.zero;
            bouncedout = true;
            boredom -= Random.Range(10,30);
            openToPlay = false;
            var timing = Random.Range(.5f, 2);
            yield return new WaitForSecondsRealtime(timing);
            anim.SetBool("Play",true);
            friendship += Random.Range(20, 80);
            boredom -= Random.Range(10, 30);

            yield return new WaitForSecondsRealtime(timing);
            friendship += Random.Range(20, 80);
            boredom -= Random.Range(10, 30);


            yield return new WaitForSecondsRealtime(timing);
            friendship += Random.Range(20, 80);
            boredom -= Random.Range(10, 30);

            if (Random.Range(0, 1) == 1)
            {
                anim.SetBool("Play", false);

            }
            yield return new WaitForSecondsRealtime(timing);
            friendship += Random.Range(20, 80);
            anim.SetBool("Play", true);
            boredom -= Random.Range(10, 30);


            yield return new WaitForSecondsRealtime(timing);
            friendship += Random.Range(20, 80);
            boredom -= Random.Range(10, 30);

            yield return new WaitForSecondsRealtime(timing);
            friendship += Random.Range(20, 80);
            if (Random.Range(0, 1) == 1)
            {
                anim.SetBool("Play", false);

            }
            boredom -= Random.Range(10, 30);

            yield return new WaitForSecondsRealtime(timing);
            friendship += Random.Range(20, 80);
            anim.SetBool("Play", true);
            boredom -= Random.Range(10, 30);

            yield return new WaitForSecondsRealtime(timing);
            friendship += Random.Range(20, 80);
            boredom -= Random.Range(10, 30);

            yield return new WaitForSecondsRealtime(timing);
            anim.SetBool("Play", false);
            boredom -= Random.Range(10, 30);

            friendship += Random.Range(20, 80);
            waiting = false;
            canDetect = true;
            bouncedout = false;
            isplaying = false;
            state = State.IDLE;
        }
    }

    public void FillFoodList()
    {
        
        GameObject[] array = GameObject.FindGameObjectsWithTag("Food");
        foods.Clear();
        foreach(GameObject go in array)
        {
            if (!foods.Contains(go))
            {
                foods.Add(go);
            }
            
        }
    }

    public void FillFriendsList()
    {

        GameObject[] array = GameObject.FindGameObjectsWithTag("NPC");
        friends.Clear();
        foreach (GameObject go in array)
        {
            if (Vector2.Distance(go.transform.position, transform.position) < 300)
            {

                if (!friends.Contains(go))
                {
                    friends.Add(go);
                }
            }

        }
    }

    public IEnumerator HungerTimer()
    {
        while (alive)
        {
            yield return new WaitForSeconds(hungerTime);
            if (hunger > 0)
            {
                hunger = hunger - 1;
            }
        }
        yield return null;
    }
	
    public void Move(Vector2 velocity, float speed)
    {
        gameObject.transform.Translate(velocity * speed * Time.deltaTime);

    }

    public Transform FindNearest()
    {
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector2 currentPos = transform.position;
        foreach (GameObject t in foods)
        {
            if (t!=null)
            {
                float dist = Vector2.Distance(t.transform.position, currentPos);
                if (dist < minDist)
                {
                    tMin = t.transform;
                    minDist = dist;
                }
            }
        }
        //directionAvg = intDirection;
        StartCoroutine(WaitForDirection());


        return tMin;
    }

    public Transform FindFriends()
    {
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector2 currentPos = transform.position;
        foreach (GameObject fr in friends)
        {
            if (fr)
            {
                if (fr != gameObject)
                {
                    float dist = Vector2.Distance(fr.transform.position, currentPos);
                    if (dist < minDist)
                    {
                        tMin = fr.transform;
                        minDist = dist;
                    }
                }
            }
        }
        // directionAvg = intDirection;
        StartCoroutine(WaitForDirection());


        return tMin;
    }


    public Transform FindSecondNearest()
    {

        Transform tMin = null;
        float minDist = Mathf.Infinity;

        Vector2 currentPos = transform.position;
        foreach (GameObject t in foods)
        {
            if (t)
            {
                if (t != storedTarget)
                {
                    if (storedTarget)
                    {
                        if (Vector2.Distance(t.transform.position, storedTarget.transform.position) > 5)
                        {
                            float dist = Vector2.Distance(t.transform.position, currentPos);
                            if (dist < minDist)
                            {
                                tMin = t.transform;
                                minDist = dist;
                            }
                        }
                    }
                    else
                    {
                        float dist = Vector2.Distance(t.transform.position, currentPos);
                        if (dist < minDist)
                        {
                            tMin = t.transform;
                            minDist = dist;
                        }
                    }
                }
            }
        }
        // directionAvg = intDirection;
        StartCoroutine(WaitForDirection());
        
        return tMin;
        
    }

    public IEnumerator WaitForDirection()
    {
        directionAvg = intDirection;
        cantTurn = true;

        count = 0;
        sum = 0;
        count2 = 0;
        sum2 = new Vector2(0, 0);
        yield return new WaitForSeconds(.1f);
        //directionAvg = intDirection;
        cantTurn = false;
        count = 0;
        sum = 0;
        yield return new WaitForFixedUpdate();
        cantTurn = false;
        yield return new WaitForSeconds(0);
        //cantTurn = false;

    }

    public void ChangeTarget()
    {
        currentTarget = currentNearest.gameObject;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (!bouncedout)
        {
            //var direction = collision.gameObject.transform.position + transform.position;
            //rb.AddRelativeForce(direction.normalized * bounciness/5, ForceMode2D.Impulse);
        }
        //StartCoroutine(WaitBool());

        //rb.isKinematic = true;
        //rb.velocity = Vector2.zero;
        
            //rb.constraints = RigidbodyConstraints2D.FreezeAll;
            //RemoveFromList(currentTarget);
            //FillFoodList();
            storedTarget = currentTarget;
            if (!bounced1)
            {
                
                bounced1 = true;
            }
            else
            {
                if (!bounced2)
                {

                    bounced2 = true;

                }
                else
                {
                    if (!bounced3)
                    {
                        bounced3 = true;

                    }
                    else
                    {
                        if (!bounced4)
                        {
                            bounced4 = true;

                        }
                        else
                        {
                            if (!bounced5)
                            {
                                bounced5 = true;

                            }
                            else
                            {
                                bounced6 = true;
                                bouncedout = true;
                                StartCoroutine(ResetBounce());
                            }
                        }
                    }
                }
            }

            
            currentTarget = null;
            //currentNearest = FindSecondNearest();
            //currentTarget = currentNearest.gameObject;
            //StartCoroutine(FixRb());
        
    }
    public IEnumerator ResetBounce()
    {

        yield return new WaitForSeconds(15);
        bouncedout = false;
        bounced1 = false;
        bounced2 = false;
        bounced3 = false;
        bounced4 = false;
        bounced5 = false;
        bounced6 = false;

        StopCoroutine(ResetBounce());

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


    public void RemoveFromList(GameObject consumed)
    {
        foods.Remove(consumed);
    }

    void FollowTargetWitouthRotation(Transform target, float distanceToStop, float speed)
    {
        rb.velocity = Vector2.zero;
        //var direction = Vector2.zero;
        if (Vector2.Distance(transform.position, target.position) > distanceToStop)
        {

            direction = target.position - transform.position;
            var localVelocity = transform.InverseTransformDirection(rb.velocity);
            testofDirection = avgVelocity;


            count2++;

            sum2 += direction.normalized;
            if (count2 == 3)
            {
                avgVelocity = sum2/3;
                count2 = 0;
                sum2 = new Vector2(0,0);
            }

            if (avgVelocity.y < 0)
            {


                if (avgVelocity.x > 0)
                {
                   
                        var turd = 0 - avgVelocity.x;
                    if (avgVelocity.x > .5)
                    {

                        if (turd < avgVelocity.y)
                        {
                            intDirection = 2; //right
                            gameObject.GetComponentInChildren<SpriteRenderer>().flipX = true;

                        }
                        else
                        {
                            intDirection = 0; //down

                            gameObject.GetComponentInChildren<SpriteRenderer>().flipX = false;
                        }
                    }
                    else
                    {

                            intDirection = 0; //down

                            gameObject.GetComponentInChildren<SpriteRenderer>().flipX = false;
                        
                        
                    }
                    
                }
                if (avgVelocity.x < 0)
                {



                    if (avgVelocity.x < -.5)
                    {
                        if (avgVelocity.x < avgVelocity.y)
                        {
                            intDirection = 3; //left
                            gameObject.GetComponentInChildren<SpriteRenderer>().flipX = false;

                        }
                        else
                        {
                            intDirection = 0; //down

                            gameObject.GetComponentInChildren<SpriteRenderer>().flipX = false;
                        }
                    }
                    else
                    {
                       
                            intDirection = 0; //down

                            gameObject.GetComponentInChildren<SpriteRenderer>().flipX = false;
                        
                        
                    }
                    
                }

                //intDirection = 0; //down

                  //  gameObject.GetComponentInChildren<SpriteRenderer>().flipX = false;
                
                    
                
            }
            else
            {
                if (avgVelocity.y > 0)
                {
                    if (avgVelocity.x < 0)
                    {

                        var turd = 0 - avgVelocity.x;

                        if (avgVelocity.x < -.5)
                        {
                            if (turd > avgVelocity.y)
                            {
                                intDirection = 3; //left
                                gameObject.GetComponentInChildren<SpriteRenderer>().flipX = false;

                            }
                            else
                            {
                                intDirection = 1; //up

                                gameObject.GetComponentInChildren<SpriteRenderer>().flipX = false;
                            }
                        }
                        else
                        {
                            
                                intDirection = 1; //up

                                gameObject.GetComponentInChildren<SpriteRenderer>().flipX = false;
                            
                            
                        }

                    }
                    else
                    {
                        if (avgVelocity.x > 0)
                        {
                            if (avgVelocity.x > .5)
                            {
                                if (avgVelocity.x > avgVelocity.y)
                                {
                                    intDirection = 2; //right
                                    gameObject.GetComponentInChildren<SpriteRenderer>().flipX = true;
                                }
                                else
                                {
                                    if (avgVelocity.x < avgVelocity.y)
                                    {
                                        intDirection = 1; //up

                                        gameObject.GetComponentInChildren<SpriteRenderer>().flipX = false;
                                    }
                                }
                            }
                            else
                            {
                                
                                    intDirection = 1; //up

                                    gameObject.GetComponentInChildren<SpriteRenderer>().flipX = false;
                                
                                
                            }
                        }

                        //intDirection = 1; //up
                        //  gameObject.GetComponentInChildren<SpriteRenderer>().flipX = false;

                    }
                }
                
            }
           
            rb.AddRelativeForce(direction.normalized * speed, ForceMode2D.Force);
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxVelocity);


        }
    }

    public void Foraging()
    {
        stopDist = 0;
        if (!hasTarget)
        {
            canseek= false;
            if (!bounced6)
            {
                FillFoodList();

                //print("Hunger Threshold Reached and Target Acquired");
                currentNearest = FindNearest();
                if (currentNearest)
                {
                    currentTarget = currentNearest.gameObject;
                    hasTarget = true;
                }
            }
            if (bounced6)
            {
                FillFoodList();
                //print("Bounced");
                currentNearest = FindSecondNearest();
                if (currentNearest == null)
                {
                    currentNearest = FindNearest();
                }
                if (currentNearest)
                {
                    currentTarget = currentNearest.gameObject;
                    hasTarget = true;
                }
            }
        }
        if (currentTarget)
        {

            hasTarget = true;
            canseek= true;
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

    private void FixedUpdate()
    {

        if (currentNearest)
        {
            Vector2 directiontoTarget = currentNearest.position - transform.position;
            Vector2 origin = new Vector2(transform.position.x + directiontoTarget.normalized.x / 3, transform.position.y + directiontoTarget.normalized.y / 3);

            RaycastHit2D hitb = Physics2D.Raycast(origin, directiontoTarget);
            Debug.DrawRay(origin, directiontoTarget, Color.green);

            if (hitb.collider)
            {
                //print(hitb.collider.gameObject.name);
                hitbObject = hitb.collider.gameObject;
                if (Vector2.Distance(origin, hitb.point) ==0)
                {
                    if (state == State.IDLE)
                    {
                        currentNearest = FindWanderSpot();
                    }
                }
            }
        }

        if (canseek)
        {
            if (!waiting)
            {
                if (currentTarget != null)
                {
                    FollowTargetWitouthRotation(currentTarget.transform, stopDist, speed);
                }
            }

        }
        if (canDetect)
        {
            end = new Vector2(transform.position.x, transform.position.y) + new Vector2(xend, yend);
            start = new Vector2(transform.position.x, transform.position.y) + new Vector2(xstart, ystart);

            start2 = new Vector2(transform.position.x, transform.position.y) + new Vector2(xstart2, ystart2);
            end2 = new Vector2(transform.position.x, transform.position.y) + new Vector2(xend2, yend2);

            start3 = new Vector2(transform.position.x, transform.position.y) + new Vector2(xstart3, ystart3);
            end3 = new Vector2(transform.position.x, transform.position.y) + new Vector2(xend3, yend3);

            start4 = new Vector2(transform.position.x, transform.position.y) + new Vector2(xstart4, ystart4);
            end4 = new Vector2(transform.position.x, transform.position.y) + new Vector2(xend4, yend4);

            RaycastHit2D hit = Physics2D.Linecast(start, end);
            RaycastHit2D hit2 = Physics2D.Linecast(start2, end2);
            RaycastHit2D hit3 = Physics2D.Linecast(start3, end3);
            RaycastHit2D hit4 = Physics2D.Linecast(start4, end4);
            Debug.DrawLine(start, end, Color.red);
            Debug.DrawLine(start2, end2, Color.red);
            Debug.DrawLine(start3, end3, Color.red);
            Debug.DrawLine(start4, end4, Color.red);
            //Physics2D.LinecastNonAlloc(start, end, hits);
            //if (hit)
            //{


            //}

            //Physics2D.Linecast( start, end) ;
            if (hit)
            {
                if (hit.collider.gameObject.tag != "Food")
                {
                    if (hit.collider.gameObject.tag != "WanderTarget")
                    {
                        if (hit.collider.gameObject.tag != "Poop")
                        {
                            if (hit.collider.gameObject.tag != "NPC")
                            {
                                //print("Detected Object Up");
                                hasObstacle1 = true;
                                noObstacle = false;

                                infront = true;


                            }


                            if (hit.collider.gameObject.CompareTag("NPC"))
                            {
                                if (openToPlay)
                                {
                                    if (hit.collider.gameObject.GetComponent<NPCAI>().openToPlay)
                                    {
                                        state = State.PLAYFUL;
                                    }
                                }
                            }


                        }




                        if (hasObstacle1)
                        {
                            if (currentTarget)
                            {
                                var obstacle = hit.collider.gameObject;

                                // print("hit stopped");
                                // print("stopped touching");

                                if (!check2)
                                {
                                    StartCoroutine(ContinueSeeking(obstacle, hitbObject));
                                }
                            }

                        }
                    }
                }
                else
                {
                    if (hit.collider.gameObject.CompareTag("Food"))
                    {
                        currentNearest = hit.collider.gameObject.transform;
                        currentTarget = hit.collider.gameObject;
                    }
                }
                //nextto = false;
                //ChangeDirection();
                //print("There is something in front of the object!");
                //print(hits[0].collider.gameObject.name);
            }
            else
            {
                if (!hit)
                {


                }












            }
            if (hit2)
            {
                //print("Detected Object Right");
                if (hit2.collider.gameObject.tag != "Food")
                {
                    if (hit2.collider.gameObject.tag != "WanderTarget")
                    {
                        if (hit2.collider.gameObject.tag != "Poop")
                        {

                            if (hit2.collider.gameObject.tag != "NPC")
                            {
                                hasObstacle2 = true;
                                noObstacle = false;

                                nextto = true;

                            }

                            if (hit2.collider.gameObject.CompareTag("NPC"))
                            {
                                if (openToPlay)
                                {
                                    if (hit2.collider.gameObject.GetComponent<NPCAI>().openToPlay)
                                    {
                                        state = State.PLAYFUL;
                                    }
                                }
                            }
                        }
                        
                        if (hasObstacle2)
                        {
                            var obstacle = hit2.collider.gameObject;

                            if (currentTarget)
                            {
                                //print("stopped touching");
                                Vector2 direction = currentTarget.transform.position - transform.position;

                                if (!check2)
                                {
                                    StartCoroutine(ContinueSeeking(obstacle, hitbObject));
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (hit2.collider.gameObject.CompareTag("Food"))
                    {
                        currentNearest = hit2.collider.gameObject.transform;
                        currentTarget = hit2.collider.gameObject;
                    }
                }
                //infront = false;
                //ChangeDirection();
                //print("There is something in front of the object!");
                //print(hits[0].collider.gameObject.name);
            }
            else
            {
                if (!hit2)
                {


                }
            }

            if (hit3)
            {
                //print("Detected Object Left");
                if (hit3.collider.gameObject.tag != "Food")
                {
                    if (hit3.collider.gameObject.tag != "WanderTarget")
                    {
                        if (hit3.collider.gameObject.tag != "Poop")
                        {

                            if (hit3.collider.gameObject.tag != "NPC")
                            {
                                hasObstacle3 = true;
                                noObstacle = false;

                                nextto = true;

                            }

                            if (hit3.collider.gameObject.CompareTag("NPC"))
                            {
                                if (openToPlay)
                                {
                                    if (hit3.collider.gameObject.GetComponent<NPCAI>().openToPlay)
                                    {
                                        state = State.PLAYFUL;
                                    }
                                }
                            }
                        }
                        
                        if (hasObstacle3)
                        {
                            var obstacle = hit3.collider.gameObject;

                            if (currentTarget)
                            {
                                //print("stopped touching");
                                Vector2 direction = currentTarget.transform.position - transform.position;

                                if (!check2)
                                {
                                    StartCoroutine(ContinueSeeking(obstacle, hitbObject));
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (hit3.collider.gameObject.CompareTag("Food"))
                    {
                        currentNearest = hit3.collider.gameObject.transform;
                        currentTarget = hit3.collider.gameObject;
                    }
                    
                }
                //infront = false;
                //ChangeDirection();
                //print("There is something in front of the object!");
                //print(hits[0].collider.gameObject.name);
            }
            else
            {
                if (!hit3)
                {


                }
            }

            if (hit4)
            {
                //print("Detected Object Down");
                if (hit4.collider.gameObject.tag != "Food")
                {
                    if (hit4.collider.gameObject.tag != "WanderTarget")
                    {
                        if (hit4.collider.gameObject.tag != "Poop")
                        {

                            if (hit4.collider.gameObject.tag != "NPC")
                            {
                                hasObstacle4 = true;
                                noObstacle = false;

                                infront = true;

                            }
                            else
                            {
                                if (hit4.collider.gameObject.CompareTag("NPC"))
                                {
                                    if (openToPlay)
                                    {
                                        if (hit4.collider.gameObject.GetComponent<NPCAI>().openToPlay)
                                        {
                                            state = State.PLAYFUL;
                                        }
                                    }
                                }
                            }
                        }
                        if (hasObstacle4)
                        {
                            var obstacle = hit4.collider.gameObject;

                            if (currentTarget)
                            {
                                Vector2 direction = currentTarget.transform.position - transform.position;

                                //print("stopped touching");
                                if (!check2)
                                {
                                    StartCoroutine(ContinueSeeking(obstacle, hitbObject));
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (hit4.collider.gameObject.CompareTag("Food"))
                    {
                        currentNearest = hit4.collider.gameObject.transform;
                        currentTarget = hit4.collider.gameObject;
                    }
                }
                // nextto = false;
                //ChangeDirection();
                //print("There is something in front of the object!");
                //print(hits[0].collider.gameObject.name);
            }
            else
            {
                if (!hit4)
                {


                }
            }


            if (!waiting)
            {
                if (!cantTurn)
                {

                    if (directionAvg == 0)
                    {
                        anim.SetTrigger("Down");
                        //StartCoroutine(WaitToTurn());
                    }
                    else
                    {
                        if (directionAvg == 1)
                        {
                            anim.SetTrigger("Up");
                            //StartCoroutine(WaitToTurn());

                        }
                        else
                        {
                            if (directionAvg >= 2)
                            {
                                anim.SetTrigger("Side");
                                //StartCoroutine(WaitToTurn());


                            }
                        }
                    }
                }
            }
            else
            {
                if (waiting)
                {

                }
            }


            if (infront && !nextto)
            {
                ChangeDirection();

            }
            if (nextto && !infront)
            {
                UpDown();

            }
            if (infront && nextto)
            {

                waiting = false;



            }

            if (!hit && !hit2 && !hit3 && !hit4)
            {
                noObstacle = true;
            }
            else
            {
                noObstacle = false;
            }

            if (noObstacle)
            {
                hasObstacle1 = false;
                hasObstacle2 = false;
                hasObstacle3 = false;
                hasObstacle4 = false;
                if (infront)
                {
                    if (!holdOnce)
                    {
                        dontCheckRays = true;
                        StartCoroutine(HoldOnASec());
                        holdOnce = true;
                    }
                }
                if (nextto)
                {
                    if (!holdOnce)
                    {
                        dontCheckRays = true;
                        StartCoroutine(HoldOnASec());
                        holdOnce = true;
                    }
                }


            }

            if (hitbObject == currentTarget)
            {

                //print("Passed Obstacle");
                infront = false;
                nextto = false;
                //print("Stopped Detecting Obstacle");
                gotRando = false;
                waiting = false;


                moving = false;
                StartCoroutine(BoolReset(2));

            }
        }

    }

    public IEnumerator WaitToTurn()
    {
        cantTurn = true;
        yield return new WaitForSeconds(1f);
        cantTurn = false;
    }

    public IEnumerator HoldOnASec()
    {
        canDetect = false;
        yield return new WaitForSecondsRealtime(2);
        if (noObstacle)
        {
            hasObstacle1 = false;
            hasObstacle2 = false;
            hasObstacle3 = false;
            hasObstacle4 = false;
            waiting = false;
            canseek = true;
            nextto = false;
            infront = false;
            gotRando = false;
            
        }
        yield return new WaitForSecondsRealtime(5);
        canDetect = true;
        //holdOnce = false;
        StartCoroutine(BoolReset(1));
        StopCoroutine(HoldOnASec());
        
    }

    public IEnumerator ContinueSeeking(GameObject obstacle, GameObject hitobject)
    {
        check2 = true;
        //if (!moving)
        // {
        //infront = true;
        //nextto = true;
        //moving = true;
        //hasObstacle = false;
        if (obstacle)
        {
            currentObstacle = obstacle;
        }
        hasObstacle1 = false;
        hasObstacle2 = false;
        hasObstacle3 = false;
        hasObstacle4 = false;
        if (dontCheckRays)
        {
            yield return null;

            StopCoroutine(ContinueSeeking(null, hitbObject));

        }
        yield return new WaitForSeconds(2);
        if (dontCheckRays)
        {
            yield return null;
            StopCoroutine(ContinueSeeking(null, hitbObject));

        }
        
        if (!dontCheckRays)
        {
            float randtime = Random.Range(2, 6);
            yield return new WaitForSecondsRealtime(randtime);
            dontCheckRays = true;

            // Debug.DrawLine(start, end, Color.yellow);
            //RaycastHit2D check = Physics2D.Linecast(start, end);
            if (hitobject==currentTarget)
            {

                //print("Passed Obstacle");
                infront = false;
                nextto = false;
                //print("Stopped Detecting Obstacle");
                gotRando = false;
                waiting = false;


                moving = false;
                StartCoroutine(BoolReset(randtime));

            }
            else
            {
               // print("Still Obstacle");
                //gotRando = false;
                StartCoroutine(BoolReset(randtime));

            }
            StopCoroutine(ContinueSeeking(null, hitbObject));
        }
        
        
           
       // }
       
    }
    IEnumerator BoolReset(float time)
    {

        yield return new WaitForSecondsRealtime(time);
        
        
            //print("why?");
            dontCheckRays = false;
            check2 = false;
        holdOnce = false;
        
        StopCoroutine(BoolReset(time));
    }

    public void ChangeDirection()
    {
        //print("Detected Obstacle in Front or Behind Me");
        //canseek = false;
        waiting = true;
        //var direction = Vector2.zero;
        var direction = Vector2.zero;
        if (!gotRando)
        {
            rando = Random.Range(0, 2);
            gotRando = true;
            //rb.velocity = Vector2.zero;
        }
        if (testofDirection.normalized.x<0)   //was rando, now trying target direction
        {
             direction = Vector2.left;
        }
        if (testofDirection.normalized.x>0)
        {
             direction = Vector2.right;

        }
        rb.velocity = Vector2.zero;
        rb.AddRelativeForce(direction.normalized * speed, ForceMode2D.Force);
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxVelocity);


        //yield return new WaitForSeconds(3);
        // canseek = true;
        //waiting = false;
    }
    public void UpDown()
    {
        //print("Detected Obstacle Beside Me");
        //canseek = false;
        waiting = true;
        //var direction = Vector2.zero;
        var direction = Vector2.zero;
        if (!gotRando)
        {
            rando = Random.Range(0, 2);
            

            gotRando = true;
            //rb.velocity = Vector2.zero;
        }
        if (testofDirection.normalized.y>0)
        {
            direction = Vector2.up;
        }
        if (testofDirection.normalized.y<0)
        {
            direction = Vector2.down;

        }
        rb.velocity = Vector2.zero;
        rb.AddRelativeForce(direction.normalized * speed, ForceMode2D.Force);
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxVelocity);


        //yield return new WaitForSeconds(3);
        // canseek = true;
        //waiting = false;
    }
    public int FriendsNearby()
    {
        FillFriendsList();
        int count = 0;
        foreach(GameObject f in friends)
        {
            
            if (Vector2.Distance(f.transform.position, transform.position) < friendDistance)
            {
                 count++;
            }
        }
        return count;
    }
    public IEnumerator CountFriends()
    {
        while (alive)
        {
            //print("Counted Friends");
            if (timetilcount == 0)
            {
                timetilcount = 10;
            }
            friendsNearbyNum = FriendsNearby();
            yield return new WaitForSeconds(timetilcount);
            
        }
        yield return null;
    }


    public void CalculateCurrentFriendship()
    {
        if (friendship > 0)
        {
            if (friendSatiety > friendsNearbyNum)
            {
                toSubtract = friendSatiety / friendsNearbyNum;
                friendship = friendship - toSubtract;
                isAddingFriendship = false;
            }
            else
            {
                if (friendSatiety < friendsNearbyNum)
                {
                    toSubtract = (friendSatiety / friendsNearbyNum) * friendsNearbyNum;
                    friendship = friendship + toSubtract;
                    isAddingFriendship = true;
                }
            }
            



        }
        
        

    }
    public IEnumerator FriendshipMeter()
    {
        while (alive)
        {
            yield return new WaitForSeconds(friendshipTime);
            CalculateCurrentFriendship();
        }
        yield return null;
    }

    public void ClearTarget()
    {
        currentNearest = null;
        currentTarget = null;
    }


    // Update is called once per frame
    void Update () {
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


        count++;
        sum += intDirection;
        if (count == 1)
        {
            directionAvg = sum;
            count = 0;
            sum = 0;
        }
        if (testing)
        {
            if (Input.GetKey(KeyCode.W))
            {
                Move(new Vector2(0, 1), speed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                Move(new Vector2(0, -1), speed);
            }
            if (Input.GetKey(KeyCode.A))
            {
                Move(new Vector2(-1, 0), speed);
            }
            if (Input.GetKey(KeyCode.D))
            {
                Move(new Vector2(1, 0), speed);
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
                        if (state!=State.PLAYFUL)
                        {

                            ClearTarget();
                           // state = State.LONELY;
                        }
                    }
                }
            }
        }
        
        if (hunger < hungerThreshold)
        {
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
            if (state != State.SLEEPING)
            {
                //idle state is here as a placeholder until advanced state priority management is in place
                if (state!=State.LONELY)
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
        if (poopCount >= poopThreshold)
        {
            if (!justPooped)
            {
                Instantiate(poopPrefab, gameObject.transform.position, transform.rotation);
                audiosource.PlayOneShot(poopSound,.004f);
                justPooped = true;
                poopCount = 0;
            }
        }
        if (poopCount == 0)
        {
            justPooped = false;
        }
        if (!currentNearest)
        {
            hasTarget = false;
        }
    }
}
