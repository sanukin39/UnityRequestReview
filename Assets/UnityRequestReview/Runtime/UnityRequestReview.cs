namespace URR
{
    public class UnityRequestReview
    {
        private static IRequestReview _requestReview;

        public static void RequestReview()
        {
            _requestReview ??= GenerateRequestReview();
            _requestReview.RequestReview();
        }


        private static IRequestReview GenerateRequestReview()
        {
#if UNITY_IOS
return new iOSRequestReview();
#elif UNITY_ANDROID
            return new AndroidRequestReview();
#else
                return new EditorRequestReview();
#endif
        }
    }
}