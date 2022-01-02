using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class UserNameDisplay : MonoBehaviour
{
    [SerializeField] PhotonView view;
    [SerializeField] TMP_Text text;

    private void Start()
    {
        if(view.IsMine)
        {
            gameObject.SetActive(false);
        }
        text.text = view.Owner.NickName;
    }
}
