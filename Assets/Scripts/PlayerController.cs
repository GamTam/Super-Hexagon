using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private string _song;

    public Stats _stats = new Stats()
    {
        ATK = 12,
        DEF = 2,
        mHP = 50,
        HP = 50
    };

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

    public void GetHurt(int dmg)
    {
        _stats.HP -= dmg;
        if (_stats.HP <= 0)
        {
            Globals.MusicManager.fadeOut(1);
            Destroy(gameObject);
        }
    }
}

[Serializable]
public struct Stats
{
    public int ATK;
    public int DEF;
    public int mHP;
    public int HP;
    public int SPEED;
}
