using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using JacksonDunstanIterator;


namespace MLAgents
{

    /// <summary>
    /// Ray perception component. Attach this to agents to enable "local perception"
    /// via the use of ray casts directed outward from the agent. 
    /// </summary>
    public class RayPerception : MonoBehaviour//, //IDisposable
    {
        
       // List<float> perceptionBuffer = new List<float>();
        Vector3 endPosition;
       // RaycastHit hit;

      //  public Transform[] currentTgtTypeListCopy;

      //  int listcount2;

       // int temp2count;

       // int nullObjectsCount;

       // int q1 = 0;

       



       //     float[] subList3 = new float[4];
      //      float[] subList;

      //      float[] direction = new float[2];

      //      float[] subList2;
      //      float[] direction2 = new float[2];
        

      //  int detectableObjectLength;

       // int q = 0;

       // int listCount;

      //  public List<float> NullObjects = new List<float>();
       // public List<Transform> bestTargets = new List<Transform>(10);
       // public List<float> distances =new List<float>(10);
      //  public List<float> finalD = new List<float>();
        //public List<Transform> CurrentTargetTypeList = new List<Transform>();
        public NorpAI norpAI;
       // public bool isaCurrentTargetType;
        public Transform currentNearest;

        public string currentTargetType;

      //  public struct poop 
       // {
         //   public List<Transform> temp;


        //    public void getit()
        //    {
        //        temp = new List<Transform>();
        //    }

      //  }

      // public List<Transform> temp = new List<Transform>();
       // public List<Transform> temp2 = new List<Transform>(10);

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

        public Vector2 start;
        public Vector2 end;
        public Vector2 start2;
        public Vector2 end2;
        public Vector2 start3;
        public Vector2 end3;
        public Vector2 start4;
        public Vector2 end4;

     //   RaycastHit2D hita ;
     //   RaycastHit2D hitb;
    //    RaycastHit2D hitc ;

     //   RaycastHit2D hit2;
     //   RaycastHit2D hit2b ;
    //    RaycastHit2D hit2c ;

     //   RaycastHit2D hit3 ;
     //   RaycastHit2D hit3b;
     //   RaycastHit2D hit3c ;

    //    RaycastHit2D hit4 ;
    //    RaycastHit2D hit4b ;
     //   RaycastHit2D hit4c;


        private NorpAgent norpAgent;

        //Vector2 currentSelfPos;

        //public int i;
        //private Collider2D[] circle = new Collider2D[25];

       // public List<Collider2D> circleList  = new List<Collider2D>();
        //public GameObject thisAgent;

        /// <summary>
        /// Creates perception vector to be used as part of an observation of an agent.
        /// </summary>
        /// <returns>The partial vector observation corresponding to the set of rays</returns>
        /// <param name="rayDistance">Radius of rays</param>
        /// <param name="rayAngles">Anlges of rays (starting from (1,0) on unit circle).</param>
        /// <param name="detectableObjects">List of tags which correspond to object types agent can see</param>
        /// <param name="startOffset">Starting heigh offset of ray from center of agent.</param>
        /// <param name="endOffset">Ending height offset of ray from center of agent.</param>
        /// 


