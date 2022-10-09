using UnityEngine;

public class GravityHandler : MonoBehaviour
{
    private const float GravityForce = 9.8f;

    private CharacterController _characterController;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (!_characterController.isGrounded)
        {
            _characterController.Move(-GravityForce* Time.deltaTime * Vector3.up);
        }
    }
}
