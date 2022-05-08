using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

///<summary>
/// Makes an object point to whatever camera is currently rendering. <br/>
/// <b>NOTE</b>: Only tested with the Universal Render Pipeline.
///</summary>
public class Billboard : MonoBehaviour {

	public enum Mode {
		X,
		XY
	}

	public Mode m_Mode = Mode.X;

	protected Transform T {
		get {
			if(t == null) t = transform;
			return t;
		}
	}
	private Transform t;


	private void Awake() {
		RenderPipelineManager.beginCameraRendering += BeginCameraRendering;
	}
	private void OnDestroy() {
		RenderPipelineManager.beginCameraRendering -= BeginCameraRendering;
	}

	private void BeginCameraRendering(ScriptableRenderContext context, Camera cam) {
		if(!Application.isPlaying) return;

		var quaternion = Quaternion.LookRotation(T.position - cam.transform.position);
		if(m_Mode == Mode.X) quaternion = Quaternion.Euler(T.rotation.x, quaternion.eulerAngles.y, quaternion.eulerAngles.z);
		T.rotation = quaternion;
	}

}
