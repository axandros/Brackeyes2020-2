using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TradePoint : MonoBehaviour
{
    public UnityEvent OnTrade;
    [SerializeField]
    string _tag = "item";

    AudioSource _sound = null;

    //[SerializeField]
    //GameObject _objToGive = null;

    [SerializeField]
    int _numberOfItemsForTrade = 1;
    int _numberItemsCollected = 0;

    public int TradesCompleted { get { return _numberItemsCollected; } }

    [SerializeField]
    Transform _spawnLocation = null;

    [SerializeField]
    int _numberOfTrades = 1;
    int _tradesCompleted = 0;

    [SerializeField]
    bool _destroyItem = true;

    private void Start()
    {
        _sound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Trigger entered by " + other.name + " tagged " + other.tag);
        if(other.tag == _tag && _tradesCompleted < _numberOfTrades)
        {
            if (_sound) { _sound.PlayOneShot(_sound.clip); }
            //Debug.Log("OnTrade Invoking");
            if (_destroyItem) { Destroy(other.gameObject); }
            _numberItemsCollected++;
            OnTrade.Invoke();
        }
    }

    void GiveReward()
    {
        _tradesCompleted++;
        //if (_objToGive != null) { Instantiate(_objToGive, _spawnLocation.position, _spawnLocation.rotation); }
        //obj.transform.parent = null;
    }

    public void GiveReward(GameObject gobj)
    {
        if (_numberItemsCollected >= _numberOfItemsForTrade && gobj != null)
        {
            _tradesCompleted++;
            //if (_objToGive != null) { Instantiate(gobj, _spawnLocation.position, _spawnLocation.rotation); }
            gobj.transform.position = _spawnLocation.position;
            gobj.transform.rotation = _spawnLocation.rotation;
            //Debug.Log("Position: " + _spawnLocation.position + " | Item: " + gobj.transform.position);

        }
    }
}
