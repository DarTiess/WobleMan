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
        //движение врага по заданной траектории
        //определяем точки начала движения и конца
        Vector3 endPosition = finishRoad.transform.position;
        Vector3 startPosition = startRoad.transform.position;

        Vector3 tempPosition = transform.position;

        //движение по оси x
        tempPosition.x += speed * Time.deltaTime;
        transform.position = tempPosition;

        //если объект дошел до начала движения, разворачиваем объект и меняем направление движения
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

}
