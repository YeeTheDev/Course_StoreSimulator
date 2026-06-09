using TMPro;
using System.Collections.Generic;
using UnityEngine;

public class Checkout : MonoBehaviour
{
    public static Checkout instance;
    private void Awake()
    {
        instance = this;
    }

    public TMP_Text priceText;
    public GameObject checkoutScreen;

    public Transform queuePoint;

    public List<Customer> customersInQueue = new List<Customer>();

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

    public void AddCustomerToQueue(Customer newCust)
    {
        customersInQueue.Add(newCust);

        UpdateQueue();
    }

    public void UpdateQueue()
    {
        for (int i = 0; i < customersInQueue.Count; i++)
        {
            customersInQueue[i].UpdateQueuePoint(queuePoint.position + (queuePoint.forward * i * 0.5f));
        }
    }
}
