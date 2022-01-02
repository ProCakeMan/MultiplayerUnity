using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;

public class GunController : MonoBehaviour
{
    bool shooting = false;
    float fireRate = 2f;
    float fireRateSeconds;
    float nextFire;

    PhotonView view;

    [SerializeField] Transform gunPoint;


    private void Start() {
        view = GetComponent<PhotonView>();
    }

    public void OnShoot(InputAction.CallbackContext ctx){
        if(!view.IsMine)
            return;

        switch(ctx.phase)
        {
            case InputActionPhase.Performed:
                shooting = true;
                break;
            case InputActionPhase.Canceled:
                shooting = false;
                break;
        }
    }

    public void Update()
    {
        if(!view.IsMine)
            return;
        if(shooting)
        {
            if(Time.time > nextFire)
            {
                fireRateSeconds = 1f / fireRate;
                nextFire = Time.time + fireRateSeconds;
                if (Physics.Raycast(gunPoint.transform.position, gunPoint.transform.forward, out RaycastHit hit)){
                    Debug.DrawLine(gunPoint.position, hit.transform.position, Color.red, 2000, false);
                    if(hit.transform.tag == "Shootable")
                    {
                        PhotonNetwork.Destroy(hit.transform.gameObject);
                    }
                }
            }
        }
    }
}
