using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	public AudioSource fxSource;
	public AudioSource musicSource;

	public static SoundManager instance = null;

	public float lowPitchRate = 0.95f;
	public float highPitchRate = 1.05f;

	// Use this for initialization
	void Awake () {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}

		DontDestroyOnLoad(gameObject);

	}

	public void PlaySingle(AudioClip clip) {
		fxSource.clip = clip;
		fxSource.Play ();
	}

	public void RandomizeSfx(params AudioClip[] clips) {
		int randomIndex = Random.Range (0, clips.Length);
		float randomPitch = Random.Range (lowPitchRate, highPitchRate);

		fxSource.pitch = randomPitch;
		fxSource.clip = clips [randomIndex];
		fxSource.Play ();
	}


	
	// Update is called once per frame
	void Update () {
	
	}
}