        public List<float> Perceive(float rayDistance,
            float[] rayAngles, string[] detectableObjects,
            float startOffset, float endOffset)
        {
           // using (//this)
           // {


                // if (!norpAI)
                // {
                norpAI = gameObject.GetComponent<NorpAI>();
                // }

                norpAgent = this.gameObject.GetComponent<NorpAgent>();

            // distances.Clear();
            int detectableObjectLength;
            detectableObjectLength = detectableObjects.Length;

                currentTargetType = norpAI.CurrentTargetType;
            //print("got it");



            // sublists subList= new sublists();

           float[] subList = new float[detectableObjectLength + 5];

            float[] subList2 = new float[detectableObjectLength + 5];

            float[] subList3 = new float[4];

            float[] direction = new float[2];
            float[] direction2 = new float[2];

            List<float> perceptionBuffer = new List<float>();

                if (yend == 0)
                {
                    yend = 3f;
                }

                if (ystart == 0)
                {
                    ystart = .48f;
                }

                if (yend2 == 0)
                {
                    yend2 = .07f;
                }

                if (ystart2 == 0)
                {
                    ystart2 = .07f;
                }

                if (xstart2 == 0)
                {
                    xstart2 = .24f;
                }

                if (xend2 == 0)
                {
                    xend2 = 3f;
                }

                if (xend == 0)
                {
                    xend = 0f;
                }

            if (yend3 == 0)
                {
                    yend3 = .07f;
                }

                if (ystart3 == 0)
                {
                    ystart3 = .07f;
                }

                if (xstart3 == 0)
                {
                    xstart3 = -.3f;
                }

                if (xend3 == 0)
                {
                    xend3 = -3f;
                }

                if (yend4 == 0)
                {
                    yend4 = -3f;
                }

                if (ystart4 == 0)
                {
                    ystart4 = -.32f;
                }

            List<Transform> CurrentTargetTypeList = new List<Transform>();
            // CurrentTargetTypeList.Clear();
            norpAI.circleListCopy.Clear();
            //NullObjects.Clear();
            List<float> NullObjects = new List<float>();
            perceptionBuffer.Clear();
            //circleList.Clear();
            List<Collider2D> circleList = new List<Collider2D>();  
            Vector2   currentSelfPos = this.gameObject.transform.position;
            // print("rayangles= " + rayDistance+" "+gameObject.name);
            // Collider2D[] circle= Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), rayDistance); 
            //circle =

            

            //   foreach(Collider2D c2 in circle)
            //   {
            //       circleList.Add(c2);
            //print("Added " + c2.name);

            //  }

            int listcount2;

            int temp2count;

            int nullObjectsCount;

            int q1 = 0;

            RaycastHit2D hita;
            RaycastHit2D hitb;
            RaycastHit2D hitc;

            RaycastHit2D hit2;
            RaycastHit2D hit2b;
            RaycastHit2D hit2c;

            RaycastHit2D hit3;
            RaycastHit2D hit3b;
            RaycastHit2D hit3c;

            RaycastHit2D hit4;
            RaycastHit2D hit4b;
            RaycastHit2D hit4c;


            // circle
            norpAI.circleListCopy = circleList;
                //print("Step1 CircleList count = " + circleList.Count);
                //GameObject.Find("NorpAcademy").GetComponentInChildren<Brain>().brainParameters.vectorObservationSize = circle.Length;
                // For each ray sublist stores categorical information on detected object
                // along with object distance.

                end = currentSelfPos + new Vector2(xend, yend);
                start = currentSelfPos + new Vector2(xstart, ystart);

                start2 = currentSelfPos + new Vector2(xstart2, ystart2);
                end2 = currentSelfPos + new Vector2(xend2, yend2);

                start3 = currentSelfPos + new Vector2(xstart3, ystart3);
                end3 = currentSelfPos + new Vector2(xend3, yend3);

                start4 = currentSelfPos + new Vector2(xstart4, ystart4);
                end4 = currentSelfPos + new Vector2(xend4, yend4);

                hita = Physics2D.Linecast(start, end + new Vector2(0, .4f));
                hitb = Physics2D.Linecast(start + new Vector2(.25f, 0), end + new Vector2(1.8f, 0.2f));
                hitc = Physics2D.Linecast(start + new Vector2(-.25f, 0), end + new Vector2(-1.8f, 0.2f));


                hit2 = Physics2D.Linecast(start2, end2 + new Vector2(0.4f, 0f));
                hit2b = Physics2D.Linecast(start2 + new Vector2(0, .25f), end2 + new Vector2(0.2f, 1.8f));
                hit2c = Physics2D.Linecast(start2 + new Vector2(0, -.25f), end2 + new Vector2(0.2f, -1.8f));

                hit3 = Physics2D.Linecast(start3, end3 + new Vector2(-0.4f, 0f));
                hit3b = Physics2D.Linecast(start3 + new Vector2(0, .25f), end3 + new Vector2(-0.2f, 1.8f));
                hit3c = Physics2D.Linecast(start3 + new Vector2(0, -.25f), end3 + new Vector2(-0.2f, -1.8f));

                hit4 = Physics2D.Linecast(start4, end4 + new Vector2(0, -.4f));
                hit4b = Physics2D.Linecast(start4 + new Vector2(.25f, 0), end4 + new Vector2(1.8f, -0.2f));
                hit4c = Physics2D.Linecast(start4 + new Vector2(-.25f, 0), end4 + new Vector2(-1.8f, -0.2f));
                if (Application.isEditor)
                {
                    //OnDrawGizmosSelected();


                    Debug.DrawLine(start, end+new Vector2(0,.4f), Color.red);
                    Debug.DrawLine(start + new Vector2(.25f, 0), end + new Vector2(1.8f, 0.2f), Color.red);
                    Debug.DrawLine(start + new Vector2(-.25f, 0), end + new Vector2(-1.8f, 0.2f), Color.red);



                    Debug.DrawLine(start2, end2 + new Vector2(0.4f, 0f), Color.green);
                    Debug.DrawLine(start2 + new Vector2(0, .25f), end2 + new Vector2(0.2f, 1.8f), Color.green);
                    Debug.DrawLine(start2 + new Vector2(0, -.25f), end2 + new Vector2(0.2f, -1.8f), Color.green);

                    Debug.DrawLine(start3, end3 + new Vector2(-0.4f,0f), Color.blue);
                    Debug.DrawLine(start3 + new Vector2(0, .25f), end3 + new Vector2(-0.2f, 1.8f), Color.blue);
                    Debug.DrawLine(start3 + new Vector2(0, -.25f), end3 + new Vector2(-0.2f, -1.8f), Color.blue);


                    Debug.DrawLine(start4, end4 + new Vector2(0, -.4f), Color.magenta);
                    Debug.DrawLine(start4 + new Vector2(.25f, 0), end4 + new Vector2(1.8f, -0.2f), Color.magenta);
                    Debug.DrawLine(start4 + new Vector2(-.25f, 0), end4 + new Vector2(-1.8f, -0.2f), Color.magenta);
                }
            //#endif

            // float[] subList3 = new float[4];

            //circle = null;

            float[] subListHit1a = new float[detectableObjectLength + 5];
            float[] subListHit1b = new float[detectableObjectLength + 5];
            float[] subListHit1c = new float[detectableObjectLength + 5];
            if (hita || hitb || hitc)
            {


                if (hita)
                {
                    subListHit1a = Raydentify(detectableObjectLength, hita.collider.gameObject, detectableObjects, subList, hita);
                    if (hita.collider.gameObject.CompareTag("Wall"))
                    {
                        // norpAgent.banDown = true;
                        subList3[0] = -1f;
                        // print("Wall Below");
                    }
                    if (hita.collider.gameObject.CompareTag("Food"))
                    {
                        // norpAgent.forceDown = true;
                        subList3[0] = 1f;
                        // print("Food Below");

                    }
                    if (hita.collider.gameObject.CompareTag(currentTargetType))
                    {
                        //norpAgent.forceDown = true;
                        subList3[0] = 1f;

                    }
                }
                else
                {
                    for (int flo = 0; flo < subListHit1a.Length; flo++)
                    {
                        subListHit1a[flo] = 0f;
                    }
                }



                if (hitb)
                {
                    subListHit1b = Raydentify(detectableObjectLength, hitb.collider.gameObject, detectableObjects, subList,hitb);
                    if (hitb.collider.gameObject.CompareTag("Wall"))
                    {
                        // norpAgent.banDown = true;
                        subList3[0] = -1f;
                        // print("Wall Below");
                    }
                    if (hitb.collider.gameObject.CompareTag("Food"))
                    {
                        // norpAgent.forceDown = true;
                        subList3[0] = 1f;
                        // print("Food Below");

                    }
                    if (hitb.collider.gameObject.CompareTag(currentTargetType))
                    {
                        //norpAgent.forceDown = true;
                        subList3[0] = 1f;

                    }
                }
                else
                {
                    for (int flo = 0; flo < subListHit1b.Length; flo++)
                    {
                        subListHit1b[flo] = 0f;
                    }
                }


                if (hitc)
                {
                    subListHit1c = Raydentify(detectableObjectLength, hitc.collider.gameObject, detectableObjects, subList,hitc);
                    if (hitc.collider.gameObject.CompareTag("Wall"))
                    {
                        // norpAgent.banDown = true;
                        subList3[0] = -1f;
                        // print("Wall Below");
                    }
                    if (hitc.collider.gameObject.CompareTag("Food"))
                    {
                        // norpAgent.forceDown = true;
                        subList3[0] = 1f;
                        // print("Food Below");

                    }
                    if (hitc.collider.gameObject.CompareTag(currentTargetType))
                    {
                        //norpAgent.forceDown = true;
                        subList3[0] = 1f;

                    }
                }
                else
                {
                    for (int flo = 0; flo < subListHit1c.Length; flo++)
                    {
                        subListHit1c[flo] = 0f;
                    }
                }





            }
            else
            {
                subList3[0] = 0f;
                //norpAgent.banDown = false;
                // norpAgent.forceDown = false;
                for (int flo = 0; flo < subListHit1a.Length; flo++)
                {
                    subListHit1a[flo] = 0f;
                }
                for (int flo = 0; flo < subListHit1b.Length; flo++)
                {
                    subListHit1b[flo] = 0f;
                }
                for (int flo = 0; flo < subListHit1c.Length; flo++)
                {
                    subListHit1c[flo] = 0f;
                }
            }

            //temp.Clear();
            // temp2.Clear();

            ArrayIterator<float> hit1alist = subListHit1a.Begin();
            float pow1a = hit1alist.GetCurrent();
            ArrayIterator<float> twond1a = hit1alist.GetNext();
            ArrayIterator<float> twinal1a = subListHit1a.End();
            twond1a.Reverse(twinal1a);

            hit1alist.ForEach(twinal1a, perceptionBuffer.Add);


            ArrayIterator<float> hit1blist = subListHit1b.Begin();
            float tow1a = hit1blist.GetCurrent();
            ArrayIterator<float> twond1b = hit1blist.GetNext();
            ArrayIterator<float> twinal1b = subListHit1b.End();
            twond1b.Reverse(twinal1b);

            hit1blist.ForEach(twinal1b, perceptionBuffer.Add);


            ArrayIterator<float> hit1clist = subListHit1c.Begin();
            float tow1c = hit1clist.GetCurrent();
            ArrayIterator<float> twond1c = hit1clist.GetNext();
            ArrayIterator<float> twinal1c = subListHit1c.End();
            twond1c.Reverse(twinal1c);

            hit1clist.ForEach(twinal1c, perceptionBuffer.Add);

            float[] subListHit2a = new float[detectableObjectLength + 5];
            float[] subListHit2b = new float[detectableObjectLength + 5];
            float[] subListHit2c = new float[detectableObjectLength + 5];
            if (hit2 || hit2b || hit2c)
            {


                if (hit2)
                {
                    subListHit2a = Raydentify(detectableObjectLength, hit2.collider.gameObject, detectableObjects, subList,hit2);
                    if (hit2.collider.gameObject.CompareTag("Wall"))
                    {
                        // norpAgent.banDown = true;
                        subList3[1] = -1f;
                        // print("Wall Below");
                    }
                    if (hit2.collider.gameObject.CompareTag("Food"))
                    {
                        // norpAgent.forceDown = true;
                        subList3[1] = 1f;
                        // print("Food Below");

                    }
                    if (hit2.collider.gameObject.CompareTag(currentTargetType))
                    {
                        //norpAgent.forceDown = true;
                        subList3[1] = 1f;

                    }
                }
                else
                {
                    for (int flo = 0; flo < subListHit2a.Length; flo++)
                    {
                        subListHit2a[flo] = 0f;
                    }
                }



                if (hit2b)
                {
                    subListHit2b = Raydentify(detectableObjectLength, hit2b.collider.gameObject, detectableObjects, subList,hit2b);
                    if (hit2b.collider.gameObject.CompareTag("Wall"))
                    {
                        // norpAgent.banDown = true;
                        subList3[1] = -1f;
                        // print("Wall Below");
                    }
                    if (hit2b.collider.gameObject.CompareTag("Food"))
                    {
                        // norpAgent.forceDown = true;
                        subList3[1] = 1f;
                        // print("Food Below");

                    }
                    if (hit2b.collider.gameObject.CompareTag(currentTargetType))
                    {
                        //norpAgent.forceDown = true;
                        subList3[1] = 1f;

                    }
                }
                else
                {
                    for (int flo = 0; flo < subListHit2b.Length; flo++)
                    {
                        subListHit2b[flo] = 0f;
                    }
                }


                if (hit2c)
                {
                    subListHit2c = Raydentify(detectableObjectLength, hit2c.collider.gameObject, detectableObjects, subList,hit2c);
                    if (hit2c.collider.gameObject.CompareTag("Wall"))
                    {
                        // norpAgent.banDown = true;
                        subList3[1] = -1f;
                        // print("Wall Below");
                    }
                    if (hit2c.collider.gameObject.CompareTag("Food"))
                    {
                        // norpAgent.forceDown = true;
                        subList3[1] = 1f;
                        // print("Food Below");

                    }
                    if (hit2c.collider.gameObject.CompareTag(currentTargetType))
                    {
                        //norpAgent.forceDown = true;
                        subList3[1] = 1f;

                    }
                }
                else
                {
                    for (int flo = 0; flo < subListHit2c.Length; flo++)
                    {
                        subListHit2c[flo] = 0f;
                    }
                }





            }
            else
            {
                subList3[1] = 0f;
                //norpAgent.banDown = false;
                // norpAgent.forceDown = false;
                for (int flo = 0; flo < subListHit2a.Length; flo++)
                {
                    subListHit2a[flo] = 0f;
                }
                for (int flo = 0; flo < subListHit2b.Length; flo++)
                {
                    subListHit2b[flo] = 0f;
                }
                for (int flo = 0; flo < subListHit2c.Length; flo++)
                {
                    subListHit2c[flo] = 0f;
                }
            }

            //temp.Clear();
            // temp2.Clear();

            ArrayIterator<float> hit2alist = subListHit2a.Begin();
            float pow2a = hit2alist.GetCurrent();
            ArrayIterator<float> twond2a = hit2alist.GetNext();
            ArrayIterator<float> twinal2a = subListHit2a.End();
            twond2a.Reverse(twinal2a);

            hit2alist.ForEach(twinal2a, perceptionBuffer.Add);


            ArrayIterator<float> hit2blist = subListHit2b.Begin();
            float tow2b = hit2blist.GetCurrent();
            ArrayIterator<float> twond2b = hit2blist.GetNext();
            ArrayIterator<float> twinal2b = subListHit2b.End();
            twond2b.Reverse(twinal2b);

            hit2blist.ForEach(twinal2b, perceptionBuffer.Add);


            ArrayIterator<float> hit2clist = subListHit2c.Begin();
            float tow2c = hit2clist.GetCurrent();
            ArrayIterator<float> twond2c = hit2clist.GetNext();
            ArrayIterator<float> twinal2c = subListHit2c.End();
            twond2c.Reverse(twinal2c);

            hit2clist.ForEach(twinal2c, perceptionBuffer.Add);

            float[] subListHit3a = new float[detectableObjectLength + 5];
            float[] subListHit3b = new float[detectableObjectLength + 5];
            float[] subListHit3c = new float[detectableObjectLength + 5];
            if (hit3 || hit3b || hit3c)
            {


                if (hit3)
                {
                    subListHit3a = Raydentify(detectableObjectLength, hit3.collider.gameObject, detectableObjects, subList, hit3);
                    if (hit3.collider.gameObject.CompareTag("Wall"))
                    {
                        // norpAgent.banDown = true;
                        subList3[2] = -1f;
                        // print("Wall Below");
                    }
                    if (hit3.collider.gameObject.CompareTag("Food"))
                    {
                        // norpAgent.forceDown = true;
                        subList3[2] = 1f;
                        // print("Food Below");

                    }
                    if (hit3.collider.gameObject.CompareTag(currentTargetType))
                    {
                        //norpAgent.forceDown = true;
                        subList3[2] = 1f;

                    }
                }
                else
                {
                    for (int flo = 0; flo < subListHit3a.Length; flo++)
                    {
                        subListHit3a[flo] = 0f;
                    }
                }



                if (hit3b)
                {
                    subListHit3b = Raydentify(detectableObjectLength, hit3b.collider.gameObject, detectableObjects, subList, hit3b);
                    if (hit3b.collider.gameObject.CompareTag("Wall"))
                    {
                        // norpAgent.banDown = true;
                        subList3[2] = -1f;
                        // print("Wall Below");
                    }
                    if (hit3b.collider.gameObject.CompareTag("Food"))
                    {
                        // norpAgent.forceDown = true;
                        subList3[2] = 1f;
                        // print("Food Below");

                    }
                    if (hit3b.collider.gameObject.CompareTag(currentTargetType))
                    {
                        //norpAgent.forceDown = true;
                        subList3[2] = 1f;

                    }
                }
                else
                {
                    for (int flo = 0; flo < subListHit3b.Length; flo++)
                    {
                        subListHit3b[flo] = 0f;
                    }
                }


                if (hit3c)
                {
                    subListHit3c = Raydentify(detectableObjectLength, hit3c.collider.gameObject, detectableObjects, subList, hit3c);
                    if (hit3c.collider.gameObject.CompareTag("Wall"))
                    {
                        // norpAgent.banDown = true;
                        subList3[2] = -1f;
                        // print("Wall Below");
                    }
                    if (hit3c.collider.gameObject.CompareTag("Food"))
                    {
                        // norpAgent.forceDown = true;
                        subList3[2] = 1f;
                        // print("Food Below");

                    }
                    if (hit3c.collider.gameObject.CompareTag(currentTargetType))
                    {
                        //norpAgent.forceDown = true;
                        subList3[2] = 1f;

                    }
                }
                else
                {
                    for (int flo = 0; flo < subListHit3c.Length; flo++)
                    {
                        subListHit3c[flo] = 0f;
                    }
                }





            }
            else
            {
                subList3[2] = 0f;
                //norpAgent.banDown = false;
                // norpAgent.forceDown = false;
                for (int flo = 0; flo < subListHit3a.Length; flo++)
                {
                    subListHit3a[flo] = 0f;
                }
                for (int flo = 0; flo < subListHit3b.Length; flo++)
                {
                    subListHit3b[flo] = 0f;
                }
                for (int flo = 0; flo < subListHit3c.Length; flo++)
                {
                    subListHit3c[flo] = 0f;
                }
            }

            //temp.Clear();
            // temp2.Clear();

            ArrayIterator<float> hit3alist = subListHit3a.Begin();
            float pow3a = hit3alist.GetCurrent();
            ArrayIterator<float> twond3a = hit3alist.GetNext();
            ArrayIterator<float> twinal3a = subListHit3a.End();
            twond3a.Reverse(twinal3a);

            hit3alist.ForEach(twinal3a, perceptionBuffer.Add);


            ArrayIterator<float> hit3blist = subListHit3b.Begin();
            float tow3b = hit3blist.GetCurrent();
            ArrayIterator<float> twond3b = hit3blist.GetNext();
            ArrayIterator<float> twinal3b = subListHit3b.End();
            twond3b.Reverse(twinal3b);

            hit3blist.ForEach(twinal3b, perceptionBuffer.Add);


            ArrayIterator<float> hit3clist = subListHit3c.Begin();
            float tow3c = hit3clist.GetCurrent();
            ArrayIterator<float> twond3c = hit3clist.GetNext();
            ArrayIterator<float> twinal3c = subListHit3c.End();
            twond3c.Reverse(twinal3c);

            hit3clist.ForEach(twinal3c, perceptionBuffer.Add);

            float[] subListHit4a = new float[detectableObjectLength + 5];
            float[] subListHit4b = new float[detectableObjectLength + 5];
            float[] subListHit4c = new float[detectableObjectLength + 5];
                if (hit4 || hit4b || hit4c)
                {
                   

                    if (hit4)
                    {
                        subListHit4a = Raydentify(detectableObjectLength, hit4.collider.gameObject, detectableObjects, subList, hit4);
                        if (hit4.collider.gameObject.CompareTag("Wall"))
                        {
                              // norpAgent.banDown = true;
                            subList3[3] = -1f;
                            // print("Wall Below");
                        }
                        if (hit4.collider.gameObject.CompareTag("Food"))
                        {
                            // norpAgent.forceDown = true;
                            subList3[3] = 1f;
                            // print("Food Below");

                        }
                        if (hit4.collider.gameObject.CompareTag(currentTargetType))
                        {
                            //norpAgent.forceDown = true;
                            subList3[3] = 1f;

                        }
                    }
                    else
                    {
                       for(int flo=0; flo<subListHit4a.Length; flo++)
                        {
                          subListHit4a[flo] = 0f;
                        }
                    }

                    

                if (hit4b)
                    {
                         subListHit4b =  Raydentify(detectableObjectLength, hit4b.collider.gameObject, detectableObjects, subList, hit4b);
                         if (hit4b.collider.gameObject.CompareTag("Wall"))
                        {
                           // norpAgent.banDown = true;
                            subList3[3] = -1f;
                            // print("Wall Below");
                        }
                        if (hit4b.collider.gameObject.CompareTag("Food"))
                        {
                        // norpAgent.forceDown = true;
                        subList3[3] = 1f;
                        // print("Food Below");

                     }
                        if (hit4b.collider.gameObject.CompareTag(currentTargetType))
                        {
                        //norpAgent.forceDown = true;
                        subList3[3] = 1f;

                        }
                    }
                    else
                    {
                        for (int flo = 0; flo < subListHit4b.Length; flo++)
                        {
                            subListHit4b[flo] = 0f;
                        }
                    }
                        

                    if (hit4c)
                    {
                        subListHit4c = Raydentify(detectableObjectLength, hit4c.collider.gameObject, detectableObjects, subList,hit4c);
                        if (hit4c.collider.gameObject.CompareTag("Wall"))
                        {
                           // norpAgent.banDown = true;
                            subList3[3] = -1f;
                            // print("Wall Below");
                        }
                        if (hit4c.collider.gameObject.CompareTag("Food"))
                        {
                        // norpAgent.forceDown = true;
                        subList3[3] = 1f;
                        // print("Food Below");

                        }
                        if (hit4c.collider.gameObject.CompareTag(currentTargetType))
                        {
                        //norpAgent.forceDown = true;
                        subList3[3] = 1f;

                        }
                    }
                    else
                    {
                        for (int flo = 0; flo < subListHit4c.Length; flo++)
                        {
                            subListHit4c[flo] = 0f;
                        }
                    }

                    



                }
                else
                {
                    subList3[3] = 0f;
                //norpAgent.banDown = false;
                // norpAgent.forceDown = false;
                    for (int flo = 0; flo < subListHit4a.Length; flo++)
                    {
                        subListHit4a[flo] = 0f;
                    }
                    for (int flo = 0; flo < subListHit4b.Length; flo++)
                    {
                        subListHit4b[flo] = 0f;
                    }
                    for (int flo = 0; flo < subListHit4c.Length; flo++)
                    {
                        subListHit4c[flo] = 0f;
                    }
                }

            //temp.Clear();
            // temp2.Clear();

            ArrayIterator<float> hit4alist = subListHit4a.Begin();
            float pow = hit4alist.GetCurrent();
            ArrayIterator<float> twond = hit4alist.GetNext();
            ArrayIterator<float> twinal = subListHit4a.End();
            twond.Reverse(twinal);

            hit4alist.ForEach(twinal, perceptionBuffer.Add);


            ArrayIterator<float> hit4blist = subListHit4b.Begin();
            float tow = hit4blist.GetCurrent();
            ArrayIterator<float> twond4b = hit4blist.GetNext();
            ArrayIterator<float> twinal4b = subListHit4b.End();
            twond4b.Reverse(twinal4b);

            hit4blist.ForEach(twinal4b, perceptionBuffer.Add);


            ArrayIterator<float> hit4clist = subListHit4c.Begin();
            float tow4c = hit4clist.GetCurrent();
            ArrayIterator<float> twond4c = hit4clist.GetNext();
            ArrayIterator<float> twinal4c = subListHit4c.End();
            twond4c.Reverse(twinal4c);

            hit4clist.ForEach(twinal4c, perceptionBuffer.Add);



            ArrayIterator<float> yup = subList3.Begin();
                float now = yup.GetCurrent();
                ArrayIterator<float> tecond = yup.GetNext();
                ArrayIterator<float> fwinal = subList3.End();
                tecond.Reverse(fwinal);

                yup.ForEach(fwinal, perceptionBuffer.Add);

            //perceptionBuffer.AddRange(subList3);


            Collider2D[] circle = new Collider2D[25];
            Physics2D.OverlapCircleNonAlloc(currentSelfPos, rayDistance, circle);



            ArrayIterator<Collider2D> begin = circle.Begin();
            Collider2D val = begin.GetCurrent();
            ArrayIterator<Collider2D> second = begin.GetNext();
            ArrayIterator<Collider2D> final = circle.End();
            second.Reverse(final);

            begin.ForEach(final, circleList.Add);


            listcount2 = circleList.Count;

                if (listcount2 > 10)
                {
                  //  poop temp =  new poop();
                   List<Transform> temp = new List<Transform>();
              //  temp.getit();
                 //  temp.temp.Clear();
                    List<Transform> temp2 = new List<Transform>(10);
                // temp2.Clear();

                // var i = 0;
                foreach (Collider2D c in circleList)
                    {

                        // ListIterator<Collider2D> begin2 = circleList.Begin();
                        // Collider2D val2 = begin2.GetCurrent();
                        // ListIterator<Collider2D> second2 = begin2.GetNext();
                        //  ListIterator<Collider2D> final2 = circleList.End();
                        //  second2.Reverse(final2);

                        //  ListIterator<Transform> begin2b = temp.Begin();
                        // Transform val2b = begin2b.GetCurrent();
                        //  ListIterator<Transform> second2b = begin2b.GetNext();
                        // ListIterator<Transform> final2b = temp.End();
                        //   second2b.Reverse(final2b);

                        //  begin2.ForEach(final2, temp.Add(final2.GetCurrent().gameObject.GetComponent<Transform>());//=begin2.GetCurrent().gameObject.GetComponent<Transform>());

                        // if (i <= 10)
                        //{
                        if (c != null)
                        {
                          if (c != gameObject)
                          {

                            temp.Add(c.gameObject.transform);
                          }
                        }
                        //  i++;
                        // }


                    }

                    //  print("Step2 temp count = " + temp.Count);
                     temp2 = GetClosestEnemy(temp);
                    circleList.Clear();
                    //var q1 = 0;
                    q1 = 0;
                    //  ListIterator<Transform> begin2 = temp2.Begin();
                    //   Transform val2 = begin2.GetCurrent();
                    //   ListIterator<Transform> second2 = begin2.GetNext();
                    //   ListIterator<Transform> final2 = temp2.End();
                    //   second2.Reverse(final2);

                    //  begin2.ForEach(begin2, AddToCircleList());

                    temp2count = temp2.Count;

                    for (int tt = 0; tt < temp2count; tt++)
                    {

                        if (q1 < 10)
                        {
                            circleList.Add(temp2[tt].gameObject.GetComponent<Collider2D>());
                            //print("CircleList is mor than 10");
                            q1++;
                        }
                        else
                        {
                            //circleList.RemoveAt(q);
                        }
                    }

                    //print("Step3 temp2 count = " + temp2.Count);
                }
                else
                {
                    if (listcount2 < 10)
                    {
                        NullObjects.Clear();

                        for (int runs = 0; runs < (10 - circleList.Count); runs++)
                        {
                            NullObjects.Add(0f);
                        }
                    }
                    else
                    {
                        if (listcount2 == 10)
                        {
                            NullObjects.Clear();
                            //print("CircleList is exactly 10");
                        }
                    }


                }

                foreach (Collider2D coll in circleList)
                {

                    if (Application.isEditor)
                    {
                        //OnDrawGizmosSelected();

                    }

                    //float[] subList = new float[detectableObjects.Length + 5];

                    // float[] direction = new float[2];



                    for (int i = 0; i < detectableObjectLength; i++)
                    {
                        if (coll.gameObject != this.gameObject)
                        {
                            if (coll.gameObject.CompareTag(detectableObjects[i]))
                            {
                               if (currentTargetType == null || currentTargetType == "")
                               {
                                //print("EatCheese");
                                currentTargetType = "Food";
                               }
                                if (coll.gameObject.CompareTag(currentTargetType))
                                {

                                  
                                    //CurrentTargetTypeList.Add(coll.gameObject.transform);
                                    CurrentTargetTypeList.Add(coll.gameObject.transform);

                                }

                                //subList[i] = 1;

                                //print(hit.distance);
                                // print(hit.distance / rayDistance);
                                Vector2 heading =
                                    new Vector2(coll.gameObject.transform.position.x,
                                        coll.gameObject.transform.position.y) -
                                    new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);



                                float distance = heading.sqrMagnitude;
                                Vector2 objDirection = heading.normalized / distance;
                               // subList[detectableObjectLength + 1] = Mathf.InverseLerp(0, 1, distance/10);
                               // subList[detectableObjectLength + 2] = objDirection.normalized.x;
                               // subList[detectableObjectLength + 3] = objDirection.normalized.y;
                              // print(objDirection+" dir of "+coll.gameObject.name);
                             //  print(objDirection.normalized + " normalized dir of " + coll.gameObject.name);
                             //   print(Mathf.InverseLerp(000.000f, 001.000f, distance)+" lerped distance ");
                                if (coll.gameObject == norpAI.currentTarget)
                                {
                                    //subList[detectableObjectLength + 4] = 1f;
                                 //print("Target is " + coll.gameObject.name);
                               // print("Target Distance is " + distance / 10);
                                //print(Mathf.InverseLerp(000.000f, 001.000f, distance/10) + " lerped distance ");
                            }
                                else
                                {
                                   // subList[detectableObjectLength + 4] = 0f;
                                }

                                //print("dist= " + Mathf.InverseLerp(0, 1, distance) +" heading= "+ heading.normalized+"objD= " + objDirection.normalized);
                                // print(gameObject.name + " " + coll.gameObject.name + " distance = " + Mathf.InverseLerp(0, 8, distance));
                                //print(objDirection);
                                // This is now the normalized direction.
                                //print("Detected " + detectableObjects[i]);
                                //print("Detected " + subList[detectableObjects.Length + 1]);
                               // direction[0] = objDirection.x;
                               // direction[1] = objDirection.y;

                                //print(objDirection);
                                break;
                            }
                            else
                            {
                              //  subList[detectableObjectLength] = 1f;
                               // direction[0] = 0f;
                               // direction[1] = 0f;
                                //subList[detectableObjects.Length + 1] = 0;
                                //subList[detectableObjects.Length + 2] = 0;
                            }
                        }


                    }

                    //print("colls "  + subList[0] + "" + subList[1] + "" + subList[2] + "" + subList[3] + "" + subList[4] + "" + subList[5]);


                    // print("sublist length is " + subList.Length);


                    //print(direction[0]+direction[1]);


                   // ArrayIterator<float> yup2 = subList.Begin();
                   // float now2 = yup2.GetCurrent();
                  //  ArrayIterator<float> tecond2 = yup2.GetNext();
                  //  ArrayIterator<float> fwinal2 = subList.End();
                  //  tecond2.Reverse(fwinal2);

                   // yup2.ForEach(fwinal2, perceptionBuffer.Add);

                    //perceptionBuffer.AddRange(subList);
                    // perceptionBuffer.AddRange(direction);

                }

