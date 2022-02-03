using UnityEngine;
using UnityEngine.Advertisements;

namespace Services.Ads
{
    public class AdsService : IAdsService, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
    {
        private const string IOSGameID = "4593624";
        private const string AndroidGameID = "4593625";

        private const string IOSBannerPlacementID = "Banner_iOS";
        private const string AndroidBannerPlacementID = "Banner_Android";

        private string _gameId;
        private string _bannerPlacementId;

        public void Initialize()
        {
            switch (Application.platform)
            {
                case RuntimePlatform.IPhonePlayer:
                    _gameId = IOSGameID;
                    _bannerPlacementId = IOSBannerPlacementID;
                    break;
                case RuntimePlatform.Android:
                    _gameId = AndroidGameID;
                    _bannerPlacementId = AndroidBannerPlacementID;
                    break;
                case RuntimePlatform.WindowsEditor:
                    _gameId = IOSGameID;
                    _bannerPlacementId = IOSBannerPlacementID;
                    break;
                default:
                    Debug.Log("Platform not found");
                    break;
            }
            
            Advertisement.Initialize(_gameId, true, this);
        }

        public void ShowBanner()
        {
            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
            Advertisement.Banner.Show(_bannerPlacementId);
        }

        public void HideBanner()
        {
            Advertisement.Banner.Hide();
        }

        public void OnInitializationComplete()
        {
            Advertisement.Load(_bannerPlacementId, this);
            Debug.Log("OnInitializationComplete");
        }

        public void OnInitializationFailed(UnityAdsInitializationError error, string message) =>
            Debug.Log($"OnInitializationFailed {error} {message}");

        public void OnUnityAdsAdLoaded(string placementId) =>
            Debug.Log($"OnUnityAdsAdLoaded {placementId}");

        public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message) =>
            Debug.Log($"OnUnityAdsFailedToLoad {placementId} {error} {message}");

        public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message) => 
            Debug.Log($"OnUnityAdsShowFailure {placementId} {error} {message}");

        public void OnUnityAdsShowStart(string placementId) =>
            Debug.Log($"OnUnityAdsShowStart {placementId}");

        public void OnUnityAdsShowClick(string placementId) => 
            Debug.Log($"OnUnityAdsShowClick {placementId}");

        public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState) =>
            Debug.Log($"OnUnityAdsShowComplete {placementId} {showCompletionState}");
    }
}