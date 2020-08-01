using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField]
    Camera _playerview;
    
    [SerializeField]
    float _reach = 5.0f;

    [SerializeField]
    float _throwingForce = 500.0f;

    [SerializeField]
    LayerMask _pickupLayer;


    Rigidbody _holding = null;

    // Start is called before the first frame update
    void Start()
    {
        if(_playerview == null)
        {
            _playerview = Camera.main;
        }
    }

    // Update is called once per frame
    void Update()
    {
        bool mouseDown = Input.GetKeyDown(KeyCode.Mouse0);
        

        if(_holding != null)
        {
            _holding.transform.position = this.transform.position;
            _holding.angularVelocity = Vector3.zero;
        }
        else if (mouseDown)
        {
            Debug.Log("Mouse Down");
            RaycastHit hit;
            Ray screenRay = _playerview.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            Debug.DrawRay(screenRay.origin,screenRay.direction * _reach, Color.blue, 3.0f);
            if (Physics.Raycast(screenRay, out hit, _reach))
            {
                Debug.Log("Found Something: " + hit.transform.name);
                _holding = hit.transform.GetComponent<Rigidbody>();
                if (_holding != null)
                {
                    hit.transform.position = this.transform.position;
                    hit.transform.parent = this.transform;
                    _holding.useGravity = false;
                    
                }
            }
        }

        // Throw 
        bool rightDown = Input.GetKeyDown(KeyCode.Mouse1);
        if (_holding != null && rightDown)
        {
            _holding.useGravity = true;
            _holding.transform.parent = null;
            _holding.AddExplosionForce(_throwingForce, this.transform.parent.transform.position, _reach * 1.5f);
            _holding = null;
        }

        // Drop
        bool centerDown = Input.GetKeyDown(KeyCode.Mouse2);
        if (_holding != null && centerDown)
        {
            _holding.useGravity = true;
            _holding.transform.parent = null;
            _holding = null;
        }
    }
}
