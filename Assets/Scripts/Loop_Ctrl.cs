using UnityEngine;

public class Loop_Ctrl : MonoBehaviour
{
    public GameObject[] prefabList;
    private GameObject MC;
    private Vector3 MCPosition;

    private void Start()
    {
        MC = GameObject.FindGameObjectWithTag("MC");
        MCPosition = MC.transform.position; // MC 오브젝트의 초기 위치 저장
    }

    private void OnTriggerEnter(Collider other)
    {
        Vector3 currentPosition = other.transform.position;
        currentPosition.x = -currentPosition.x + 3;
        currentPosition.y = 3.415697f;
        currentPosition.z = -currentPosition.z + 3;
        
        other.transform.position = currentPosition;
        Debug.Log("Teleported to new position: " + currentPosition);

        if (prefabList.Length > 0 && MC != null)
        {
            Destroy(MC); // MC 객체 삭제
            
            int randomIndex = Random.Range(0, prefabList.Length);
            GameObject selectedPrefab = prefabList[randomIndex];
            
            Instantiate(selectedPrefab, MCPosition, Quaternion.identity);
            Debug.Log("Replaced with new prefab: " + selectedPrefab.name);
        }
        else
        {
            Debug.LogWarning("Prefab list is empty or MC is not assigned.");
        }
    }
}
