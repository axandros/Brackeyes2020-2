using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToRoutine : RoutineBase
{
    [SerializeField]
    Vector3 location = Vector3.zero;
    public void GoToLocation()
    {
        _navAgent.SetDestination(location);
    }
}
