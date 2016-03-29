using UnityEngine;
using System.Collections;

public static class EventEnums
{
    //与其他界面交互的应该定义为一个公共事件
    #region 场景插件事件;

    #endregion

    #region 战斗事件

    public static readonly string GameStart = "GameStart";                      //游戏开始

    public static readonly string PlayerDead = "PlayerDead";                   //游戏结束;

    public static readonly string EnemyDead = "EnemyDead";                     //僵尸死亡;

    public static readonly string WeaponShoot = "WeaponShoot";                //发射子弹;

    public static readonly string ShipDestroy = "ShipDestroy";                //飞船销毁;

    public static readonly string SwitchWeapon = "SwitchWeapon";             //切换武器;

    #endregion

    #region UI相关事件;

    public static readonly string UIGameStart = "UIGameStart";              //UI开始游戏通知;

    public static readonly string UIAddScore = "UIAddScore";                //得分;

    public static readonly string UIChangeWeaponIcon = " UIChangeWeaponIcon "; //切換武器ICON

    public static readonly string UINewHandIsOver = "UINewHandIsOver";      //已经执行过了新手指导

    public static readonly string UIDoNotNeedNewHand = "UIDoNotNeedNewHand"; //不需要再显示新手指导


    #endregion

    #region 耳机操作事件;

    public static readonly string OnSingleClick = "OnSingleClick";                          //单击事件;

    public static readonly string OnDoubleClick = "OnDoubleClick";                         //双击事件;

    public static readonly string OnLongPress = "OnLongPress";                            //长按事件;

    public static readonly string OnReturn = "OnReturn";                                 //返回事件;

    public static readonly string OnEarphonePlug = "OnEarphonePlug";                    // 耳机插拔事件.

    

    #endregion

    #region 耳机音量事件传递

    public static readonly string OnChangeVolume = "ChangeVolume";                            //改变音量事件;
    //public static readonly string OnReduceVolume = "ReduceVolume";                      //减少音量事件;

    public static readonly string OnEarphonePlay = "OnEarphonePlay";                          //开启耳机播放事件.
    public static readonly string OnSpeakerPlay = "OnSpeakerPlay";                              //开启扬声器播放事件.

    #endregion

}
