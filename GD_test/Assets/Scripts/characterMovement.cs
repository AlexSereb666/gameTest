using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMovement : MonoBehaviour
{
    public Transform[] waypoints; // Массив точек траектории
    public float walkingSpeed = 3f; // Скорость движения (ходьбы)
    public float runningSpeed = 7f; // Скорость движения (бег)
    private int currentWaypointIndex = 0; // Текущая точка траектории

    private void Update()
    {
        float speed = 0f;

        if (currentWaypointIndex < waypoints.Length)
        {
            // Получаем текущую точку
            Transform targetWaypoint = waypoints[currentWaypointIndex];

            // переключение режима передвижения //
            if (currentWaypointIndex < 3 || currentWaypointIndex > 4 && currentWaypointIndex < 6)
                speed = walkingSpeed;
            else
                speed = runningSpeed;

            // Двигаемся к текущей точке
            transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);

            // Ориентируемся к текущей точке
            Vector3 direction = targetWaypoint.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = rotation;

            // Если достигли текущей точки, переходим к следующей
            if (transform.position == targetWaypoint.position)
            {
                currentWaypointIndex++;
            }
        }
    }
}
