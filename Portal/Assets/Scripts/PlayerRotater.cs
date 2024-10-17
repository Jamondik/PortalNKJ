using System.Collections;
using UnityEngine;

public class PlayerRotater : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float rotationPerioud;
    [SerializeField] private float rotationSpeed;

    private void Update()
    {
        StartCoroutine(XRotator());
        StartCoroutine(ZRotator());
    }

    private IEnumerator XRotator()
    {
        // ������ �����, ��� ������� �������, ��� �������� "���������� ������" � 0.
        float threshold = 0.01f;

        while (Mathf.Abs(playerTransform.rotation.eulerAngles.x) > threshold)
        {
            // ������������ ������� ��������, ��� ������� x ����� 0.
            Quaternion targetRotation = Quaternion.Euler(0, playerTransform.rotation.eulerAngles.y, playerTransform.rotation.eulerAngles.z);

            // ���������� Quaternion.RotateTowards ��� �������� �������� ������ � ����.
            playerTransform.rotation = Quaternion.RotateTowards(playerTransform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // ���� ��������� �������� ����� ����������� �������� �����.
            yield return new WaitForSeconds(rotationPerioud);
        }

        // ����������, ��� �������� �� ��� x ����� ����������� �� 0 � �����.
        playerTransform.rotation = Quaternion.Euler(0, playerTransform.rotation.eulerAngles.y, playerTransform.rotation.eulerAngles.z);
    }

    private IEnumerator ZRotator()
    {
        // ������ �����, ��� ������� �������, ��� �������� �� ��� z "���������� ������" � 0.
        float threshold = 0.01f;

        while (Mathf.Abs(playerTransform.rotation.eulerAngles.z) > threshold)
        {
            // ������������ ������� ��������, ��� ������� z ����� 0.
            Quaternion targetRotation = Quaternion.Euler(playerTransform.rotation.eulerAngles.x, playerTransform.rotation.eulerAngles.y, 0);

            // ���������� Quaternion.RotateTowards ��� �������� �������� ������ � ����.
            playerTransform.rotation = Quaternion.RotateTowards(playerTransform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // ���� ��������� �������� ����� ����������� �������� �����.
            yield return new WaitForSeconds(rotationPerioud);
        }

        // ����������, ��� �������� �� ��� z ����� ����������� �� 0 � �����.
        playerTransform.rotation = Quaternion.Euler(playerTransform.rotation.eulerAngles.x, playerTransform.rotation.eulerAngles.y, 0);
    }

}
