using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Stats _stats = new Stats();

    [SerializeField] protected PlayerController _player;

    protected void Start()
    {
        if (_player == null) _player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        Debug.Log(_player);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        MoveTowardsPlayer(_stats.SPEED);
    }
    
    protected virtual void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }

    protected void MoveTowardsPlayer(int speed)
    {
        transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, speed * Time.deltaTime);
    }
}
