using Unity.Netcode;
using UnityEngine;

public class GameNetworkManager : NetworkManager
{
    [SerializeField]
    private float spawnRadius = 2f;
    [SerializeField]
    private Vector3 defaultSpawnPos = new Vector3(5, 1, 5);

   
    private void Start()
    {
        Singleton.ConnectionApprovalCallback += ApprovalCheck;
    }

    private void ApprovalCheck(ConnectionApprovalRequest request, ConnectionApprovalResponse response)
    {
        if (!IsServer)
            return;

        var clientId = request.ClientNetworkId;
        var connectionData = request.Payload;

        response.Approved = true;
        response.CreatePlayerObject = true;

        response.PlayerPrefabHash = null;

        var startPos = GetStartPosition();

        response.Position = startPos;

        response.Rotation = Quaternion.identity;

        response.Pending = false;

        Debug.Log($"Client[{clientId}] was connected! StrarPosition - {startPos}");

    }

    private Vector3 GetStartPosition()
    {
        var spawnRng = Random.insideUnitCircle * spawnRadius;
        var startPosition = new Vector3(defaultSpawnPos.x + spawnRng.x, defaultSpawnPos.y, defaultSpawnPos.z + spawnRng.y);
        return startPosition;
    }
}
