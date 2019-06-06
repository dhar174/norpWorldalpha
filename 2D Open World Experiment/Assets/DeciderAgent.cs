using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class DeciderAgent : Agent
{
    public NorpAgent norpAgent;
    public NorpAI norpAI;
    public RayPerception rayPer;
    public override void InitializeAgent()
    {
        base.InitializeAgent();
        norpAgent = gameObject.GetComponent<NorpAgent>();
        rayPer = gameObject.GetComponent<RayPerception>();
        norpAI = gameObject.GetComponent<NorpAI>();
    }

    public override void CollectObservations()
    {
        if (norpAgent == null) {
            norpAgent = gameObject.GetComponent<NorpAgent>();
        }
        if (rayPer == null) {
            rayPer = gameObject.GetComponent<RayPerception>();
        }
        if (norpAI == null) {
            norpAI = gameObject.GetComponent<NorpAI>();
        }
        AddVectorObs(norpAgent.currentReward);
        AddVectorObs(norpAgent.GetReward());
        AddVectorObs(norpAgent.GetStepCount());
        AddVectorObs(norpAgent.relativePositionToTarget);
        AddVectorObs(gameObject.transform.position);
        AddVectorObs(norpAI.currentTarget.transform.position);
        //AddVectorObs(rayPer.currentNearest.transform.position);
       // if (rayPer.currentNearest.gameObject.tag == norpAgent.targetTag)
      //  {
            AddVectorObs(1);
      //  }
      //  else
      //  {
            AddVectorObs(0);
      //  }
    }

    public override void AgentAction(float[] vectorAction, string textAction)
    {

    }

    public override void AgentReset()
    {

    }

    public override void AgentOnDone()
    {

    }
}
