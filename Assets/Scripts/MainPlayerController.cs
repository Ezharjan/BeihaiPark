using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MainPlayerController : MonoBehaviour
{

    private Animation animation;//动画
    public NavMeshAgent navAgent;//寻路

    public bool isFirstView = false;

    public RaycastHit hitInfo;
    public bool isMoving = false;

    public static MainPlayerController Instance; //单例模式
    private void Awake()
    {
        Instance = this;
    }


    void Start()
    {
        animation = GetComponent<Animation>();
        navAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))//如果点击鼠标左键
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (UICamera.isOverUI)
            {

            }
            else if (Physics.Raycast(ray, out hitInfo))
            {
                navAgent.SetDestination(hitInfo.point);
                animation.CrossFade("walk", 1f);
            }
        }
        if (Mathf.Abs(hitInfo.point.x - this.gameObject.transform.position.x) < 0.2 && Mathf.Abs(hitInfo.point.z - this.gameObject.transform.position.z) < 0.2)
        {
            animation.CrossFade("Idle", 1f);
        }
        if (isMoving)
        {
            navAgent.SetDestination(hitInfo.point);
            animation.CrossFade("Idle", 0f);
            isMoving = false;
        }
    }

}
