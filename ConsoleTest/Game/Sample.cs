using System;

namespace ConsoleTest
{
	/// <summary>
	/// 应用的时候，我想怎么去使用这些模块
	/// 整个系统都是MVC的概念
	/// 整个系统都应该都可以实现系统三要素, 三要素可以让系统变的非常的健壮\有活力\可扩展:
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
	/// </summary>
	namespace Sample
	{
		class SampleFirst
		{
			public InstallEnvironment()
			{
			}
			
			public void SampleFirst()
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
				// 
			}
		}
	}

}
