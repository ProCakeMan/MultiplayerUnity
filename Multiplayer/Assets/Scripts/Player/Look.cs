using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;

public class Look : MonoBehaviour
{
    // Vectors
    Vector2 looking;
    // Floats
    [SerializeField] float sensitivity;
    [SerializeField] float headRotationLimit = 90f;
    float headRotation = 0f;
    // References
    [SerializeField] Transform cam;
    PhotonView view;


    private void Start()
    {
        Screen.lockCursor = true;
        view = GetComponent<PhotonView>();
    }
    public void OnLook(InputAction.CallbackContext ctx)
    {
        if (view.IsMine)
        { 
            looking = ctx.ReadValue<Vector2>(); 
        }
    }


    void Update()
    {
        if(view.IsMine)
        {
            float x = looking.x;
            float y = looking.y;
            transform.Rotate(0f, x, 0f);
            headRotation += -y;
            headRotation = Mathf.Clamp(headRotation, -headRotationLimit, headRotationLimit);
            cam.localEulerAngles = new Vector3(headRotation, 0f, 0f);
        }
    }
}
