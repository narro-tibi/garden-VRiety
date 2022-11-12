using UnityEngine;

/// <summary>
/// Logic for spawning Ingredient GameObjects from the Object Pool.
/// They will float along a path until despawning.
/// </summary>

public class Spawner_Ingredients : MonoBehaviour
{
    [SerializeField] private float timeToSpawn = 5f;
    private float timeSinceSpawn;
    private ObjectPool_Ingredients objectPool;

    [Tooltip("Starting Spawn Position for ingredients")]
    [SerializeField] private Vector3 _ingredientSpawnPosition = new Vector3(-1.2f, 2f, 4.5f);

    void Start()
    {
        objectPool = FindObjectOfType<ObjectPool_Ingredients>();
    }

    void FixedUpdate()
    {
        timeSinceSpawn += Time.deltaTime;
        if (timeSinceSpawn >= timeToSpawn)
        {
            GameObject newIngredient = objectPool.SpawnIngredient();
            Debug.Log("initial posiiton of new Ingredient" + gameObject.transform.position);
            newIngredient.transform.position = _ingredientSpawnPosition;
            timeSinceSpawn = 0f;
        }
    }
}