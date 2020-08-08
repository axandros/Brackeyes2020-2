using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class PatrolBehavior : RoutineBase
{
    [SerializeField]
    List<Vector3> _patrolWaypoints = null;

    [SerializeField]
    float _timeAtWaypoint = 0.0f;

    int _wayPointIndex = 0;
    float _atWaypoint;

    public void StartPatrol()
    {
        _navAgent.isStopped = false;
        _navAgent.SetDestination(_patrolWaypoints[_wayPointIndex]);
    }
    public void StopPatrol()
    {
        _navAgent.isStopped = true;
        
    }
    protected new void Start()
    {
        base.Start();
        _dialogue.OnStartTalking.AddListener(StopPatrol);
        _ds.OnDialogueStop.AddListener(StartPatrol);
        StartPatrol();
    }
    protected new void Update()
    {
        base.Update();
        //Debug.Log("Child Update");
        if(_navAgent.remainingDistance < 0.5 )
        {
            _atWaypoint += Time.deltaTime;
            if(_atWaypoint > _timeAtWaypoint)
            {
                _wayPointIndex++;
                if (_wayPointIndex >= _patrolWaypoints.Count)
                {
                    _wayPointIndex = 0;
                }
                _atWaypoint = 0.0f;
                _navAgent.SetDestination(_patrolWaypoints[_wayPointIndex]);
            }
        }
    }


}
