using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    // Use this for initialization

    public GameObject maincamera;
    public GameObject mainplayer;

    public Transform target;
    public Transform targetTO;
    public Vector3 targetOffset;
    public float distance = 5.0f;
    public float maxDistance = 20;//缩放
    public float minDistance = 4f;//缩放
    public float xSpeed = 200.0f;//速度
    public float ySpeed = 200.0f;
    public int yMinLimit = -80;//限定角度
    public int yMaxLimit = 80;
    public int zoomRate = 40;
    public float zoomDampening = 5.0f;
    public float xDeg = 180f;//自身的角度记录
    public float yDeg = 40f;//自身的角度
    public float currentDistance;//缩放记录
    public float desiredDistance;//缩放
    private Quaternion currentRotation;
    private Quaternion desiredRotation;
    public Quaternion rotation;
    private Vector3 position;

    public float X;//初始化角度X轴
    public float Y;//初始化角度Y轴
    /// <summary>
    /// 初始化距离
    /// </summary>
    public float CameDistance;
    void Start()
    {
        Init();
        desiredDistance = CameDistance;
        yDeg = X;
        xDeg = Y;
    }
    //void OnEnable()
    //{
    //    Init();
    //    desiredDistance = CameDistance;
    //    yDeg = X;
    //    xDeg = Y;

    //}

    public void Init()
    {

        if (!target)
        {
            GameObject go = new GameObject("Cam Target");
            go.transform.position = transform.position + (transform.forward * distance);
            target = go.transform;
        }

        distance = Vector3.Distance(transform.position, target.position);
        currentDistance = distance;
        desiredDistance = distance;


        position = transform.position;
        rotation = transform.rotation;
        currentRotation = transform.rotation;
        desiredRotation = transform.rotation;

        xDeg = Vector3.Angle(Vector3.right, transform.right);
        yDeg = Vector3.Angle(Vector3.up, transform.up);
    }


    void LateUpdate()
    {
        if (!MainPlayerController.Instance.isFirstView)
        {
            if (Input.GetMouseButton(1))
            {
                xDeg += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
                yDeg -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
            }
            yDeg = ClampAngle(yDeg, yMinLimit, yMaxLimit);
            // 设置相机旋转

            desiredRotation = Quaternion.Euler(yDeg, xDeg, 0);
            currentRotation = transform.rotation;


            rotation = Quaternion.Lerp(currentRotation, desiredRotation, Time.deltaTime * zoomDampening);
            transform.rotation = rotation;



            // 影响scrollwheel变焦距离
            desiredDistance -= Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * zoomRate * Mathf.Abs(desiredDistance);
            //变焦最小/最大
            desiredDistance = Mathf.Clamp(desiredDistance, minDistance, maxDistance);
            //平滑变焦
            currentDistance = Mathf.Lerp(currentDistance, desiredDistance, Time.deltaTime * zoomDampening);


            target.position = Vector3.Lerp(target.position, targetTO.position, Time.deltaTime * 5);


            position = target.position - (rotation * Vector3.forward * currentDistance + targetOffset);
            transform.position = position;
        }
        else
        {
            maincamera.transform.position = new Vector3(mainplayer.transform.position.x, mainplayer.transform.position.y + 1.2f, mainplayer.transform.position.z - 0.2f);
            maincamera.transform.eulerAngles = mainplayer.transform.eulerAngles;
        }
    }

    private static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }
}
