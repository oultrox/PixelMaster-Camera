using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class SnapToPixel : MonoBehaviour {

    private PixelResolution cam;
	private float d;
	
	void Start()
    {
		cam = GetComponentInChildren<PixelResolution>();
		d = 1f / cam.PixelsPerUnit;
	}

	void LateUpdate()
    {
		Vector3 pos = transform.position;
		Vector3 camPos = new Vector3 (pos.x - pos.x % d, pos.y - pos.y % d, pos.z);	
		cam.transform.position = camPos;
	}
}
