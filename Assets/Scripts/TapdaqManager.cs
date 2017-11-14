using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tapdaq;

public class TapdaqManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        AdManager.Init();
        AdManager.LoadInterstitial("main_menu");
        AdManager.LaunchMediationDebugger();
    }

    private void OnEnable()
    {
        TDCallbacks.TapdaqConfigLoaded += OnTapdaqConfigLoaded;
        TDCallbacks.AdAvailable += OnAdAvailable;
    }

    private void OnDisable()
    {
        TDCallbacks.TapdaqConfigLoaded -= OnTapdaqConfigLoaded;
        TDCallbacks.AdAvailable -= OnAdAvailable;
    }

    private void OnAdAvailable(TDAdEvent e)
    {
        if (e.adType == "INTERSTITIAL" && e.tag == "main_menu")
        {
            AdManager.ShowInterstitial("main_menu");
        }
    }

    private void OnTapdaqConfigLoaded()
    {
        AdManager.LoadInterstitial("main_menu");
    }
}
