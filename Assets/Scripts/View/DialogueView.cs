using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class DialogueView : MonoBehaviour
{
    public UIUtil uiUtil;
    private string _onePath = "Frame/Buttons/One";
    private string _twoPath = "Frame/Buttons/Two";
    private string _yesBtn = "/Yes";
    private string _noBtn = "/No";
    private int _up = 40;
    private int _offset = 40;
    private int _maxWidth = 550;
    private int _minWidth = 330;
    private int _leftAndRight = 60;
    public void InitDialogue(string content, Action yesAction = null, Action noAction = null)
    {
        if (uiUtil == null)
        {
            uiUtil = gameObject.AddComponent<UIUtil>();
            uiUtil.Init();
        }
        UpdateDialogueContent(content);
        AddAction(yesAction,noAction);
        CoroutineMgr.Instance.ExecuteOnce(ChangeSize());
    }

    private IEnumerator ChangeSize()
    {
        yield return null;
        var content = uiUtil.Get("Frame/Content").RectTrans;
        var button = uiUtil.Get("Frame/Buttons").RectTrans;
        var frame =uiUtil.Get("Frame").RectTrans;
        yield return null;
        SetFrameWidth(content,frame);
        yield return null;
        SetY(content,button,frame);
    }

    private void SetY(RectTransform content,RectTransform button,RectTransform frame)
    {
        SetContentY(content);
        SetButtonY(content,button);
        SetFrameY(content,button,frame);
    }

    private void SetFrameWidth(RectTransform content,RectTransform frame)
    {
        var width = _leftAndRight * 2 + content.rect.width;
        if (width < _minWidth)
        {
            width = _minWidth;
        }
        else if (width > _maxWidth)
        {
            width = _maxWidth + _leftAndRight*2;
            
            content.gameObject.AddComponent<LayoutElement>().preferredWidth = _maxWidth;
        }
        var pos = frame.sizeDelta;
        pos.x = width;
        frame.sizeDelta = pos;
    }

    private void SetContentY(RectTransform content)
    {
        var pos = content.anchoredPosition;
        pos.y = -(_up + content.rect.height / 2);
        content.anchoredPosition = pos;
    }

    private void SetButtonY(RectTransform content,RectTransform button)
    {

        var pos = button.anchoredPosition;
        pos.y = -(_up + content.rect.height + _offset + button.rect.height / 2);
        button.anchoredPosition = pos;
    }

    private void SetFrameY(RectTransform content, RectTransform button,RectTransform frame)
    {
        var pos = frame.sizeDelta;
        pos.y = _up * 2 + content.rect.height + button.rect.height + _offset;
        frame.sizeDelta = pos;
    }

    private void UpdateDialogueContent(string content)
    {
        transform.Find("Frame/Content").GetComponent<Text>().text = content;
    }

    private void AddAction(Action yesAction, Action noAction)
    {
        if (yesAction == null && noAction == null)
        {
            SetButtonState(true);
            AddOneBtnAction(yesAction);
        }
        else if (yesAction == null && noAction != null)
        {
            Debug.LogError("当前回调添加有问题");
            AddOneBtnAction(yesAction);
        }
        else if (yesAction != null && noAction == null)
        {
            AddOneBtnAction(yesAction);
        }
        else
        {
            AddTwoBtnAction(yesAction,noAction);
        }
    }

    private void SetButtonState(bool isOne)
    {
        transform.Find(_onePath).gameObject.SetActive(isOne);
        transform.Find(_twoPath).gameObject.SetActive(!isOne);
    }
    
    private void AddOneBtnAction(Action callBack)
    {
        if (callBack == null)
        {
            //todo::back
        }
        else
        { 
            transform.AddButtonAction(_onePath+_yesBtn,callBack);
        }
    }

    private void AddTwoBtnAction(Action yesAction, Action noAction)
    {
        transform.AddButtonAction(_twoPath+_yesBtn,yesAction);
        transform.AddButtonAction(_twoPath+_noBtn,noAction);
    }
}
