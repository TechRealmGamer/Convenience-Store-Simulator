using System.Collections;
using UnityEngine;

public class VehiclesManager : MonoBehaviour
{
    public Car[] carPrefabs;

    public Transform waitingArea;
    public Transform carSpawnPointEast;
    public Transform carSpawnPointWest;

    public int carPriority = 0;

    private void Start()
    {
        StartCoroutine(SpawnCarsWest());
        StartCoroutine(SpawnCarsEast());
    }

    private IEnumerator SpawnCarsWest()
    {
        yield return new WaitForSeconds(Random.Range(4f, 8f));
        Car car = Instantiate(carPrefabs[Random.Range(0, carPrefabs.Length)], carSpawnPointWest.position, carSpawnPointWest.rotation, transform);
        car.SetNewDestination(carSpawnPointEast.position);
        StartCoroutine(SpawnCarsWest());
    }

    private IEnumerator SpawnCarsEast()
    {
        yield return new WaitForSeconds(Random.Range(4f, 8f));
        Car car = Instantiate(carPrefabs[Random.Range(0, carPrefabs.Length)], carSpawnPointEast.position, carSpawnPointEast.rotation, transform);

        // Randomize the chances of the Car going to gas station or going straight
        int randomX = Random.Range(0, 10);        
        if(randomX < 4)
            car.SetNewDestination(carSpawnPointWest.position);
        else
            car.SetNewDestination(waitingArea.position);

        car.agent.avoidancePriority = carPriority;
        carPriority++;
        if(carPriority > 50)
            carPriority = 0;
        Debug.Log(carPriority);

        StartCoroutine(SpawnCarsEast());
    }
}
