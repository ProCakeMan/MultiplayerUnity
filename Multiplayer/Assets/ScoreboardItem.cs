using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Realtime;
using Photon.Pun;

public class ScoreboardItem : MonoBehaviour, Photon.Pun.IPunObservable
{
    public TMP_Text usernameText;
    public TMP_Text killsText;
    public TMP_Text deathsText;
    PhotonView view;

    public void Initialize(Player player)
    {
        usernameText.text = player.NickName;
    }

    public void UpdateStat(float val, string stat)
    {
        switch(stat)
        {
            case "deaths":
                deathsText.text = val.ToString();
                break;
            case "kills":
                killsText.text = val.ToString();
                break;
        }
    }

    public void UpdateStats(Dictionary<string, dynamic> stats)
    {
        foreach(var item in stats)
        {
            UpdateStat(item.Value, item.Key);
        }
    }

    public void OnPhotonSerializeView (PhotonStream stream, PhotonMessageInfo info)
    {

    }
}
