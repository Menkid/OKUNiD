using UnityEngine;
using System.Collections;

public class PlanctonPoint : MonoBehaviour {
	public int points = 1;
    public int mutation = 0;
	public int lifeTime = 0;
	public bool isEnemy = false;
    public int levelToLoadOnDeath = -1;
    public string alternateLvlToLoad = null;
	
	// Use this for initialization
	void Start()
	{
		if (lifeTime == 0)
		{
			return;
		}
		Destroy(gameObject, lifeTime);
	}

    void OnDestroy()
    {
        if (levelToLoadOnDeath >= 0)
        {
            Application.LoadLevel(levelToLoadOnDeath);
        }
        else if (alternateLvlToLoad != null)
        {
            Application.LoadLevel(alternateLvlToLoad);
        }
    }
}
