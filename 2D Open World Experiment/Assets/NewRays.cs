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
    public class NewRays : MonoBehaviour
    {
        List<float> perceptionBuffer = new List<float>();
        Vector3 endPosition;
        RaycastHit hit;
        public NorpAI norpAI;
        public bool isaCurrentTargetType;
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
        /// <summary>
        /// Creates perception vector to be used as part of an observation of an agent.
        /// </summary>
        /// <returns>The partial vector observation corresponding to the set of rays</returns>
        /// <param name="rayDistance">Radius of rays</param>
        /// <param name="rayAngles">Anlges of rays (starting from (1,0) on unit circle).</param>
        /// <param name="detectableObjects">List of tags which correspond to object types agent can see</param>
        /// <param name="startOffset">Starting heigh offset of ray from center of agent.</param>
        /// <param name="endOffset">Ending height offset of ray from center of agent.</param>
        public List<float> Perceive(float rayDistance,
            float[] rayAngles, string[] detectableObjects,
            float startOffset, float endOffset)
        {
            perceptionBuffer.Clear();
            // For each ray sublist stores categorial information on detected object
            // along with object distance.
            foreach (float angle in rayAngles)
            {
                endPosition = transform.TransformDirection(
                    PolarToCartesian(rayDistance, angle));
                endPosition.y = endOffset;
                if (Application.isEditor)
                {
                    Debug.DrawRay(transform.position + new Vector3(0f, startOffset, 0f),
                        endPosition, Color.black, 0.01f, true);
                }

                float[] subList = new float[detectableObjects.Length + 2];
                if (Physics.SphereCast(transform.position +
                                       new Vector3(0f, startOffset, 0f), 0.5f,
                    endPosition, out hit, rayDistance))
                {
                    for (int i = 0; i < detectableObjects.Length; i++)
                    {
                        if (hit.collider.gameObject.CompareTag(detectableObjects[i]))
                        {
                            print(hit.collider.gameObject.tag);
                            subList[i] = 1;
                            subList[detectableObjects.Length + 1] = hit.distance / rayDistance;
                            break;
                        }
                    }
                }
                else
                {
                    subList[detectableObjects.Length] = 1f;
                }

                perceptionBuffer.AddRange(subList);
            }

            return perceptionBuffer;
        }

        /// <summary>
        /// Converts polar coordinate to cartesian coordinate.
        /// </summary>
        public static Vector3 PolarToCartesian(float radius, float angle)
        {
            float x = radius * Mathf.Cos(DegreeToRadian(angle));
            float z = radius * Mathf.Sin(DegreeToRadian(angle));
            return new Vector3(x, 0f, z);
        }

        /// <summary>
        /// Converts degrees to radians.
        /// </summary>
        public static float DegreeToRadian(float degree)
        {
            return degree * Mathf.PI / 180f;
        }
    }
}
