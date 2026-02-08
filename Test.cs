using NgoUyenNguyen;
using UnityEngine;

[RequireComponent(typeof(TweenController))]
public class Test : MonoBehaviour
{
    private void Update()
    {
        var tc = GetComponent<TweenController>();
        if (Input.GetKeyDown(KeyCode.Space))
            tc.Play(0);
        
        if (Input.GetKeyDown(KeyCode.P))
            tc.Pause(0);
        
        if (Input.GetKeyDown(KeyCode.C))
            tc.Cancel(0);
        
        if (Input.GetKeyDown(KeyCode.R))
            tc.Resume(0);
    }
}