                nullObjectsCount = NullObjects.Count;
                if (NullObjects.Count != 0)
                {

                    foreach (float ft in NullObjects)
                    {
                        // float[] subList2 = new float[detectableObjects.Length + 5];
                        //  float[] direction2 = new float[2];

                        for (int i = 0; i < detectableObjectLength; i++)
                        {

                            //subList2[i] = 0f;
                            //subList2[detectableObjectLength + 1] = 0f;
                            //subList2[detectableObjectLength] = 0f;
                            direction2[0] = 0f;
                            direction2[1] = 0f;
                            //subList2[detectableObjects.Length + 2] = 0f;
                            //subList2[detectableObjects.Length + 3] = 0f;

                        }

                        // print("nulls " + subList2[0] + "" + subList2[1] + "" + subList2[2] + "" + subList2[3] + "" + subList2[4] + "" + subList2[5]);


                        //print("sublist2 length is " +subList2.Length);
                        // print("Step4 nullobjects count = " + NullObjects.Count);

                       // ArrayIterator<float> yup3 = subList2.Begin();
                       // float now3 = yup3.GetCurrent();
                      //  ArrayIterator<float> tecond3 = yup3.GetNext();
                      //  ArrayIterator<float> fwinal3 = subList2.End();
                      //  tecond3.Reverse(fwinal3);

                       // yup3.ForEach(fwinal3, perceptionBuffer.Add);


                        // perceptionBuffer.AddRange(subList2);
                        // perceptionBuffer.AddRange(direction2);
                    }

                }
                else
                {
                    // print("Step4 nullobjects count = " + 0f);
                }

