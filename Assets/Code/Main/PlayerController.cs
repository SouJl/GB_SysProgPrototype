using Unity.Netcode;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    [SerializeField] private Vector3 _cameraOffset;
    [SerializeField] private Quaternion _cameraAngle;
    [SerializeField] private NetworkVariable<int> _playerId;

    private Camera _mainCamera;

    public int PlayerId => _playerId.Value;

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        Initialize();
    }

    private void Initialize()
    {
        if (!IsOwner)
            return;

        _mainCamera = Camera.main;
        var playerPos = transform.position;

        _mainCamera.transform.position = playerPos + _cameraOffset;
        _mainCamera.transform.rotation = _cameraAngle;

        
    }

    [ClientRpc]
    public void SetPlayerIdClientRpc(int id)
    {
        _playerId.Value = id;
    }

}
