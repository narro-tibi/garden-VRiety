using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Object Pool for multiple ingredients.
/// They will be initialized and spawned in set order. 
/// If Pool exceeds initial starting size, new prefabs will be spawned randomly from the Array.
/// </summary>

public class ObjectPool_Ingredients : MonoBehaviour
{
    #region Variables

    // initial Pool objects and size
    [SerializeField] private GameObject[] ingredientPrefabs;
    [SerializeField] private Queue<GameObject> ingredientPool = new Queue<GameObject>();
    [SerializeField] private int poolStartSize = 5;

    #endregion

    #region Functions

    private void Start()
    {
        for (int i = 0; i < poolStartSize; i++)
        {
            foreach (GameObject GO_ingredient in ingredientPrefabs)
            {
                GameObject ingredient = Instantiate(GO_ingredient);
                ingredientPool.Enqueue(ingredient);
                ingredient.SetActive(false);
            }
        }
    }

    public GameObject SpawnIngredient()
    {
        if (ingredientPool.Count > 0)
        {
            GameObject ingredient = ingredientPool.Dequeue();
            ingredient.SetActive(true);
            return ingredient;
        }
        else
        {
            // if Pool grows beyond initial pool size, add randomization to determine which object to spawn
            GameObject ingredient = Instantiate(ingredientPrefabs[Random.Range(0, ingredientPrefabs.Length)]);
            return ingredient;
        }
    }

    public void ReturnIngredientToPool(GameObject ingredient)
    {
        ingredientPool.Enqueue(ingredient);
        ingredient.SetActive(false);
    }

    #endregion
}