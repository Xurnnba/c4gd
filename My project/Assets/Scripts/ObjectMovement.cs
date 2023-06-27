using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public float speed = 5f;
    public float movementRange = 5f;

    private bool movingRight = true;
    private Vector3 initialPosition;
    
    private void Start()
    {
        // Store the initial position of the object
        initialPosition = transform.position;

        // Start the coroutine to move the object
        StartCoroutine(MoveObject());
    }

    private IEnumerator MoveObject()
    {
        while (true) // Continue indefinitely
        {
            // Calculate the target position based on the current direction
            Vector3 targetPosition = movingRight ? initialPosition + Vector3.forward * movementRange : initialPosition - Vector3.forward * movementRange;


            // Move towards the target position
            while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
            {
                // Move the object smoothly towards the target position
                transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * speed);
                yield return null;
            }

            // Reverse the direction
            movingRight = !movingRight;
            yield return null;
        }
    }
}