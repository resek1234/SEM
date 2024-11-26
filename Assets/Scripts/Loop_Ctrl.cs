using UnityEngine;

public class Loop_Ctrl : MonoBehaviour
{
    // OnTriggerEnter �Լ��� "isTrigger"�� Ȱ��ȭ�� Collider ���� �浹�� �����մϴ�.
    private void OnTriggerEnter(Collider other)
    {
        // �浹�� ������Ʈ�� Ư�� ������Ʈ���� Ȯ�� (Optional)
            // ���� ��ġ�� �����ɴϴ�.
            Vector3 currentPosition = other.transform.position;


            // x, z ��ǥ�� ��ȣ�� ������ŵ�ϴ�.
            currentPosition.x = -currentPosition.x+4;
            currentPosition.y = 3.415697f;
            currentPosition.z = - currentPosition.z+4;

            // ���ο� ��ġ�� �����̵�
            other.transform.position = currentPosition;

            // ����� �α� ��� (�浹�� �߻��� ��ġ)
            Debug.Log("Teleported to new position: " + currentPosition);
    }
}
