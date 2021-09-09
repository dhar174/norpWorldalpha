using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outputNeuron : MonoBehaviour
{
   
        public int nameID;
    //public float senseThresh;
    public double delta = 0;

    public float MemPo;

        public int axonConn;
        public bool fire = false;

        //dendrites = dict<id-of-neuron-connected-to, synaptic weight>
        //conections = dict<id-of-neuron-connected-to, synaptic weight>
        public IDictionary<int, float> outputWeights = new Dictionary<int, float>();
        public IDictionary<int, float> outputs = new Dictionary<int, float>();


    
}
