using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    private void Awake()
    {
        instance = this;    
    }

    public GameObject updatePricePanel;

    public TMP_Text basePriceText, currentPriceText;

    public TMP_InputField priceInputField;

    private StockInfo activeStockInfo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenUpdatePrice(StockInfo stockToUpdate)
    {
        updatePricePanel.SetActive(true);

        Cursor.lockState = CursorLockMode.None;

        basePriceText.text = "$" + stockToUpdate.price;
        currentPriceText.text = "$" + stockToUpdate.currentPrice;

        activeStockInfo = stockToUpdate;
    }

    public void CloseUpdatePrice()
    {
        updatePricePanel.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ApplyPriceUpdate()
    {
        activeStockInfo.currentPrice = float.Parse( priceInputField.text);

        currentPriceText.text = "$" + activeStockInfo.currentPrice;
    }
}
