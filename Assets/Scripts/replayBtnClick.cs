using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class replayBtnClick : MonoBehaviour
{
    public void replayBtn_Click(){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
