using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageBox : MonoBehaviour
{

    [SerializeField]
    GameObject _storedObject = null;

    [SerializeField]
    LayerMask _pickupLayer = 8;

    public void Retreive()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.gameObject.layer == _pickupLayer)
        {
            if(_storedObject == null)
            {
                //_storedObject = 
                Destroy(other);

            }
        }
    }
}
