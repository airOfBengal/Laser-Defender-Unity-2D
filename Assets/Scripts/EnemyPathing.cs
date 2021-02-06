using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField] WaveConfig waveConfig;
    List<Transform> wayPaths;
    [SerializeField] float moveSpeed = 5f;

    int wayPointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        wayPaths = waveConfig.GetWaypoints();
        transform.position = wayPaths[wayPointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if(wayPointIndex < wayPaths.Count)
        {
            var targetPosition = wayPaths[wayPointIndex].transform.position;
            var movementThisFrame = moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position,
                targetPosition, movementThisFrame);

            if(transform.position == targetPosition)
            {
                wayPointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
