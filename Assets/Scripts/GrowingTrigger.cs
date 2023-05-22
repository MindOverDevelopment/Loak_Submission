using RainDropGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingTrigger : MonoBehaviour
{
    public GameObject objectToGrow; // The object to be scaled
    public float growthRate = 0.05f; // The rate at which the object will grow
    public int maxTriggers = 5; // The maximum number of triggers allowed
    public int maxGrowth = 20; // The maximum growth limit
    public Material maxGrowthMaterial; // The material to apply when max growth is reached
    private int currentTriggers = 0; // The current number of active triggers
    private bool isInsideTrigger = false; // Flag to track if the object is inside the trigger
    private float growthAmount = 1f;
    public float maxGrowthAmount = 5f;

    private Renderer objectRenderer; // Reference to the object's renderer component
    private Material originalMaterial; // Original material of the object

    private GameManager gameManager; // Reference to the GameManager script

    private void Start()
    {
        objectRenderer = objectToGrow.GetComponent<Renderer>();
        originalMaterial = objectRenderer.material;

        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        
        if (!isInsideTrigger || currentTriggers >= maxTriggers || currentTriggers >= maxGrowth)
            return;

        StartGrowing();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (growthAmount >=  maxGrowthAmount)
        {
            if (other.CompareTag("Player"))
            {
                DestroySelf();
                gameManager.AddPoint();
            }
        }
        if (other.CompareTag("RainDrop"))
        {
            if (currentTriggers >= maxTriggers)
                return;

            currentTriggers++;
            growthAmount++;
            isInsideTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("RainDrop"))
        {
            currentTriggers--;
            currentTriggers = Mathf.Max(0, currentTriggers);
            isInsideTrigger = false;
        }
    }

private void StartGrowing()
{
    StartCoroutine(GrowObject());
}

private IEnumerator GrowObject()
{
    while (objectToGrow.transform.localScale.x < 1.0f && isInsideTrigger)
    {
        Vector3 newScale = objectToGrow.transform.localScale + Vector3.one * growthRate;
        objectToGrow.transform.localScale = newScale;
        yield return null;
    }

    if(growthAmount == maxGrowthAmount)
        {
            objectRenderer.material = maxGrowthMaterial;
        }
}


    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
