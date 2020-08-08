using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorKey : MonoBehaviour
{
    [SerializeField]
    Text _numberDisplayText = null;

    GameObject _player = null;

    List<int> _inputNum = new List<int>();

    [SerializeField]
    bool _playerHere = false;

    [SerializeField]
    Vector3 _openPosition = Vector3.zero;
    Vector3 _adjustedOpenPosition = Vector3.zero;

    bool _open = false;
    bool _moving = false;
    Vector3 _startPosition;
    public float TimeToMove = 1.5f;
    float _timeMoving = 0.0f;

    private void Start()
    {
        _playerHere = false;
        if (_player == null) { _player = GameObject.FindGameObjectWithTag("Player"); }
        if(_numberDisplayText == null) { _numberDisplayText = GetComponentInChildren<Text>(); }
        _adjustedOpenPosition = _openPosition + transform.position;
    }

    private void Update()
    {
        if (_moving)
        {
            Debug.Log("Opening");
            _timeMoving += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, _adjustedOpenPosition, _timeMoving / TimeToMove);
            if (_timeMoving > TimeToMove) { _moving = false; }
        }
        if (!_open && _playerHere)
        {
            bool delete = Input.GetKeyDown(KeyCode.Backspace) || Input.GetKeyDown(KeyCode.Delete);
            bool zero = Input.GetKeyDown(KeyCode.Alpha0) || Input.GetKeyDown(KeyCode.Keypad0);
            bool one = Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1);
            bool two = Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2);
            bool three = Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3);
            bool four = Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4);
            bool five = Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5);
            bool six = Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad6);
            bool seven = Input.GetKeyDown(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.Keypad7);
            bool eight = Input.GetKeyDown(KeyCode.Alpha8) || Input.GetKeyDown(KeyCode.Keypad8);
            bool nine = Input.GetKeyDown(KeyCode.Alpha9) || Input.GetKeyDown(KeyCode.Keypad9);
            if (delete) { removeLastDigit(); }
            if (zero) { addDigitToDisplay(0); }
            if (one) { addDigitToDisplay(1); }
            if (two) { addDigitToDisplay(2); }
            if (three) { addDigitToDisplay(3); }
            if (four) { addDigitToDisplay(4); }
            if (five) { addDigitToDisplay(5); }
            if (six) { addDigitToDisplay(6); }
            if (seven) { addDigitToDisplay(7); }
            if (eight) { addDigitToDisplay(8); }
            if (nine) { addDigitToDisplay(9); }
        }
    }

    private void addDigitToDisplay(int i)
    {
        if(i >= 0 && i <= 9)
        {
            _inputNum.Add(i);
            Debug.Log("Writing " + i + " to door.");
            _numberDisplayText.text = _numberDisplayText.text + " " + i;
            if (_inputNum.Count == WorldManager.KeyNumber.Count)
            {
                bool good = true;
                for(int index = 0; index < _inputNum.Count && good; index++)
                {
                    good = _inputNum[index] == WorldManager.KeyNumber[index];
                }
                if (good)
                {
                    OpenDoor();
                }
                else
                {
                    WrongAnswer();
                }
            }
            else if(_inputNum.Count > WorldManager.KeyNumber.Count)
            {
                WrongAnswer();
            }
        }
    }
    private void removeLastDigit()
    {
        if(_inputNum.Count > 0)
        {
            _inputNum.RemoveAt(_inputNum.Count - 1);
            _numberDisplayText.text = _numberDisplayText.text.Substring(0, Mathf.Max(_numberDisplayText.text.Length - 2, 0));
        }
    }

    public void WrongAnswer()
    {
        Debug.Log("Wrong code input.  Clearing input.");
        // Play a sound
        // Clear Text
        _numberDisplayText.text = "";
        // Clear Entry
        _inputNum.Clear();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered enter");
        if (_player != null && other.gameObject == _player)
        {
            _playerHere = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_player != null && other.gameObject == _player)
        {
            _playerHere = false;
        }
    }

    public void OpenDoor()
    {
        _moving = true;
        _numberDisplayText.text = "";
    }
}
