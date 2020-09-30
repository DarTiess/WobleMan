using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed = 5f;

   public GameObject finishRoad;
    public GameObject startRoad;

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    public void Move()
    {
        Vector3 endPosition = finishRoad.transform.position;
        Vector3 startPosition = startRoad.transform.position;

        Vector3 tempPosition = transform.position;

        tempPosition.x += speed * Time.deltaTime;
        transform.position = tempPosition;

        if (tempPosition.x > startPosition.x)
        {
            speed = -Mathf.Abs(speed);
            transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
        }
        else if (tempPosition.x < endPosition.x)
        {
            speed =Mathf.Abs(speed);
            transform.rotation = Quaternion.Euler(new Vector3(0, 270, 0));
        }
      
    }

    void TurnAround()
    {
        float yTemp = transform.rotation.y;
     
        if (yTemp == 90)
        {
            yTemp = yTemp + 180;
        } 
        transform.rotation = Quaternion.Euler(new Vector3(0, yTemp, 0));
    }
}
