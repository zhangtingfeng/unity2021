using UnityEngine;

/// Camera class.
///
/// Component of the main camera of the scene to move and scale the sky dome.

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
[AddComponentMenu("Time of Day/Camera Main Script")]
public class TOD_Camera : MonoBehaviour
{
    /// Sky dome reference inspector variable.
    /// Has to be manually set to the sky dome instance.
    public TOD_Sky sky;

    /// Inspector variable to automatically move the sky dome to the camera position in OnPreCull().
    public bool DomePosToCamera = true;

    /// Inspector variable to automatically scale the sky dome to the camera far clip plane in OnPreCull().
    public bool DomeScaleToFarClip = false;

    /// Inspector variable to adjust the sky dome scale factor relative to the camera far clip plane.
    public float DomeScaleFactor = 0.95f;

    private Transform cameraTransform = null;

    #if UNITY_EDITOR
    protected void Update()
    {
        DomeScaleFactor = Mathf.Clamp(DomeScaleFactor, 0.01f, 1.0f);
    }
    #endif

    protected void OnEnable()
    {
        cameraTransform = GetComponent<Transform>();
    }

    protected void OnPreCull()
    {
        if (!sky) return;

        if (DomeScaleToFarClip)
        {
            float size = DomeScaleFactor * GetComponent<Camera>().farClipPlane;
            var localScale = new Vector3(size, size, size);

            #if UNITY_EDITOR
            if (sky.Components.DomeTransform.localScale != localScale)
            #endif
            {
                sky.Components.DomeTransform.localScale = localScale;
            }
        }
        if (DomePosToCamera)
        {
            var position = cameraTransform.position;

            #if UNITY_EDITOR
            if (sky.Components.DomeTransform.position != position)
            #endif
            {
                sky.Components.DomeTransform.position = position;
            }
        }
    }
}
