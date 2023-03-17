using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterFlySpawnScript : MonoBehaviour
{
    [SerializeField] private GameObject ButterFlyPrefab;
    [SerializeField] private float SpawnRadius;
    [SerializeField] private List<GameObject> ButterFlys = new List<GameObject>();
    [SerializeField] private LayerMask GroundLayer;

    
    RaycastHit hit;
    float SpawnX, SpawnZ, SpawnY,Distance;
    int Timer,i;

    private void FixedUpdate()
    {

        SpawnX = (transform.position.x + Random.Range(-SpawnRadius, SpawnRadius + 1));
        SpawnZ = (transform.position.z + Random.Range(-SpawnRadius, SpawnRadius + 1));
        if (ButterFlys.Count < 10)
        {
            Timer++;
            if (Timer > 50)
            {
                if(Physics.Raycast(new Vector3(SpawnX, 5000, SpawnZ), transform.TransformDirection(-Vector3.up), out hit, Mathf.Infinity, GroundLayer))
                {
                    SpawnY = hit.point.y;
                    ButterFlys.Add(Instantiate(ButterFlyPrefab, new Vector3(SpawnX, SpawnY, SpawnX), Quaternion.identity));
                }
                
                Timer = 0;
                
            }
        }
        else
        {
            for (i = 0; i < ButterFlys.Count; i++)
            {
                Distance = Vector3.Distance(transform.position, ButterFlys[i].transform.position);
                if (Distance > 250f)
                {
                    Destroy(ButterFlys[i]);
                    ButterFlys.RemoveAt(i);
                }
            }
            i = 0;
        }
        
    }




    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position,SpawnRadius);
    }

}
