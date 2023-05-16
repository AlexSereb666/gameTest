using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMovement : MonoBehaviour
{
    public Transform[] waypoints; // ������ ����� ����������
    public float walkingSpeed = 3f; // �������� �������� (������)
    public float runningSpeed = 7f; // �������� �������� (���)
    private int currentWaypointIndex = 0; // ������� ����� ����������

    private void Update()
    {
        float speed = 0f;

        if (currentWaypointIndex < waypoints.Length)
        {
            // �������� ������� �����
            Transform targetWaypoint = waypoints[currentWaypointIndex];

            // ������������ ������ ������������ //
            if (currentWaypointIndex < 3 || currentWaypointIndex > 4 && currentWaypointIndex < 6)
                speed = walkingSpeed;
            else
                speed = runningSpeed;

            // ��������� � ������� �����
            transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);

            // ������������� � ������� �����
            Vector3 direction = targetWaypoint.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = rotation;

            // ���� �������� ������� �����, ��������� � ���������
            if (transform.position == targetWaypoint.position)
            {
                currentWaypointIndex++;
            }
        }
    }
}
