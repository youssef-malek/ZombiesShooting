using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Spawn;
    public int amount = 1;
    public float delaySpawn = 1;

    private int getAmount;
    private float timer;
    private int spawned;
    void Start()
    {
        ResetRound();
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;
        if (delaySpawn < timer)
        {
            if (spawned < getAmount)
            {
                timer = 0;
                spawned++;
                GameObject instance = Instantiate(Spawn, transform);
                instance.transform.parent = null;
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (Spawn != null)
        {
            Gizmos.DrawWireMesh(Spawn.GetComponent<MeshFilter>().sharedMesh, transform.position, Spawn.transform.rotation, Vector3.one);
        }
    }
    private void ResetRound()
    {
        getAmount = amount;
    }
}
