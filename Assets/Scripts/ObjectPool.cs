using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject pipe;
    public static ObjectPool instance;
    Queue<GameObject> objQueue = new Queue<GameObject>();
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            var instantpipe = Instantiate(pipe);
            instantpipe.SetActive(false);
            instantpipe.transform.SetParent(transform);
            objQueue.Enqueue(instantpipe);
        }
    }
    public void GetObj(Vector3 pos)
    {
        if(objQueue.Count > 0)
        {
            var obj = objQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.transform.position = pos;
            obj.SetActive(true);
        }
        else
        {
            var instantpipe = Instantiate(pipe);
            instantpipe.transform.SetParent(null);
            instantpipe.transform.position = pos;
            instantpipe.SetActive(false);
        }
    }
    public void ReturnObj(GameObject obj)
    {
        obj.transform.SetParent(transform);
        obj.SetActive(false);
        objQueue.Enqueue(obj);
    }
}
