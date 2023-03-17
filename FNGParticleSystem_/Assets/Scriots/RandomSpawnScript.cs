using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RandomSpawnScript : MonoBehaviour
{
    [SerializeField] private GameObject Prefab;
    [SerializeField] private float SpawnRadius;
    [SerializeField] private List<GameObject> Prefabs = new List<GameObject>();
    [SerializeField] private LayerMask GroundLayer;
    [SerializeField] private int MaxPrefabCount;

    RaycastHit hit;
    float SpawnX, SpawnZ, SpawnY, Distance;
    int Timer, i;

    private void FixedUpdate()
    {

        SpawnX = (transform.position.x + Random.Range(-SpawnRadius, SpawnRadius + 1));
        SpawnZ = (transform.position.z + Random.Range(-SpawnRadius, SpawnRadius + 1));
        if (Prefabs.Count < MaxPrefabCount)
        {
            Timer++;
            if (Timer > 50)
            {
                if (Physics.Raycast(new Vector3(SpawnX, 5000, SpawnZ), transform.TransformDirection(-Vector3.up), out hit, Mathf.Infinity, GroundLayer))
                {
                    SpawnY = hit.point.y;
                    Prefabs.Add(Instantiate(Prefab, new Vector3(SpawnX, SpawnY, SpawnX), Quaternion.identity));
                }

                Timer = 0;

            }
        }
        else
        {
            for (i = 0; i < Prefabs.Count; i++)
            {
                Distance = Vector3.Distance(transform.position, Prefabs[i].transform.position);
                if (Distance > 250f)
                {
                    Destroy(Prefabs[i]);
                    Prefabs.RemoveAt(i);
                }
            }
            i = 0;
        }

    }




    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, SpawnRadius);
    }
}
