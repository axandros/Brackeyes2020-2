using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueSearcher : MonoBehaviour
{
    public UnityEvent OnTalk;
    Camera _playerview = null;

    [SerializeField]
    float _dialogueDistance = 7.0f;

    public NPCDialogue NPCSeen()
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
                return npcd;
            }
        }
        return null;
    }

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
                    OnTalk.Invoke();
                    npcd.Dialogue();
                }

            }
        }
    }
}
