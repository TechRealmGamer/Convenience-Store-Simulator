using UnityEngine;
using UnityEngine.AI;

[DefaultExecutionOrder(2)]
public class Car : MonoBehaviour
{
    public bool isPaying;

    [Header("Paying for Gas")]

    [Header("Not Paying for Gas")]
    public GameObject licensePlate;

    public NavMeshAgent agent;

    public WaitingArea waitingArea;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void OnEnable()
    {
        waitingArea = GameManager.Instance.GasStation.waitingArea;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == waitingArea.gameObject)
        {
            waitingArea.carsInWaitingArea.Add(this);
            agent.isStopped = true;
        }
        else if(other.name == "End Area")
        {
            Destroy(gameObject);
        }
    }

    public void SetNewDestination(Vector3 newDestination)
    {
        agent.destination = newDestination;
        agent.isStopped = false;
    }
}
