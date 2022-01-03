using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class TeamManager : MonoBehaviourPunCallbacks
{
    public static TeamManager Instance;
    List<string> redTeam = new List<string>();
    List<string> blueTeam = new List<string>();

    private void Awake() {
        Instance = this;
    }

    public string JoinTeam(string player)
    {
        if(redTeam.Count < blueTeam.Count)
        {
            redTeam.Add(player);
            return "red";
        }
        else if(blueTeam.Count < redTeam.Count)
        {
            blueTeam.Add(player);
            return "blue";
        }
        else
        {
            if(Random.Range(1, 2) == 1)
            {
                redTeam.Add(player);
                return "red";
            }
            else
            {
                blueTeam.Add(player);
                return "blue";
            }
        }
    }
}
