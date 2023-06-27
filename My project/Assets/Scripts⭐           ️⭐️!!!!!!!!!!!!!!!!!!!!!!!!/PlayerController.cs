using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float leftOrRightSpeed = 1;
    public float jumpForce = 15f;
    public float gravityModifier = 3f;
    public Rigidbody playerRb;
    bool isOnGround = true;
    bool isOnBlackTile = false;
    bool isOnPurpleTile = false;
    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isOnBlackTile && !isOnPurpleTile)
        {

            transform.Translate(Vector3.left * Time.deltaTime * BlackTile.bT.returnSpeed());//,Space.World);
            //playerRb.velocity = Vector3.left * BlackTile.bT.returnSpeed();
        }
        if (Input.GetKey(KeyCode.A)){
            transform.Translate(-Vector3.forward * Time.deltaTime * leftOrRightSpeed);//,Space.World);
        }
        if (Input.GetKey(KeyCode.D)){
            transform.Translate(Vector3.forward * Time.deltaTime * leftOrRightSpeed);//,Space.World);
        }
        if (Input.GetKeyDown(KeyCode.Space)&&isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
        if (Input.GetKeyDown(KeyCode.F)){

        }
        if (Input.GetKeyDown(KeyCode.Q)){

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BlackTile"))
        {
            isOnGround = true;
            isOnBlackTile = true;
        }
        if (collision.gameObject.CompareTag("PurpleTile"))
        {
            isOnPurpleTile = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("PurpleTile"))
        {
            isOnPurpleTile = false;
        }
        
    }

}
