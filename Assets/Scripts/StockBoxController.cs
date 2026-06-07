using System.Collections.Generic;
using UnityEngine;

public class StockBoxController : MonoBehaviour
{
    public StockInfo info;

    public List<Transform> bigDrinkPoints;
    public List<Transform> cerealPoints, tubeChipsPoints, fruitPoints, largeFruitPoints;

    public List<StockObject> stockInBox;

    public bool testFill;

    public Rigidbody theRB;
    public Collider col;

    private bool isHeld;

    public float moveSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (testFill == true)
        {
            testFill = false;
            SetupBox(info);
        }

        if (isHeld == true)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, Vector3.zero, moveSpeed * Time.deltaTime);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.identity, moveSpeed * Time.deltaTime);
        }
    }

    public void SetupBox(StockInfo stockType)
    {
        info = stockType;

        List<Transform> activePoints = new List<Transform>();

        switch (info.typeOfStock)
        {
            case StockInfo.StockType.bigDrink:

                activePoints.AddRange(bigDrinkPoints);

                break;

            case StockInfo.StockType.cereal:

                activePoints.AddRange(cerealPoints);

                break;

            case StockInfo.StockType.chipsTube:

                activePoints.AddRange(tubeChipsPoints);

                break;

            case StockInfo.StockType.fruit:

                activePoints.AddRange(fruitPoints);

                break;

            case StockInfo.StockType.fruitLarge:

                activePoints.AddRange(largeFruitPoints);

                break;
        }

        if (stockInBox.Count == 0)
        {
            for (int i = 0; i < activePoints.Count; i++)
            {
                StockObject stock = Instantiate(stockType.stockObject, activePoints[i]);
                stock.transform.localPosition = Vector3.zero;
                stock.transform.localRotation = Quaternion.identity;

                stockInBox.Add(stock);

                stock.PlaceInBox();
            }
        }
    }

    public void Pickup()
    {
        theRB.isKinematic = true;

        col.enabled = false;

        isHeld = true;
    }

    public void Release()
    {
        theRB.isKinematic = false;

        col.enabled = true;

        isHeld = false;
    }
}
