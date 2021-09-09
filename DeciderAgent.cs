using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;

public class DeciderAgent : Agent
{
    public NorpAgent norpAgent;
    public NorpAI norpAI;
    public RayPerception rayPer;
    public override void Initialize()
    {
        base.Initialize();
        norpAgent = gameObject.GetComponent<NorpAgent>();
        rayPer = gameObject.GetComponent<RayPerception>();
        norpAI = gameObject.GetComponent<NorpAI>();
    }

    public override void CollectObservations(VectorSensor sensor)
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
        sensor.AddObservation(norpAgent.currentReward);
        sensor.AddObservation(norpAgent.GetCumulativeReward());
        sensor.AddObservation(norpAgent.StepCount);
        sensor.AddObservation(norpAgent.relativePositionToTarget);
        sensor.AddObservation(gameObject.transform.position);
        sensor.AddObservation(norpAI.currentTarget.transform.position);
        //AddVectorObs(rayPer.currentNearest.transform.position);
        // if (rayPer.currentNearest.gameObject.tag == norpAgent.targetTag)
        //  {
        sensor.AddObservation(1);
        //  }
        //  else
        //  {
        sensor.AddObservation(0);
      //  }
    }

    public override void OnActionReceived(float[] vectorAction)
    {

    }

    public override void OnEpisodeBegin()
    {

    }

    public  void AgentOnDone()
    {

    }
}
