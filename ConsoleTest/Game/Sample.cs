using System;

namespace ConsoleTest
{
	/// <summary>
	/// 应用的时候，我想怎么去使用这些模块
	/// 整个系统就是 两点一线
	/// 整个系统都是 MVC 的概念
	/// 整个系统都应该都可以实现 系统三要素 , 三要素可以让系统变的非常的健壮\有活力\可扩展:
	/// 1.适应力 - 为了生存, 自我复原能力, 在不同的环境下还能够正常的运转下去(多反馈回路相互影响自我调节)
	/// 2.自组织 - 使自身结构复杂化能力, 学习\进化 (层次性可以认为就是自组织过程中产生出来)
	/// 3.层次性 - 系统与子系统的包含&生成关系, 树形结构, 上层系统是为了下层系统而建立的
	///    3.1.1个人的世界
	///    3.2.5个人,1个领导,4个执行
	///    3.3.25个人,5个领导,20个执行
	///    3.4.26个人,1个中领导,5个领导,20个执行
	///    3.5.130个人,5个中领导,25个领导,100个执行
	///    3.6.131个人,1个大领导,5个中领导,25个领导,100个执行
	///   建立层性性的原因有很多,自身的需求(天生的需求,后天的需求),被引导的需求(更有名的画,更好听的音乐...)
	///    经济学中的交易系统的建立, 直到当下, 全球为我服务, 我为全球服务
	///   需求最终要有消费者,没有消费者的需求是没有存在的意义的.上层系统的建立,是为了更好的服务/协调下层的需求
	///   最开始一个函数就可以搞定玩游戏这件事情,随着需求的复杂化,加入了更多的子系统来服务于玩游戏这件事情
	///     1.我打你
	///     2.我打你,你要看到(拆出或添加几个子系统)
	///     3.我打你,你要看到,服务器要知道是否结束了(拆出或添加更多的子系统与子子系统)
	///     4.我打你,你要看到,服务器要知道是否结束了,记录下得分情况(更复杂化)
	///     5....
	///    从起点到终点的一条线,本来只有两个点,是直线,中间加入越来越多的点,可以拉成非常复杂的曲线,但最终还是要到终点的,即目标
	/// 整个系统都是流水线,所有的模块都是在提供各种服务,最终就是为了把A变成B,如:把猪放到一个机器里面去,出来的是热狗一样
	/// 
	/// 
	/// !!!先 解耦 ,再 复用 !!!
	/// 
	/// </summary>
	namespace Sample
	{
		class SampleFirst
		{
			public void InstallEnvironment()
			{
			}
			
			public SampleFirst()
			{
				this.InstallEnvironment();

				// 加入好友模块。
				// 加入公会模块。
				// 加入活动模块。
				App.Instance.AddComponent("Friend");
				App.Instance.AddComponent("Union");
				App.Instance.AddComponent("Activity");
				
				// 数据管理都用yyyyyy。
				App.Instance.AddComponent("Database");	
				App.Instance.BindDatabase("Friend", "Database");
				App.Instance.BindDatabase("Union", "Database");
				App.Instance.BindDatabase("Activity", "Database");
			
				App.Instance.AddComponent("GUI");
				App.Instance.BindView("Friend", "Friend.xaml");
				App.Instance.BindView("Union", "Union.xaml");
				App.Instance.BindView("Activity", "Activity.xaml");

				// 界面的root换风格
				// 基础控件换风格
				// 好友界面模板默认
				// 组合几个模块的入口到Lobby
				App.Instance.BindCommand("ShowFriendUI", "Friend.V.Show");
				App.Instance.BindCommand("ShowUnionUI", "Union.V.Show");
				App.Instance.BindCommand("ShowActivityUI", "Activity.V.Show");

				App.Instance.AddComponent("Lobby");
				App.Instance.BindDatabase("Lobby", "Database");
				App.Instance.BindView("Lobby", "Lobby.xaml");

				// Lobby.xaml
				// <Button Name=Friend OnClicked = DoCommand("ShowFriendUI") />
				// <Button Name=Union OnClicked = DoCommand("ShowUnionUI") />
				// <Button Name=Activity OnClicked = DoCommand("ShowActivityUI") />
				
				// 游戏一启动，这些组件一加上，直接就可以显示出一个想要的Lobby了，功能都已经支持了
				
				// 根据当前显示的环境，再去调整Lobby的显示方式，通过界面编辑器去进行修改就够了

				// MMO的各种模块实现
			}

