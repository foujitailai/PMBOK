using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest.Product
{
	class Product
	{
		// 用户与项目关联
		// 1.用户建立ssh-key(用原版git的git bash)
		//    ssh-keygen -t rsa -C "$your_email"
		//    cat ~/.ssh/id_rsa.pub
		// 2.将ssh-key复制到gitlab的用户SSH-KEY里面
		// 3.ssh-key的名字直接叫id_rsa别改了，git会自动去找这个名字的
		// 
		// 项目
		// 1.建立项目
		// 2.设置项目保护方式
		// 3.添加不同用户的权限
		// 4.日常开发放在develop分支
		// 5.注意master分支是否要保护！！！
		// 
		// 
		// project 的设置里面 Protect a branch
		// 去掉保护，就可以提交了
		// 
		// 
		// 
		// git的submodule 可以让两个不相关的git库关联在一起
		// 
		// 持续集成
		// teamcity（MonoGame用这个）
		// jenkins（未知）
	}
}
