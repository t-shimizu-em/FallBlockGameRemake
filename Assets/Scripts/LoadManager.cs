using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class LoadManager : SingletonMonoBehaviour<LoadManager>
{
    protected override bool dontDestroyOnLoad { get { return true; } }

    [SerializeField] private GameObject canvasPrefab;
    [SerializeField] private float loadTime = 3.0f;

    private GameObject _canvas;
    private GameObject _loadScreen;
    private Image _loadScreenColor;
    private TextMeshProUGUI _loadText;
    private Slider _slider;
    private AsyncOperation _async;

    void Start()
    {
        // シーンの切り替えを検知してフェードアウト処理を実行
        SceneManager.activeSceneChanged += ActiveSceneChanged;
    }

    // ロードプレハブ生成＆ロード処理
    public void FirstLoadScene(string scene)
    {
        _canvas = Instantiate(canvasPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        DontDestroyOnLoad(_canvas);
        _loadScreenColor = _canvas.transform.Find("LoadScreen").GetComponent<Image>();
        _slider = _canvas.transform.Find("Slider").gameObject.GetComponent<Slider>();
        _loadText = _canvas.transform.Find("LoadingText").gameObject.GetComponent<TextMeshProUGUI>();

        StartCoroutine(LoadScene(scene));
    }

    // ロード処理
    public IEnumerator LoadScene(string scene)
    {
        float fadeTime = 1;
        float t = 0;

        _canvas.gameObject.SetActive(true);
        _slider.gameObject.SetActive(false);
        _loadText.gameObject.SetActive(false);

        while (t < fadeTime)
        {
            _loadScreenColor.color = new Color(0, 0, 0, t);
            t += Time.deltaTime;
            yield return null;
        }

        _loadScreenColor.color = new Color(0, 0, 0, 1);

        _slider.gameObject.SetActive(true);
        _loadText.gameObject.SetActive(true);

        _async = SceneManager.LoadSceneAsync(scene);
        _async.allowSceneActivation = false;

        t = 0;
        _slider.value = 0;

        StartCoroutine(CommaAnimation());

        while (t < loadTime)
        {
            _slider.value = t / loadTime;
            t += Time.deltaTime;
            yield return null;
        }

        _slider.value = 1;

        _slider.gameObject.SetActive(false);
        _loadText.gameObject.SetActive(false);
        _async.allowSceneActivation = true;
    }

    private void ActiveSceneChanged(Scene prevScene, Scene nextScene)
    {
        StartCoroutine(FadeOutLoadPanel());
    }

    private IEnumerator FadeOutLoadPanel()
    {
        float fadeTime = 1;

        while (fadeTime > 0)
        {
            _loadScreenColor.color = new Color(0, 0, 0, fadeTime);
            fadeTime -= Time.deltaTime;
            yield return null;
        }

        _loadScreenColor.color = new Color(0, 0, 0, 0);

        _canvas.gameObject.SetActive(false);
    }

    private IEnumerator CommaAnimation()
    {
        float countTime = 0;
        float t = 0;
        float maxTime = 0.2f;
        _loadText.text = "NowLoading";

        while (countTime < loadTime)
        {
            countTime += Time.deltaTime;
            t += Time.deltaTime;
            if (t > maxTime)
            {
                if (_loadText.text == "NowLoading...")
                {
                    _loadText.text = "NowLoading";
                }
                else
                {
                    _loadText.text += ".";
                }
                t = 0;
            }
            yield return null;
        }
    }
}
