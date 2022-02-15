using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymbolSpawner : MonoBehaviour
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
    private void OnMouseDown()
    {
        SpawnShape();
        SendSpaceData(spaceIndex,isCircle,isCross);
    }

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
        Instantiate(instance.crossPrefab, position, instance.crossPrefab.transform.rotation);
        boxCollider.enabled = false;
    }
    void SpawnCircle()
    {
        Instantiate(instance.circlePrefab, position, instance.circlePrefab.transform.rotation);
        boxCollider.enabled = false;
    }
    void SendSpaceData(int x,bool y, bool z)
    {
        instance.boardSpace[spaceIndex] = new GameManager.BoardSpace(x, y, z);
    }
    
}
