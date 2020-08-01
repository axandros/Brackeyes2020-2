using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField]
    Vector3 _targetPosition;

    bool moving = false;
    Vector3 _startPosition;
    public float TimeToMove = 3;
    float _timeMoving = 0.0f;

    // Update is called once per frame
    void Update()
    {

        if (moving) {
            Debug.Log("Opening");
            _timeMoving += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, _targetPosition, _timeMoving / TimeToMove);
            if (_timeMoving > TimeToMove) { moving = false; }
        }
    }

    public void Open(){
        moving = true;
        }
}
