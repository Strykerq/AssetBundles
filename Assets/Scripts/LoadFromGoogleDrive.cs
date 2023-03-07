using System.Collections;
using UnityEngine;

public class LoadFromGoogleDrive : MonoBehaviour
{
    private string _url = "https://drive.google.com/uc?export=download&confirm=no_antivirus&id=1Bxv6zPIAkjhTq-0wwFeLgogXAJ7kcdTw";

    [SerializeField] AudioSource source;
    [SerializeField] SpriteRenderer render;

    public void OnClickDownload()
    {
        StartCoroutine(Download());
    }

    IEnumerator Download()
    {
        var www = WWW.LoadFromCacheOrDownload(_url,0);
        yield return www;

        Debug.Log("Download");
        var assetBundle = www.assetBundle;
        string musicname = "phonk.mp3";
        string spritename = "fighter.png";

        var musicRequest = assetBundle.LoadAssetAsync(musicname, typeof(AudioClip));
        yield return musicRequest;
        Debug.Log("Music Download");
        var spriteRequest = assetBundle.LoadAssetAsync(spritename, typeof(Sprite));
        yield return spriteRequest;
        Debug.Log("Sprite Download");
        
        source.clip = musicRequest.asset as AudioClip;
        source.Play();
        render.sprite = spriteRequest.asset as Sprite;
    }
}
