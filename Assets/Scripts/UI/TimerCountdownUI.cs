using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCountdownUI : MonoBehaviour
{
    WorldManager _wm = null;
    Text _text = null;

    // Start is called before the first frame update
    void Start()
    {
        _wm = Object.FindObjectOfType<WorldManager>();
        _text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_wm != null && _text != null)
        {
            /*
            int minutes = (int)_wm.TimeRemaining / 60;
            int seconds = (int)_wm.TimeRemaining % 60;
            //Debug.Log("Time Remaining: "+ _wm.TimeRemaining + " minutes: " + minutes + "seconds: " + seconds);

            _text.text = minutes.ToString() + ":" + seconds.ToString();
            */
            _text.text = ((int)_wm.TimeRemaining).ToString();
        }
    }
}

