using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldManager : MonoBehaviour
{
    [SerializeField]
    int _lengthOfWorldInSeconds = 120;

    [SerializeField]
    string _startingWorld = "";

    float _elapsedTime;

    public float TimeRemaining
    {
        get { return _lengthOfWorldInSeconds - _elapsedTime; }
    }
    public float TimeElapsed
    {
        get { return _elapsedTime; }
    }


    // Update is called once per frame
    void Update()
    {
        _elapsedTime += Time.deltaTime;
        if(TimeRemaining < 0.0)
        {
            ResetWorld();
        }
    }
    private void ResetWorld()
    {
        Scene s = SceneManager.GetSceneByName(_startingWorld);
        if (s.IsValid())
        {
            SceneManager.LoadScene(s.buildIndex);
        }
        
    }
}
