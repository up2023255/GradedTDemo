using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private enum State
    {
        Roaming,
        ChaseTarget,
    }

    private Vector2 RandomPos;
    private Vector2 StartPos;
    private State state;
    //public GameObject Player;

    public static Vector2 RanDirection()
    {
        return new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;
    }
    private void TargetFound()
    {
        float Range = 50f;
        //if (Vector2.Distance(transform.position ) < Range) ;
    }
    void Start()
    {
        
    }
    private void Update()
    {
        
    }
}
