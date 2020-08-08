using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class WorldManager : MonoBehaviour
{
    bool _invoke = false;

    public UnityEvent GameWon;
    public UnityEvent OnReset;

    static WorldManager _instance = null;
    public static WorldManager Instance { get { return _instance; } }
    int _randNumber = 0;
    List<int> _keyNumber = new List<int>();

    [SerializeField]
    CanvasGroup _endGameScreen = null;

    bool _hasPickedUp = false;
    public bool PickedUp
    {
        get { return _hasPickedUp; }
        set { _hasPickedUp = _hasPickedUp || value; }
    }
    bool _hasTalked = false;
    public bool Talked
    {
        get { return _hasTalked; }
        set { _hasTalked = _hasTalked || value; }
    }
    bool _hasMoved = false;
    public bool Moved
    {
        get { return _hasMoved; }
        set { _hasMoved = _hasMoved || value; }
    }

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
    bool _gameWon = false;
    float _gameWinCount = 0;
    float _gameWinFullValue = 2.5f;

    public float TimeRemaining
    {
        get { return _lengthOfWorldInSeconds - _elapsedTime; }
    }

    public float TimeElapsed
    {
        get { return _elapsedTime; }
    }

    bool _counting = true;

    private void Awake()
    {
        int num = (int)( Random.value * 100.0f);
        _keyNumber.Add(1);
        _keyNumber.Add(9);
        _keyNumber.Add(4);
        _keyNumber.Add(6);
        _keyNumber.Add(2);
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
        if (_counting) { 
            _elapsedTime += Time.deltaTime;
            if (TimeRemaining < 0.0)
            {
                ResetWorld();
            }
            else if(TimeRemaining < 3 && !_invoke)
            {
                _invoke = true;
                OnReset.Invoke();
            }
        }
        else if (_gameWon)
        {
            _gameWinCount += Time.deltaTime;
            _endGameScreen.alpha = _gameWinCount / _gameWinFullValue;
        }
        else
        {

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

    public void EndGame()
    {
        _counting = false;
        _gameWon = true;
        GameWon.Invoke();
    }
}
