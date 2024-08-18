using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingCutsceneDirector : MonoBehaviour
{
    GameObject playerFuture;
    GameObject playerPast;
    TimelineSwitcher timelineSwitcher;
    public GameObject screenFader;
    public GameObject messageBoxHolder;
    public GameObject messageBoxPrefab;
    public GameObject titleScene;

    void OnEnable()
    {
        timelineSwitcher = FindAnyObjectByType<TimelineSwitcher>();
        playerFuture = timelineSwitcher.playerFuture;
        playerPast = timelineSwitcher.playerPast;

        StartCoroutine(PlayCutscene());
    }

    IEnumerator PlayCutscene()
    {
        // Init
        SetPlayerXPosition(95.5f);
        playerPast.GetComponent<PlayerMove>().enabled = false;
        playerPast.GetComponent<PlayerAnimate>().animationFps = 4;
        playerFuture.GetComponent<PlayerMove>().enabled = false;
        playerFuture.GetComponent<PlayerAnimate>().animationFps = 4;

        Past();
        playerPast.SendMessage("AnimateSeeFront");

        // Fade in
        if (screenFader != null)
        {
            screenFader.SetActive(true);
            screenFader.GetComponent<CanvasGroup>().alpha = 1.0f;
            while (screenFader.GetComponent<CanvasGroup>().alpha > 0.0f)
            {
                screenFader.GetComponent<CanvasGroup>().alpha -= Time.deltaTime / 2.0f;
                yield return null;
            }
        }

        yield return MoveBy(-2.5f);
        yield return new WaitForSeconds(5.0f);

        Future();
        yield return new WaitForSeconds(5.0f);
        ShowText("맞아. 이제 다 기억났어.");
        yield return new WaitForSeconds(5.0f);

        Past();
        yield return MoveBy(-1.25f);
        yield return new WaitForSeconds(5.0f);

        Future();
        yield return new WaitForSeconds(0.5f);
        yield return MoveBy(-1.25f);
        ShowText("나는 다가오는 미래를 보았어.");
        yield return new WaitForSeconds(2.0f);
        yield return MoveBy(1.0f);
        yield return new WaitForSeconds(2.0f);
        ShowText("하지만 내가 할 줄 아는 건 기계공학.");
        yield return new WaitForSeconds(0.5f);
        yield return MoveBy(1.0f);
        yield return new WaitForSeconds(5f);

        Past();
        ShowText("죽을 병을 고치는 방법 같은 건 배운 적 없었지.");
        yield return new WaitForSeconds(1f);
        yield return MoveBy(1f);
        yield return new WaitForSeconds(0.25f);
        yield return MoveBy(-1f);
        yield return new WaitForSeconds(0.25f);
        yield return MoveBy(1f);
        yield return new WaitForSeconds(0.25f);
        yield return MoveBy(-2.0f);
        yield return new WaitForSeconds(0.5f);
        ShowText("\"이제 내 기억만 넣어 주면 돼.\"");
        yield return new WaitForSeconds(6f);

        Future();
        ShowText("그래서 나는 또 다른 나를 만들었어.");
        yield return new WaitForSeconds(4f);
        ShowText("아마 계획은 완벽했을 거야.");
        yield return MoveBy(0.5f);
        yield return new WaitForSeconds(5f);

        Past();
        ShowText("\"시간이 없는데...\"");
        yield return MoveBy(1f);
        yield return new WaitForSeconds(0.5f);
        yield return MoveBy(-1f);
        yield return new WaitForSeconds(0.5f);
        yield return MoveBy(1f);
        yield return new WaitForSeconds(0.5f);
        yield return MoveBy(-1f);
        yield return new WaitForSeconds(0.5f);

        Future();
        yield return new WaitForSeconds(2.0f);
        yield return MoveBy(2f);
        ShowText("뭘 좀 잘못 계산해서 수십 년쯤 늦잠을 자긴 했지만...");
        yield return new WaitForSeconds(4.0f);
        playerFuture.SendMessage("AnimateSetDirection", -1);
        yield return new WaitForSeconds(2.0f);

        screenFader.SetActive(true);
        screenFader.GetComponent<CanvasGroup>().alpha = 1.0f;
        screenFader.GetComponent<AudioSource>().Play();

        ShowText("그러고 보니 바깥 공기는 오랜만이네");
        yield return new WaitForSeconds(3.7f);
        ShowText("살아있을 때 봤다면 많이 신기했을 거야.");
        yield return new WaitForSeconds(5f);
        ShowText("아마, 그랬겠지?");

        yield return new WaitForSeconds(10.0f);

        // 씬 전환
        UnityEngine.SceneManagement.SceneManager.LoadScene("TitleScene");
    }

    IEnumerator MoveTo(float x, float duration)
    {
        var activePlayer = timelineSwitcher.isPastActive ? playerPast : playerFuture;
        var lerpFrom = activePlayer.transform.position.x;
        var direction = Mathf.Sign(x - lerpFrom);

        float time = 0.0f;
        while (time < duration)
        {
            time += Time.deltaTime;
            SetPlayerXPosition(Mathf.Lerp(lerpFrom, x, time / duration));
            activePlayer.SendMessage("AnimateMovement", direction);
            yield return null;
        }
        activePlayer.SendMessage("AnimateMovement", (object) 0.0f);
    }

    IEnumerator MoveBy(float x)
    {
        var moveTime = Mathf.Abs(x / 1.5f);
        return MoveTo(playerFuture.transform.position.x + x, moveTime);
    }

    void SetPlayerXPosition(float x)
    {
        playerFuture.transform.position = new Vector3(x, playerFuture.transform.position.y, playerFuture.transform.position.z);
        playerPast.transform.position = new Vector3(x, playerPast.transform.position.y, playerPast.transform.position.z);
    }

    void ShowText(string text)
    {
        var messageBox = Instantiate(messageBoxPrefab, messageBoxHolder.transform);
        messageBox.GetComponent<MessageBox>().content = text;
        messageBox.transform.SetAsFirstSibling();
    }

    void Past() => timelineSwitcher.SwitchToPast();
    void Future() => timelineSwitcher.SwitchToFuture();
}
