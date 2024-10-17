using UnityEngine;

public static class PortalExtensions
{
    private static readonly Quaternion _halfTurn = Quaternion.Euler(0.0f, 180.0f, 0.0f);

    public static void MirrorPosition(this Transform target, Transform p1, Transform p2)
    {
        Vector3 relativePos = p1.InverseTransformPoint(target.position);
        relativePos = _halfTurn * relativePos;
        target.position = p2.TransformPoint(relativePos);
    }

    public static void MirrorRotation(this Transform target, Transform p1, Transform p2)
    {
        Quaternion relativeRot = Quaternion.Inverse(p1.rotation) * target.rotation;
        relativeRot = _halfTurn * relativeRot;
        target.rotation = p2.rotation * relativeRot;
    }

    public static void MirrorPositionVector(this Vector3 target, Vector3 point1, Vector3 point2)
    {
        // Получаем вектор относительной позиции относительно point1
        Vector3 relativePos = point1 - target;
        // Отражаем позицию
        relativePos = _halfTurn * relativePos;
        // Устанавливаем новую позицию
        target = point2 + relativePos;
    }

    public static void MirrorRotationVector(this Quaternion target, Quaternion rotation1, Quaternion rotation2)
    {
        // Получаем относительную ротацию относительно rotation1
        Quaternion relativeRot = Quaternion.Inverse(rotation1) * target;
        // Отражаем ротацию
        relativeRot = _halfTurn * relativeRot;
        // Устанавливаем новую ротацию
        target = rotation2 * relativeRot;
    }
}