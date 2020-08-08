using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoutine : RoutineBase
{
    protected static WorldManager _wm = null;

    protected new void Start()
    {
        base.Start();
        if(_wm == null)
        {
            _wm = FindObjectOfType<WorldManager>();
        }
    }

    public void ResetWorld()
    {
        WorldManager.Instance.ResetWorld();
    }

}
