using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using System.Linq;
using JacksonDunstanIterator;
using Unity.MLAgents.Sensors;
using UnityEngine.Serialization;
using UnityEngine.UI;









public class SpikingNNv1 : MonoBehaviour
{


    public List<int> neuronTotal = new List<int>();

    public RayPerception rayPer;

    public float FireThresh;
    public float outputThresh;

    public List<int> cellIDs;
    public double[] momentums;

    public int neuronNum = 100;
    public double[] dedw;

    public float[] act;
    public float[] act1p;
    public float[] act2p;

    public bool inflip;
    public bool midflip;
    public bool outflip;

    public bool init;
    public neuron HL_neuron;

    public inputNeuron blank;
    public neuron blank2;
    public outputNeuron blank3;

    public int timer;
    //public List<neuron> neurons;
    public neuron[] neurons = new neuron[786];
    public inputNeuron[] inputNeurons = new inputNeuron[174];
    public outputNeuron[] outputNeurons = new outputNeuron[50];
    public List<float> obs = new List<float>();

    public int inputConnLim = 50;

    NorpAgentSpike norpagent;
    NorpAISpike norpai;

    public List<float> genericDendrites;
    //IDictionary<int, float> dendrites = new Dictionary<int, float>();
    //IDictionary<int, List<float>> connections = new Dictionary<int, List<float>>();

    //public float inputValue;
    public NorpAgentSpike nas;
    public List<int> inpNdict;

