using UnityEngine;
using System.Collections;

public class FlagPole : MonoBehaviour
{
    public Transform flag;
    public Transform poleBottom;
    public Transform castle;
    public float speed = 4f;
    public int nextWorld = 0;
    public int nextStage = 0;
    public GameObject creditsScroll;
    public GameObject creditsPanel;
    public GameObject hud;
    public Ui ui;

    private bool isActive;


    private void Update()
    {
        if (isActive == true && Input.anyKey)
        {
            GameManager.Instance.LoadLevel(nextWorld, nextStage);
            creditsPanel.SetActive(false);
            creditsScroll.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            hud.gameObject.SetActive(false);
        
            StartCoroutine(MoveTo(flag, poleBottom.position));
            StartCoroutine(LevelCompleteSequence(other.transform));
        }
    }

    private IEnumerator LevelCompleteSequence(Transform player)
    {
        player.GetComponent<PlayerMovement>().enabled = false;

        yield return MoveTo(player, poleBottom.position);
        yield return MoveTo(player, player.position + Vector3.right);
        yield return MoveTo(player, player.position + Vector3.right + Vector3.down);
        yield return MoveTo(player, castle.position);

        player.gameObject.SetActive(false);

        yield return new WaitForSeconds(2f);

        creditsPanel.SetActive(true);
        creditsScroll.SetActive(true);
        isActive = true;
    }

    private IEnumerator MoveTo(Transform subject, Vector3 destination)
    {
        while (Vector3.Distance(subject.position, destination) > 0.125f)
        {
            subject.position = Vector3.MoveTowards(subject.position, destination, speed * Time.deltaTime);
            yield return null;
        }

        subject.position = destination;
    }
}
