using UnityEngine;

[RequireComponent(typeof(CharacterController), typeof(Input))]
public class Character : MonoBehaviour
{
    [SerializeField] private CharacterConfig _config;

    private CharacterMovementStateMachine _movementStateMachine;
    private CharacterController _controller;
    private Input _input;

    [SerializeField] private CharacterView _view;

    public CharacterController Controller => _controller;
    public Input Input => _input;
    public CharacterView View => _view;
    public CharacterConfig Config => _config;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _input = GetComponent<Input>();
        _view.Initialize();
        _movementStateMachine = new CharacterMovementStateMachine(this);
    }

    private void Update()
    {
        _movementStateMachine.HandleInput();

        _movementStateMachine.Update();
    }
}
