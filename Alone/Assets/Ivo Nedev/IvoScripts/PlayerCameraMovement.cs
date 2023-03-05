using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraMovement : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private PlayerSettings settings;

    private float _cameraVerticalRotation = 0;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxis("Mouse X") * settings.camSensitivity, Input.GetAxis("Mouse Y") * settings.camSensitivity);

        _cameraVerticalRotation = Mathf.Clamp(_cameraVerticalRotation - input.y, -90f, 90f);
        transform.localEulerAngles = Vector3.right * _cameraVerticalRotation;

        player.Rotate(Vector3.up * input.x * settings.camSensitivity);
    }
}
