using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenNumberDisplay : MonoBehaviour
{
    Text _displayText = null;
    [SerializeField]
    int indexInKey;

    // Start is called before the first frame update
    void Start()
    {
        if(_displayText == null) { _displayText = GetComponentInChildren<Text>(); }
        _displayText.text = "";
    }

    public void DisplayNumber()
    {
        updateText(WorldManager.KeyNumber[indexInKey].ToString());
    }

    public void updateText(string str)
    {
        _displayText.text = str;
    }
    public string DisplayedText()
    {
        return _displayText.text;
    }
}
