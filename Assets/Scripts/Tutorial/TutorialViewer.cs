using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialViewer : MonoBehaviour
{
    public QuestionHandler questionHandler;

    public GameObject tutorials;

    public List<Tutorial> exercises;

    int currentStep = 0;

    bool canAttack = true;

    private void Start() {
        Invoke("TutorialButtonPressed",1f);
    }

    public void TutorialButtonPressed() {
        if(tutorials.activeSelf) {
            HideTutorial();
        } else {
            tutorials.SetActive(true);
            exercises[questionHandler.question.exerciseNumber].tutorial.SetActive(true);
            currentStep = 0;
            ShowStep();
            canAttack = false;
        }
        
    }

    private void Update() {
        if(!canAttack) {
            Combat.canAttack = false;
        }    
    }

    void ShowStep() {
        foreach(GameObject g in exercises[questionHandler.question.exerciseNumber].Steps) {
            g.SetActive(false);
        }
        exercises[questionHandler.question.exerciseNumber].Steps[currentStep].SetActive(true);
    }

    public void NextStepButtonPressed() {
        currentStep++;
        if(currentStep >= exercises[questionHandler.question.exerciseNumber].Steps.Count) {
            currentStep = 0;
            HideTutorial();
        } else {
            ShowStep();
        }
    }

    void HideTutorial() {
        tutorials.SetActive(false);
        foreach(Tutorial g in exercises) {
            g.tutorial.SetActive(false);
            foreach(GameObject o in g.Steps) {
                o.SetActive(false);
            }
            
        }
        canAttack = true;
        Combat.canAttack = true;
    }

}
[System.Serializable]
public class Tutorial {
    public GameObject tutorial;
    public List<GameObject> Steps;
}
