using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class wiinGame : MonoBehaviour
{
    static int endGame = 4;
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
    if (hit.collider.gameObject.layer == LayerMask.NameToLayer("endGame"))
    {
        SceneManager.LoadScene(endGame);
    }
    }
}
