using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Scriptable_Objects/Settings")]
public class PlayerSettings : ScriptableObject
{
    [SerializeField]
    private float _speed = 5;
    public float speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    [SerializeField]
    private float _jumpForce = 13;
    public float jumpForce
    {
        get { return _jumpForce; }
        set { _jumpForce = value; }
    }

    [SerializeField]
    private float _antiBump = 4.5f;
    public float antiBump
    {
        get { return _antiBump; }
        set { _antiBump = value; }
    }
    
    [SerializeField]
    private float _gravity = 30f;
    public float gravity
    {
        get { return _gravity; }
        set { _gravity = value; }
    }

    [SerializeField]
    private float _camSensitivity = 1.5f;
    public float camSensitivity
    {
        get { return _camSensitivity; }
        set { _camSensitivity = value; }
    }
    
    [SerializeField, Range(0, 0.1f)]
    private float _headbobAmplitude = 0.015f;
    public float headbobAmplitude
    {
        get { return _headbobAmplitude; }
        set { _headbobAmplitude = value; }
    }
    
    [SerializeField, Range(0, 30)]
    private float _headbobFrequency = 10;
    public float headbobFrequency
    {
        get { return _headbobFrequency; }
        set { _headbobFrequency = value; }
    }
    
    
}
