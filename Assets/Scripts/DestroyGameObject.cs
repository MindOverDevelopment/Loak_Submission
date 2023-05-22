using System.Collections;
using UnityEngine;

public class DestroyGameObject : MonoBehaviour
{
    public float destroyDelay = 3f; // Time in seconds before destruction
    private void Start()
    {
        StartCoroutine(DestroyObjectDelayed(gameObject));
    }

    private IEnumerator DestroyObjectDelayed(GameObject obj)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(destroyDelay);

        // Destroy the object after the delay
        Destroy(obj);
    }
}
