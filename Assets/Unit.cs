using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Panda;

public class Unit : MonoBehaviour {

    public Definitions.eSide Team;
    Transform _target = null;

    // Use this for initialization
    void Start () {
        
    }
    
    // Update is called once per frame
    void Update () {
        
    }

    [Task]
    bool HasTarget()
    {
        return _target != null;
    }

    [Task]
    void FindNewTarget()
    {
        Debug.Log("Finding new target");
    }

    [Task]
    void MoveToTarget()
    {
        Debug.Log("Moving to target");
    }
}
