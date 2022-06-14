using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class diceClickRoll : MonoBehaviour
{
    Rigidbody dice;
    Vector3 direction;
    Vector3 torque;
    Vector3 offset;
    public TextMeshProUGUI accelerometrData;
    [SerializeField] int torqueForce = 10;
    [SerializeField] int directionForce = 10;
    [SerializeField] int force = 3;
    private void Start()
    {
        dice = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //if(Input.acceleration.z != 0 || Input.acceleration.x != 0)
        //if((Input.acceleration.y >= 0.7f + offset.y) || Input.acceleration.x >= 0.7f + offset.x || Input.acceleration.z >= 0.7f + offset.z)
        if((Input.acceleration.y >= 1.1f) || Input.acceleration.x >= 1.1f || Input.acceleration.z >= 1.1f)
        {
            dice.AddForce(new Vector3(Input.acceleration.x, Input.acceleration.z, Input.acceleration.y) * 200);
            //dice.AddForce(Input.acceleration * force * 100);
            dice.AddTorque(Input.acceleration * torqueForce);
        }
        if (Input.acceleration.y <= -1.1f || Input.acceleration.x <= -1.1f || Input.acceleration.z <= -1.1f)
        {
            dice.AddForce(new Vector3(Input.acceleration.x, Input.acceleration.z, Input.acceleration.y) * 200);
            //dice.AddForce(Input.acceleration * force * 100);
            dice.AddTorque(Input.acceleration * torqueForce);
        }
        accelerometrData.text = Input.acceleration.ToString();
        Debug.Log(accelerometrData);

    }
    private void OnMouseDown()
    {
        direction = new Vector3(Random.Range(-directionForce, directionForce), Random.Range(2, directionForce), Random.Range(-directionForce, directionForce));
        torque = new Vector3(Random.Range(-torqueForce, torqueForce), Random.Range(-torqueForce, torqueForce), Random.Range(-torqueForce, torqueForce));
        dice.AddForce(direction * force,ForceMode.Impulse);
        dice.AddTorque(torque,ForceMode.Impulse);
        Debug.Log("!");
    }
}
