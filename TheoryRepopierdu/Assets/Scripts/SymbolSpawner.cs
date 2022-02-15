using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SymbolSpawner : MonoBehaviour, IPointerDownHandler
{
    GameManager instance;

    Vector3 position;
    Vector3 positionOffset = new Vector3(0, 0, -90);
    BoxCollider boxCollider;

    public int spaceIndex;
    [SerializeField] bool isCross;
    [SerializeField] bool isCircle;


    private void Start()
    {
        instance = GameManager.Instance;
        position = transform.position + positionOffset;
        boxCollider = this.gameObject.GetComponent<BoxCollider>();
        spaceIndex = int.Parse(this.gameObject.name);
    }

    /*
    private void OnMouseDown()
    {
        if (!instance.crossVictory && !instance.circleVictory)
            SpawnShape();
        SendSpaceData(spaceIndex, isCircle, isCross);
        instance.GameOverCheck();
    }
    */
    private void SpawnShape()
    {
        if (GameManager.Instance.crossTurn)
        {
            SpawnCross();
            isCross = true;
            GameManager.Instance.crossTurn = false;
            GameManager.Instance.circleTurn = true;
            return;
        }
        if (GameManager.Instance.circleTurn)
        {
            SpawnCircle();
            isCircle = true;
            GameManager.Instance.crossTurn = true;
            GameManager.Instance.circleTurn = false;
            return;
        }
    }

    void SpawnCross()
    {
        var spawnedShape = Instantiate(instance.crossPrefab, position, instance.crossPrefab.transform.rotation);
        spawnedShape.transform.parent = gameObject.transform;
        boxCollider.enabled = false;
    }

    void SpawnCircle()
    {
        var spawnedShape = Instantiate(instance.circlePrefab, position, instance.circlePrefab.transform.rotation);
        spawnedShape.transform.parent = gameObject.transform;
        boxCollider.enabled = false;
    }

    void SendSpaceData(int x, bool y, bool z)
    {
        instance.boardSpace[spaceIndex] = new GameManager.BoardSpace(x, y, z);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!instance.crossVictory && !instance.circleVictory)
            SpawnShape();
        SendSpaceData(spaceIndex, isCircle, isCross);
        instance.GameOverCheck();
    }
   
}
