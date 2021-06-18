using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] GameObject angus;
    private GameObject playerInstance;
    [SerializeField] Transform startPosition;
    [SerializeField] CinemachineFreeLook cameraRig;
    private Transform currentCheckpoint;
    private InputManager controls;

    void Awake()
    {
        controls = new InputManager();
        controls.Player.DebugRespawn.performed += _ => RespawnAngus();
    }
    void Start()
    {
        currentCheckpoint = startPosition;
        SpawnAngus();
    }

    private void SpawnAngus()
    {
        playerInstance = Instantiate(angus,startPosition.position,Quaternion.identity);
        cameraRig.Follow = playerInstance.transform;
        cameraRig.LookAt = playerInstance.transform;
    }

    public void RespawnAngus()
    {
        cameraRig.Follow = currentCheckpoint;
        cameraRig.LookAt = currentCheckpoint;
        Destroy(playerInstance);
        playerInstance = Instantiate(angus,currentCheckpoint.position,Quaternion.identity);
        cameraRig.Follow = playerInstance.transform;
        cameraRig.LookAt = playerInstance.transform;
    }

    public void SetCheckpoint(Transform t)
    {
        currentCheckpoint = t;
    }

    void OnEnable() {controls.Enable();}
    void OnDisable(){controls.Disable();}
    
}