            if (currentNearest == null || !CurrentTargetTypeList.Contains(currentNearest))
            {
                currentNearest = FindNearest(CurrentTargetTypeList);
            }

            norpAI.AddCurrentNearest(currentNearest);
                // print("CurrentTargetTypeList= " + CurrentTargetTypeList);

                // ArrayUtil.ListToArray(CurrentTargetTypeList);
               Transform[] currentTgtTypeListCopy = ArrayUtil.ListToArray(CurrentTargetTypeList);

                norpAI.TargetList(currentTgtTypeListCopy);
                //perceptionBuffer.AddRange(NullObjects);
                //print(perceptionBuffer.Count);
                norpAI.circleListCopy = circleList;

                //currentTgtTypeListCopy = null;

               // int j = (int) listCount;
                int j2 = (int) detectableObjectLength;
                int j3 = (int) nullObjectsCount;
                int j4 = (int) listcount2;
                Vector2 j5 = (Vector2) currentSelfPos;

            if (currentNearest != null)
            {
               
                gameObject.layer = 2; //IgnoreRaycast Layer
                currentNearest.gameObject.layer = 2;

                RaycastHit2D lineosight = Physics2D.Linecast(gameObject.transform.position, currentNearest.transform.position);

                Debug.DrawLine(gameObject.transform.position, currentNearest.transform.position);

                if (lineosight.collider==null)
                {
                    //clear
                    //print("lineosight");
                    perceptionBuffer.Add(1);
                    norpAgent.lineSight = true;
                   
                    
                }
                else
                {
                    //print("no lineofsight");
                    norpAgent.lineSight = false;
                    perceptionBuffer.Add(-1);


                }

                // perceptionBuffer.Add(lineosight.distance);





                gameObject.layer = 0; //Normal Layer
                currentNearest.gameObject.layer = 0;


            }
            else
            {
                norpAgent.lineSight = false;

                //Vector2 relativePosPoint = lineosight.point - new Vector2(transform.position.x, transform.position.y);




                //print(targetDirectionX/10);
                //print(targetDirectionY/10);

                

                perceptionBuffer.Add(0);
            }


                
            


