using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBob : MonoBehaviour
{
    [SerializeField] private PlayerSettings settings;
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform _cameraHolder;

    private float _toggleSpeed = 3;
    private Vector3 _startPos;
    private CharacterController _controller;

    private void Awake() {
        _controller = GetComponent<CharacterController>();
        _startPos = _camera.localPosition;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckMotion();
        ResetPos();
        _camera.LookAt(FocusTarget());
    }

    private Vector3 FocusTarget()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + _cameraHolder.localPosition.y, transform.position.z);
        pos += _cameraHolder.forward * 15f;

        return pos;
    }

    private Vector3 FootStepMotion(){
        Vector3 pos = Vector3.zero;

        pos.y += Mathf.Sin(Time.time * settings.headbobFrequency) * settings.headbobAmplitude; 
        pos.x += Mathf.Cos(Time.time * settings.headbobFrequency / 2) * settings.headbobAmplitude; 

        return pos;
    }

    private void PlayMotion(Vector3 motion){
        _camera.localPosition += motion;
    }

    private void CheckMotion(){
        float speed = new Vector3(_controller.velocity.x, 0, _controller.velocity.z).magnitude;

        if(speed < _toggleSpeed || !_controller.isGrounded) return;

        PlayMotion(FootStepMotion());
    }

    private void ResetPos(){

        if(_camera.localPosition == _startPos) return;
        _camera.localPosition = Vector3.Lerp(_camera.localPosition, _startPos, 1 * Time.deltaTime);
    }
}
