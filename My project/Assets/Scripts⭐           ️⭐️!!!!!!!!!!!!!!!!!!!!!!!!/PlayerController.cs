using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    [Header("Basic Parameters")]
    public float leftOrRightSpeed = 1;
    public float jumpForce = 15f;
    public float gravityModifier = 3f;
    public GameObject platformPosition;

    public Rigidbody playerRb;
    private bool isOnGround = true;
    bool isOnBlackTile = false;
    bool isOnPurpleTile = false;
    private Vector3 stillRotation=new Vector3(0, 0, 0);

    public float normalForwardSpeed = 10;

    private void Awake()
    {
        
        isOnGround = true;
        isOnBlackTile = true;
        isOnPurpleTile = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.rotation = Quaternion.Euler(stillRotation);
        if (transform.position.y < platformPosition.transform.position.y)
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            isOnGround = true;
        }
        if (isOnBlackTile && !isOnPurpleTile)
        {
            transform.Translate(Vector3.left * Time.deltaTime * normalForwardSpeed);//,Space.World);
            //playerRb.velocity = Vector3.left * normalForwardSpeed;//BlackTile.bT.returnSpeed();
}
        if (Input.GetKey(KeyCode.A)){
            transform.Translate(-Vector3.forward * Time.deltaTime * leftOrRightSpeed);//,Space.World);
        }
        if (Input.GetKey(KeyCode.D)){
            transform.Translate(Vector3.forward * Time.deltaTime * leftOrRightSpeed);//,Space.World);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            Debug.Log("Space pressed");
            playerRb.velocity = new Vector3(playerRb.velocity.x, jumpForce, playerRb.velocity.z);
                //AddForce(Vector3.up * jumpForce, ForceMode.Impulse);       
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
