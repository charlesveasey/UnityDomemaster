using UnityEngine;
using System.Collections;

#if SHIPPING_NOT
[ExecuteInEditMode]
#endif
/*
* DomeCamera
* This class links to the DomeCamera prefab and syncs the 
* properties of the DomeCamera with either a user specified
* target or the current main camera.
*/
public class DomeCamera : MonoBehaviour {

    public Camera Target;                               // Camera target
    private Camera[] DomeCameras;					    // The 5 cameras of the DomeCamera rig

#if SHIPPING
    private int StoredCullingMask;                      // Stored culling mask property of the camera
    private CameraClearFlags StoredClearFlags;          // Stored cleared flags property of the camera
    bool TargetResetPending = false;                    // flag to signal the target camera's rending properties should be reset
#endif

    void Awake () {
        // try to sync to camera object with tag: MainCamera
        if (Target == null){
            Target = Camera.main;
            return; // if target is null then bail
        }

#if SHIPPING_NOT
        // store properties that are used to turn off the target camera's rendering
        StoredClearFlags = Target.clearFlags;
        StoredCullingMask = Target.cullingMask;
#endif
        // sync the dome cameras rendering properties to target camera
        DomeCameras = GetComponentsInChildren<Camera>();
        foreach (Camera item in DomeCameras){
            item.clearFlags = Target.clearFlags;
            item.cullingMask = Target.cullingMask;
            item.farClipPlane = Target.farClipPlane;
            item.nearClipPlane = Target.nearClipPlane;
            item.useOcclusionCulling = Target.useOcclusionCulling;
            item.hdr = Target.hdr;
            item.backgroundColor = Target.backgroundColor;
        }

        // disable the rendering of the target camera
        Target.clearFlags = CameraClearFlags.Nothing;
        Target.cullingMask = 0;
#if SHIPPING_NOT
        TargetResetPending = true;
#endif
    }


    void Update () {
        // target is null then bail
        if (Target == null)
            return;

        // update the transforms to the target camera
        transform.position = Target.transform.position;
        transform.rotation = Target.transform.rotation;

#if SHIPPING_NOT
        if (!UnityEditor.EditorApplication.isPlaying) {
            // reset the cameras render properties of the target camera on stop
            if (TargetResetPending) {
                Target.clearFlags = StoredClearFlags;
                Target.cullingMask = StoredCullingMask;
                TargetResetPending = false;
            }
            
            // update the rendering properties of the camera target
            DomeCameras = GetComponentsInChildren<Camera>();
            foreach (Camera item in DomeCameras){
                item.clearFlags = Target.clearFlags;
                item.cullingMask = Target.cullingMask;
            }
        }
#endif
    }

}
