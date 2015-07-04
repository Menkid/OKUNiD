using UnityEngine;
using System.Collections;

public class WebCamSobel : MonoBehaviour {

	public WebCamTexture mCamera = null;
	public GameObject plane;

	public float finalX;
	public float finalY;
	public bool firing;

	private Texture2D image;

	public float hueMin;
	public float hueMax;
	public float bMin;
	public float bMax;
	public float sMin;
		
		// Use this for initialization
		void Start ()
		{
			Debug.Log ("Script has been started");
			plane = GameObject.FindWithTag ("Player");
			
			mCamera = new WebCamTexture ();
		if (mCamera != null) {
			print("no webcam");
		}
		mCamera.Play ();
			
		}
		
		// Update is called once per frame
		void Update (){
			if (mCamera != null) {
				image = HsbFilter ();
				computeCenter (image);
				//Texture renderer = plane.GetComponent<Texture> ();
				//Component renderer = plane.GetComponent<Renderer> ();
				//renderer= image;
				}
			}


		void computeCenter(Texture2D image){
		float sumX = 0;
		float sumY = 0;
		float centerX = image.width / 2;
		float centerY = image.height / 2;
		for (int x = 0; x<image.width; x++) {
			for (int y = 0; y<image.height; y++) {
				if (image.GetPixel (x, y) == new Color (255, 255, 255)) {
					sumY = sumY + y;
					sumX = sumX + x;
				}
			}
		}

		float moyenneX = sumX / image.width;
		float moyenneY = sumY / image.height;

		finalX = moyenneX;
		finalY = moyenneY;
		Color color1 = new Color (25, 52, 23);
		image.SetPixel ((int)centerX, (int)centerY, color1);
		image.SetPixel ((int)finalX, (int)finalY, new Color (44, 78, 192));

	}

		private Texture2D HsbFilter(){
			int width = mCamera.width;
			int height = mCamera.height;
		
			//int totPixels = width * height;

			Texture2D result = new Texture2D(width,height);
	
			for (int x = 0; x<width; x++) {
				for (int y = 0; y<height; y++) {

					Color c = mCamera.GetPixel (x, y);
				
					float red = c.r;
					float blue = c.b;
					float green = c.g;

					float r = red / 255;
					float g = green / 255;
					float b = blue / 255;

					float Cmax = Mathf.Max (r, g, b);
					float Cmin = Mathf.Min (r, g, b);

					float delta = Cmax - Cmin;

					//HUE
					float Hue = 0;
					if (Cmax == r){
						Hue = (Mathf.PI / 3) * (((g - b) / delta) % 6);
					}
					if (Cmax == g){
						Hue = (Mathf.PI / 3) * (((b - r) / delta) + 2);
					}	
					if (Cmax == b){
						Hue = (Mathf.PI / 3) * (((r - g) / delta) + 4);
					}
					//SATURATION
					float Sat = 0;
					if (Cmax > 0){
						Sat = delta / Cmax;
					}
					float brightness = Cmax;

					if (Hue >= hueMin && Hue < hueMax && brightness >= bMin && brightness < bMax && Sat >= sMin) {
						result.SetPixel (x, y,new Color (255, 255, 255));
					} else {
						result.SetPixel (x, y,new Color (0, 0, 0));
					}	
			}
		}
				return result;
	}
}
