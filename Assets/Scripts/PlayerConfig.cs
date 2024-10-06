using UnityEngine;

[CreateAssetMenu(fileName = "PlayerDefaultConfig", menuName = "Config/Player Config")]
public class PlayerConfig : ScriptableObject
{
    [SerializeField, Range(0f, 100f)] public float Hp;
    [SerializeField, Range(0f, 10f)] public float Speed;
    [SerializeField, Range(0f, 1f)] public float Attack;
}
