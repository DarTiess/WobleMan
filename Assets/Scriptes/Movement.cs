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
      public Vector3 position
    {
        get
        {
            return (this.transform.position);
        }
        set
        {
            this.transform.position = value;
        }
    }


    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
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
             

            Vector3 moveDirection = startTouch - endTouch;

            
            Vector3 tempPosition = rigidbody.position;
                tempPosition.x -= moveDirection.x * speedMove  * Time.deltaTime;
                tempPosition.z -= moveDirection.y * speedMove * Time.deltaTime;
            rigidbody.position = tempPosition;
           

        }
    }
}
