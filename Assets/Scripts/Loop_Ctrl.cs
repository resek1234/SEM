using UnityEngine;

public class Loop_Ctrl : MonoBehaviour
{
    // OnTriggerEnter 함수는 "isTrigger"가 활성화된 Collider 간의 충돌을 감지합니다.
    private void OnTriggerEnter(Collider other)
    {
        // 충돌한 오브젝트가 특정 오브젝트인지 확인 (Optional)
            // 현재 위치를 가져옵니다.
            Vector3 currentPosition = other.transform.position;


            // x, z 좌표의 부호를 반전시킵니다.
            currentPosition.x = -currentPosition.x+4;
            currentPosition.y = 3.415697f;
            currentPosition.z = - currentPosition.z+4;

            // 새로운 위치로 순간이동
            other.transform.position = currentPosition;

            // 디버그 로그 출력 (충돌이 발생한 위치)
            Debug.Log("Teleported to new position: " + currentPosition);
    }
}
