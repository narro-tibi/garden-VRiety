using System.Collections;
using UnityEngine;

/// <summary>
/// Move the GameObject that this script is attached to along a set of Vector3 coordinates.
/// </summary>

public class MoveAlongCoordinates : MonoBehaviour
{
    #region Variables

    [Tooltip("Set list of coordinates for object to move along.")]
    [SerializeField] private Vector3[] _coordinates;

    // The IEnumerator for the position movement from A to B.
    private IEnumerator _coroutinePosition;

    #endregion

    void Start()
    {
        StartCoroutine(StartPath());
    }

    // Function that passes each new position in Array to the LerpPosition IEnumerator.
    public IEnumerator StartPath()
    {
        foreach (Vector3 position in _coordinates)
        {
            _coroutinePosition = LerpPosition(position, 6);

            // Wait until Coroutine is finished before moving to the next position.
            yield return StartCoroutine(_coroutinePosition);
        }
    }

    // Function that moves object to given target position.
    IEnumerator LerpPosition(Vector3 targetPosition, float duration)
    {
        float animationDuration = 0;

        // Set initial start position as the current location.
        Vector3 startPosition = transform.position;

        while (animationDuration < duration)
        {
            // Lerp with given parameters. 
            transform.position = Vector3.Lerp(startPosition, targetPosition, animationDuration / duration);
            animationDuration += Time.deltaTime;
            yield return null;
        }

        // Set new current location.
        transform.position = targetPosition;

        yield return new WaitForSeconds(1);
    }
}
