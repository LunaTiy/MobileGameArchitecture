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

            var rotation = Quaternion.Euler(_rotationAngleX, 0, 0);
            var position = rotation * new Vector3(0, 0, -_distance) + GetFollowingPosition();

            transform.rotation = rotation;
            transform.position = position;
        }

        public void Follow(GameObject target) => _followingTransform = target.transform;

        private Vector3 GetFollowingPosition()
        {
            var followingPosition = _followingTransform.position;
            followingPosition.y = _offsetY;
            
            return followingPosition;
        }
    }
}