    // Start is called before the first frame update
    void Start()
    {
        act = new float[2];
        act1p = new float[] { 1, 2, 3, 4, 5 };
        act2p = new float[] { 1, 2, 3, 4, 5 };
        rayPer = GetComponent<RayPerception>();
       // print(inputNeurons.Length);
       // print(inputNeurons[5]);

        timer = 0;
        //for (int n = 0; n < neuronNum; n++)

       // float[] obs = new float[174];
        nas = gameObject.GetComponent<NorpAgentSpike>();
        obs = nas.CollectObservations();

        int id = 0;


        norpagent = gameObject.GetComponent<NorpAgentSpike>();
        norpai = gameObject.GetComponent<NorpAISpike>();

        List<inputNeuron> list1;
        list1 = new List<inputNeuron>();

        for (int ii = 0; ii < inputNeurons.Length; ii++)
        {
            
            blank = Instantiate(blank);
            blank.name = "Input Neuron " + ii;
            list1.Add(blank);
            list1[ii].nameID = id;
            neuronTotal.Add(id);
            //print("id= "+id+"ii= "+ii+"nameID= " +list1[ii].nameID);
            //print(list1[ii].nameID);
            //if (list1[ii].nameID != id)
            //{
            //    print("Mismatch before nameID change");
            //}
            
            id += 1;
        }

        inputNeurons = list1.ToArray();
        
        int usedTotal = 0;

        //int usedThis=0;


        foreach (inputNeuron g in inputNeurons)
        {
           IDictionary<int, float> obsDict = new Dictionary<int, float>();
            int ind = 0;

            // obs = obs.ToDictionary
            foreach (float f in obs)
            {
                obsDict.Add(ind, f);
                ind++;
            }

            int index = usedTotal;
            usedTotal++;
           
            if (usedTotal > obsDict.Count()) { usedTotal = 0; index = 0;}
                    //float val = obsDict[index];

                    g.inputWeights.Add(index, Random.Range(.00001f, 1f));
            g.MemPo = g.inputWeights[index];
            inpNdict.Add(index);
                    foreach (int c in g.inputWeights.Keys)
                    {

                        //g.dendriteWeights[c] = Random.Range(.00001f, 1f);
                        inputCycle(obsDict[index], g.nameID, index);

                    }
                
            

        }



        List<neuron> list2;
        list2 = new List<neuron>();

        for (int ii = 0; ii < neurons.Length; ii++)
        {
            
            blank2 = Instantiate(blank2);
            blank2.name = "Hidden Layer Neuron " + ii;

            list2.Add(blank2);
            neuronTotal.Add(id);
            list2[ii].nameID = id;
            if ((id-174) != ii)
            {
                print(" L2 ii: "+ii+" id: "+id+ " realID: "+ list2[ii].nameID);
            }
            //print(id);
            //print(neurons[ii].nameID);
            
            id += 1;

            

        }

        neurons = list2.ToArray();

        //inputConnLim = inputNeurons.Length * 2;

        inputConnLim = neurons.Length;
        if(inputConnLim > neurons.Length)
        {
            inputConnLim = neurons.Length+1 / 2;
            print("Mismatch of input and HL node counts. Problem has been corrected by a change of formula");
        }
        int inputConns = 0;
       // inpNdict = new List<int>();
        foreach (neuron g in neurons)
        {

            //inpNdict = new List<int>();
            //try
            //{
            //    print("g is: "+g.nameID);
            //}
            //catch
            //{
            //    print("Couldnt print");
            //}

            for (int x =0; x <= Random.Range(1, 8); x++)
            {
                int index = Random.Range(0, (inputNeurons.Length+neurons.Length));
                //print("lengths: " + (inputNeurons.Length + neurons.Length));
               // if(index>= neuronTotal.Count - outputNeurons.Length)
               // {
              //      print("woah " + (neuronTotal.Count - outputNeurons.Length));


               //// }
               // bool b1 = false;
               // bool b2 = false;

               //// try
               ////{
                   
               //     if (System.Array.Exists(neurons, element => element.nameID.Equals((index))))
               //     {
               //         b1 = true;
               //         print("sometimes n true, index:"+index);

               //     }
                   
               //     if (System.Array.Exists(inputNeurons, element => element.Equals(index)))
               //     {
               //         b2 = true;
               //         print("sometimes i true, index:" + index);

               //     }

               //     if (b1 || b2) {

               //         print("working normal");
               //     }
               //     else 
               //     {
               //         if (index < inputNeurons.Length)
               //         {


               //             if (inputNeurons[index].nameID != index)
               //             {
               //                 print("There's the issue, sucka, they dont exist! Index was " + index + "and g was " + g.nameID);
               //                 // try
               //                 //  {
               //                 print("b1 was " + b1 + "and b2 was " + b2 + "and should have really matching n " + neurons[index].nameID);
               //                 //  }
               //                 //  catch
               //                 //   {
               //                 print("was really matching ipn " + inputNeurons[index].nameID);
               //             }
               //         }
               //         else
               //         {
               //             if (neurons[index].nameID != index)
               //             {

               //                 print("Not finding it here either");
               //             }
               //         }
               //     }
                        
                       
                    
                  
                if (index < inputNeurons.Length)
                {
                    if(inputConns <= inputConnLim)
                    {
                        inputConns++;
                        if (!g.dendriteWeights.Keys.Contains(inputNeurons[index].nameID))
                        {
                            g.dendriteWeights.Add(inputNeurons[index].nameID, Random.Range(.00001f, 1f));
                            //inpNdict.Add(index);
                          //  print("Here's a conn to an input neuron");
                        }
                    }
                    else
                    {
                        if (!g.dendriteWeights.Keys.Contains(neurons[index-174].nameID))
                        {
                            g.dendriteWeights.Add(neurons[index - 174].nameID, Random.Range(.00001f, 1f));
                        }
                    }
                }
                else
                {
                    //print("index is " + index);
                    if (!g.dendriteWeights.Keys.Contains(neurons[index-174].nameID))
                    {
                        g.dendriteWeights.Add(neurons[index - 174].nameID, Random.Range(.00001f, 1f));
                    }
                }
                //else
                //{
                //    if (!g.dendriteWeights.Keys.Contains(neurons[index - inputNeurons.Length].nameID))
                //    {
                //        g.dendriteWeights.Add(neurons[index - inputNeurons.Length].nameID, Random.Range(.00001f, 1f));
                //    }
                //}
               // }
              // catch
              // {
                   // print("HERE'S YOUR PROBLEM, SON! Index "+index+" g: "+g.nameID);

              // }

                //g.dendriteWeights.Add(neurons[index].nameID, Random.Range(.00001f, 1f));

            }
            if (!g.dendriteWeights.Keys.Contains(g.nameID))
            {
                g.dendriteWeights.Add(g.nameID, Random.Range(.00001f, 1f));
            }
            g.MemPo = g.dendriteWeights[g.nameID];

            //print(g.dendriteWeights.Keys.Count);

            foreach (int c in g.dendriteWeights.Keys)
            {
                //g.dendriteWeights[c] = Random.Range(.00001f, 1f);
                //print("dendrite key in HL neuron is: " + c+" id: "+ g.nameID);
                //try
                //{
                    fireCycle(c, g.nameID);
                //}
                //catch
                //{
                //    print("didnt pass to fire cycle"+c+" "+" "+g.nameID+" "+" "+ inpNdict.Count + " id: " + id);
                   
                //}
                //print(c + "  " + g.nameID);

            }
            //print("Total Dendrites: " + g.dendriteWeights.Count);
        }

        List<outputNeuron> list3;
        list3 = new List<outputNeuron>();

        for (int ii = 0; ii < outputNeurons.Length; ii++)
        {
            

            blank3 = Instantiate(blank3);
            blank3.name = "Output Neuron " + ii;

            list3.Add(blank3);
            neuronTotal.Add(id);

            //print(id);
            //print(outputNeurons[ii].nameID);
            list3[ii].nameID = id;
            id += 1;
            
        }
        print("Adding all neurons equals " + id + "neurons");

        outputNeurons = list3.ToArray();

        int usedCells = 0;

        foreach (outputNeuron g in outputNeurons)
        {

            //IDictionary<int, float> actDict = new Dictionary<int, float>();
            //int ind = 0;

            


            // obs = obs.ToDictionary
            //foreach (float f in act)
            //{
            //    actDict.Add(ind, f);
            //    ind++;
            //}

            usedCells++;
            int index = usedCells;
            if (usedCells > outputNeurons.Length) { usedCells = 0;  }
            //float val = actDict[ind];

            //foreach (neuron n in neurons)
            //{
            int rn = Random.Range(0, neurons.Length);

                if (Random.Range(1, 6) == 1)
                {

                   

                        //g.dendriteWeights[c] = Random.Range(.00001f, 1f);
                        g.outputWeights.Add(neurons[rn].nameID, Random.Range(.00001f, 1f));

                    
                }
            if (!g.outputWeights.Keys.Contains(g.nameID))
            {
                g.outputWeights.Add(g.nameID, Random.Range(.00001f, 1f));
                g.MemPo = g.outputWeights[g.nameID];
            }




            //}
            foreach (int c in g.outputWeights.Keys)
                {

                //g.dendriteWeights[c] = Random.Range(.00001f, 1f);
                    //print(g.nameID);
                    outputCycle(c, g.nameID);

                }
            

        }


        //  int id = 0;
        //  foreach(int c in cellIDs)
        // {
        //   genericDendrites.Add(Random.Range(.00001f, 1f));
        //   id += 1;
        //   dendrites.Add(id, genericDendrites);
        // }
        init = true;
        int ni = neuronTotal.Count;
        dedw = new double[ni];
    }



