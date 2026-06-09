using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public List<NavPoint> points = new List<NavPoint>();

    public float moveSpeed;
    private float currentWaitTime;

    public Animator anim;

    public enum CustomerState { entering, browsing, queuing, atCheckout, leaving }
    public CustomerState currentState;

    public int maxBrowsePoints = 5;
    private int browsePointsRemain;

    public float browseTime;

    public FurnitureController currentShelfCase;

    public GameObject shoppingBag;
    private bool hasGrabbed;
    public float waitAfterGrabbig = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        points.Clear();
        points.AddRange(CustomerManager.instance.GetEntryPoints());

        if (points.Count > 0)
        {
            transform.position = points[0].point.position;

            currentWaitTime = points[0].waitTime;
        }

        //points.AddRange(CustomerManager.instance.GetExitPoints());
    }

    // Update is called once per frame
    void Update()
    {
        /* if (points.Count > 0)
        {
            MoveToPoint();
        } */

        switch (currentState)
        {
            case CustomerState.entering:

                if (points.Count > 0)
                {
                    MoveToPoint();
                } else
                {
                    //StartLeaving();

                    currentState = CustomerState.browsing;

                    browsePointsRemain = Random.Range(1, maxBrowsePoints + 1);
                    browsePointsRemain = Mathf.Clamp(browsePointsRemain, 1, StoreController.instance.shelvingCases.Count);

                    GetBrowsePoint();
                }

                    break;

            case CustomerState.browsing:

                MoveToPoint();

                if (points.Count == 0)
                {
                    if (hasGrabbed == false)
                    {
                        GrabStock();
                    }
                    else
                    {
                        hasGrabbed = false;

                        browsePointsRemain--;
                        if (browsePointsRemain > 0)
                        {
                            GetBrowsePoint();
                        }
                        else
                        {
                            StartLeaving();
                        }
                    }
                }

                break;

            case CustomerState.queuing:

                break;

            case CustomerState.atCheckout:

                break;

            case CustomerState.leaving:

                if (points.Count > 0)
                {
                    MoveToPoint();
                }
                else
                {
                    Destroy(gameObject);
                }

                break;
        }
    }

    public void MoveToPoint()
    {
        bool isMoving = true;

        Vector3 targetPosition = new Vector3(points[0].point.position.x, transform.position.y, points[0].point.position.z);

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        transform.LookAt(targetPosition);

        if (Vector3.Distance(transform.position, targetPosition) < 0.25f)
        {
            isMoving = false;

                currentWaitTime -= Time.deltaTime;

                if (currentWaitTime <= 0)
                {
                    StartNextPoint();
                }
            
        }

        anim.SetBool("IsMoving", isMoving);
    }

    public void StartNextPoint()
    {
        if (points.Count > 0)
        {
            points.RemoveAt(0);

            if (points.Count > 0)
            {
                currentWaitTime = points[0].waitTime;
            }
        }
    }

    public void StartLeaving()
    {
        currentState = CustomerState.leaving;

        points.Clear();
        points.AddRange(CustomerManager.instance.GetExitPoints());
    }

    void GetBrowsePoint()
    {
        points.Clear();

        int selectedShelf = Random.Range(0, StoreController.instance.shelvingCases.Count);

        points.Add(new NavPoint());
        points[0].point = StoreController.instance.shelvingCases[selectedShelf].standPoint;

        points[0].waitTime = browseTime * Random.Range(0.75f, 1.25f);

        currentWaitTime = points[0].waitTime;

        currentShelfCase = StoreController.instance.shelvingCases[selectedShelf];
    }

    public void GrabStock()
    {
        shoppingBag.SetActive(true);
        hasGrabbed = true;

        points.Clear();
        points.Add(new NavPoint());
        points[0].point = currentShelfCase.standPoint;
        points[0].waitTime = waitAfterGrabbig * Random.Range(0.75f, 1.25f);
        currentWaitTime = points[0].waitTime;
    }
}

[System.Serializable]
public class NavPoint
{
    public Transform point;
    public float waitTime;
}