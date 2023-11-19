using Unity.Netcode;
using UnityEngine;

namespace Main
{
    public class SolarSystemNetworkManager : NetworkManager
    {
        [SerializeField] private string _playerName;

        private void Start()
        {
            Singleton.ConnectionApprovalCallback += ServerAddPlayer;
        }

        private void ServerAddPlayer(ConnectionApprovalRequest request, ConnectionApprovalResponse response)
        {
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
            var startPosition = Vector3.zero;
            return startPosition;
        }
    }
}
