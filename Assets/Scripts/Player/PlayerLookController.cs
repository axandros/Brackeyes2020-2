using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookController : MonoBehaviour
{
    [SerializeField]
    float _sensitivity = 5.0f;
    [SerializeField]
    float _smoothing = 2.0f;
    GameObject _character;

    private Vector2 _mouseLook;
    private Vector2 _smoothV;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _character = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        var mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        mouseDelta = Vector2.Scale(mouseDelta, new Vector2(_sensitivity * _smoothing, _sensitivity * _smoothing));
        _smoothV.x = Mathf.Lerp(_smoothV.x, mouseDelta.x, 1f / _smoothing);
        _smoothV.y = Mathf.Lerp(_smoothV.y, mouseDelta.y, 1f / _smoothing);

        _mouseLook += _smoothV;

        transform.localRotation = Quaternion.AngleAxis(-_mouseLook.y, Vector3.right);
        _character.transform.localRotation = Quaternion.AngleAxis(_mouseLook.x, _character.transform.up);
    }
}
