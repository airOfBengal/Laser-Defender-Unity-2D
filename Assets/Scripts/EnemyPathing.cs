using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    WaveConfig waveConfig;
    List<Transform> wayPaths;

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

    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }

    private void Move()
    {
        if(wayPointIndex < wayPaths.Count)
        {
            var targetPosition = wayPaths[wayPointIndex].transform.position;
            var movementThisFrame = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position,
                targetPosition, movementThisFrame);
            //Debug.Log(waveConfig.GetMoveSpeed());

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
