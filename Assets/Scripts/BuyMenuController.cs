using UnityEngine;

public class BuyMenuController : MonoBehaviour
{
    public GameObject stockPanel, furniturePanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenStockPanel()
    {
        stockPanel.SetActive(true);
        furniturePanel.SetActive(false);
    }

    public void OpenFurniture()
    {
        stockPanel.SetActive(false);
        furniturePanel.SetActive(true);
    }
}
