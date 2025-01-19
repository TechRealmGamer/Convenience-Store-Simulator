using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(2)]
public class WaitingArea : MonoBehaviour
{
    public GasStation gasStation;
    public List<Car> carsInWaitingArea;

    private void Start()
    {
        StartCoroutine(AllocatePumpToFirstCar());
    }

    IEnumerator AllocatePumpToFirstCar()
    {
        if(carsInWaitingArea.Count > 0)
        {
            FuelPump unoccupiedPump = gasStation.FindUnoccupiedPump();
            if (unoccupiedPump != null)
            {
                unoccupiedPump.assignedCar = carsInWaitingArea[0];
                unoccupiedPump.isOccupied = true;
                carsInWaitingArea[0].SetNewDestination(unoccupiedPump.transform.position);
                carsInWaitingArea.RemoveAt(0);
            }
        }

        yield return new WaitForSeconds(3f);

        StartCoroutine(AllocatePumpToFirstCar());
    }
}
