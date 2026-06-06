using System.Collections.Generic;
using UnityEngine;

public class ShelfSpaceController : MonoBehaviour
{
    public StockInfo info;

    //public int amountOnShelf;

    public List<StockObject> objectsOnShelf;

    public List<Transform> bigDrinkPoints;

    public void PlaceStock(StockObject objectToPlace)
    {
        //Debug.Log(objectToPlace.info.name);
        bool preventPlacing = true;

        //if (amountOnShelf == 0)
        if(objectsOnShelf.Count == 0)
        {
            info = objectToPlace.info;
            preventPlacing = false;

        } else
        {
            if(info.name == objectToPlace.info.name)
            {
                preventPlacing = false;

                if (objectsOnShelf.Count >= bigDrinkPoints.Count)
                {
                    preventPlacing = true;
                }
            }
        }


        if (preventPlacing == false)
        {
            //objectToPlace.transform.SetParent(transform);
            objectToPlace.MakePlaced();

            objectToPlace.transform.SetParent(bigDrinkPoints[objectsOnShelf.Count]);

            //amountOnShelf += 1;
            objectsOnShelf.Add(objectToPlace);
        }
    }

    public StockObject GetStock()
    {
        StockObject objectToReturn = null;

        if (objectsOnShelf.Count > 0)
        {
            objectToReturn = objectsOnShelf[objectsOnShelf.Count - 1];

            objectsOnShelf.RemoveAt(objectsOnShelf.Count - 1);
        }

        return objectToReturn;
    }
}
