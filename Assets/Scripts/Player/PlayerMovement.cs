using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10.0f;
    private float _translation;
    private float _strafe;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        _translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        _strafe = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(_strafe, 0, _translation);
    }
}
