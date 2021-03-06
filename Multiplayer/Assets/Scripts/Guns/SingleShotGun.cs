using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.VFX;
using System;
using System.Threading.Tasks;

public class SingleShotGun : Gun
{
    [SerializeField] Camera cam;

    [SerializeField] BulletTrail bulletTrail;

    PhotonView view;

    [SerializeField] VisualEffect flash;
    [SerializeField] GameObject bulletTrailPrefab;
    [SerializeField] Transform gunPoint;


    private void Awake()
    {
        view = GetComponent<PhotonView>();
        Reload();
    }

    public override void Use()
    {
        Shoot();
    }

    void Shoot()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
        ray.origin = cam.transform.position;
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            hit.collider.gameObject.GetComponent<IDamageable>()?.TakeDamage(((GunInfo)itemInfo).damage);
            if(hit.collider.gameObject.GetComponent<PlayerController>()?.currentHealth <= ((GunInfo)itemInfo).damage)
            {
                transform.parent.parent.gameObject.GetComponent<PlayerManager>().stats["kills"] += 1;
            }
            view.RPC("RPC_Shoot", RpcTarget.All, hit.point, hit.normal);
            // set start and end point of particle system to gun and hit
        }
    }

    public override float GetAmmo()
    {
        return ((GunInfo)itemInfo).ammo;
    }

    public override void SetAmmo(float ammo)
    {
        ((GunInfo)itemInfo).ammo = ammo;
    }

    public override float Reload()
    {
        ((GunInfo)itemInfo).ammo = ((GunInfo)itemInfo).maxAmmo;
        return GetAmmo();
    }

    [PunRPC]
    void RPC_Shoot(Vector3 hitPosition, Vector3 hitNormal)
    {
        Collider[] colliders = Physics.OverlapSphere(hitPosition, 0.3f);
        if(colliders.Length != 0)
        {
            GameObject bulletImpactObj = Instantiate(bulletImpactPrefab, hitPosition + hitNormal * 0.001f, Quaternion.LookRotation(hitNormal, Vector3.up) * bulletImpactPrefab.transform.rotation);
            Destroy(bulletImpactObj, 10f);
            bulletImpactObj.transform.SetParent(colliders[0].transform);
        }
        flash.SendEvent("OnPlay"); //muzzleflash
        GameObject bulletTrailObj = Instantiate(bulletTrailPrefab, Vector3.zero, Quaternion.identity);
        LineRenderer bulletTrailLine = bulletTrailObj.GetComponent<LineRenderer>();
        bulletTrailLine.SetWidth(0.05f, 0.05f);
        ShootTrailFromTargetPosition(hitPosition, bulletTrailLine);
    }

    async void ShootTrailFromTargetPosition(Vector3 hitPos, LineRenderer bulletTrailLine)
    {
        Vector3 endPosition = hitPos;
        bulletTrailLine.SetPosition(0, gunPoint.position);
        bulletTrailLine.SetPosition(1, endPosition);
        await Task.Delay(TimeSpan.FromSeconds(0.5));
        Destroy(bulletTrailLine.gameObject);
    }
}