    public void inputCycle(float ob, int id, int index)
    {
        ob =ob / 1;
        if (ob > inputNeurons[id].senseThresh)
        {
            inputNeurons[id].MemPo += ob * (1+ inputNeurons[id].inputWeights[index]);
        }

        inflip = true;
    }

    public void fireCycle(int c, int idc)
    {
        int ipIndex = 0;
        //print("c at firecycle of id " + id + " is " + c);
        int corr = 0;


        //c = c - inputNeurons.Length;
        if (!inpNdict.Contains(c))
        {
            bool check1 = false;
            
            foreach (neuron nnn in neurons)
            {
                
                if (nnn.nameID == c)
                {
                    check1 = true;
                    corr = nnn.nameID;
                    break;
                }
            }
           if(check1 != true)
            {
                print("Fuck");
            }
            //print("c= " + c + "length= " + neurons.Length);
            //    try
            //{
            if(c != corr)
            {
                print("Anomaly at " + c + " and " + corr);
            }


                if ( c > inputNeurons.Length)
                {
                    float dendWeight = 0;

                    foreach (int bb in neurons[idc-174].dendriteWeights.Keys)
                    {
                        if (bb > inputNeurons.Length)
                        {
                        //print("bb "+bb);
                            if (bb == neurons[bb-174].nameID)
                            {
                                dendWeight = neurons[idc - 174].dendriteWeights[bb];
                            }
                        }


                    }
                             //try
                             //{
                                  if (neurons[corr-174].MemPo > FireThresh)
                                    {
                        
                       
                                       if (DReLU(neurons[corr-174].MemPo) >= 1)
                                       {
                                          neurons[corr - 174].fire = true;
                                           neurons[idc - 174].MemPo += neurons[c - 174].MemPo * dendWeight;
                                        }
                                  }
                               //}
                            //catch
                            //{
                              // print("error: c= "+c+" corr="+corr);
                    
                //}
                    //   int z = neurons.Length + inputNeurons.Length;
                    //z = z 
                    //  int oc = c;
                    //  c = c - inputNeurons.Length;
                    //c = z - c;
                    //  if(c != neurons[c].nameID)
                    //  {
                    //       print("What?");
                    //      print("z= " + z+"real id= "+ neurons[c].nameID + "oc= "+oc);
                    //   }
                //}
            }
            //catch
            //{


                //try
                //{



                    //foreach (neuron nnn in neurons)
                    //{

                    //    if (nnn.nameID == c)
                    //    {
                    //        corr = nnn.nameID;
                    //        break;
                    //    }
                    //}
                    //float dendWeight2 = 0;

                    //foreach (int bb in neurons[idc].dendriteWeights.Keys)
                    //{
                    //    if (bb > inputNeurons.Length)
                    //    {
                    //        if (bb == neurons[bb].nameID)
                    //        {
                    //            dendWeight2 = neurons[idc].dendriteWeights[bb];
                    //            break;
                    //        }
                    //    }


                    //}
                    //if (neurons[c].MemPo > FireThresh)
                    //{
                    //    neurons[corr].fire = true;
                    //    neurons[idc].MemPo += neurons[corr].MemPo * dendWeight2;




                    //}
                    //print("Good? real id= " + neurons[c-inputNeurons.Length].nameID + "oc= " + c);
                //}
                //catch
                //{
                //    print("damn. c= "+c+" and g= "+id);
                //    //print("What? real id= " + neurons[c].nameID + "oc= " + c);
                //}
            //}
            

            

        }
        else
        {
            int ind = 0;

            // obs = obs.ToDictionary
            if (ipIndex > inpNdict.Count()) { ipIndex = 0; }
            float val = inpNdict[ipIndex];

            //foreach (inputNeuron nnn in inputNeurons)
            //{

            //    if (nnn.nameID == c)
            //    {
            //        corr = nnn.nameID;
            //        ipIndex++;
            //        break;
            //    }
            //}
            
           

            if (inputNeurons[corr].MemPo > FireThresh)
            {
               // print("id: " + id + "c: " + c+" corr: "+ corr);

                float dendWeight = 0;

                foreach (int bb in neurons[idc-174].dendriteWeights.Keys)
                {
                    if (bb < inputNeurons.Length)
                    {
                        if (bb == inputNeurons[bb].nameID)
                        {
                            dendWeight = neurons[idc-174].dendriteWeights[bb];
                        }
                    }


                }
                if (DReLU(inputNeurons[corr].MemPo) >= 1)
                {
                    inputNeurons[corr].fire = true;
                    neurons[idc-174].MemPo += inputNeurons[corr].MemPo * (1+dendWeight);
                    //print("Here's a conn to an input neuron: "+ neurons[idc - 174].nameID+ " with "+ neurons[idc - 174].MemPo);
                }
                else
                {
                    //print("input neuron firing failed");
                }
            }
        }
        

        midflip = true;
    }

