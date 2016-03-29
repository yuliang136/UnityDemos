using UnityEngine;
using System.Collections;

public class HandleLogo : MonoBehaviour {

    private Transform mCacheTransform;

    public float _fFollowRotationSpeed;
    public float _fFollowMoveSpeed;

    public GameObject _goPos;

    public Transform _tfHead;

    private RaycastHit _hit;

    private bool _bCanMove;
    private bool _bCanRotate;

    public void Awake()
    {
        mCacheTransform = transform;
    }



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
        //var rot = Cardboard.SDK.HeadPose.Orientation;

        //Vector3 targetRotation = rot.eulerAngles;

        //Quaternion targetQuation = Quaternion.Euler(targetRotation);

        //mCacheTransform.localRotation = Quaternion.Lerp(
        //                                                mCacheTransform.localRotation,
        //                                                targetQuation,
        //                                                _fFollowRotationSpeed*Time.smoothDeltaTime);
	}

    public void LateUpdate()
    {
        _bCanMove = JudgeCanMove();


        //if (!bJudgeCanMove)
        //{
        //    return;
        //}

        // 设置偏转.
        var rot = Cardboard.SDK.HeadPose.Orientation;
        Vector3 targetRotation = rot.eulerAngles;
        Quaternion targetQuation = Quaternion.Euler(targetRotation);
        mCacheTransform.localRotation = Quaternion.Lerp(
                                                        mCacheTransform.localRotation,
                                                        targetQuation,
                                                        _fFollowRotationSpeed * Time.smoothDeltaTime);

        if (_bCanMove)
        {
            this.transform.position = Vector3.Lerp(
                                                    this.transform.position,
                                                    _goPos.transform.position,
                                                    _fFollowMoveSpeed * Time.smoothDeltaTime);
        }
        // 设置位置.
        //this.transform.position = _goPos.transform.position;



        //var fwd = _tfHead.TransformDirection(Vector3.forward);

        //if (Physics.Raycast(_tfHead.position, fwd, out _hit, 1000f))
        //{
        //    Debug.Log(_hit.transform.name);
        //}

    }

    // 默认可以旋转. 如果装机到虚拟区域时，不能旋转和移动.
    private bool JudgeCanMove()
    {
        bool bRtn = true;

        var fwd = _tfHead.TransformDirection(Vector3.forward);

        if (Physics.Raycast(_tfHead.position, fwd, out _hit, 1000f))
        {
            Debug.Log(_hit.transform.name);
            // 撞击到LOGO或者ReStartScene时,认为在区域内.
            // 如果撞击到虚拟区域. 认为不需要移动和转动
            if ((_hit.transform.name == "LOGO") || (_hit.transform.name == "ReStartScene"))
            {
                bRtn = false;
            }
        }
    

        return bRtn;
    }


}
