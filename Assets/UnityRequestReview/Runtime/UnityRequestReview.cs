#if UNITY_ANDROID
using Google.Play.Review;
#endif
using UnityEngine;

namespace URR
{
    public class UnityRequestReview : MonoBehaviour
    {
        private static UnityRequestReview _instance;
        public static UnityRequestReview Instance => _instance;

        void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }

            DontDestroyOnLoad(gameObject);
        }


        public void RequestReview()
        {
#if UNITY_EDITOR
            Debug.Log("Review Requested");
#elif UNITY_IOS
UnityEngine.iOS.Device.RequestStoreReview();
#elif UNITY_ANDROID
            StartCoroutine(AndroidRequestReview());
#endif
        }

#if UNITY_ANDROID

        private IEnumerator AndroidRequestReview()
        {
            var reviewManager = new ReviewManager();
            var requestFlowOperation = reviewManager.RequestReviewFlow();
            yield return requestFlowOperation;
            if (requestFlowOperation.Error != ReviewErrorCode.NoError)
            {

                yield break;
            }

            var playReviewInfo = requestFlowOperation.GetResult();

            var launchFlowOperation = reviewManager.LaunchReviewFlow(playReviewInfo);
            yield return launchFlowOperation;
            if (launchFlowOperation.Error != ReviewErrorCode.NoError)
            {
                yield break;
            }
        }
#endif
    }
}