    public void outputCycle(int c, int idp)
    {
        // print("outputconnections= " + outputNeurons[id - (inputNeurons.Length + neurons.Length)].outputWeights.Count); ;
        // print("1c= " + c);
        //c = c - (inputNeurons.Length);



        int count = 0;
        //foreach (neuron nn in neurons)
        //{
        //    if (nn.nameID == c)
        //    {
        //        neuron HL_neuron = nn;
        //        break;
        //    }
        //}

        // print("c= " + c + "length= " + outputNeurons.Length);

        //print("idp= " + idp);



        bool fitsa = false;
        //List<int> tempArra = new List<int>();

        //foreach (neuron ppp in neurons)
        //{
        //    tempArra.Add(ppp.nameID);
        //}
        //int[] tempArra2 = tempArra.ToArray();
        foreach (neuron on in neurons)
        {
            if (on.nameID == c)
            {

                fitsa = true;
                //print(idp.GetType());
                //c = System.Array.BinarySearch<int>(tempArra2, c);
                break;
            }
        }

       
        //print(HL_neuron.MemPo);
        float dendWeight = 0;
        if (fitsa)
        {
            //    try
            //    {

            neuron HL_neuron = neurons[c - 174];

            foreach (int bb in HL_neuron.dendriteWeights.Keys)
            {
                if (bb < neurons.Length && bb > inputNeurons.Length)
                {
                    if (bb == neurons[bb].nameID)
                    {
                        dendWeight = outputNeurons[idp].outputWeights[bb];
                    }
                }


            }




            if (HL_neuron.MemPo > FireThresh)
            {

                if (DReLU(outputNeurons[idp - 960].MemPo) >= 1)
                {
                    HL_neuron.fire = true;
                    outputNeurons[idp - 960].MemPo += HL_neuron.MemPo * (1 + dendWeight);


                }
            }
        }
        





        bool fits = false;
        //List<int> tempArr = new List<int>();

        //foreach (outputNeuron pp in outputNeurons)
        //{
        //    tempArr.Add(pp.nameID);
        //}
        //int[] tempArr2 = tempArr.ToArray();

        foreach (outputNeuron on in outputNeurons)
        {
            //if (count <= 50)
            //{
            //    print(outputNeurons[idp - 960].nameID + " " + on.nameID);
            //}
            //count++;
            if (on.nameID == outputNeurons[idp - 960].nameID)
            {

                fits = true;
                //print(idp.GetType());
                //idp = System.Array.BinarySearch<int>(tempArr2, idp);

            }
            //else
            //{
            //    // print("idp "+idp+" failed to get thru OP fit");
            //}

        }

            if (fits)
            {
               // print("Got thru OP fit");
                //    try
                //{
                outputNeuron OP_neuron = outputNeurons[idp - 960];
                if (OP_neuron.MemPo < .00001)
                {
                print("wtf? real name id " + outputNeurons[idp - 960].nameID + " with idp" + idp + " and mempo is " + OP_neuron.MemPo);
                }

                if (OP_neuron.MemPo > outputThresh)
                {
                    //print("Got thru OP thresh");
                    if (SoftPlus(outputNeurons[idp - 960].MemPo) >= 1)
                    {
                        OP_neuron.fire = true;
                    }

                }
                //}
                //catch
                //{
                //print("It did not work, idp was = " + (idp - 960));
                //}

                //else
                //{
                //    print("It did not poop, idp was = " + (idp - 960));
                //}


                //}
                //catch
                //{
                //print("It did not work, c was = " + c);
                //}
            }
            else
            {
               //print("It did not work, c was = " + c);
            }
            outflip = true;

        
    }
    public void actionCycle()
    {
        // HERE IS WHERE ACTIVATION FUNCTION NEEDS TO GO

        int xx = outputNeurons.Length;
        double[] votes = new double[5];
        double[] votes2 = new double[5];


        List<int> tempArr3 = new List<int>();

        foreach (outputNeuron pp in outputNeurons)
        {
            tempArr3.Add(pp.nameID);
        }
        int[] tempArr4 = tempArr3.ToArray();
        foreach (outputNeuron o in outputNeurons)
        {
            int oInd = System.Array.BinarySearch(tempArr4, o.nameID);
            int xxx = (xx / 2);
            if (oInd < xxx)
            {
                //print("first math works");

                if (o.fire)
                {



                    if (oInd <= xxx / 5)
                    {
                        votes[0]++;
                        //print("vote 0 works");
                    }
                    if (oInd > xxx / 5 && oInd <= xxx / 2)
                    {

                       
                            votes[1]++;

                       // print("vote 1 works");

                    }
                    if (oInd > xxx / 2 && oInd <= ((xxx / 4) * 3))
                    {
                       
                            votes[2]++;
                        

                    }
                    if (oInd > ((xxx / 4) * 3))
                    {

                            votes[3]++;
                        

                    }
                    if (oInd >= ((xxx / 5) * 4))
                    {

                     
                            votes[4]++;
                        

                    }
                    o.fire = false;
                }
                //else
                //{

                //    if (oInd <= xxx / 5)
                //    {
                //        //votes.Add(1, 0);
                //    }
                //    if (oInd > xxx / 5 && oInd <= xxx / 2)
                //    {

                //        if (oInd <= xxx / 5)
                //        {
                //            votes.Add(2, 0);
                //        }

                //    }
                //    if (oInd > xxx / 2 && oInd <= ((xxx / 4) * 3))
                //    {
                //        if (oInd <= xxx / 5)
                //        {
                //            votes.Add(3, 0);
                //        }

                //    }
                //    if (oInd > ((xxx / 4) * 3))
                //    {

                //        if (oInd <= xxx / 0)
                //        {
                //            votes.Add(4, 0);
                //        }

                //    }
                //    if (oInd >= ((xxx / 5) * 4))
                //    {

                //        if (oInd <= xxx / 5)
                //        {
                //            votes.Add(5, 0);
                //        }

                //    }
                //}
                //double[] wins = new double[5];
                //int nim = 0;
                //foreach(int num in votes.Keys)
                //{

                //    if (votes[num] == 1)
                //    {
                //        wins[num]++;
                //    }
                //}
                act[0] = (float)SoftMax(votes)+1;
            }
            else
            {
                if (oInd >=xxx)
                {
                    if (o.fire)
                    {



                        if (oInd - xxx <= xxx / 5)
                        {
                            votes2[0]++;
                           // print("vote2 1 works");

                        }
                        if (oInd - xxx > xxx / 5 && oInd - xxx <= xxx / 2)
                        {

                                votes2[1]++;
                           // print("vote2 2 works");


                        }
                        if (oInd - xxx > xxx / 2 && oInd - xxx <= ((xxx / 4) * 3))
                        {
                           
                                votes2[2]++;
                            

                        }
                        if (oInd - xxx > ((xxx / 4) * 3))
                        {

                            
                                votes2[3]++;
                            

                        }
                        if (oInd - xxx >= ((xxx / 5) * 4))
                        {

                                votes2[4]++;
                            

                        }
                        o.fire = false;
                    }
                    //else
                    //{

                    //    if (oInd <= -xxx / 5)
                    //    {
                    //        votes.Add(1, 0);
                    //    }
                    //    if (oInd - xxx > xxx / 5 && oInd - xxx <= xxx / 2)
                    //    {

                    //        if (oInd - xxx <= xxx / 5)
                    //        {
                    //            votes.Add(2, 0);
                    //        }

                    //    }
                    //    if (oInd - xxx > xxx / 2 && oInd - xxx <= ((xxx / 4) * 3))
                    //    {
                    //        if (oInd - xxx <= xxx / 5)
                    //        {
                    //            votes.Add(3, 0);
                    //        }

                    //    }
                    //    if (oInd - xxx > ((xxx / 4) * 3))
                    //    {

                    //        if (oInd - xxx <= xxx / 0)
                    //        {
                    //            votes.Add(4, 0);
                    //        }

                    //    }
                    //    if (oInd - xxx >= ((xxx / 5) * 4))
                    //    {

                    //        if (oInd - xxx <= xxx / 5)
                    //        {
                    //            votes.Add(5, 0);
                    //        }

                    //    }
                    //}
                    //double[] wins = new double[5];
                    //int nim = 0;
                    //foreach(int num in votes.Keys)
                    //{

                    //    if (votes[num] == 1)
                    //    {
                    //        wins[num]++;
                    //    }
                    //}
                    act[1] = (float)SoftMax(votes2) + 1;
                }

            }
        }
        //print("ACT[] =" + act[0] + " and " + act[1]);
        print("votes were: " + votes[0]+votes[1]+votes[2]+votes[3]+ votes[4] + " and " + votes2[0] +votes2[1]+votes2[2]+votes2[3]+votes2[4]);
        norpagent.MoveAgent(act);

        rewardPhase();

    }

