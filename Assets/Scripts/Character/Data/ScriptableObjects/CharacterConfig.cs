using UnityEngine;

[CreateAssetMenu(fileName = "CharacterConfig", menuName = "Configs/CharacterConfig")]
public class CharacterConfig : ScriptableObject
{
    [SerializeField] private CharacterGroundedConfig _characterGroundedConfig;

    public CharacterGroundedConfig CharacterGroundedConfig => _characterGroundedConfig;
}
