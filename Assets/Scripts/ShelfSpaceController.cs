using UnityEngine;

public class ShelfSpaceController : MonoBehaviour
{
    public StockInfo info;

    public int amountOnShelf;

    public void PlaceStock(StockObject objectToPlace)
    {
        //Debug.Log(objectToPlace.info.name);
        bool preventPlacing = true;

        if (amountOnShelf == 0)
        {
            info = objectToPlace.info;
            preventPlacing = false;

        } else
        {
            if(info.name == objectToPlace.info.name)
            {
                preventPlacing = false;
            }
        }


        if (preventPlacing == false)
        {
            objectToPlace.transform.SetParent(transform);
            objectToPlace.MakePlaced();

            amountOnShelf += 1;
        }
    }
}