    public void rewardPhase()
    {
        float reward = nas.totalReward;
        foreach (outputNeuron n in outputNeurons)
        {
            backwardOut(reward,n.nameID, n.outputWeights,n);
        }
        foreach (neuron n in neurons)
        {
            backwardHidden(n.nameID, n.dendriteWeights, n);
        }
    }

  
    public void backwardOut(double expected, int n, IDictionary<int, float> conns, outputNeuron oN)
    {
        //delta = output * (1 - output) * (output - expected);
       
        
         
        
        for (int j = 0; j < neuronTotal.Count; j++)
        {
            conns[j] =  Random.Range(.00001f, 1f);
        }

        momentums = new double[neuronTotal.Count];
        for (int i = 0; i < neuronTotal.Count; i++)
        {
            conns[i] = Random.Range(.00001f, 1f);
            momentums[i] = 0;
        }

        //Console.WriteLine("in");
    

    //Works!
    oN.delta = ReLUder( summation(obs,(x, y) => x * conns[y])) * (oN.MemPo - expected);
        //
        momentums = dedw;
        for (int i = 0; i < dedw.Length; i++)
        {
            dedw[i] = oN.delta * conns[i];
        }
    }


    public void backwardHidden(int myLayer, IDictionary<int,float> conns, neuron nn)
    {
       
        double s = 0;
        int index = myLayer;

        if(nn.nameID != myLayer)
        {
            print("Uh-oh");
            print(nn.nameID);
            print(myLayer);

        }
        else
        {
            print("Seems fine");

        }





        for (int i = 0; i < conns.Count; i++)
        {
            s += conns[index] * neurons[index].delta;
        }

        //delta = output * (1 - output) * s;//* (output - expected);
        //foreach(float f in obs)
      //  {
      //      print(f);
       // }
       

       // nn.delta = ReLUder(summation(obs, (x, y) => x * conns[y])) * s;
        //math.derLogisticsFunc(logFunc, inputs.summation((x, y) => x * weights[y])) = output * (1 - output)

        for (int i = 0; i < dedw.Length; i++)
        {
            dedw[i] = neurons[index].delta * conns[i];
        }
    }

