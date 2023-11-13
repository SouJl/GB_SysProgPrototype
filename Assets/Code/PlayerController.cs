using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 2;
    [SerializeField] private float _rotationSpeed = 100;

    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        var verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 moveDirect = new Vector3(horizontalInput, 0, verticalInput);
        moveDirect.Normalize();

        _rb.velocity = moveDirect * _movementSpeed;

        if(moveDirect != Vector3.zero) 
        {
            var toRotation = Quaternion.LookRotation(moveDirect, Vector3.up);
            _rb.rotation = Quaternion.RotateTowards(_rb.rotation, toRotation, _rotationSpeed * Time.deltaTime);
        }
    }

}
