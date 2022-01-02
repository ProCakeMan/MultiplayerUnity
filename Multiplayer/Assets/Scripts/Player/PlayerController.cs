using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.InputSystem;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviourPunCallbacks, IDamageable
{
    GunController gunController;
    PhotonView view;

    [SerializeField] Item[] items;
    Item equippedItem;

    Rigidbody rb;

    [SerializeField] Image healthBarImage;
    [SerializeField] TMP_Text ammoText;

    [SerializeField] GameObject ui;

    int itemIndex;
    int previousItemIndex = -1;

    const float maxHealth = 100f;
    float currentHealth = maxHealth;

    float currentAmmo;

    PlayerManager playerMangaer;

    private void Awake()
    {
        view = GetComponent<PhotonView>();
        rb = GetComponent<Rigidbody>();

        playerMangaer = PhotonView.Find((int)view.InstantiationData[0]).GetComponent<PlayerManager>();
    }


    private void Start()
    {
        if (view.IsMine)
        {
            ammoText.text = " ";
        }
        else
        {
            Destroy(GetComponentInChildren<Camera>().gameObject);
            Destroy(rb);
            Destroy(ui);
        }
    }

    public void EquipInput(InputAction.CallbackContext ctx)
    {
        if (!view.IsMine)
            return;
        int _index;
        int.TryParse(ctx.control.name, out _index);
        _index = _index - 1;

        EquipItem(_index);
    }

    public void EquipItem(int _index)
    {
        if (_index == previousItemIndex)
            return;

        itemIndex = _index;

        items[itemIndex].itemGameObject.SetActive(true);
        equippedItem = items[itemIndex];

        currentAmmo = items[itemIndex].GetAmmo();
        ammoText.text = currentAmmo.ToString();

        if (previousItemIndex != -1)
        {
            items[previousItemIndex].itemGameObject.SetActive(false);
        }

        previousItemIndex = itemIndex;

        if (view.IsMine)
        {
            Hashtable hash = new Hashtable();
            hash.Add("itemIndex", itemIndex);
            PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
        }
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
    {
        if (!view.IsMine && targetPlayer == view.Owner)
        {
            EquipItem((int)changedProps["itemIndex"]);
        }
    }

    public void Shoot(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            if (currentAmmo != 0)
            {
                Debug.Log("Shoot");
                items[itemIndex].Use();
                ReduceAmmo();
            }
        }
    }

    public void Reload(InputAction.CallbackContext ctx)
    {
        if(ctx.performed)
        {
            currentAmmo = equippedItem.Reload();
            ammoText.text = currentAmmo.ToString();
        }
    }

    void ReduceAmmo()
    {
        currentAmmo -= 1;
        ammoText.text = currentAmmo.ToString();
        equippedItem.SetAmmo(currentAmmo);
    }

    public void TakeDamage(float damage)
    {
        view.RPC("RPC_TakeDamage", RpcTarget.All, damage);
    }

    [PunRPC]
    void RPC_TakeDamage(float damage)
    {
        if (!view.IsMine)
            return;

        Debug.Log("took damage: " + damage);

        currentHealth -= damage;

        healthBarImage.fillAmount = currentHealth / maxHealth;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        playerMangaer.Die();
    }
}
