using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using System.IO;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public static RoomManager Instance;

    private void Awake()
    {
        if (Instance) // Does Room Manager already exist?
        {
            Destroy(gameObject); // Destroys other Room Managers
            return;
        }
        DontDestroyOnLoad(gameObject);
        Instance = this; // Makes itself the main Room Manager
    }

    public override void OnEnable()
    {
        base.OnEnable();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public override void OnDisable()
    {
        base.OnDisable();
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        if(scene.buildIndex == 1) // We're in the game scene
        {
            PhotonNetwork.Instantiate(Path.Combine("PlayerManager", "PlayerManager"), Vector3.zero, Quaternion.identity);
        }
    }
}
