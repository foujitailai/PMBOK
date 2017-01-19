using System;

namespace ConsoleTest
{
	/// <summary>
	/// 应用的时候，我想怎么去使用这些模块
	/// </summary>
	namespace Sample
	{
		class SampleFirst
		{
			public InstallEnvironment()
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
		}
	}

}
