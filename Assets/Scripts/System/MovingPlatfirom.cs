using UnityEngine;

namespace StarterAssets
{
    public class MovingPlatform : MonoBehaviour
    {
        public Vector3 moveDirection = Vector3.right;
        public float moveDistance = 3f;
        public float speed = 2f;

        private Vector3 _startPos;
        private CharacterController _playerCC;
        private bool _isPlayerOn = false;

        void Start()
        {
            _startPos = transform.position;
        }

        void FixedUpdate()
        {
            float offset = Mathf.Sin(Time.fixedTime * speed) * moveDistance;
            Vector3 nextPos = _startPos + moveDirection.normalized * offset;
            Vector3 platformDelta = nextPos - transform.position;

            transform.position = nextPos;

            if (_isPlayerOn && _playerCC != null)
            {
                // 吸着移動
                _playerCC.enabled = false;
                _playerCC.transform.position += platformDelta;
                _playerCC.enabled = true;
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (_playerCC == null)
                    _playerCC = other.GetComponent<CharacterController>();

                _isPlayerOn = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                // 【重要】足場から離れた瞬間の処理
                if (_playerCC != null)
                {
                    // 1. 一旦CCを無効化
                    _playerCC.enabled = false;

                    // 2. プレイヤーの移動ベクトルをリセットする処理
                    // StarterAssetsの内部速度を強制的に書き換えることは難しいため、
                    // CCを無効化して再度有効化するこの瞬間に、蓄積された「ズレ」を遮断します。

                    _playerCC.enabled = true;
                }

                _isPlayerOn = false;
                _playerCC = null;
            }
        }
    }
}