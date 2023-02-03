using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private string _song;

    private PlayerInput _playerInput;
    private InputAction _moveVector;
    
    void Start()
    {
        _playerInput = GameObject.FindWithTag("Controller Manager").GetComponent<PlayerInput>();
        _moveVector = _playerInput.actions["Main/Movement"];

        Globals.MusicManager.Play(_song);
    }
    
    void Update()
    {
        Vector2 moveVector = _moveVector.ReadValue<Vector2>();
        
        gameObject.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - (_moveSpeed * moveVector.x * Time.deltaTime ));
    }
}
