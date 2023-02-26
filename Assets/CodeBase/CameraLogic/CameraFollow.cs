using UnityEngine;

namespace CodeBase.CameraLogic
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private float _rotationAngleX;
        [SerializeField] private float _distance;
        [SerializeField] private float _offsetY;
        
        [SerializeField] private Transform _followingTransform;

        private void LateUpdate()
        {
            if (_followingTransform == null)
                return;

            Quaternion rotation = Quaternion.Euler(_rotationAngleX, 0, 0);
            Vector3 position = rotation * new Vector3(0, 0, -_distance) + GetFollowingPosition();

            transform.rotation = rotation;
            transform.position = position;
        }

        public void Follow(GameObject target) => _followingTransform = target.transform;

        private Vector3 GetFollowingPosition()
        {
            Vector3 followingPosition = _followingTransform.position;
            followingPosition.y = _offsetY;
            
            return followingPosition;
        }
    }
}