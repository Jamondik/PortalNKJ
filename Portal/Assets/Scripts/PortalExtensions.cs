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
        // �������� ������ ������������� ������� ������������ point1
        Vector3 relativePos = point1 - target;
        // �������� �������
        relativePos = _halfTurn * relativePos;
        // ������������� ����� �������
        target = point2 + relativePos;
    }

    public static void MirrorRotationVector(this Quaternion target, Quaternion rotation1, Quaternion rotation2)
    {
        // �������� ������������� ������� ������������ rotation1
        Quaternion relativeRot = Quaternion.Inverse(rotation1) * target;
        // �������� �������
        relativeRot = _halfTurn * relativeRot;
        // ������������� ����� �������
        target = rotation2 * relativeRot;
    }
}