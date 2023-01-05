using UnityEngine;

public class BasicCameraMovement : MonoBehaviour
{
    [SerializeField] private float _speedMove;

    private Transform _cameraTransform;

    // Start is called before the first frame update
    void Start()
    {
        _cameraTransform = GetComponent<Camera>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _cameraTransform.position += Vector3.left * _speedMove * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            _cameraTransform.position += Vector3.right * _speedMove * Time.deltaTime;
        }
    }
}
