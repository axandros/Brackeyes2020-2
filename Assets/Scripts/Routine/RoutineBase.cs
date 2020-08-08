using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class RoutineBase : MonoBehaviour
{
    [Serializable]
    public struct Task
    {
        public string name;
        public int secondsPassed;
        public UnityEvent event_Task;

    }

    [SerializeField]
    List<Task> Schedule = new List<Task>();
    int _scheduleIndex = 0;

    static WorldManager _wm;
    protected NavMeshAgent _navAgent;
    protected NPCDialogue _dialogue;
    protected static DialogueSystem _ds = null;
    protected GameObject _player = null;

    // Start is called before the first frame update
    protected void Start()
    {
        if (_wm == null) { _wm = FindObjectOfType<WorldManager>(); }
        Schedule.Sort((s1, s2) => s1.secondsPassed.CompareTo(s2.secondsPassed));
        _navAgent = GetComponent<NavMeshAgent>();
        _dialogue = GetComponent<NPCDialogue>();
        if (_ds == null) { _ds = FindObjectOfType<DialogueSystem>(); }
        if(_player == null) { _player = GameObject.FindGameObjectWithTag("Player"); }
    }

    // Update is called once per frame
    protected void Update()
    {
        ScheduleUpdate();

        FacePlayer();
    }

    private void ScheduleUpdate()
    {
        //Debug.Log(this.transform.name + " Schedule Check: " + _scheduleIndex + " / " + Schedule.Count);
        if (_scheduleIndex < Schedule.Count && _wm.TimeElapsed >= Schedule[_scheduleIndex].secondsPassed)
        {
            //Debug.Log(this.transform.name + " Invoking Task " + Schedule[_scheduleIndex].name);
            Schedule[_scheduleIndex].event_Task.Invoke();
            _scheduleIndex++;
        }
    }

    private void FacePlayer()
    {
        // Are we stopped?
        if (_navAgent != null &&_navAgent.velocity.magnitude < 0.1f){
            // >Is the player close?
            float dist = Mathf.Abs((_player.transform.position - transform.position).magnitude);
            if (dist < 10) {
                Quaternion rot = transform.rotation;
                transform.LookAt(_player.transform);
                Quaternion lookAtRot = transform.rotation;
                transform.rotation= Quaternion.Lerp(rot, lookAtRot, 0.01f);
                    }
        }
    }

}
