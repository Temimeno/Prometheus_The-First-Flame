using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;

    [SerializeField] private CinemachineVirtualCamera[] _allVirtualCamera;

    [Header("Controls for lerping the Y Damping during player jump/fall")]
    [SerializeField] private float _fallPanAmount = 0.25f;
    [SerializeField] private float _fallYPanTime = 0.35f;
    public float _fallSpeedYDampingChangeThreshold = -15f;

    public bool IsLerpingYDamping { get; private set;}
    public bool LerpingFromPlayerFalling { get; set;}

    private CinemachineVirtualCamera _currentCamera;
    private CinemachineFramingTransposer _framingTransponser;

    private float _normYPanAmount;

    private Coroutine _lerpYPanCoroutine;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        for (int i = 0; i < _allVirtualCamera.Length; i++)
        {
            if (_allVirtualCamera[i].enabled)
            {
                //Set the current active camera
                _currentCamera = _allVirtualCamera[i];

                //Set the framing transponser
                _framingTransponser = _currentCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
            }
        }

        //Set the YDamping amount so it's based on the inspector value
        _normYPanAmount = _framingTransponser.m_YDamping;
    }

    #region Lerp the Y Damping

    public void LerpYDamping(bool isPlayerFalling)
    {
        _lerpYPanCoroutine = StartCoroutine(LerpYAction(isPlayerFalling));
    }

    private IEnumerator LerpYAction(bool isPLayerFalling)
    {
        IsLerpingYDamping = true;

        //Grap the starting damping amount
        float startDampAmount = _framingTransponser.m_YDamping;
        float endDampAmount = 0f;

        //Determine the end damping amount
        if (isPLayerFalling)
        {
            endDampAmount = _fallPanAmount;
            LerpingFromPlayerFalling = true;
        }

        else
        {
            endDampAmount = _normYPanAmount;
        }

        //Lerp the pan amount
        float elapsedTime = 0f;
        while (elapsedTime < _fallYPanTime)
        {
            elapsedTime += Time.deltaTime;

            float lerpedPanAmount = Mathf.Lerp(startDampAmount, endDampAmount, (elapsedTime / _fallYPanTime));
            _framingTransponser.m_YDamping = lerpedPanAmount;

            yield return null;
        }

        IsLerpingYDamping = false;
    }

    #endregion
}
