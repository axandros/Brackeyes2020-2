using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField]
    Image _image = null;

    [SerializeField]
    Sprite MoveImage = null;
    [SerializeField]
    Sprite TalkImage = null;
    [SerializeField]
    Sprite PickupImage = null;
    [SerializeField]
    Sprite KeypadImage = null;

    [SerializeField]
    Pickup _playerPickup = null;
    DialogueSearcher _playerDialogue = null;
    PlayerMovement _playerMovement = null;
    DoorKey _door = null;
    // Start is called before the first frame update
    void Start()
    {
        _image = GetComponent<Image>();

        if (_playerPickup == null) { _playerPickup = FindObjectOfType<Pickup>(); }
        if (_playerPickup != null) {
            //Debug.Log(_playerPickup.name);
            //Debug.Log(_playerPickup.OnPickup.Equals.ToString());
            //Debug.Log(_playerPickup.OnPickup.Equals.ToString());
            _playerPickup.OnPickup.AddListener(Pickup);
            //Debug.Log("what");
        }
        _playerDialogue = FindObjectOfType<DialogueSearcher>();
        _playerDialogue.OnTalk.AddListener(Dialogue);
        _playerMovement = FindObjectOfType<PlayerMovement>();
        _playerMovement.OnMove.AddListener(Moved);
        _door = FindObjectOfType<DoorKey>();
        _door.PlayerEnter.AddListener(OnPlayerEnterDoor);
        _door.PlayerExit.AddListener(OnPlayerLeaveDoor);
    }

    public void Pickup()
    {
        WorldManager.Instance.PickedUp = true;
        //OnPlayerLeaveDoor();
    }
    void Dialogue()
    {
        WorldManager.Instance.Talked = true;
        OnPlayerLeaveDoor();
    }

    void Moved()
    {
        WorldManager.Instance.Moved = true;
        //OnPlayerLeaveDoor();
    }

    void OnPlayerEnterDoor()
    {
        _image.color = Color.white;
        _image.sprite = KeypadImage;
    }
    void OnPlayerLeaveDoor()
    {
        _image.color = Color.clear;
    }

    void Update()
    {
        if (!WorldManager.Instance.Moved)
        {
            Debug.Log("Havn't Moved.");
            _image.color = Color.white;
            _image.sprite = MoveImage;
        }
        else if (!WorldManager.Instance.PickedUp && _playerPickup.ObjectSeen() != null)
        {
            _image.color = Color.white;
            _image.sprite = PickupImage;
        }
        else if (!WorldManager.Instance.Talked && _playerDialogue.NPCSeen() != null)
        {
            _image.color = Color.white;
            _image.sprite = TalkImage;
        }
        else if(_image.sprite != KeypadImage)
        {
            _image.color = Color.clear;
        }
    }
}
