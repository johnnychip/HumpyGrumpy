using UnityEngine;
using UnityEngine.Advertisements;

public class ShowAdd : MonoBehaviour
{
	public void ShowAd()
	{
		if (Advertisement.IsReady())
		{
			Advertisement.Show();
		}
	}
}
