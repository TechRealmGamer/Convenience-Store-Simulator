using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(1)]
public class GasStation : MonoBehaviour
{
    public WaitingArea waitingArea;
    public Transform endArea;
    public FuelPump[] fuelPumps;

    void Awake()
    {
        GameManager.Instance.GasStation = this;
        waitingArea.gasStation = this;
    }

    public FuelPump FindUnoccupiedPump()
    {
        int i = 0;
        while (i < fuelPumps.Length)
        {
            if (!fuelPumps[i].isOccupied)
            {
                return fuelPumps[i];
            }
            i++;
        }
        return null;
    }
}
