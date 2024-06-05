using System.Collections.Generic;
using UnityEngine;

public class MoveBody : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 5f;
    public Rigidbody2D body;
    public Camera cam;
    public List<string> inventory;
    public Vector2 moveDirection;
    void Start()
    {
        cam = Camera.main;
        inventory = new List<string>();


    }

    void Update()
    {

        /*if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            body.velocity = Vector2.left * 2;

        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            body.velocity = Vector2.left * 0;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            body.velocity = Vector2.right * 2;
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            body.velocity = Vector2.right * 0;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            body.velocity = Vector2.down * 2;
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            body.velocity = Vector2.down * 0;
        }*/
        ProcessInputs();

    }
    void FixedUpdate()
    {
        Move();
    }
    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;
    }
    void Move()
    {
        body.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectable"))
        {

            string itemType = collision.gameObject.GetComponent<CollatableScript>().itemType;
            Debug.Log("We have collected an :" + itemType);
            inventory.Add(itemType);
            print("inventory length:" + inventory.Count);
            Destroy(collision.gameObject);
        }
    }
}
