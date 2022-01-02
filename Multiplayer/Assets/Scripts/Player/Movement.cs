using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;

public class Movement : MonoBehaviour
{
    // Vectors
    Vector2 inputVec;
    Vector3 horizontalInput;

    // Floats
    float speed = 5f;

    // Booleans
    bool crouching;

    // References
    public Rigidbody rb;
    PhotonView view;
    public Transform bottomRay;
    public Transform topRay;
    [SerializeField] GameObject[] children;

    // Other

    private void Start()
    {
        view = GetComponent<PhotonView>();
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        if (!view.IsMine) // Returns if this isn't the player supposed to move
            return;


        inputVec = ctx.ReadValue<Vector2>();
        horizontalInput = new Vector3(inputVec.x, 0f, inputVec.y);
        horizontalInput.Normalize();
    }

    public void OnJump(InputAction.CallbackContext ctx)
    {
        if (!view.IsMine)
            return;

        rb.velocity = new Vector3(0, 10, 0);
    }

    public void OnCrouch(InputAction.CallbackContext ctx)
    {
        if (!view.IsMine)
            return;

        if (ctx.performed)
        {
            Debug.Log(crouching);
            if (crouching == false)
            {
                this.gameObject.transform.localScale = new Vector3(1f, 0.5f, 1f);
                foreach (GameObject child in children)
                {
                    child.transform.localScale = new Vector3(1f, 2f, 1f);
                }
                crouching = true;
            }
            else if (crouching == true)
            {
                this.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
                foreach (GameObject child in children)
                {
                    child.transform.localScale = new Vector3(1f, 1f, 1f);
                }
                crouching = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if (!view.IsMine) // Returns if this isn't the player supposed to move
            return;


        Vector3 moveBy = transform.right * horizontalInput.x + transform.forward * horizontalInput.z;
        rb.MovePosition(transform.position + moveBy.normalized * speed * Time.deltaTime);
    }
}
