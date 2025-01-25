using System.Collections;
using UnityEngine;

public class FuelPump : MonoBehaviour
{
    public int pumpID;
    public bool isOccupied;
    public Car assignedCar;

    private void OnTriggerEnter(Collider other)
    {
        if(assignedCar && other.gameObject == assignedCar.gameObject)
        {
            assignedCar.agent.isStopped = true;
            RequestFuel();
        }
    }

    public void RequestFuel()
    {
        int randomX = Random.Range(1, 10);
        float randomY = Random.Range(10f, 12f);

        float randomNumber = randomX * randomY;
        Debug.Log(assignedCar.name + " : " +  randomNumber);

        //////////////////////////////////
        ///// Delete all this nonsense
        //////////////////////////////////
        //if(randomNumber < 60f)
        //    OnApprovalToRefuel();
        //else
        //    OnRefusalToRefuel();

        ///////////////////
    }

    public void OnApprovalToRefuel()
    {
        StartCoroutine(WaitForRefueling());
    }

    private IEnumerator WaitForRefueling()
    {
        float randomWaitTime = Random.Range(3f, 7f);
        yield return new WaitForSeconds(randomWaitTime);

        OnRefusalToRefuel();
    }

    public void OnRefusalToRefuel()
    {
        assignedCar.SetNewDestination(GameManager.Instance.GasStation.endArea.position);
        isOccupied = false;
        assignedCar = null;
    }
}
