using TMPro;
using UnityEngine;

public class Checkout : MonoBehaviour
{
    public TMP_Text priceText;
    public GameObject checkoutScreen;

    // Start is called before the first frame update
    void Start()
    {
        ShowPrice(45.32f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowPrice(float priceTotal)
    {
        checkoutScreen.SetActive(true);

        priceText.text = "$" + priceTotal.ToString("F2");
    }

    public void HidePrice()
    {
        checkoutScreen.SetActive(false);
    }

    public void CheckoutCustomer()
    {
        HidePrice();
    }
}
