using UnityEngine;

/// <summary>
/// Rotate the GameObject that this script is attached to around a different GameObject.
/// </summary>

public class RotateAroundPivotPoint : MonoBehaviour
{
    [SerializeField] private GameObject _pivotPointObject;
    [SerializeField] private float _rotationSpeed = 10;

    void Start()
    {
        _pivotPointObject = GameObject.Find("modified_cauldron");
    }

    void Update()
    {
        transform.RotateAround(_pivotPointObject.transform.position, new Vector3(0, 1, 0), _rotationSpeed * Time.deltaTime);
    }
}
