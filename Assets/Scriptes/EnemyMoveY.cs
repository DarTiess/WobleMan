using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveY : MonoBehaviour
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

        tempPosition.z += speed * Time.deltaTime;
        transform.position = tempPosition;

        if (tempPosition.z > startPosition.z)
        {
            speed = -Mathf.Abs(speed);
            transform.rotation = Quaternion.Euler(new Vector3(0, 360, 0));
        }
        else if (tempPosition.z < endPosition.z)
        {
            speed =Mathf.Abs(speed);
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
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
