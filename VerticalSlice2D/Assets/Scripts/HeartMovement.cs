using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartMovement : MonoBehaviour
{
    [SerializeField] private SpriteRenderer box;
    [SerializeField] private float boxBorderOffset = 0.63f;
    [SerializeField] private float speed = 5f;

    private void Update()
    {
        Move(GetUserInput());
    }

    private Vector2 GetUserInput()
    {
        int x = 0;
        int y = 0;

        //Get user input
        if (Input.GetKey(KeyCode.W)) y += 1;
        if (Input.GetKey(KeyCode.A)) x += -1;
        if (Input.GetKey(KeyCode.S)) y += -1;
        if (Input.GetKey(KeyCode.D)) x += 1;

        return new Vector2(x, y);
    }

    private void Move(Vector2 userInput)
    {
        //Calculate new position
        Vector2 newPosition = new Vector2(transform.position.x, transform.position.y) + (userInput * speed * Time.deltaTime);

        //Clamp position in box with offset
        newPosition = new Vector2(Mathf.Clamp(newPosition.x, box.bounds.min.x + boxBorderOffset, box.bounds.max.x - boxBorderOffset), Mathf.Clamp(newPosition.y, box.bounds.min.y + boxBorderOffset, box.bounds.max.y - boxBorderOffset));

        transform.position = newPosition;
    }
}
