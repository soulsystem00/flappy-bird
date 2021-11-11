using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMove : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D rigidbody;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        rigidbody.velocity = new Vector3(-speed, 0f, 0f);
    }
    private void OnEnable()
    {
        rigidbody.velocity = new Vector3(-speed, 0f, 0f);
    }
}
