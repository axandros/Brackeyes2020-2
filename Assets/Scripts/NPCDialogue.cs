using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    [SerializeField]
    string _name = "";
    public string Name { get
        {
            if(_name == "")
            {
                return this.transform.name;
            }
            return _name;
        } }

    [SerializeField]
    string _Introduction = "";
    bool _introPlayed = false;

    [SerializeField]
    string _Request = "";

    [SerializeField] 
    string _Thanks = "";

    DialogueSystem _ds = null;
    [SerializeField]
    TradePoint _trade = null;

    bool _itemReceived
    {
        get
        {
            return _trade.TradesCompleted > 0;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _ds = FindObjectOfType<DialogueSystem>();
        if(_trade == null)
        {
            _trade = GetComponentInChildren<TradePoint>();
        }
    }

    public void Dialogue()
    {
        
        if (!_introPlayed)
        {
            if (_ds.ChangeDisplayText(_Introduction, Name))
            {
                _introPlayed = true;
            }
        }
        else
        {
            string diag = _Thanks;
            if (!_itemReceived)
            {
                diag = _Request;
            }
            _ds.ChangeDisplayText(diag, Name);
        }
        
    }
}
