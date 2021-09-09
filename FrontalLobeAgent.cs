using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;



public class FrontalLobeAgent : Agent {
    private NorpAI norpai;

    public bool useVectorObs;

    private Calendar cal;

    public float hunger;
    public float hungerTime;
    public float hungerThreshold;


    public bool angry;
    public bool moping;
    public bool scared;
    public bool hasPlayPartner;
    public bool hasMatingPartner;
    public bool matingSatiety;
    public int matingRejuvDays;

    public bool holdingObj;
    public bool holdingFood;
    
    

    public float SleepTime;
    public float SleepNeed;
    public float SleepThreshold;

    public float exploration;
    public float explorationThreshold;
    public Vector2 expStartPos;

    public float pain;

    public float thirst;
    public float thirstThreshold;
    public bool isThirsty;

    public float friendship;
    public float friendshipNeed;

    public float boredom;
    public float boredomThreshhold;

    public int poopCount;
    public int poopThreshold;

    public float anger;
    public float angerThreshold;

    public float sadness;
    public float sadThreshold;

    public float horniness;

    public bool curious;


    // Use this for initialization
    public override void Initialize()
    {
        matingRejuvDays = Random.Range(1, 4);
        cal = GameObject.Find("Calendar").GetComponent<Calendar>();
        norpai = this.gameObject.GetComponent<NorpAI>();
        hunger = norpai.hunger;
        hungerTime = norpai.hungerTime;
        hungerThreshold = norpai.hungerThreshold;
        SleepTime = norpai.SleepTime;
        SleepNeed = norpai.SleepNeed;
        SleepThreshold = norpai.SleepThreshold;
        exploration = norpai.exploration;
        explorationThreshold = norpai.explorationThreshold;
        pain = norpai.pain;
        thirst = norpai.thirst;
        thirstThreshold = norpai.thirstThreshold;
        isThirsty = norpai.isThirsty;
        friendship = norpai.friendship;
        friendshipNeed = norpai.friendshipNeed;
        boredom = norpai.boredom;
        boredomThreshhold = norpai.boredomThreshhold;
        poopCount = norpai.poopCount;
        poopThreshold = norpai.poopThreshold;
        anger = norpai.anger;
        angerThreshold = norpai.angerThreshold;
        sadness = norpai.sadness;
        sadThreshold = norpai.sadThreshold;
        horniness = norpai.horniness;

    }

    public override void CollectObservations(VectorSensor sensor)
    {
        if (useVectorObs)
        {

            //stable values

            hungerThreshold = norpai.hungerThreshold;
            sensor.AddObservation(hungerThreshold);

            SleepThreshold = norpai.SleepThreshold;
            sensor.AddObservation(SleepThreshold);

            thirstThreshold = norpai.thirstThreshold;
            sensor.AddObservation(thirstThreshold);


            friendshipNeed = norpai.friendshipNeed;
            sensor.AddObservation(friendshipNeed);


            boredomThreshhold = norpai.boredomThreshhold;
            sensor.AddObservation(boredomThreshhold);


            poopThreshold = norpai.poopThreshold;
            sensor.AddObservation(poopThreshold);


            angerThreshold = norpai.angerThreshold;
            sensor.AddObservation(angerThreshold);


            sadThreshold = norpai.sadThreshold;
            sensor.AddObservation(sadThreshold);



            //dynamic values

            hunger = norpai.hunger;
            sensor.AddObservation(hunger);

            SleepNeed = norpai.SleepNeed;
            sensor.AddObservation(SleepNeed);

            exploration = norpai.exploration;
            sensor.AddObservation(exploration);


            explorationThreshold = norpai.explorationThreshold;
            sensor.AddObservation(explorationThreshold);


            pain = norpai.pain;
            sensor.AddObservation(pain);


            thirst = norpai.thirst;
            sensor.AddObservation(thirst);


            isThirsty = norpai.isThirsty;
            sensor.AddObservation(isThirsty);


            friendship = norpai.friendship;
            sensor.AddObservation(friendship);


            boredom = norpai.boredom;
            sensor.AddObservation(boredom);


            poopCount = norpai.poopCount;
            sensor.AddObservation(poopCount);


            anger = norpai.anger;
            sensor.AddObservation(anger);


            sadness = norpai.sadness;
            sensor.AddObservation(sadness);


            horniness = norpai.horniness;
            sensor.AddObservation(horniness);



        }


    }

    public void PoopReward(float value)
    {
        AddReward(value);


    }




