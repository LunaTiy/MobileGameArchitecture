using UnityEngine;

namespace CodeBase.Enemy
{
    public static class DrawDebugTools
    {
        public static void DrawSphere(Vector3 worldPosition, float radius, float duration, Color color, int quality = 2)
        {
            int segments = quality << 2;
            int subdivisions = quality << 3;
            int halfSegments = segments >> 1;
            float strideAngle = 360F / subdivisions;
            float segmentStride = 180F / segments;

            Vector3 first;
            Vector3 next;
            
            for (int i = 0; i < segments; i++)
            {
                first = (Vector3.forward * radius);
                first = Quaternion.AngleAxis(segmentStride * (i - halfSegments), Vector3.right) * first;

                for (int j = 0; j < subdivisions; j++)
                {
                    next = Quaternion.AngleAxis(strideAngle, Vector3.up) * first;
                    UnityEngine.Debug.DrawLine(first + worldPosition, next + worldPosition, color, duration);
                    first = next;
                }
            }

            for (int i = 0; i < segments; i++)
            {
                first = (Vector3.forward * radius);
                first = Quaternion.AngleAxis(segmentStride * (i - halfSegments), Vector3.up) * first;
                Vector3 axis = Quaternion.AngleAxis(90F, Vector3.up) * first;

                for (int j = 0; j < subdivisions; j++)
                {
                    next = Quaternion.AngleAxis(strideAngle, axis) * first;
                    Debug.DrawLine(first + worldPosition, next + worldPosition, color, duration);
                    first = next;
                }
            }
        }
    }
}