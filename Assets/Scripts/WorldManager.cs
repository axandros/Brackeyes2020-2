using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldManager : MonoBehaviour
{
    static WorldManager _instance = null;
    public static WorldManager Instance { get { return _instance; } }
    int _randNumber = 0;
    List<int> _keyNumber = new List<int>();
    public static List<int> KeyNumber
    {
        get
        {
            return Instance._keyNumber;
        }
    }

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

    private void Awake()
    {
        int num = (int)( Random.value * 100.0f);
        _keyNumber.Add(0);
        _keyNumber.Add(1);
        _keyNumber.Add(2);
        _keyNumber.Add(3);
        _keyNumber.Add(4);
        _keyNumber.Add(5);
        //Debug.Log("World Manager Awake: " + this.transform.name + " #" + num);
        if (_instance == null)
        {
            //Debug.Log(this.transform.name + " setting as Instance.");
            DontDestroyOnLoad(this.gameObject);
            _instance = this;
            _randNumber = num;
            SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        } else if(_instance != this) 
        {
            //Debug.Log(this.transform.name + " destroying self.");
            Destroy(this.gameObject); 
        }
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        //Debug.Log("World Manager LevelLoaded: " + this.transform.name + " #" + _randNumber);
        _elapsedTime = 0;
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
    public void ResetWorld()
    {
        Scene s = SceneManager.GetSceneByName(_startingWorld);
        if (s.IsValid())
        {
            SceneManager.LoadScene(s.buildIndex);
        }
        
    }
}
