using Unity.Netcode;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    [SerializeField] 
    private float _movementSpeed = 2;
    [SerializeField] 
    private float _rotationSpeed = 100;
    [SerializeField]
    private float spawnRadius = 2f;
    [SerializeField]
    private Vector3 defaultSpawnPos = new Vector3(5, 1, 5);

    [SerializeField]
    private NetworkVariable<Vector3> networkInput = new NetworkVariable<Vector3>();

    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        if (IsClient && IsOwner)
        {
            PlayerInput();
        }
    }

    private void FixedUpdate()
    {
        MoveAndRotate();
    }

    public override void OnNetworkSpawn()
    {
        var spawnRng = Random.insideUnitCircle * spawnRadius;
        var startPosition = new Vector3(defaultSpawnPos.x + spawnRng.x, defaultSpawnPos.y, defaultSpawnPos.z + spawnRng.y);
        transform.position = startPosition;
    }

    private void PlayerInput()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        var verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 moveDirect = new Vector3(horizontalInput, 0, verticalInput);
        moveDirect.Normalize();

        UpdateClientInputServerRpc(moveDirect);
    }

    private void MoveAndRotate()
    {
        if (networkInput.Value != Vector3.zero)
        {
            _rb.velocity = networkInput.Value * _movementSpeed;

            var toRotation = Quaternion.LookRotation(networkInput.Value, Vector3.up);
            _rb.rotation = Quaternion.RotateTowards(_rb.rotation, toRotation, _rotationSpeed * Time.deltaTime);
        }
    }


    [ServerRpc]
    public void UpdateClientInputServerRpc(Vector3 newPosition)
    {
        networkInput.Value = newPosition;
    }
}
