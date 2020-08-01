using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    string _textToDisplay = "";
    Text _textComponent = null;
    Image _backgroundImage = null;

    public float timeBetweenLetters = 0.2f;
    public float timeToRemainOpen = 1.0f;
    private float _timeSinceLastLetter = 0.0f;
    private float _timeSinceComplete = 0.0f;
    public float _closeAfterSeconds = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        _textComponent = GetComponentInChildren<Text>();
        _backgroundImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_textComponent.text != _textToDisplay)
        {
            _timeSinceLastLetter -= Time.deltaTime;
            //Debug.Log("Time since Last Letter: " + _timeSinceLastLetter);
            if (_timeSinceLastLetter <= 0)
            {
                _timeSinceLastLetter += timeBetweenLetters;
                int substringLength = _textComponent.text.Length + 1;
                _textComponent.text = _textToDisplay.Substring(0, substringLength);
            }

        }
        else if (_textToDisplay.Length > 0)
        {
            _timeSinceComplete += Time.deltaTime;
            if(_timeSinceComplete > _closeAfterSeconds)
            {
                Close();
            }
        }
    }

    public bool ChangeDisplayText( string toDisplay)
    {
        bool ret = false;
        if (_timeSinceComplete > timeToRemainOpen || _textToDisplay.Length == 0)
        {
            ret = true;
            _backgroundImage.enabled = true;
            _textComponent.enabled = true;
            _textToDisplay = toDisplay;
            _textComponent.text = "";
            _timeSinceComplete = 0.0f;
            _timeSinceLastLetter = 0.0f;
        }
        return ret;
    }
    public void Close()
    {
        if (_timeSinceComplete > timeToRemainOpen && _textToDisplay.Length != 0) {
            _textToDisplay = "";
            _textComponent.text = "";
            _backgroundImage.enabled = false;
            _textComponent.enabled = false;
        }
    }
}
