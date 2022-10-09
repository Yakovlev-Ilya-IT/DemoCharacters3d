using UnityEngine;
using UnityEngine.InputSystem;

public class Input : MonoBehaviour
{
    public PlayerInput PlayerInput { get; private set; }
    public PlayerInput.PlayerActions PlayerActions { get; private set; }

    private void Awake()
    {
        PlayerInput = new PlayerInput();
        PlayerActions = PlayerInput.Player;
    }

    private void OnEnable()
    {
        PlayerInput?.Enable();
    }

    private void OnDisable()
    {
        PlayerInput?.Disable();
    }
}