    public static double summation(List<float> source, System.Func<float, int, float> action)
    {
        // double[] source2 = source.ToArray();
        //source.ThrowIfNull("source");
        //action.ThrowIfNull("action");
        //if (!(source.IsArrayOf(typeof(Double)))) throw new Exception("Needs to be double array");
        //float[] a = source.ToArray();
        List<float> a = source;
        float sum = 0;
        foreach (int i in a)
        {
            sum += action(a[i], i);
        }
        return sum;
    }

    public static double ReLUder( double x)
    {
        
           
                if (x < 0) return 0;
                if (x > 0) return 1;
                return 0;
            
        
    }

    public double SoftMax(double[] z)
    {


        var z_exp = z.Select(System.Math.Exp);
        // [2.72, 7.39, 20.09, 54.6, 2.72, 7.39, 20.09]

        var sum_z_exp = z_exp.Sum();
        // 114.98

        var softmax = z_exp.Select(i => i / sum_z_exp);
        // [0.024, 0.064, 0.175, 0.475, 0.024, 0.064, 0.175]

        double maxValue = softmax.Max();
        double maxIndex = softmax.ToList().IndexOf(maxValue);

        return maxIndex;
    }

    public double Logistic(double x)
    {
        print("x" + x);
        var p = 1 / (1 + System.Math.Pow(System.Math.E, -x));
        print("Logistic: " + p);
        print("Derivative: " + p * (1 - Logistic(x)));
        return 1 / (1 + System.Math.Pow(System.Math.E, -x));

    }

