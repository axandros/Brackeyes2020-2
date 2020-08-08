using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    public UnityEvent OnMove;

    public float speed = 10.0f;
    private float _translation;
    private float _strafe;

    bool _canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        WorldManager.Instance.GameWon.AddListener(StopAction);
    }

    // Update is called once per frame
    void Update()
    {
        if (_canMove)
        {
            _translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
            _strafe = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            transform.Translate(_strafe, 0, _translation);
            if (_strafe != 0 || _translation != 0)
            {
                OnMove.Invoke();
            }
        }
    }

    void StopAction()
    {
        _canMove = false;
    }
}
