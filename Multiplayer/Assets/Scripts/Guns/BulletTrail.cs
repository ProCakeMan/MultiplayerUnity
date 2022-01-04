using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using System;

public class BulletTrail : MonoBehaviour
{
    [SerializeField] LineRenderer bulletTrail;
    public float trailWidth = 0.1f;
    public float trailMaxLength = 5f;

    [SerializeField] Transform gunPoint;

    Vector3[] initTrailPositions = new Vector3[2] { Vector3.zero, Vector3.zero };

    bool lineActive;

    private void Start()
    {
        bulletTrail.SetPositions(initTrailPositions);
        bulletTrail.SetWidth(trailWidth, trailWidth);
    }

    public void ShootTrailFromTargetPosition(RaycastHit hit)
    {
        Vector3 endPosition = hit.point;
        bulletTrail.SetPosition(0, gunPoint.position);
        bulletTrail.SetPosition(1, endPosition);
        lineActive = true;
        DisableLine();
    }

    async void DisableLine()
    {
        if(lineActive)
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            lineActive = false;
            bulletTrail.SetPositions(initTrailPositions);
        }
    }
}
