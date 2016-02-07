using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	public Transform	mCameraPositioner;
	public Transform	mCamera;
	[Range(0,10)]
	public float		mFlySpeed = 1;
	[Range(0,10)]
	public float		mPanSpeed = 1;


	Vector2?			mDragStart;

	void Start () {
		if (mCamera == null)
			mCamera = Camera.main.transform;
	
	}
	
	void Update () {
	
		if ( !Input.GetMouseButton(0) )
		{
			mDragStart = null;
			return;
		}

		//	first touch
		if (mDragStart == null)
			mDragStart = Input.mousePosition;

		var Mouse2 = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
		Vector2 Delta2 = (Mouse2 - mDragStart.Value);

#if UNITY_ANDROID
		Delta2.x *= -1.0f;
		Delta2 *= 1.3f;
#endif

		Delta2.Scale( new Vector2( 1.0f/Screen.width, 1.0f/Screen.height ) );

		Delta2.Scale (new Vector2 (mFlySpeed, mPanSpeed));
		Debug.Log("Mouse delta = " + Mouse2 );

		mCameraPositioner.transform.position += mCamera.transform.forward * Delta2.x;
		mCameraPositioner.transform.position += mCamera.transform.up * Delta2.y;

	}
}
