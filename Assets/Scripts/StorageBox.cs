using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageBox : MonoBehaviour
{

    [SerializeField]
    GameObject _storedObject = null;

    [SerializeField]
    LayerMask _pickupLayer = 8;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