			public void SimapleSecond()
			{
				var step = new SimapleSecondStep();
				// 从当前的网络环境来讲, 软件开发不是问题, 最大的问题是人性的懒惰
				// 解决方案:
				// 1.多劳多得 - 计件式的工作方式
				//   1.1.针对接口开发
				// 2.质量保证 - 科学的质检
				//   2.1.单元测试
				//   2.2.效率测试
				step.First();

				// 在出版本的时候, 设备会存在问题
				// 解决方案:
				// 1.由核心人员出版本
				// 2.将代码变成DLL版本(需要较稳定的版本), 交给其他人员来制作版本
				step.Second();

				// 启动前要针对一些问题先做好准备
				// 1.约法三章
				// 1.1.即时沟通的问题
				// 1.2.严重问题的即时处理问题
				// 1.3.赏罚制作的问题
				// 1.4.工作总结,绩效考核的问题
				// 2.需要一起工作
				// 2.1.什么时候需要一起工作
				// 3.工作成果
				// 3.1.能力交换自由
				// 3.2.工作人员可以将任务外包出去,只要质量是过关的
				step.Third();
			}

			class SimapleSecondStep
			{
				public void First()
				{
					// 从当前的网络环境来讲, 软件开发不是问题, 最大的问题是人性的懒惰
					// 解决方案:
					// 1.多劳多得 - 计件式的工作方式
					//   1.1.针对接口开发
					this.InterfaceDevelopment();
					// 2.质量保证 - 科学的质检
					//   2.1.单元测试
					//   2.2.效率测试
					this.UnitTest();
					this.PerformanceTest();
				}

				private void InterfaceDevelopment()
				{
					// 步骤是什么样子的?
					//   如下
					// 输入什么?输出什么?处理什么?
					//   输入需求,输出接口&实现,转换需求为接口&实现
					// 目的是什么? 
					//   翻译人类需求为计算机语言,使机器实现人类定义的需求逻辑

					// 1.获得功能或系统的需求
					object demand = this.GetBusinessDemand();
					// 2.定义对应这些需求的接口
					object objInterface = this.MakeInterfactFromBusinessDemand();
					// 3.实现对应这些接口的具体功能
					object objImplementation = this.MakeImplementationFromInterface();
					// 4.用单元测试来测试这些接口的具体功能的质量
					object testResult = this.TestInterfaceForQualityAssurance();
				}

				private void UnitTest()
				{
				}

				private void PerformanceTest()
				{
				}

				public void Second()
				{
				}

				public void Third()
				{
				}
			}

			public void SimapleThird()
			{
				// TODO 整体的MVC系统设计
				// TODO 战斗系统降解成多个小系统（时间轴、各种轴插件、数值计算、动作同步、防外挂、BUFF系统、AI、游戏模式）
				// 1.动作系统
				// 1.1.时间轴
				// 1.2.各种轴插件
				// 设计它为了解决什么问题？播放一个动作，让这个动作可以附带上各种效果（视、听、某种约束规则、战斗属性计算）
				// 功能有什么？
				// 反馈有什么？
				// 需要什么支持？
				// 
				// 2.数值
				// 2.1.碰撞规则 - 物理系统说碰撞了，数值认为这是一次有效的碰撞
				// 2.2.计算 - 根据游戏规则，定义攻防计算公式，无敌、霸体、伤血、加成、反伤等
				// 2.3.属性 - 看到这些数字，我可以想像我的NB之处
				// 为游戏制作者组织游戏内容时提供数值运算逻辑、可定义的数值元素
				// 对AB进行相互作用之后产生的结果
				// 若将相互作用降解掉，就会成为A做了什么收到什么反馈，B做了什么收到什么反馈
				// 
				// 3.BUFF系统
				// 为游戏制作者组织游戏内容时提供丰富可变的战斗细节、变化元素
				// 一般是在某个事件触发了，在正常的流程中加入一个处理节点，这个节点是影响，还是通知，还是其它根据设计来定
				// 
				// 4.技能
				// 让我方便的操纵游戏提供的变化元素，这些元素被游戏制作者组织成容易理解、有特色、系列化、系统化的BUFF集合
				// 
				// 5.游戏模式
				// 让我得到不同玩法体验（刺激、成就）、游戏目标等等
				// 
				// 6.AI
				// 陪我玩游戏，模拟真人行为，简单版本，复杂版本
				// 
				// 7.动作同步
				// 让真人陪我玩游戏，多人互动，即要像本地一样流畅，又要真人的多变
				// 
				// 8.防外挂
				// 让我觉的公平的环境，杜绝非官方的作弊手段
			}
		}
	}

}
