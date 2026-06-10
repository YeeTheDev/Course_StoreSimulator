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
        //ShowPrice(45.32f);
        HidePrice();
    }

    // Update is called once per frame
    void Update()
    {
        if (customersInQueue.Count > 0 && checkoutScreen.activeSelf == false)
        {
            if (Vector3.Distance(customersInQueue[0].transform.position, queuePoint.position) < 0.1f)
            {
                ShowPrice(customersInQueue[0].GetTotalSpend());
            }
        }
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
        if (checkoutScreen.activeSelf == true && customersInQueue.Count > 0)
        {

            HidePrice();

            StoreController.instance.AddMoney(customersInQueue[0].GetTotalSpend());

            customersInQueue[0].StartLeaving();

            customersInQueue.RemoveAt(0);

            UpdateQueue();

            if (AudioManager.instance != null)
            {
                AudioManager.instance.PlaySFX(3);
            }
        }
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
