using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using Photon.Realtime;


public class PlayerManager : MonoBehaviourPunCallbacks
{
    PhotonView view;
    GameObject controller;

    [SerializeField] GameObject playerPrefab;

    public float deaths;
    public float kills;

    private void Awake()
    {
        view = GetComponent<PhotonView>();
    }

    private void Start()
    {
        if (view.IsMine)
        {
            CreateController();
        }
    }

    void CreateController()
    {
        Transform spawnPoint = SpawnManager.Instance.GetSpawnPoint();
        controller = PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint.position, spawnPoint.rotation, 0, new object[] {view.ViewID});
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
    {
        if (!view.IsMine && targetPlayer == view.Owner)
        {
            Scoreboard.Instance.UpdateScoreboardItem(targetPlayer, (float)changedProps[deaths]);
        }
    }

    public void Die()
    {
        deaths += 1f;
        Hashtable deathsHash = new Hashtable();
        deathsHash.Add("Deaths", deaths);
        PhotonNetwork.LocalPlayer.SetCustomProperties(deathsHash);
        PhotonNetwork.Destroy(controller);
        CreateController();
    }
}