                return perceptionBuffer;
            //}
        }

       // public void CreateSublists(float[] a, float[] b, float[] c)
      //  {
      //      subList = new float[detectableObjectLength + 5];

      //      subList2 = new float[detectableObjectLength + 5];

      //      subList3 = new float[4];
      //  }

        public Transform FindNearest(List<Transform> CurrentTargetTypeList)
        {
            Transform tMin = null;
           float minDist = Mathf.Infinity;
            Vector2 currentPos = transform.position;
           // List<float> alldistances;

          //  ListIterator<Transform> yup4 = CurrentTargetTypeList.Begin();
           // Transform now4 = yup4.GetCurrent();
           // ListIterator<Transform> tecond4 = yup4.GetNext();
          //  ListIterator<Transform> fwinal4 = CurrentTargetTypeList.End();
           // tecond4.Reverse(fwinal4);

            //yup4.ForEach(fwinal4, fw);

            //ArrayUtil.GetIndexOfLowestValue



            foreach (Transform t in CurrentTargetTypeList)
            {
                if (t != null)
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
            //StartCoroutine(WaitForDirection());

            //print("Found nearest");
            return tMin;
        }

        float[] Raydentify(int detectableObjectLength, GameObject coll, String[] detectableObjects, float[] subList, RaycastHit2D hit)
        {
            for (int i = 0; i < detectableObjectLength; i++)
            {
                if (coll.gameObject != this.gameObject)
                {
                    if (coll.gameObject.CompareTag(detectableObjects[i]))
                    {
                        if (currentTargetType == null || currentTargetType == "")
                        {
                            //print("EatCheese");
                            currentTargetType = "Food";
                        }
                        if (coll.gameObject.CompareTag(currentTargetType))
                        {


                            //CurrentTargetTypeList.Add(coll.gameObject.transform);
                            //CurrentTargetTypeList.Add(coll.gameObject.transform);

                        }

                        subList[i] = 1;

                        //print(hit.distance);
                        // print(hit.distance / rayDistance);
                        Vector2 heading =
                            new Vector2(hit.point.x,
                                hit.point.y) -
                            new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);



                        float distance = heading.sqrMagnitude;
                        Vector2 objDirection = heading.normalized / distance;
                        subList[detectableObjectLength + 1] = Mathf.InverseLerp(0, 1, hit.distance / 10);
                        subList[detectableObjectLength + 2] = objDirection.normalized.x;
                        subList[detectableObjectLength + 3] = objDirection.normalized.y;
                        // print(objDirection+" dir of "+coll.gameObject.name);
                        //  print(objDirection.normalized + " normalized dir of " + coll.gameObject.name);
                        //   print(Mathf.InverseLerp(000.000f, 001.000f, distance)+" lerped distance ");
                        if (coll.gameObject == norpAI.currentTarget)
                        {
                            subList[detectableObjectLength + 4] = 1f;
                            //print("Target is " + coll.gameObject.name);
                            // print("Target Distance is " + distance / 10);
                            //print(Mathf.InverseLerp(000.000f, 001.000f, distance/10) + " lerped distance ");
                        }
                        else
                        {
                            subList[detectableObjectLength + 4] = 0f;
                        }

                        //print("dist= " + Mathf.InverseLerp(0, 1, distance) +" heading= "+ heading.normalized+"objD= " + objDirection.normalized);
                        // print(gameObject.name + " " + coll.gameObject.name + " distance = " + Mathf.InverseLerp(0, 8, distance));
                        //print(objDirection);
                        // This is now the normalized direction.
                        //print("Detected " + detectableObjects[i]);
                        //print("Detected " + subList[detectableObjects.Length + 1]);
                        //direction[0] = objDirection.x;
                        //direction[1] = objDirection.y;

                        //print(objDirection);
                        break;
                    }
                    else
                    {
                        subList[detectableObjectLength] = 1f;
                        //direction[0] = 0f;
                        //direction[1] = 0f;
                        //subList[detectableObjects.Length + 1] = 0;
                        //subList[detectableObjects.Length + 2] = 0;
                    }
                }


            }
            return subList;
        }


