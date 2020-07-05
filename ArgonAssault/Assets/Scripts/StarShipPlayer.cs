using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class StarShipPlayer : MonoBehaviour
{

    [Tooltip("In ms^-1")][SerializeField] float xSpeed = 30f;
    [Tooltip("In m")][SerializeField] float xRange = 5f;

    [Tooltip("In ms^-1")][SerializeField] float ySpeed = 12f;
    [Tooltip("In m")][SerializeField] float yRange = 2f;

    [SerializeField] float positionYawFactor = -5f;
    [SerializeField] float controlYawFactor = -30f;

    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float controlPitchFactor = -30f;

    bool isControlsEnabled = true;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if( isControlsEnabled ){
            float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
            float yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        
            HandleMovement(xThrow, yThrow);
            HandleAim(xThrow, yThrow);
        }
    }

    private void HandleMovement(float xThrow, float yThrow){
        float xOffset =  xThrow * xSpeed * Time.deltaTime;
        float rawX = transform.localPosition.x + xOffset;
        float clampedX = Mathf.Clamp(rawX, -xRange, xRange);
        
        float yOffset =  yThrow * ySpeed * Time.deltaTime;
        float rawY = transform.localPosition.y + yOffset;
        float clampedY = Mathf.Clamp(rawY, -yRange, yRange);
        transform.localPosition = new Vector3(clampedX, clampedY, transform.localPosition.z);
    }

    private void HandleAim(float xThrow, float yThrow){
        float pitch = positionYawFactor * transform.localPosition.y + controlYawFactor * yThrow;
        float yaw = positionPitchFactor * transform.localPosition.x + controlPitchFactor * xThrow;
        float roll = 0f;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);

    }

    void OnPlayerDeath(){
        isControlsEnabled = false;
    }
}
