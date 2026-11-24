using UnityEngine;

[CreateAssetMenu(fileName = "Skateboard", menuName = "Skateboard/Base")]
public class Skateboard : ScriptableObject
{
    [Header("Basic Info")]
    public string Name;

    [Header("Prefabs")]
    public GameObject PreviewPrefab;
    public GameObject PlayablePrefab;

    [Header("Stats")]
    [Range(1f, 100f)] public float Speed;
    [Range(1f, 100f)] public float Handling;
}
