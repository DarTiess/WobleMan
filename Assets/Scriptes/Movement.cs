using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Touch touch;
    private Vector2 startTouch;
    private Vector2 endTouch;
    public float speedMove = 2f;
  

    private void FixedUpdate()
    {
         Move();
    }

    public void Move()
    {
        //определяем начало и конец прикосновения
        //перемещаем игрока на заданную дистанцию
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

            Vector3 tempPosition =transform.position;
              tempPosition.x -= moveDirection.x * speedMove  * Time.deltaTime;
                tempPosition.z -= moveDirection.y * speedMove * Time.deltaTime;
            transform.position = tempPosition;
        }
    }
   
}
