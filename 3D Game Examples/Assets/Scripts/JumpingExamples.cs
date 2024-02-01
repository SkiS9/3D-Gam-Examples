using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingExamples : MonoBehaviour
{
    public float Speed = 100f;
    public float JumpForce = 10f;
    public float GravityModifier = 1f;
    public bool IsOnGround = true;
    

    private float _horizontalinput;
    private float _forwardinput;
    private Rigidbody _playerRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody>();
        Physics.gravity *= GravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        _horizontalinput = Input.GetAxis("Horizontal");
        _forwardinput = Input.GetAxis("Vertical");

         if(Input.GetKeyDown(KeyCode.Space) && IsOnGround)
        {
            _playerRigidbody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            IsOnGround = false;
        }
    }
    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(_horizontalinput, 0.0f, _forwardinput);

        _playerRigidbody.AddForce(movement * Speed);
    }

       private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsOnGround = true;
        }
    }
    
}