using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraRotationEndScene : MonoBehaviour
{
    public Transform endPosition;
    public Transform endEnemyPosition;
    public float LerpValue;
    public float time;
    public float duration;
    public PlayerMovement playerMovement;
    public CameraRotation cameraRotation;
    public GameObject Enemy;
    public GameObject BlackSreen;
    public GameObject torch;
    public void EndScene()
    {
        playerMovement.enabled = false;
        cameraRotation.enabled = false;
        Enemy.SetActive(true);
        playerMovement.moveSound.Stop();
        torch.SetActive(false);
        StartCoroutine(end());
    }

    public IEnumerator end()
    {
        Vector3 startValue = Camera.main.transform.position;
        Quaternion startValueRotation = Camera.main.transform.rotation;
        Vector3 startValueEnemy = Enemy.transform.position;
        Quaternion startValueRotationEnemy = Enemy.transform.rotation;
        while (time < duration)
        {
            Camera.main.transform.position = Vector3.Lerp(startValue, endPosition.position, time / duration);
            Camera.main.transform.rotation = Quaternion.Lerp(startValueRotation, endPosition.rotation, time / duration);
            time += Time.deltaTime;
            Enemy.transform.position = Vector3.Lerp(startValueEnemy, endEnemyPosition.position, time / duration);
            Enemy.transform.rotation = Quaternion.Lerp(startValueRotation, endEnemyPosition.rotation, time / duration);
            yield return null;
        }
        yield return new WaitForSecondsRealtime(2);
        BlackSreen.SetActive(true);
        yield return new WaitForSecondsRealtime(2);
        SceneManager.LoadScene(0);
    }
}
