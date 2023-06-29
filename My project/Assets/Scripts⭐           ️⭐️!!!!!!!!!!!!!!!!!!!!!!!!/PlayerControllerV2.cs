using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class PlayerControllerV2 : MonoBehaviour
{

    [Header("Basic Parameters")]
    public float leftOrRightSpeed = 1;
    public float jumpForce = 15f;
    
    //float jumpHeight = 5;
    public float gravityModifier = 3f;
    public GameObject platformPosition;

    public Rigidbody playerRb;
    private bool isOnGround = true;
    bool isOnBlackTile = false;
    //bool isOnPurpleTile = false;
    bool isOnBlueTile = false;
    bool isOnWhiteTile = false;

    public float normalForwardSpeed = 10;

    private Vector3 blueTilePos;
    bool theBlueTileCollision = true;

    MeshRenderer meshRenderer;
    //Material oldMaterial;
    [Header("Materials")]
    public Material Black;
    public Material Orange;
    public Material Purple;
    public Material Blue;
    public Material White;

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = new Vector3(0, -9.8f * gravityModifier, 0);
        isOnGround = true;
        isOnBlackTile = true;
        //isOnPurpleTile = false;
        isOnBlueTile = false;
        isOnWhiteTile = false;
        meshRenderer = GetComponent<MeshRenderer>();
        //oldMaterial = meshRenderer.material;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //transform.rotation = Quaternion.Euler(stillRotation);
        if (transform.position.y < -5)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            isOnGround = true;
        }
        
        if (isOnWhiteTile)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.left * Time.deltaTime * normalForwardSpeed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(-Vector3.left * Time.deltaTime * normalForwardSpeed);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(-Vector3.forward * Time.deltaTime * leftOrRightSpeed);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * leftOrRightSpeed);
            }
        }
        if (isOnBlackTile)
        {
            transform.Translate(Vector3.left * Time.deltaTime * normalForwardSpeed);
        }
        if (isOnBlueTile && !(Input.GetKeyDown(KeyCode.Space) && isOnBlueTile))
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.left * Time.deltaTime * normalForwardSpeed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(-Vector3.left * Time.deltaTime * normalForwardSpeed);
            }
            transform.position = new Vector3(transform.position.x,blueTilePos.y , transform.position.z);

        }
        if (Input.GetKey(KeyCode.A)&&!isOnWhiteTile)
        {
            transform.Translate(-Vector3.forward * Time.deltaTime * leftOrRightSpeed);//,Space.World);
        }
        if (Input.GetKey(KeyCode.D)&&!isOnWhiteTile)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * leftOrRightSpeed);//,Space.World);
        }
        if ((Input.GetKeyDown(KeyCode.Space) && isOnGround)|| (Input.GetKeyDown(KeyCode.Space) && isOnBlueTile))
        {
            //Debug.Log("Space pressed");


            //isOnPurpleTile = false;
            //isOnBlueTile = false;
            playerRb.velocity = new Vector3(playerRb.velocity.x, jumpForce, playerRb.velocity.z);
            
            ////AddForce(Vector3.up * jumpForce, ForceMode.Impulse);       
            isOnGround = false;
        }
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            meshRenderer.material = Black;
            //if (meshRenderer.material == Orange)
            //{
                
            //}
            //if (meshRenderer.material == Black)
            //{
            //    meshRenderer.material = Purple;
            //}
            //if (meshRenderer.material == Purple)
            //{
            //    meshRenderer.material = Blue;
            //}
            //if (meshRenderer.material == Blue)
            //{
            //    meshRenderer.material = White;
            //}
            //if (meshRenderer.material == White)
            //{
            //    meshRenderer.material = Orange;
            //}

            //    = materials.Dequeue();
            //materials.Enqueue(oldMaterial);
            //oldMaterial = meshRenderer.material;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BlackTile"))
        {
            isOnGround = true;
            isOnBlackTile = true;
        }

        if (collision.gameObject.CompareTag("WhiteTile"))
        {
            Debug.Log("IS on white tile");
            isOnBlackTile = false;
            isOnGround = true;
            isOnWhiteTile = true;
        }
        if (collision.gameObject.CompareTag("BlueTile") && theBlueTileCollision)
        {
            isOnBlueTile = true;
            blueTilePos =  gameObject.transform.position;//1234141343414
            theBlueTileCollision = false;
        }
        //if (collision.gameObject.CompareTag("BlueTile") )
        //{
        //    isOnBlueTile = true;
        //}
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("BlackTile"))
        {
            isOnGround = true;
            isOnBlackTile = true;
        }

        if (collision.gameObject.CompareTag("BlueTile"))
        {
            isOnBlueTile = false;
            theBlueTileCollision = true;

        }

    }

    

}
