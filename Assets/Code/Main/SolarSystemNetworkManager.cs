using Unity.Netcode;
using UnityEngine;

namespace Main
{
    public class SolarSystemNetworkManager : NetworkBehaviour
    {
        [SerializeField] private string _playerName;

        private void Start()
        {
            NetworkManager.ConnectionApprovalCallback += ServerAddPlayer;
        }

        private void ServerAddPlayer(NetworkManager.ConnectionApprovalRequest request, NetworkManager.ConnectionApprovalResponse response)
        {
            
        }
    }
}
