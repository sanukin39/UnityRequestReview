namespace URR
{
    public class iOSRequestReview : IRequestReview
    {
        public void RequestReview()
        {
#if IOS_UNITY
            UnityEngine.iOS.Device.RequestStoreReview();
#endif
        }
    }
}
