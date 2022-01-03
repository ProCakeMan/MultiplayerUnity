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

    ScoreboardItem selfScoreboardItem;
    Player thisPlayer;

    [SerializeField] GameObject playerPrefab;

    public Dictionary<string, dynamic> stats = new Dictionary<string, dynamic>();

    string team;

    public Material red;
    public Material blue;

    private void Awake()
    {
        view = GetComponent<PhotonView>();
        team = TeamManager.Instance.JoinTeam(view.Owner.NickName);
        switch(team)
        {
            case "red":
                controller.gameObject.GetComponent<MeshRenderer>().material = red;
                break;
            case "blue":
                controller.gameObject.GetComponent<MeshRenderer>().material = blue;
                break;
        }
        
    }

    private void Start()
    {
        if(!view.IsMine)
            return;

        CreateController();
        stats.Add("deaths", 0);
        stats.Add("kills", 0);
        foreach(Player player in PhotonNetwork.PlayerList)
        { 
            if (player.NickName == view.Owner.NickName)
            {
                selfScoreboardItem = Scoreboard.Instance.GetItem(player);
                break;
            }
        }

    }

    private void Update()
    {
        if(!view.IsMine)
            return;

        selfScoreboardItem.UpdateStats(stats);
        //view.RPC("RPC_UPDATESTATS", RpcTarget.All, stats);
    }

    void CreateController()
    {
        Transform spawnPoint = SpawnManager.Instance.GetSpawnPoint();
        controller = PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint.position, spawnPoint.rotation, 0, new object[] { view.ViewID });
    }

    public void Die()
    {
        stats["deaths"] += 1;
        PhotonNetwork.Destroy(controller);
        CreateController();
    }

    [PunRPC]
    public void RPC_UPDATESTATS(Dictionary<string, dynamic> stats)
    {
        selfScoreboardItem.UpdateStats(stats);
    }
}
