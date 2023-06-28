using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    bool isOnPurpleTile = false;
    bool isOnBlueTile = false;
    private Vector3 stillRotation = new Vector3(0, 0, 0);

    public float normalForwardSpeed = 10;

    MeshRenderer meshRenderer;
    Material oldMaterial;
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
        isOnPurpleTile = false;
        isOnBlueTile = false;
        meshRenderer = GetComponent<MeshRenderer>();
        oldMaterial = meshRenderer.material;
        
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
        
        if (isOnBlackTile)
        {
            transform.Translate(Vector3.left * Time.deltaTime * normalForwardSpeed);//,Space.World);                                                        //playerRb.velocity = Vector3.left * normalForwardSpeed;//BlackTile.bT.returnSpeed();
        }
        if (Input.GetKey(KeyCode.W)&&!isOnBlackTile)
        {
            transform.Translate(Vector3.left * Time.deltaTime * normalForwardSpeed);
        }
        if (Input.GetKey(KeyCode.S) && !isOnBlackTile)
        {
            transform.Translate(-Vector3.left * Time.deltaTime * normalForwardSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-Vector3.forward * Time.deltaTime * leftOrRightSpeed);//,Space.World);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * leftOrRightSpeed);//,Space.World);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            //Debug.Log("Space pressed");
            playerRb.velocity = new Vector3(playerRb.velocity.x, jumpForce, playerRb.velocity.z);
            
            ////AddForce(Vector3.up * jumpForce, ForceMode.Impulse);       
            isOnGround = false;
        }
        //if (Input.GetKeyDown(KeyCode.F)&&isOnBlueTile)
        //{
        //    Vector3 temp = new Vector3(0,transform.position.y,0);
        //    transform.Translate(Vector3.left * Time.deltaTime * normalForwardSpeed);
        //    transform.position = new Vector3(,0,)+temp;
        //}
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (meshRenderer.material == Orange)
            {
                meshRenderer.material = Black;
            }
            if (meshRenderer.material == Black)
            {
                meshRenderer.material = Purple;
            }
            if (meshRenderer.material == Purple)
            {
                meshRenderer.material = Blue;
            }
            if (meshRenderer.material == Blue)
            {
                meshRenderer.material = White;
            }
            if (meshRenderer.material == White)
            {
                meshRenderer.material = Orange;
            }

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
            isOnGround = true;
            isOnWhiteTile = true;
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
        if (collision.gameObject.CompareTag("BlueTile"))
        {
            isOnBlueTile = true;
            //transform.Translate(Vector3.left * Time.deltaTime * normalForwardSpeed);
        }
        if (collision.gameObject.CompareTag("OrangeTile"))
        {

        }
        if (collision.gameObject.CompareTag("RedTile"))
        {

        }

    }

}