        /// <summary>
        /// Converts polar coordinate to cartesian coordinate.
        /// </summary>
        public static Vector3 PolarToCartesian(float radius, float angle)
        {
            float x = radius * Mathf.Sin(DegreeToRadian(angle));
            float y = radius * Mathf.Cos(DegreeToRadian(angle));
            return new Vector3(-x,  y);
        }

        /// <summary>
        /// Converts degrees to radians.
        /// </summary>
        public static float DegreeToRadian(float degree)
        {
            return degree * Mathf.PI /180f;
        }
        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.white;
            Gizmos.DrawWireSphere(transform.position, 15f);
        }
        List<Transform> GetClosestEnemy(List<Transform> enemies)  
        {
          //  using (this)
          // {
           List<Transform> bestTargets = new List<Transform>(10);
            List<float> distances =new List<float>(10);
            List<float> finalD = new List<float>();

            int q = 0;

            int listCount;

            //finalD.Clear();
            // bestTargets.Clear();
            float closestDistanceSqr = Mathf.Infinity;
                Vector3 currentPosition = transform.position;
                //var p = 0;
             //   q = 0;
                // print("Step5 enemies count1 = " + enemies.Count);
                //int q = 0;
                // int 
              //  listCount = finalD.Count;

                //print("Made it this far 1");

                foreach (Transform ww in enemies)
                {
                    if (ww != null)
                    {
                        Vector3 directionToTarget = ww.position - currentPosition;
                        float dSqrToTarget = directionToTarget.sqrMagnitude;
                        if (currentTargetType == null || currentTargetType == "")
                        {
                        //print("EatCheese "+ww.name);
                         currentTargetType = "Food";
                        }

                        if (ww.CompareTag(currentTargetType))
                        {
                        //Mathf.Min(enemies)
                            if (dSqrToTarget < closestDistanceSqr)
                            {
                               closestDistanceSqr = dSqrToTarget;
                            }

                        //distances.Add(dSqrToTarget);
                            finalD.Add(dSqrToTarget);

                            //distances.Remove(distances[ArrayUtil.GetIndexOfLowestValue(distances)]);
                            q++;
                            // bestTargets[p] = potentialTarget;
                        }
                        else
                        {
                            if (dSqrToTarget < closestDistanceSqr)
                            {
                                closestDistanceSqr = dSqrToTarget;
                            }

                            distances.Add(dSqrToTarget);
                        }
                    }



                }
                //print("Made it this far 2");

                listCount = finalD.Count;
                //print("Step6 distances count1 = " + distances.Count);
                for (int p = 0; p < 10; p++)
                {
                    listCount = finalD.Count;
                    if (listCount < 10)
                    {
                        //print("Step6 distances count = " + distances.Count);

                        finalD.Add(distances[ArrayUtil.GetIndexOfLowestValue(distances)]);
                        //print("Added " + distances[ArrayUtil.GetIndexOfLowestValue(distances)]);

                        distances.Remove(distances[ArrayUtil.GetIndexOfLowestValue(distances)]);


                    }
                    else
                    {
                        if (listCount >= 10)
                        {

                            distances.Clear();

                        }
                    }


                }

                // print("Made it this far 3");
                foreach (Transform tp in enemies)
                {
                    if (tp != null)
                     {
                        Vector3 directionToTarget = tp.position - currentPosition;
                        float dSqrToTarget = directionToTarget.sqrMagnitude;
                        if (distances.Contains(dSqrToTarget))
                        {
                            distances.Remove(dSqrToTarget);
                            // enemies.Remove(pt);


                            //p++;
                        }

                        if (finalD.Contains(dSqrToTarget))
                        {
                            // if (!bestTargets.Contains(tp))
                            // {
                            bestTargets.Add(tp);
                            // }
                            finalD.Remove(dSqrToTarget);
                            //enemies.Remove(pt);
                        }
                    }
                }

                // print(finalD.Count);
                // print("Step5 enemies count2 = " + enemies.Count);
                // print("Step6 distances count2 = " + distances.Count);
                // print("Step7 finalD count = " + finalD.Count);
                // print("Step8 bestTargets count = " + bestTargets.Count);
                // print("Made it this far 4"+q);
                q = 0;
                //print(bestTargets.Count);
                //IDisposable(this);


                //enemies.Clear();
                distances.Clear();
               finalD.Clear();
            //enemies = null;
            distances = null;
            finalD = null;
            


               //Dispose(true);

                return bestTargets;
           // }
        }

        

        public void AddToCircleList(GameObject ttt)
        {
           // if (q1 < 10)
           // {
                //circleList.Add(ttt.GetComponent<Collider2D>());
            //    q1++;
            //}
        }

       // public class Disposal : IDisposable
      //  {
      //
      //      private bool isDisposed;
      //      private IntPtr handle;
      //      private Component component = new Component();


      //      public Disposal(IntPtr handle)
      //      {
      //          this.handle = handle;
      //      }

      //      Disposal l = new Disposal(new IntPtr());

      //      public void Dispose()
      //      {
      //          Dispose(true);
      //          GC.SuppressFinalize(this);
      //      }

      //      protected virtual void Dispose(bool isDisposing)
      //      {
      //          if (isDisposed)
      //              return;

      //          if (isDisposing)
      //          {
      //              Dispose();
      //          }

      //          if (handle != IntPtr.Zero)
      //              CloseHandle(handle);
      //          handle = IntPtr.Zero;

       //         isDisposed = true;
       //     }

       //     [System.Runtime.InteropServices.DllImport("Kernel32")]
       //     private extern static Boolean CloseHandle(IntPtr handle);

            // Use C# destructor syntax for finalization code.
            // This destructor will run only if the Dispose method
            // does not get called.
            // It gives your base class the opportunity to finalize.
            // Do not provide destructors in types derived from this class.



            //}
       //     public static void Main(IntPtr handle1)
         //   {
           //     Disposal newlist = new Disposal(handle1);

          //  }





           // class Dispose
            //{

            //    ~Dispose()
             //   {
            //    }
           // }



         //   ~Disposal()
           // {
                // Do not re-create Dispose clean-up code here.
                // Calling Dispose(false) is optimal in terms of
                // readability and maintainability.
             //   Dispose(false);
            //}
    }

       // #region IDisposable Support
        //private bool disposedValue = false; // To detect redundant calls

        //protected virtual void Dispose(bool disposing)
       // {
         //   if (!disposedValue)
           // {
             //   if (disposing)
         //       {
                    // TODO: dispose managed state (managed objects).
       //         }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

      //          disposedValue = true;
      //      }
      //  }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~RayPerception() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
      //  void IDisposable.Dispose()
     //   {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
      //      Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
     //   }
      //  #endregion
    //}
    public class ArrayUtil : IDisposable
    {
        public static int GetIndexOfLowestValue(List<float> arr)
        {
            float value = float.PositiveInfinity;
            int index = 0;
            for (int i = 0; i < arr.Count; i++)
            {
               
                    if (arr[i] < value)
                    {
                       if (arr[i] < 0)
                       {
                        index = i;
                        value = arr[i];
                       }
                    }
                
            }
           // Debug.Log(index);
            return index;
        }
        public static Transform[] ListToArray(List<Transform> tarr)
        {
            Transform[] farts = tarr.ToArray();


            
            return farts;
            
        }
        public static List<Transform> ArrayToList(Transform[] tarr)
        {
            List<Transform> cheese = tarr.ToList<Transform>();

            return cheese;
        }
        public static ResizableArray<Transform> toResizableArray(Transform[] tarr)
        {
            ResizableArray<Transform> cheese = new ResizableArray<Transform>(tarr.Length);
            foreach(Transform tl in tarr)
            {
                cheese.Add(tl);
            }

            return cheese;
        }
        public static Transform[] ResizableToArray(ResizableArray<Transform> tarr)
        {
            Transform[] farts = new Transform[tarr.Count];
            ResizableArray<Transform> fart2 = new ResizableArray<Transform>(tarr.Count);
            for(int ou = 0;ou<tarr.Count;ou++)
            {
                if (tarr.InternalArray[ou] != null)
                {
                    farts[ou] = tarr.InternalArray[ou];
                }

            }



            return farts;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~ArrayUtil() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
        ~ArrayUtil()
        {

        }
    }


   


   public class ResizableArray<T>
    {
        T[] m_array;
        int m_count;

        public ResizableArray(int? initialCapacity = null)
        {
            m_array = new T[initialCapacity ?? 1]; // or whatever
        }

        public void ClearArray()
        {
            Array.Clear(m_array, 0, m_array.Length);
        }

        internal T[] InternalArray { get { return m_array; } }

      

        public int Count { get { return m_count; } }

        public void Add(T element)
        {
            if (m_count == m_array.Length)
            {
                Array.Resize(ref m_array, m_array.Length * 2);
            }

            m_array[m_count++] = element;
        }

    }

     


}

