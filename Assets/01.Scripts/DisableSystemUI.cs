using UnityEngine;

public class DisableSystemUI
{
#if UNITY_ANDROID

    private static AndroidJavaObject activityInstance;

    private static AndroidJavaObject windowInstance;

    private static AndroidJavaObject viewInstance;

    private const int SYSTEM_UI_FLAG_HIDE_NAVIGATION = 2;

    private const int SYSTEM_UI_FLAG_LAYOUT_STABLE = 256;

    private const int SYSTEM_UI_FLAG_LAYOUT_HIDE_NAVIGATION = 512;

    private const int SYSTEM_UI_FLAG_LAYOUT_FULLSCREEN = 1024;

    private const int SYSTEM_UI_FLAG_IMMERSIVE = 2048;

    private const int SYSTEM_UI_FLAG_IMMERSIVE_STICKY = 4096;

    private const int SYSTEM_UI_FLAG_FULLSCREEN = 4;

    public delegate void RunPtr();

    public static void Run()

    {
        if (viewInstance != null)
        {
            viewInstance.Call("setSystemUiVisibility",

                              SYSTEM_UI_FLAG_LAYOUT_STABLE

                              | SYSTEM_UI_FLAG_LAYOUT_HIDE_NAVIGATION

                              | SYSTEM_UI_FLAG_LAYOUT_FULLSCREEN

                              | SYSTEM_UI_FLAG_HIDE_NAVIGATION

                              | SYSTEM_UI_FLAG_FULLSCREEN

                              | SYSTEM_UI_FLAG_IMMERSIVE_STICKY);
        }
    }

#endif

    public static void DisableNavUI()

    {
        if (Application.platform != RuntimePlatform.Android)

            return;

#if UNITY_ANDROID

        using (AndroidJavaClass unityPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))

        {
            activityInstance = unityPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");

            windowInstance = activityInstance.Call<AndroidJavaObject>("getWindow");

            viewInstance = windowInstance.Call<AndroidJavaObject>("getDecorView");

            AndroidJavaRunnable RunThis;

            RunThis = new AndroidJavaRunnable(new RunPtr(Run));

            activityInstance.Call("runOnUiThread", RunThis);
        }

#endif
    }
}