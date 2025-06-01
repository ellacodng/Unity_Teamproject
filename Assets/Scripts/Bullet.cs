using UnityEngine;

public class FlyingObject : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float lifeTime = 10f;
    [SerializeField] private int damage = 1;

    // �Ѿ��� �߻�� �� �÷��̾��� ������ ������ ���� �߰�
    private int direction = 1; // 1: ������, -1: ����

    private float timer = 0f;

    // �Ѿ��� ������ �� ȣ��� �ʱ�ȭ �Լ�
    public void Initialize(int playerDirection)
    {
        direction = playerDirection;
        // �Ѿ��� �ʱ� �����ϵ� �÷��̾� ���⿡ �°� ���� (���� ����)
        Vector3 currentScale = transform.localScale;
        transform.localScale = new Vector3(Mathf.Abs(currentScale.x) * direction, currentScale.y, currentScale.z);
    }

    void Update()
    {
        // �÷��̾� ���⿡ ���� �̵�
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime * direction); // Vector2.right�� ����ϰ� direction�� ����

        timer += Time.deltaTime;
        if (timer >= lifeTime)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyPatrol enemy = other.GetComponent<EnemyPatrol>();
            if (enemy != null)
            {
                enemy.Die();
                enemy.DestroyAfterDeath();
            }
            Destroy(gameObject);
        }
        else if (other.CompareTag("Obstacle")) // ��ֹ��� ������ �������
        {
            Destroy(gameObject);
        }
    }
}
