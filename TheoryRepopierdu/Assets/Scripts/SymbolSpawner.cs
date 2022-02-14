using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymbolSpawner : MonoBehaviour
{
    Vector3 position;
    Vector3 positionOffset = new Vector3(0, 0, -90);
    GameManager instance;


    private void Start()
    {
        instance = GameManager.Instance;
        position = transform.position + positionOffset;
    }
    private void OnMouseDown()
    {
        //add if function to check turn
        Instantiate(instance.crossPrefab, position, instance.crossPrefab.transform.rotation);
        Instantiate(instance.circlePrefab, position, instance.circlePrefab.transform.rotation);
    }
}
