###  主要功能

* 锁定范围内的目标
* 将防御塔的枪口对准目标
* 发射子弹

### 参数说明

* EnemyTag 这个string类型的变量是为了让防御塔确定目标，凡是带有“Enemy”属性的对象都可以被锁定
* partToRotation 防御塔炮管旋转时候的旋转点， firePoint 发射炮弹的位置
* range 攻击范围， turnSpeed 炮台旋转速度， fireRate 开火速度
* bulletPrefab 炮弹预设体
* fireCountdown 距离下次开火的时间
* target 当前正在攻击的敌人

### 具体实现

##### 锁定目标（UpdateTarget）

主要过程是，遍历每一个敌人，如果它在射程之内，就把它设为目标。如果有多个，那就选择最近的。

##### 开火（Update，Shoot ）

在update中回不断让fireCountdown递减，当它为0时，就意味着要开火了，于是调用Shoot，并把fireCountdown重置。

在Shoot中，只需在firePoint位置创建一个子弹预设体，并调用它bullet.cs中的seek函数，为其设置目标。

##### 把枪管对准敌人（LockOnTarget）

```c#
void LockOnTarget() {
	Vector3 dir = target.transform.position - transform.position;//1.
	Quaternion lookRotation = Quaternion.LookRotation(dir);//2.
	Vector3 rotation = Quaternion.Lerp(partToRotation.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;//3.
	partToRotation.rotation = Quaternion.Euler(0f, rotation.y, 0f);//3.
}
```



这部分比较玄学

1. dir是敌人和防御塔的位移差

2. 然后我们创建了一个Quaternion类型变量，把dir导入它

3. 然后用它的Lerp函数算出来角度差，随后让它旋转。

这一部分教程讲的也不是很详细，所以俺也不太懂（悲）。

### 使用方法

把这脚本挂载到防御塔预设体上，然后把旋转位置和开火点设置好即可。

**注意**：有可能在运行时，枪管位置始终和目标会差一个特定角度，这时候就要把旋转位置的旋转y坐标设置为这个特殊角度的相反数。