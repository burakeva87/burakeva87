using UnityEngine;

public class _0x4b23f399 : MonoBehaviour
{
    public bool IsCheckScoreEnabled;
    public bool IsLevelIncrementOnWin;
    public bool IsTimerEnabled;
    public bool IsStoryEnabled;
    public bool IsLevelSelectorEnabled;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this.gameObject.GetComponent<_0x4b23f399>();
            DontDestroyOnLoad(this.gameObject);
            this._0x85571834();
        }
        else
        {
            this._0xac7ae924();
            Destroy(this.gameObject);
        }
    }

    public bool IsTutorialEnabled;
    private void _0xac7ae924()
    {
    }

    public bool IsOnlyWinGameEndEnabled;
    public static _0x4b23f399 Instance;
    public bool IsSkipSplashEnabled;
    private void _0x85571834()
    {
        {
#if !B_LOGS
        {
            Debug.unityLogger.logEnabled = false;
            Application.SetStackTraceLogType(LogType.Assert, StackTraceLogType.None);
            Application.SetStackTraceLogType(LogType.Exception, StackTraceLogType.None);
            Application.SetStackTraceLogType(LogType.Warning, StackTraceLogType.None);
            Application.SetStackTraceLogType(LogType.Error, StackTraceLogType.None);
            Application.SetStackTraceLogType(LogType.Log, StackTraceLogType.None);
        }
#endif
        }

        QualitySettings.vSyncCount = 1;
        Application.runInBackground = true;
    //Application.targetFrameRate = 60;
    // Time.fixedDeltaTime = 0.03f; // USE CUSTOM PHYSICS TIME FOR OPTIMIZATION IF NEEDED
    // Add this once at startup to silence the specific assertion
    }

    public bool IsBestScoreEnabled;
}