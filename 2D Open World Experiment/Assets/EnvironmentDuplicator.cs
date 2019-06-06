using MLAgents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentDuplicator : MonoBehaviour {

    public int Rows = 4;
    public int Cols = 5;
    public GameObject Prefab;
    public float ColSpacing = 2f;
    public float RowSpacing = 2.5f;
    public Brain BrainToUse;
    public Brain BrainToUse2;
    public bool use2Brains;
	// Use this for initialization
	void Awake () {
        var count = 1;
        Vector2 Cursor = new Vector2(ColSpacing * Cols * -0.5f, RowSpacing * Rows * -0.5f);

        for (var y = 0; y < Rows; y++)
        {
            for (var x = 0; x < Cols; x++)
            {
                var env = Instantiate<GameObject>(Prefab, Cursor, Quaternion.identity, transform);
                env.name = "Environment" + count;
                count++;

                Agent[] agentScript = env.GetComponentsInChildren<Agent>();
                foreach (Agent a in agentScript) {
                    if (use2Brains)
                    {
                        int rando = Random.Range(0, 2);
                        if (rando == 0)
                        {
                            a.GiveBrain(BrainToUse);
                        }
                        else
                        {
                            a.GiveBrain(BrainToUse2);
                        }
                        Cursor.x += ColSpacing;
                        env.SetActive(true);
                    }
                    else
                    {
                        a.GiveBrain(BrainToUse);
                        Cursor.x += ColSpacing;
                        env.SetActive(true);

                    }
                }
            }

            Cursor.x = ColSpacing * Cols * -0.5f;
            Cursor.y += RowSpacing;
        }
	}

}
