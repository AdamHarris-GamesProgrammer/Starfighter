using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Header("Player Speed Settings")]
    [SerializeField] [Tooltip("In ms^-1")] float xSpeed = 4.0f;
    [SerializeField] [Tooltip("In ms^-1")] float ySpeed = 5f;

    [Header("Player Clamping Settings")]
    [SerializeField] [Tooltip("In m")] float xClamp = 5f;
    [SerializeField] [Tooltip("In m")] float yClamp = 3f;

    [Header("Player Rotation Settings")]
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float controlPitchFactor = -5f;
    [SerializeField] float positionYawFactor = -5f;
    [SerializeField] float controlRollFactor = -5f;


    float xThrow;
    float yThrow;

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    void ProcessTranslation()
    {
        //X Movement
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffset;
        float newXPos = Mathf.Clamp(rawXPos, -xClamp, xClamp);

        //Y Movement
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * ySpeed * Time.deltaTime;

        float rawYPos = transform.localPosition.y + yOffset;
        float newYPos = Mathf.Clamp(rawYPos, -yClamp, yClamp);

        //Set Position
        transform.localPosition = new Vector3(newXPos, newYPos, transform.localPosition.z);
    }

    void ProcessRotation()
    {
        float pitch = transform.localPosition.y * positionPitchFactor + yThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch,yaw,roll);
    }
}
