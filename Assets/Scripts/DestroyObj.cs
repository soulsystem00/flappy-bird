using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObj : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pipe"))
        {
            //Destroy(collision.gameObject);
            ObjectPool.instance.ReturnObj(collision.gameObject);
        }
    }
}
