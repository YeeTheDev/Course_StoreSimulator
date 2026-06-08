using UnityEngine;

public class FurnitureController : MonoBehaviour
{
    public GameObject mainObject, placingObject;
    public Collider col;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MakePlaceable()
    {
        mainObject.SetActive(false);
        placingObject.SetActive(true);
        col.enabled = false;
    }

    public void PlaceFurnitue()
    {
        mainObject.SetActive(true);
        placingObject.SetActive(false);
        col.enabled = true;
    }
}
