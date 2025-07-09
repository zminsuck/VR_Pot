using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CueTipCollision : MonoBehaviour
{
    public float forceMultiplier = 200f;
    public bool debug = false;

    private void OnCollisionEnter(Collision collision)
    {
        // 태그로 공인지 확인 (Ball)
        if (collision.gameObject.CompareTag("Ball"))
        {
            Rigidbody ballRb = collision.gameObject.GetComponent<Rigidbody>();
            if (ballRb == null) return;

            // 충돌 방향 계산
            Vector3 forceDir = collision.contacts[0].point - transform.position;
            forceDir = forceDir.normalized;

            // 충돌 상대 속도로 힘 크기 계산
            float forcePower = collision.relativeVelocity.magnitude * forceMultiplier;

            // 힘 가하기
            ballRb.AddForce(forceDir * forcePower, ForceMode.Impulse);

            if (debug)
            {
                Debug.Log($"Ball Hit: Force={forcePower}, Dir={forceDir}");
            }
        }
    }
}
