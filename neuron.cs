using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using System.Linq;
using JacksonDunstanIterator;
using Unity.MLAgents.Sensors;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class neuron : MonoBehaviour
{
    public int nameID;
    public double delta = 0;

    public float MemPo;

    public int axonConn;
    public bool fire = false;

    //dendrites = dict<id-of-neuron-connected-to, synaptic weight>
    //conections = dict<id-of-neuron-connected-to, synaptic weight>
    public IDictionary<int, float> dendriteWeights = new Dictionary<int, float>();
    public IDictionary<int, float> connections = new Dictionary<int, float>();



}