    public void MoveAgent(float[] act)
    {

        switch ((int)act[1])
        {
            case 1:
                //tell Target Choosing brain to change target
                break;
        }

        switch ((int)act[1])
        {
            case 1:
                //change state to wander/idle

                norpai.state = NorpAI.State.IDLE;

                break;
            case 2:
                //change state to Foraging
                norpai.state = NorpAI.State.FORAGING;


                break;
            case 3:

                //change state to Seeking Water
                norpai.state = NorpAI.State.THIRSTY;


                break;
            case 4:

                //change state to playful
                norpai.state = NorpAI.State.PLAYFUL;

                break;
            case 5:

                //change state to relaxing
                norpai.state = NorpAI.State.RELAXING;


                break;

            case 6:

                //change state to horny
                norpai.state = NorpAI.State.HORNY;


                break;

            case 7:

                //change state to lonely/seeking friends
                norpai.state = NorpAI.State.LONELY;


                break;

            case 8:

                //change state to tantrum
                norpai.state = NorpAI.State.ANGRY;

                break;

            case 9:

                //change state to sleeping
                norpai.state = NorpAI.State.SLEEPING;

                break;

            case 10:

                //change state to fleeing
                norpai.state = NorpAI.State.FLEEING;

                break;

            case 11:

                //go potty
                norpai.Poop();

                break;

            case 12:

                //change state to exploring
                norpai.state = NorpAI.State.EXPLORING;

                break;


        }
        angry = norpai.angry;
        switch ((int)act[2])
        {

            case 1:
                
               
                    //tantrum action
                    tantrum();
                
               
                    AddReward(-1);
                    //tantrum action
                    tantrum();
                

                break;
            case 2:
                //attack action
                Attack();
                break;
            case 3:
                //play
                Play();
                break;
            case 4:
                //mate action
                Mate();
                break;
            case 5:
                
                break;




        }
    }

    public void Play()
    {
        
        if (hasPlayPartner)
        {
            //play playing animation
            AddReward(1);

            if (norpai.state == NorpAI.State.PLAYFUL)
            {
                AddReward(1);
            }
        }
    }

    public void Mate()
    {
        if (hasMatingPartner)
        {
            if (!matingSatiety)
            {
                //play mating animation

                matingSatiety = true;
            }
        }
        
    }


    public void tantrum()
    {
        angry = norpai.angry;
        if (angry)
        {
            AddReward(.1f);
        }
        else
        {
            AddReward(-1f);
        }
        anger -= (1);
        //play tantrum animation


    }

    public void Attack()
    {
        //play attack anim
        if (angry)
        {
            anger--;
            AddReward(.1f);
        }
        else
        {
            if (!scared)
            {
                anger++;
                AddReward(-1);
            }
            else
            {
                AddReward(.1f);
            }
        }
    }

    public void RemoveBoredom(float val)
    {
        boredom -= val;
        norpai.boredom -= val;
        AddReward(val * .1f);
    }

    public void Pain()
    {
        pain = norpai.pain;
        AddReward(-pain);
    }


    public override void OnActionReceived(float[] vectorAction)
    {

        if (hunger < hungerThreshold)
        {
            if (cal.secondsCounter == 0)
            {
                AddReward(-.1f);
            }

        }
        if (isThirsty)
        {
            if (cal.secondsCounter == 0)
            {
                AddReward(-.1f);
            }
        }
        if (SleepNeed > SleepThreshold)
        {
            if (cal.secondsCounter == 0)
            {
                AddReward(-.01f);
            }
        }
        if (friendship < friendshipNeed)
        {
            if (cal.secondsCounter == 0)
            {
                AddReward(-.001f);
            }
        }
        if (cal.hourCounter == 0)
        {
            if (cal.MinuteCounter == 0)
            {
                if (cal.secondsCounter == 0)
                {
                    friendship = norpai.friendship;
                    friendshipNeed = norpai.friendshipNeed;



                    AddReward(Mathf.LerpUnclamped(0, 10, (friendship - friendshipNeed)));
                    //print(Mathf.LerpUnclamped(0, 10, (friendship - friendshipNeed)));
                }
            }
        }
        angry = norpai.angry;
        if (cal.hourCounter == 0)
        {
            if (cal.MinuteCounter == 0)
            {
                if (cal.secondsCounter == 0)
                {
                    horniness = norpai.horniness;

                    if (horniness > norpai.hornyFactors[0] && horniness>norpai.hornyFactors[1])
                    {
                        AddReward((horniness) * (norpai.hornyFactors[1] * -.1f));
                    }

                    if (angry)
                    {
                        if (anger <= angerThreshold)
                        {
                            AddReward(-1f);
                        }
                        else
                        {
                            if (anger >= angerThreshold)
                            {
                                AddReward(1);
                            }
                        }
                    }
                    matingRejuvDays--;
                    if (matingRejuvDays == 0)
                    {
                        matingSatiety = false;
                        matingRejuvDays = Random.Range(1, 4);
                    }


            }   }
        

        }

        





        MoveAgent(vectorAction);

    }

    public void ExplorationReward()
    {
        exploration = norpai.exploration;
        explorationThreshold = norpai.explorationThreshold;
        float val = exploration - explorationThreshold;

        if (val < 0)
        {
            if (curious)
            {
                AddReward(val);
            }
        }
        if (val > 0) {
            RemoveBoredom(10);
            if (!curious)
            {
                AddReward(val * .01f);
            }
            else
            {
                AddReward((val*2) * .01f);
            }
        }
    }

    public override void OnEpisodeBegin()
    {
        print("Agent reset");
        
        base.OnEpisodeBegin();
        //GameObject.Find("NorpAcademy").GetComponent<NorpAcademy>().Done();
        //InitializeAgent();
    }

    public void AgentOnDone()
    {

    }

        // Update is called once per frame
     public void FixedUpdate()

    {
        
    }
}
