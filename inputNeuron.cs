using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputNeuron : MonoBehaviour
{
    
        public int nameID =0;
        public float senseThresh;

        public float MemPo;
    public double delta = 0;

    public int axonConn;
        public bool fire = false;

        //dendrites = dict<id-of-neuron-connected-to, synaptic weight>
        //conections = dict<id-of-neuron-connected-to, synaptic weight>
        public IDictionary<int, float> inputWeights = new Dictionary<int, float>();
        public IDictionary<int, float> inputs = new Dictionary<int, float>();


    
}
