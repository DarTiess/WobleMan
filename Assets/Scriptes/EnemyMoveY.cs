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
        //движение врага по заданной траектории
        //определяем точки начала движения и конца
        Vector3 endPosition = finishRoad.transform.position;
        Vector3 startPosition = startRoad.transform.position;

        Vector3 tempPosition = transform.position;

        //движение по оси z
        tempPosition.z += speed * Time.deltaTime;
        transform.position = tempPosition;

        //если объект дошел до начала движения, разворачиваем объект и меняем направление движения
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
}
