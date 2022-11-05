using UnityEngine;

public class DespawnAfterTime : MonoBehaviour
{
    [SerializeField]
    private float timeToDespawn = 3;
    private float timeSinceSpawn;
    private GameObject currentGameObject;
    private ObjectPool_Ingredients objectPool;

    // Start is called before the first frame update
    void Start()
    {
        objectPool = FindObjectOfType<ObjectPool_Ingredients>();
        currentGameObject = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceSpawn += Time.deltaTime;

        if (timeSinceSpawn >= timeToDespawn)
        {
            //objectPool.ReturnIngredientToPool(currentGameObject);
            timeSinceSpawn = 0f;
        }
    }
}
