using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityGameFramework.Runtime;

namespace Homer
{
    public class VideoPlay : MonoBehaviour
    {
        public Image BackImg;
        public RawImage vp_RawImage;
        public VideoPlayer vp_Player;
        public AudioSource VideoAudio;
        //public VideoPlayer Video;
        public static string VideoFilePath = "";
        public static bool isEndVideo = false;


        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(LoadToImage(BackImg, "Texture.jpg"));
            vp_RawImage.texture = BackImg.mainTexture;
            vp_Player.url = GetFilePath("", "1", ".MP4");
            vp_Player.Play();
        }

        void Update()
        {
            // Debug.Log(string.Format("{0}, {1}", vp_Player.frame, vp_Player.frameCount));
            if (vp_Player.frame != -1 && (ulong)vp_Player.frame >= (vp_Player.frameCount - 1))
            {
                isEndVideo = true;
                //Debug.Log("播放完毕!");
                Log.Info("播放完毕!");
            }

            if (vp_Player.isPlaying)
            {
                vp_RawImage.texture = vp_Player.texture;
            }

        }

        private string GetFilePath(string foldPath, string fileName, string fileFormat)
        {
            string filePath;
            if (!string.IsNullOrEmpty(foldPath))
            {
                filePath = Application.dataPath + "/StreamingAssets/" + foldPath + "/" + fileName + fileFormat;
            }
            else
            {
                filePath = Application.dataPath + "/StreamingAssets/" + fileName + fileFormat;
            }

            return filePath;
        }

        private IEnumerator LoadToImage(Image _image, string _filePath)
        {
            WWW www = new WWW("file://" + Application.dataPath + "/StreamingAssets/" + _filePath);
            yield return www;

            if (!string.IsNullOrEmpty(www.error))
            {
                Log.Info("load Image {} error!", _filePath);
            }

            if (www.isDone)
            {
                Texture2D text = new Texture2D(64, 64);
                www.LoadImageIntoTexture(text);
                Sprite sprite = Sprite.Create(text, new Rect(0, 0, text.width, text.height), Vector2.zero);
                _image.sprite = sprite;
            }
        }
    }
}

