using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro.Examples;
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

    private Coroutine _lerpYPanCoroutine;
    private Coroutine _panCameraCoroutine;
    

    private CinemachineVirtualCamera _currentCamera;
    private CinemachineFramingTransposer _framingTransponser;

    private float _normYPanAmount;

    private Vector2 _startingTrackedObjectOffset;

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

        //Set the starting position of the tracked object offset
        _startingTrackedObjectOffset = _framingTransponser.m_TrackedObjectOffset;
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

    #region Pan Camera

    public void PanCameraOnContact(float panDistance, float panTime, PanDirection panDirection, bool panToStartingPos)
    {
        _panCameraCoroutine = StartCoroutine(PanCamera(panDistance, panTime, panDirection, panToStartingPos));
    }

    private IEnumerator PanCamera(float panDistance, float panTime, PanDirection panDirection, bool panToStartingPos)
    {
        Vector2 endPos = Vector2.zero;
        Vector2 startingPos = Vector2.zero;

        //Handle pan from trigger
        if (!panToStartingPos)
        {
            //Set the direction and distance
            switch (panDirection)
            {
                case PanDirection.Up:
                    endPos = Vector2.up;
                    break;
                case PanDirection.Down:
                    endPos = Vector2.down;
                    break;
                case PanDirection.Left:
                    endPos = Vector2.left;
                    break;
                case PanDirection.Right:
                    endPos = Vector2.right;
                    break;
            }

            endPos *= panDistance;

            startingPos = _startingTrackedObjectOffset;

            endPos += startingPos;
        }

        //Handle the pan back to starting position
        else
        {
            startingPos = _framingTransponser.m_TrackedObjectOffset;
            endPos = _startingTrackedObjectOffset;
        }

        //Handle the actual panning of the cameara
        float elapsedTime = 0f;
        while(elapsedTime < panTime)
        {
            elapsedTime += Time.deltaTime;

            Vector3 panLerp = Vector3.Lerp(startingPos, endPos, (elapsedTime / panTime));
            _framingTransponser.m_TrackedObjectOffset = panLerp;

            yield return null;
        }
    }

    #endregion

    #region Swap Cameras

    public void SwapCamera(CinemachineVirtualCamera cameraFromLeft, CinemachineVirtualCamera cameraFromRight, Vector2 triggerExitDirection)
    {
        //If the current camera is the camera on the left and our trigger exit direction was on the right
        if (_currentCamera == cameraFromLeft && triggerExitDirection.x > 0f)
        {
            //Activate new camera
            cameraFromRight.enabled = true;

            //Deactivate old camera
            cameraFromLeft.enabled = false;

            //Set the new camera as the current camera
            _currentCamera = cameraFromRight;

            //Update our composer variable
            _framingTransponser = _currentCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
        }

        //If the current camera is the camera on the right and our trigger exit direction was on the left
        else if (_currentCamera == cameraFromRight && triggerExitDirection.x < 0f)
        {
            //Activate new camera
            cameraFromLeft.enabled = true;

            //Deactivate old camera
            cameraFromRight.enabled = false;

            //Set the new camera as the current camera
            _currentCamera = cameraFromLeft;

            //Update our composer variable
            _framingTransponser = _currentCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
        }
    }

    #endregion
}
