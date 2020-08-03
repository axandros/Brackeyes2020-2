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

    [SerializeField]
    Collider _largerCollision = null;

    public void GoToLunch()
    {
        Debug.Log("Running Guard GO_TO_LUNCH");
        if (!_helpingScientist)
        {
            if(_largerCollision != null) { _largerCollision.enabled = false; }
            _navAgent.destination = LunchPosition;
            _atLunch = true;
        }
    }

    public void HelpScientist()
    {
        if (!_atLunch)
        {
            if (_largerCollision != null) { _largerCollision.enabled = false; }
            _navAgent.destination = ScientistPosition;
            _helpingScientist = true;
        }
    }
}
