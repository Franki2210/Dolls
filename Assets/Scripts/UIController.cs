using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    private GameController gameController;
    public GirlController girlController;
    public Color activeColor;

    public ColorPicker colorPicker;

    public Button moveButton;
    public Button rotateButton;
    public Button changeColorButton;
    public Button changeClothColorBtn;
    public Button changeSkinColorBtn;
    public Button recordButton;

    private bool _isMoveBtnActive;
    private bool _isRotateBtnActive;
    private bool _isChangeColorBtnActive;
    private bool _isChangeClothColorBtnActive;
    private bool _isChangeSkinColorBtnActive;
    private bool _isRecordBtnActive;

    void Start() {
        gameController = GetComponent<GameController>();
        _isMoveBtnActive = false;
        _isRotateBtnActive = false;
        _isRecordBtnActive = false;
        _isChangeColorBtnActive = false;
        _isChangeClothColorBtnActive = false;
        _isChangeSkinColorBtnActive = false;
    }

    public void ClickMoveButton() {
        if (_isMoveBtnActive) {
            _isMoveBtnActive = false;
            DeactivateButton(moveButton);
            gameController.mode = GameController.Mode.ControlGirl;
            return;
        }

        gameController.mode = GameController.Mode.MoveInterior;
        _isMoveBtnActive = true;
        _isRotateBtnActive = false;
        _isChangeColorBtnActive = false;
        ActivateButton(moveButton);
        DeactivateButton(rotateButton);
        DeactivateButton(changeColorButton);
    }
    public void ClickRotateButton() {
        if (_isRotateBtnActive) {
            _isRotateBtnActive = false;
            DeactivateButton(rotateButton);
            gameController.mode = GameController.Mode.ControlGirl;
            return;
        }
        gameController.mode = GameController.Mode.RotateInterior;
        _isRotateBtnActive = true;
        _isMoveBtnActive = false;
        _isChangeColorBtnActive = false;
        ActivateButton(rotateButton);
        DeactivateButton(moveButton);
        DeactivateButton(changeColorButton);
    }
    public void ClickChangeColorButton() {
        if (_isChangeColorBtnActive) {
            _isChangeColorBtnActive = false;
            _isChangeClothColorBtnActive = false;
            _isChangeSkinColorBtnActive = false;
            DeactivateButton(changeColorButton);
            DeactivateButton(changeClothColorBtn);
            DeactivateButton(changeSkinColorBtn);
            ShowButton(moveButton);
            ShowButton(rotateButton);
            HideButton(changeClothColorBtn);
            HideButton(changeSkinColorBtn);
            colorPicker.gameObject.SetActive(false);
            gameController.mode = GameController.Mode.ControlGirl;
            return;
        }
        gameController.mode = GameController.Mode.ChangeClothColor;
        _isChangeColorBtnActive = true;
        _isChangeClothColorBtnActive = true;
        _isMoveBtnActive = false;
        _isRotateBtnActive = false;
        ActivateButton(changeColorButton);
        ActivateButton(changeClothColorBtn);
        DeactivateButton(moveButton);
        DeactivateButton(rotateButton);
        HideButton(moveButton);
        HideButton(rotateButton);
        ShowButton(changeClothColorBtn);
        ShowButton(changeSkinColorBtn);
        colorPicker.gameObject.SetActive(true);
        girlController.InitColor();
    }
    
    public void ClickChangeSkinColorButton() {
        if (_isChangeSkinColorBtnActive) {
            return;
        }
        gameController.mode = GameController.Mode.ChangeSkinColor;
        _isChangeClothColorBtnActive = false;
        _isChangeSkinColorBtnActive = true;
        ActivateButton(changeSkinColorBtn);
        DeactivateButton(changeClothColorBtn);
        girlController.InitColor();
    }
    
    public void ClickChangeClothColorButton() {
        if (_isChangeClothColorBtnActive) {
            return;
        }
        gameController.mode = GameController.Mode.ChangeClothColor;
        _isChangeSkinColorBtnActive = false;
        _isChangeClothColorBtnActive = true;
        ActivateButton(changeClothColorBtn);
        DeactivateButton(changeSkinColorBtn);
        girlController.InitColor();
    }
    
    public void ClickRecordButton() {
        if (_isRecordBtnActive) {
            _isRecordBtnActive = false;
            DeactivateButton(recordButton);
            return;
        }
        _isRecordBtnActive = true;
        ActivateButton(recordButton);
    }

    private void ActivateButton(Button btn) {
        btn.gameObject.GetComponent<Image>().color = activeColor;
    }

    private void DeactivateButton(Button btn) {
        btn.gameObject.GetComponent<Image>().color = Color.white;
    }

    private void HideButton(Button btn) {
        btn.gameObject.SetActive(false);
    }
    
    private void ShowButton(Button btn) {
        btn.gameObject.SetActive(true);
    }

    public void SetColorToColorPicker(Color color) {
        colorPicker.CurrentColor = color;
    }
}
