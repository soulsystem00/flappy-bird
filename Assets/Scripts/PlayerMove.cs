using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float maxSpeed;
    [SerializeField] ScoreScript scoreScript;
    Rigidbody2D playerRigid;
    public event Action OnGameOver;
    Vector3 startPos;
    Vector3 endPos;
    Vector3 dirPos;
    private void Awake()
    {
        playerRigid = GetComponent<Rigidbody2D>();
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
        }
        else if (Input.GetMouseButtonUp(0))
        {
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
}
