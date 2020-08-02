using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardRoutine : RoutineBase
{
    bool _atLunch = false;
    bool _helpingScientist = false;

    [SerializeField]
    Vector3 LunchPosition = Vector3.zero;
    [SerializeField]
    Vector3 ScientistPosition = Vector3.zero;

    public void GoToLunch()
    {
        if (!_helpingScientist)
        {
            _navAgent.destination = LunchPosition;
            _atLunch = true;
        }
    }

    public void HelpScientist()
    {
        if (!_atLunch)
        {
            _navAgent.destination = LunchPosition;
            _helpingScientist = true;
        }
    }
}
