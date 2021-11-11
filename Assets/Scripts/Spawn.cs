using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject spawnPoint;
    [SerializeField] GameObject pipePrefeb;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Pipe"))
        {
            //SpawnPipe();
            SpawnPipe2();
        }
    }
    void SpawnPipe()
    {
        var pipe = Instantiate(pipePrefeb, spawnPoint.transform.position, Quaternion.identity);
        var pipePos = Random.Range(-3, 3);
        pipe.transform.position = new Vector3(pipe.transform.position.x, pipePos, pipe.transform.position.z);
    }
    void SpawnPipe2()
    {
        var pipePos = Random.Range(-3, 3);
        var SpawnPos = new Vector3(spawnPoint.transform.position.x, pipePos, spawnPoint.transform.position.z);
        ObjectPool.instance.GetObj(SpawnPos);
    }
}
