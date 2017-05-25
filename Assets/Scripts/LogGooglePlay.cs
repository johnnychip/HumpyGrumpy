using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;



public class LogGooglePlay : MonoBehaviour {

	private bool isConnectedToGoogleServices;
	private bool mWaitingForAuth;

	// Use this for initialization
	void Start () {
		PlayGamesPlatform.Activate();
		Social.localUser.Authenticate((bool success) =>
			{
				//ConnectToGoogleServices ();	
			});
		
	}

	public void ConnectToGoogleServices()
	{

		if (mWaitingForAuth)
		{
			return;
		}
			


			if (!Social.localUser.authenticated)
			{
				// Authenticate
				mWaitingForAuth = true;
				
				Social.localUser.Authenticate((bool success) =>
					{
						mWaitingForAuth = false;
						if (success)
						{
						Debug.Log("Wellcome");
						}
						else
						{
						Debug.Log("Authentication Fail");
						}
					});
			}
			else
			{
				((GooglePlayGames.PlayGamesPlatform)Social.Active).SignOut();
			}


	}

	/*public void UnlockAchivment ()
	{
		Social.ReportProgress("CgkItdedyb8cEAIQAQ", 100.0f, (bool success) => {
			// handle success or failure
		});
	}*/



	public void LeaderBoard ()
	{
		if (Social.localUser.authenticated) {
			Social.ShowAchievementsUI ();
		}
	}
}
