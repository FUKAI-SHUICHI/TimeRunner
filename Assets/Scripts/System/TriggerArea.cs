using UnityEngine;

namespace StarterAssets
{
    public class TriggerArea : MonoBehaviour
    {
        public Vector3 moveDirection = Vector3.right;
        public float moveDistance = 3f;
        public float speed = 2f;

        private Vector3 _startPos;
        private Vector3 _lastPos;
        private CharacterController _playerCC;

        void Start()
        {
            _startPos = transform.position;
            _lastPos = transform.position;
        }

        void LateUpdate() // プレイヤーの移動計算の後に実行
        {
            // 1. 足場を動かす
            float offset = Mathf.Sin(Time.time * speed) * moveDistance;
            transform.position = _startPos + moveDirection.normalized * offset;

            // 2. 移動量（Delta）を計算
            Vector3 delta = transform.position - _lastPos;

            // 3. プレイヤーがトリガー内にいれば、移動量をMoveで直接流し込む
            if (_playerCC != null)
            {
                // これがStarterAssetsで最も安定する追従方法です
                _playerCC.Move(delta);
            }

            _lastPos = transform.position;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _playerCC = other.GetComponent<CharacterController>();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _playerCC = null;
            }
        }
    }
}