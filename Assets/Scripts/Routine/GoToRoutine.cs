using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToRoutine : RoutineBase
{
    [SerializeField]
    List<Vector3> location = new List<Vector3>();

    int _storedIndex = 0;
    public void GoToLocation(int index)
    {
        if (index < location.Count && index >= 0)
        {
            _storedIndex = index;
            _navAgent.SetDestination(location[index]);
        }
    }

    public void StopWalk()
    {
        _navAgent.isStopped = true;
    }

    public void StartWalk()
    {
        GoToLocation(_storedIndex);
    }

    protected new void Start()
    {
        base.Start();
        _dialogue.OnStartTalking.AddListener(StopWalk);
        _ds.OnDialogueStop.AddListener(StartWalk);
    }
}
