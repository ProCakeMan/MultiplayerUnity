using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Realtime;
using Photon.Pun;

public class ScoreboardItem : MonoBehaviour
{
    public TMP_Text usernameText;
    public TMP_Text killsText;
    public TMP_Text deathsText;
    PhotonView view;

    public void Initialize(Player player)
    {
        usernameText.text = player.NickName;
    }

    public void UpdateItem(Player player, float deaths)
    {
        deathsText.text = (float.Parse(deathsText.text) + deaths).ToString();
    }
    
    [PunRPC]
    public void RPC_Update(Player player, float deaths)
    {
        deathsText.text = (int.Parse(deathsText.text) + deaths).ToString();
    }
}
