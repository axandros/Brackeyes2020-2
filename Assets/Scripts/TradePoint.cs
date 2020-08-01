using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradePoint : MonoBehaviour
{
    [SerializeField]
    string _tag = "item";

    [SerializeField]
    GameObject _objToGive = null;

    [SerializeField]
    Transform _spawnLocation = null;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered by " + other.name + " tagged " + other.tag);
        if(other.tag == _tag)
        {
            Destroy(other.gameObject);
            GiveReward();
        }
    }

    void GiveReward()
    {
        GameObject obj = Instantiate(_objToGive, _spawnLocation.position, _spawnLocation.rotation);
        //obj.transform.parent = null;
    }

}
