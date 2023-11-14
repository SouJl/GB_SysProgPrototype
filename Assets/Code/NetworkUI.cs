using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class NetworkUI : NetworkBehaviour
{
    [SerializeField] private Button _serverButton;
    [SerializeField] private Button _hostButton;
    [SerializeField] private Button _clientButton;
    [SerializeField] private TextMeshProUGUI _connectedPlayersCount;

    private NetworkVariable<int> _playersCount 
        = new NetworkVariable<int>(0, NetworkVariableReadPermission.Everyone);

    private void Awake()
    {
        _serverButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartServer();
        });

        _hostButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartHost();
        });

        _clientButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartClient();
        });
    }


    private void Update()
    {
        if (IsServer) 
        {
            _playersCount.Value = NetworkManager.Singleton.ConnectedClients.Count;
        }

        _connectedPlayersCount.text = $"Players: {_playersCount.Value }";
    }
}
