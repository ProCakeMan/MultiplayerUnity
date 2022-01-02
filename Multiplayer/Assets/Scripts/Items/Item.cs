using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public ItemInfo itemInfo;
    public GameObject itemGameObject;

    public abstract void Use();

    public abstract float GetAmmo();

    public abstract void SetAmmo(float ammo);
    public abstract float Reload();
}
