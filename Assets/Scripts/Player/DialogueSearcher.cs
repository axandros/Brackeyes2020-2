using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSearcher : MonoBehaviour
{
    Camera _playerview = null;

    [SerializeField]
    float _dialogueDistance = 7.0f;

    private void Start()
    {
        _playerview = Camera.main;
    }

    private void Update()
    {
        bool mouseDown = Input.GetMouseButtonDown(0);
        if (mouseDown)
        {
            RaycastHit hit;
            Ray screenRay = _playerview.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            //Debug.DrawRay(screenRay.origin, screenRay.direction * _dialogueDistance, Color.blue, 3.0f);
            if (Physics.Raycast(screenRay, out hit, _dialogueDistance))
            {
               // Debug.Log("Found Something: " + hit.transform.name);
                NPCDialogue npcd = hit.transform.GetComponent<NPCDialogue>();
                if (npcd)
                {
                    npcd.Dialogue();
                }

            }
        }
    }
}
