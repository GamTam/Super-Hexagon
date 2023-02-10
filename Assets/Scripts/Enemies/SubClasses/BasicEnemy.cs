using System;
using UnityEngine;

public class BasicEnemy : Enemy
{
    new void Start()
    {
        base.Start();
        _stats = new Stats()
        {
            ATK = 1,
            DEF = 0,
            mHP = 1,
            HP = 1,
            SPEED = 4
        };
    }

    protected override void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject == _player.gameObject)
        {
            _player.GetHurt(Globals.DamageFormula(_stats.ATK, _player._stats.DEF));
        }
        Destroy(gameObject);
    }
}