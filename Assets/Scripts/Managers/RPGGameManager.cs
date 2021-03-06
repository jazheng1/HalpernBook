using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGGameManager : MonoBehaviour
{
    public static RPGGameManager sharedInstance = null;
    public RPGCameraManager cameraManager;
    public SpawnPoint playerSpawnPoint;

    void Awake()
    {
        if (sharedInstance != null && sharedInstance != this)
        {
            // 3
            Destroy(gameObject);
        }
        else
        {
            // 4
            sharedInstance = this;
        }
    }
    void Start()
    {
        // 5
        SetupScene();
    }
    // 6
    public void SetupScene()
    {
        if(playerSpawnPoint != null)
        {
            GameObject player = playerSpawnPoint.SpawnObject();
            cameraManager.virtualCamera.Follow = player.transform;
        }
    }
    public void SpawnPlayer()
    {
        if (playerSpawnPoint != null){
            GameObject player = playerSpawnPoint.SpawnObject();
        }
    }
}
