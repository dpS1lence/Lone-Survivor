using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerSettings settings;

    private Vector3 _moveDirection;
    private CharacterController _controller;

    private void Awake() {
        _controller = GetComponent<CharacterController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_controller.isGrounded){
            Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            if(input.x != 0 && input.y != 0)
            {
                input *= 0.777f;
            }

            _moveDirection.x = input.x * settings.speed;
            _moveDirection.z = input.y * settings.speed;
            _moveDirection.y = -settings.antiBump;

            _moveDirection = transform.TransformDirection(_moveDirection);

            if(Input.GetKey(KeyCode.Space)){
                Jump();
            }
        }
        else{
            _moveDirection.y -= settings.gravity * Time.deltaTime;
        }
    }

    private void FixedUpdate() {
        _controller.Move(_moveDirection * Time.deltaTime);
    }

    private void Jump(){
        _moveDirection.y += settings.jumpForce;
    }
}
