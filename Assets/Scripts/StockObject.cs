using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockObject : MonoBehaviour
{
    public StockInfo info;

    public float moveSpeed;

    public bool isPlaced;

    public Rigidbody theRB;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaced == true)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, Vector3.zero, moveSpeed * Time.deltaTime);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.identity, moveSpeed * Time.deltaTime);
        }
    }

    public void Pickup()
    {
        theRB.isKinematic = true;
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;

        isPlaced = false;
    }

    public void MakePlaced()
    {
        theRB.isKinematic = true;

        isPlaced = true;
    }

    public void Release()
    {
        theRB.isKinematic = false;
    }
}
