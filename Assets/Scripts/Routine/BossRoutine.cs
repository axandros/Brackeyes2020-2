using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoutine : RoutineBase
{
    protected static WorldManager _wm = null;

    [SerializeField]
    float CountToReset = 3;
    bool Resetting = false;

    protected new void Start()
    {
        base.Start();
        if (_wm == null)
        {
            _wm = FindObjectOfType<WorldManager>();
        }
        
    }

    public void ResetWorld()
    {
         Resetting = true;
        FindObjectOfType<RewindSound>().PlaySound();
    }

    public void WinGame()
    {
        WorldManager.Instance.EndGame();
    }

    protected new void Update()
    {
        if (Resetting)
        {
            CountToReset = CountToReset - Time.deltaTime;
            if (CountToReset <= 0)
            {
                WorldManager.Instance.ResetWorld();
            }
        }
    }

}
