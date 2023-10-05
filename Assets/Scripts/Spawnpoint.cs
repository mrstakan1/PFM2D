using UnityEngine;

public class Spawnpoint : MonoBehaviour
{
    [SerializeField] private Enemy _prefab;

    public Enemy GetPrefab()
    {
        return _prefab;
    }
}