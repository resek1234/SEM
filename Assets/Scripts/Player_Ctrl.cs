using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Ctrl : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float runSpeed = 10f;
    public float lookSpeed = 2f;
    public Camera playerCamera;
    private float xRotation = 0f;

    public AudioClip walkClip;
    public AudioClip runClip;
    private AudioSource audioSource;
    private bool isRunning = false;
    private bool isMoving = false;

    private Rigidbody rb; // Rigidbody 컴포넌트 추가

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.loop = true;

        rb = GetComponent<Rigidbody>(); // Rigidbody 컴포넌트 가져오기
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>(); // Rigidbody가 없다면 추가
        }

        rb.freezeRotation = true; // 회전 고정
    }

    void Update()
    {
        isRunning = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        float currentMoveSpeed = isRunning ? runSpeed : moveSpeed;

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        isMoving = moveHorizontal != 0 || moveVertical != 0;

        Vector3 movement = transform.right * moveHorizontal + transform.forward * moveVertical;
        Vector3 velocity = movement * currentMoveSpeed;

        // Rigidbody의 velocity를 설정하여 이동하도록 처리
        rb.velocity = new Vector3(velocity.x, rb.velocity.y, velocity.z);

        float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeed;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

        if (isMoving)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }

            if (isRunning && audioSource.clip != runClip)
            {
                audioSource.Stop();
                audioSource.clip = runClip;
                audioSource.Play();
            }
            else if (!isRunning && audioSource.clip != walkClip)
            {
                audioSource.Stop();
                audioSource.clip = walkClip;
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
    }
}
