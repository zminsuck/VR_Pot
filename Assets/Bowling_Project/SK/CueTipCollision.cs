using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CueTipCollision : MonoBehaviour
{
    public float forceMultiplier = 200f;
    public bool debug = false;

    private void OnCollisionEnter(Collision collision)
    {
        // �±׷� ������ Ȯ�� (Ball)
        if (collision.gameObject.CompareTag("Ball"))
        {
            Rigidbody ballRb = collision.gameObject.GetComponent<Rigidbody>();
            if (ballRb == null) return;

            // �浹 ���� ���
            Vector3 forceDir = collision.contacts[0].point - transform.position;
            forceDir = forceDir.normalized;

            // �浹 ��� �ӵ��� �� ũ�� ���
            float forcePower = collision.relativeVelocity.magnitude * forceMultiplier;

            // �� ���ϱ�
            ballRb.AddForce(forceDir * forcePower, ForceMode.Impulse);

            if (debug)
            {
                Debug.Log($"Ball Hit: Force={forcePower}, Dir={forceDir}");
            }
        }
    }
}
