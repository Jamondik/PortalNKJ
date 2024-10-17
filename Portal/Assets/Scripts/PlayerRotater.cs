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
        // Задаем порог, при котором считаем, что вращение "достаточно близко" к 0.
        float threshold = 0.01f;

        while (Mathf.Abs(playerTransform.rotation.eulerAngles.x) > threshold)
        {
            // Рассчитываем целевое вращение, при котором x равен 0.
            Quaternion targetRotation = Quaternion.Euler(0, playerTransform.rotation.eulerAngles.y, playerTransform.rotation.eulerAngles.z);

            // Используем Quaternion.RotateTowards для плавного поворота игрока к цели.
            playerTransform.rotation = Quaternion.RotateTowards(playerTransform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // Ждем указанный интервал перед обновлением вращения снова.
            yield return new WaitForSeconds(rotationPerioud);
        }

        // Убеждаемся, что вращение по оси x точно установлено на 0 в конце.
        playerTransform.rotation = Quaternion.Euler(0, playerTransform.rotation.eulerAngles.y, playerTransform.rotation.eulerAngles.z);
    }

    private IEnumerator ZRotator()
    {
        // Задаем порог, при котором считаем, что вращение по оси z "достаточно близко" к 0.
        float threshold = 0.01f;

        while (Mathf.Abs(playerTransform.rotation.eulerAngles.z) > threshold)
        {
            // Рассчитываем целевое вращение, при котором z равен 0.
            Quaternion targetRotation = Quaternion.Euler(playerTransform.rotation.eulerAngles.x, playerTransform.rotation.eulerAngles.y, 0);

            // Используем Quaternion.RotateTowards для плавного поворота игрока к цели.
            playerTransform.rotation = Quaternion.RotateTowards(playerTransform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // Ждем указанный интервал перед обновлением вращения снова.
            yield return new WaitForSeconds(rotationPerioud);
        }

        // Убеждаемся, что вращение по оси z точно установлено на 0 в конце.
        playerTransform.rotation = Quaternion.Euler(playerTransform.rotation.eulerAngles.x, playerTransform.rotation.eulerAngles.y, 0);
    }

}
