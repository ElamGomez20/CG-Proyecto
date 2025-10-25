using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UIElements;

public class Scale : MonoBehaviour
{
    private int state = 1;

    public Rigidbody rb;

    public CinemachineCamera cineCam;
    private CinemachineRotationComposer camara;

    private Vector3 tinyScale = new Vector3(0.5f, 0.5f, 0.5f);
    private Vector3 normalScale = new Vector3(1f, 1f, 1f);
    private Vector3 gigaScale = new Vector3(3f, 3f, 3f);


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camara = cineCam.GetComponent<CinemachineRotationComposer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (state < 2)
            {
                state++;
                ChangeScale();

            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (state > 0)
            {
                state--;
                ChangeScale();
            }
        }
    }

    void ChangeScale()
    {
        switch (state)
        {
            case 0:
                transform.localScale = tinyScale;
                gameObject.tag = "TinyPlayer";
                rb.mass = 1f;
                camara.TargetOffset = new Vector3(0f, 0.5f, 0f);
                break;
            case 1:
                transform.localScale = normalScale;
                gameObject.tag = "Player";
                rb.mass = 1f;
                camara.TargetOffset = new Vector3(0f, 1f, 0f);
                break;
            case 2:
                transform.localScale = gigaScale;
                gameObject.tag = "GigaPlayer";
                rb.mass = 5f;
                camara.TargetOffset = new Vector3(0f, 3f, 0f);
                break;
        }
    }
}
