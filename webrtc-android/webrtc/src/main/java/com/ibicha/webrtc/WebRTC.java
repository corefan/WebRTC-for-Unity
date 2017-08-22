package com.ibicha.webrtc;

import android.app.Activity;
import android.opengl.EGL14;
import android.opengl.EGLContext;
import android.util.Log;
import android.widget.Toast;

import org.webrtc.ScreenCapturerAndroid;
import org.webrtc.VideoRenderer;
import org.webrtc.VideoTrack;

import java.lang.reflect.Field;

/**
 * Created by bhadriche on 7/31/2017.
 */

public class WebRTC  {
    private static final String TAG = WebRTC.class.getSimpleName();

    static final boolean HW_ACCELERATE = true;

    private static Activity getMainActivity() {
        try {
            Class<?> unityPlayerClass = Class.forName("com.unity3d.player.UnityPlayer");
            Field currentActivityField = unityPlayerClass.getDeclaredField("currentActivity");
            return (Activity) currentActivityField.get(null);
        } catch (ClassNotFoundException | NoSuchFieldException | IllegalAccessException e) {
            e.printStackTrace();
        }
        return null;
    }

    public static void StartScreenCapture(VideoCallback callback, float resolution) {
        VideoCapture.getInstance().StartScreenCapture(getMainActivity(), callback, resolution);
    }

    public static void StartCameraCapture(boolean fontCamera, VideoCallback callback) {
        VideoCapture.StartCameraCapture(getMainActivity(), fontCamera, callback);
    }

    private static Toast logToast;
    private static void logAndToast(String msg) {
        Log.d(TAG, msg);
        if (logToast != null) {
            logToast.cancel();
        }
        logToast = Toast.makeText(getMainActivity(), msg, Toast.LENGTH_SHORT);
        logToast.show();
    }

}
