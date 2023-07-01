using UnityEngine;

namespace URR
{
    public class EditorRequestReview : IRequestReview
    {
        public void RequestReview()
        {
            Debug.Log("Request Review");
        }
    }
}
