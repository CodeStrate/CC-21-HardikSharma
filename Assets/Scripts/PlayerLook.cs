using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private float sensX;
    [SerializeField] private float sensY;
    [SerializeField] Transform cameraHolder;
    [SerializeField] Transform orientation;

    float mouseX;
    float mouseY;
    float camMultiplier = 0.01f;
    float cameraXrotation;
    float cameraYrotation;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        LookAtMouse();
        cameraHolder.transform.localRotation = Quaternion.Euler(cameraXrotation, cameraYrotation, 0);
        orientation.rotation = Quaternion.Euler(0, cameraYrotation, 0);
    }

    void LookAtMouse(){
        mouseX = Input.GetAxisRaw("Mouse X");
        mouseY = Input.GetAxisRaw("Mouse Y");

        cameraYrotation += mouseX * sensX * camMultiplier;

        cameraXrotation -= mouseY * sensY * camMultiplier;

        //clamping
        cameraXrotation = Mathf.Clamp(cameraXrotation, -90f, 90f);


    }
}
