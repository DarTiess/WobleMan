using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Touch touch;
    private Vector2 startTouch;
    private Vector2 endTouch;
    public float speedMove = 2f;

   private Rigidbody rigidbody;

    private ParticleSystem dieParticle;
    public GameObject explosionDie;
  
    void Start()
    {
      rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       rigidbody.AddForce(new Vector2(0, 50));
    }
    private void FixedUpdate()
    {
         Move();
    }

    public void Move()
    {
            if (Input.touchCount > 0)
             {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                startTouch = touch.position;
              
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                endTouch = touch.position;
               
            }
            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

            Vector3 moveDirection = startTouch - endTouch;

            Vector3 tempPosition =transform.position;
              tempPosition.x -= moveDirection.x * speedMove  * Time.deltaTime;
                tempPosition.z -= moveDirection.y * speedMove * Time.deltaTime;
            transform.position = tempPosition;
           // rigidbody.velocity = new Vector2(tempPosition.x * speedMove, rigidbody.velocity.y);
           rigidbody.MovePosition(transform.position);

        }
    }
   
}
