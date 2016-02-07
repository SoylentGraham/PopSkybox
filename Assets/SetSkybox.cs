using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class SetSkybox : MonoBehaviour {

	public List<Shader>		SkyboxShaders;
	[Range(0,20)]
	public float			ChangeFrequency = 10;


	[Range(0,20)]
	public float			ChangeCountdown = 0;
	int						SkyboxIndex = 0;

	void Start()
	{
		ChangeCountdown = ChangeFrequency;
	}

	void Update () {

		ChangeCountdown -= Time.deltaTime;

		if (ChangeCountdown < 0) {
			var Shader = SkyboxShaders [SkyboxIndex % SkyboxShaders.Count];

			if (Shader != null && RenderSettings.skybox != null) {
				RenderSettings.skybox.shader = Shader;
			}
			SkyboxIndex++;
			ChangeCountdown = ChangeFrequency;
		}
	}
}
