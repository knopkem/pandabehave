using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Panda;
using UnityEngine.AI;

public class AI : MonoBehaviour {

    public Definitions.eSide Team;
    Vector3 _destination;
    NavMeshAgent _agent;

    // Use this for initialization
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _destination = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }


    [Task]
    void FindBestTarget()
    {
        Debug.Log("Finding new target");
    }


    [Task]
    public bool SetDestination(Vector3 p)
    {
        _destination = p;
        _agent.destination = _destination;

        return true;
    }

    [Task]
    public void WaitArrival()
    {
        var task = Task.current;
        float d = _agent.remainingDistance;
        if (!task.isStarting && _agent.remainingDistance <= 1e-2)
        {
            task.Succeed();
            d = 0.0f;
        }
    }

    [Task]
    public void MoveTo(Vector3 dst)
    {
        SetDestination(dst);
        if (Task.current.isStarting)
        {
            _agent.isStopped = false;
        }
        WaitArrival();
    }

    [Task]
    public void MoveTo_Destination()
    {
        MoveTo(_destination);
        WaitArrival();
    }

    [Task]
    public bool Stop()
    {
        _agent.isStopped = true;
        return true;
    }
}
