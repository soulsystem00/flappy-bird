using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    
    [SerializeField] float maxSpeed;
    [SerializeField] ScoreScript scoreScript;
    [SerializeField] AnimationCurve ac;
    Rigidbody2D playerRigid;
    public event Action OnGameOver;
    Vector3 startPos;
    Vector3 endPos;
    Vector3 dirPos;

    Vector3 startMousePos;
    Vector3 endMousePos;
    Camera camera;
    LineRenderer lr;

    Vector3 camOffset = new Vector3(0f, 0f, 10f);
    private void Awake()
    {
        OnGameOver += () =>
        {
            lr.enabled = false;
        };
        lr = GetComponent<LineRenderer>();
        playerRigid = GetComponent<Rigidbody2D>();
        camera = Camera.main;
    }
    void Update()
    {
        //HandleUpdate();
    }
    public void HandleUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetStartPos();
            SetStartMousePos();
        }
        else if(Input.GetMouseButton(0))
        {
            SetEndMousePos();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            EndofMouse();
            SetDirection();
            MoveObject();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Pipe2"))
        {
            //gameover
            OnGameOver.Invoke();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Pipe"))
        {
            //score up
            scoreScript.Score += 20;
        }
    }
    void SetStartPos()
    {
        startPos = Input.mousePosition;
    }
    void SetDirection()
    {
        endPos = Input.mousePosition;
        dirPos = startPos - endPos;
        dirPos = new Vector3(0f, dirPos.y, 0f);
        dirPos = Vector3.ClampMagnitude(dirPos, maxSpeed);
    }
    void MoveObject()
    {
        playerRigid.velocity = new Vector3(0f, 0f, 0f);
        playerRigid.AddForce(dirPos);
    }
    void SetStartMousePos()
    {
        if (lr == null)
            lr = gameObject.AddComponent<LineRenderer>();
        lr.enabled = true;
        lr.positionCount = 2;
        startMousePos = camera.ScreenToWorldPoint(Input.mousePosition) + camOffset;
        lr.SetPosition(0, startMousePos);
        lr.useWorldSpace = true;
        lr.widthCurve = ac;
        lr.numCapVertices = 10;
    }
    void SetEndMousePos()
    {
        endMousePos = camera.ScreenToWorldPoint(Input.mousePosition) + camOffset;
        lr.SetPosition(1, endMousePos);
    }
    void EndofMouse()
    {
        lr.enabled = false;
    }
}
