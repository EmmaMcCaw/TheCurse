using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPM : MonoBehaviour
{
    public float Speed = 20f;
    float horizontal;
    float vertical;
    public Rigidbody2D playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        playerController.velocity = new Vector2(horizontal * Speed, vertical * Speed);
    }

}
