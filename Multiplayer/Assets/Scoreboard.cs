using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class Scoreboard : MonoBehaviourPunCallbacks
{
    public static Scoreboard Instance;
    [SerializeField] Transform container;
    [SerializeField] GameObject scoreboardItemPrefab;

    Dictionary<Player, ScoreboardItem> scoreboardItems = new Dictionary<Player, ScoreboardItem>();

    private void Awake() {
        Instance = this;
    }
    private void Start() {
       foreach(Player player in PhotonNetwork.PlayerList)
       {
           AddScoreboardItem(player);
       } 
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        AddScoreboardItem(newPlayer);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        RemoveScoreboardItem(otherPlayer);
    }

    void AddScoreboardItem(Player player)
    {
        ScoreboardItem item = Instantiate(scoreboardItemPrefab, container).GetComponent<ScoreboardItem>();
        item.Initialize(player);
        scoreboardItems[player] = item;
    }

    public void UpdateScoreboardItem(Player player, float deaths)
    {
        //scoreboardItems[player].UpdateItem(player, deaths);
        foreach(Player playerRef in PhotonNetwork.PlayerList)
        {
            //scoreboardItems
        }
    }

    void RemoveScoreboardItem(Player player)
    {
        Destroy(scoreboardItems[player].gameObject);
        scoreboardItems.Remove(player);
    }

    public ScoreboardItem GetItem(Player player)
    {
        foreach(var item in scoreboardItems)
        {
            Debug.Log(item.Key + " " + item.Value);
        }
        return scoreboardItems[player];
    }

    
}
