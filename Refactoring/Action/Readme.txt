Config 			读写Action的配置
Info 			当前动作中Shaft信息相关查询的类
Manager 		动作切换的逻辑规则、条件，其它系统的关连
State 			当前动作的各种数据信息记录、运算，可以当作Action对象
Controller 		按键、位移、碰撞
Property 		受伤：自定义Shaft、伤害计算、Buff、UState、血条、伤血显示，死亡
AttackBox 		碰撞底层确定有效目标
AnimParts 		动作的动画播放切片，空播放
Hurt 			伤害计算公式、规则
Shaft 			各节点配置
ControllerShaft	各节的功能实现


动作切换
Controller.OnKey
	Controller.FillKey with State
Manager.Update
	Config.Load
	Manager.CheckNextAction
		Info.SwitchAction
		State.SwitchAction
			AttackBox.Enable
			AnimParts.Enable
			Shaft.Enable
			ControllerShaft.Enable
Controller.Move

Actor.Run
	Actor.FillKey
	ActionSystem.Run
		ActionSystem.CanSwitch
		ActionSystem.SwitchAction
			Action.Switch
			Action.AddPlugins
			Action.PluginRun
				Plugin.Enable
				AttackBox.Enable
				AnimParts.Enable
	Actor.UpdateMove

攻击碰撞
A=Attacker
B=ByAttacker
A.AttackBox.OnCollided
A.State.OnAttacked
B.ActorProperty.OnByAttacked
B.Hurt.Calc
B.Manager.SwitchAction






网络协议重构,可以考虑使用自动代码生成功能!!!







1.确定修改点


2.找出测试点


3.解依赖


4.编写测试


5.修改\重构


