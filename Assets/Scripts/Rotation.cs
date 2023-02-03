using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private Vector3 _rotationSpeed;
    [SerializeField] private Vector3 _maxRotation;
    private System.Random _random = new System.Random();

    private void Start()
    {
        if (_maxRotation.x == 0)
        {
            _maxRotation.x = float.MaxValue;
        }
        
        if (_maxRotation.y == 0)
        {
            _maxRotation.y = float.MaxValue;
        }
        
        if (_maxRotation.z == 0)
        {
            _maxRotation.z = float.MaxValue;
        }
    }

    void Update()
    {
        int num = _random.Next(500);
        if (num == 250)
        {
            int directionShift = _random.Next(3);
            switch (directionShift)
            {
                case 0:
                    _rotationSpeed.x *= -1;
                    break;
                case 1:
                    _rotationSpeed.y *= -1;
                    break;
                default:
                    _rotationSpeed.z *= -1;
                    break;
            }
        }

        if (Mathf.Abs(transform.rotation.eulerAngles.x) >= Mathf.Abs(_maxRotation.x))
        {
            _rotationSpeed.x *= -1;
        }
        
        if (Mathf.Abs(transform.rotation.eulerAngles.y) >= Mathf.Abs(_maxRotation.y))
        {
            _rotationSpeed.y *= -1;
        }
        
        if (Mathf.Abs(transform.rotation.eulerAngles.z) >= Mathf.Abs(_maxRotation.z))
        {
            _rotationSpeed.z *= -1;
        }
        
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + (_rotationSpeed * Time.deltaTime));
    }
}
