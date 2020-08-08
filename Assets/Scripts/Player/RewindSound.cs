using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindSound : MonoBehaviour
{

    [SerializeField]
    AudioSource _as = null;
    // Start is called before the first frame update
    void Start()
    {
        if(_as != null) { WorldManager.Instance.OnReset.AddListener(PlaySound); }
    }

    public void PlaySound()
    {
        _as.PlayOneShot(_as.clip);
    }
}