    public double DReLU(double x)
    {
        x = System.Math.Max(0, x);
        //print(x);
        return x;// x < 0 ? 0 : x;

    }
    public double SoftExponential(double x, double alpha)
    {

        // """Soft Exponential activation function by Godfrey and Gashler
        // See: https://arxiv.org/pdf/1602.01321.pdf
        // α == 0:  f(α, x) = x
        // α  > 0:  f(α, x) = (exp(αx)-1) / α + α
        // α< 0:  f(α, x) = -ln(1 - α(x + α)) / α
        // """

        if (alpha == 0)
            return x;
        else if (alpha > 0)
            return alpha + (System.Math.Exp(alpha * x) - 1.0) / alpha;
        else
            return -System.Math.Log(1 - alpha * (x + alpha)) / alpha;
    }
    // Update is called once per frame

    private void FixedUpdate()
    {

        if (inflip && midflip && outflip)
        {
            inflip = false;
            midflip = false;
            outflip = false;
            actionCycle();
            

        }


    }
    public double SoftPlus(double x)
    {
        return System.Math.Log(System.Math.Exp(x) + 1);
    }
    void Update()
    {
        
        if (init)
        {
            //print("Initialized");
            obs = nas.CollectObservations();
            bool bob = false;
            
            int tt = 0;
            foreach (inputNeuron g in inputNeurons)
            {
                IDictionary<int, float> obsDict = new Dictionary<int, float>();
                int ind = 0;

                
                foreach (float f in obs)
                {
                    obsDict.Add(ind, f);
                    ind++;
                }

                int index = tt;
                tt++;
                if (tt > obsDict.Count()) { tt = 0; index = 0; }
                float val = obsDict[index];

                // DO NOT add input weights/conns after init!! -> g.inputWeights.Add(index, Random.Range(.00001f, 1f));
                foreach (int c in g.inputWeights.Keys)
                {

                    
                    inputCycle(obsDict[index], g.nameID, index);

                }



            }
            foreach (neuron g in neurons)
            {


                    // DO NOT add input weights/conns after init!! ->g.dendriteWeights.Add(neurons[index].nameID, Random.Range(.00001f, 1f));
                    foreach (int c in g.dendriteWeights.Keys)
                    {


                        fireCycle(c, g.nameID);
                        //print(c + "  " + g.nameID);

                    }
                

            }

            foreach (outputNeuron g in outputNeurons)
            {

                //IDictionary<int, float> actDict = new Dictionary<int, float>();
                //int ind = 0;




                //// obs = obs.ToDictionary
                //foreach (float f in act)
                //{
                //    actDict.Add(ind, f);
                //    ind++;
                //}

              
                //float val = actDict[ind];

                foreach (int cc in g.outputWeights.Keys)
                {

                    //g.dendriteWeights[c] = Random.Range(.00001f, 1f);
                    //print(g.nameID);
                    //if (g.nameID > inputNeurons.Length + neurons.Length)
                    //{
                        outputCycle(cc, g.nameID);
                    //}

                }


            }
        }
    }
}
