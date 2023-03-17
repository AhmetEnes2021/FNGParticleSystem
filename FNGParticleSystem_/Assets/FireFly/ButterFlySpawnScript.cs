using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterFlySpawnScript : MonoBehaviour
{
    GameObject ButterFlyPrefab;
    [SerializeField] private float SpawnRadius;
    [SerializeField] private List<int> Count = new List<int>();
    [SerializeField] private LayerMask GroundLayer;


    RaycastHit hit;
    float SpawnX, SpawnZ, SpawnY;
    int timer;

    private void FixedUpdate()
    {

        SpawnX = (transform.position.x + Random.Range(-SpawnRadius, SpawnRadius + 1));
        SpawnZ = (transform.position.z + Random.Range(-SpawnRadius, SpawnRadius + 1));
        if (Count.Count < 10)
        {
            timer++;
            if (timer > 50)
            {
                if(Physics.Raycast(new Vector3(SpawnX, 5000, SpawnZ), transform.TransformDirection(-Vector3.up), out hit, Mathf.Infinity, GroundLayer))
                {
                    SpawnY = hit.point.y;
                    Instantiate(ButterFlyPrefab, new Vector3(SpawnX, SpawnY, SpawnX), Quaternion.identity);
                }
                timer = 0;
                
            }
        }
    }




    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position,SpawnRadius);
    }

}
