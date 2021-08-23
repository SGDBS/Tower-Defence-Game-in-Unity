### 主要内容

用来控制每个敌人移动，依次经过每一个标记点，从而实现从起点向目标位置前进。

### 参数说明

* speed 顾名思义，就是移动速度
* target 我们当前要移动的waypoint‘位置
* waypointIndex  我们当前要移动到的waypoint 编号。



### 实现方法

##### 向目标点移动

```c++
void Update () {
		Vector3 dir = target.position - transform.position;
		transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

		if (Vector3.Distance(transform.position, target.position) < 0.2f) {
			getNextPoint();	 //if we have got to the waypoint,we will move the next one
        }
	}
```

dir通过当前位置与目标位置的位置差矢量，在移动之前，我们要把它单位化（即转化为单位矢量），当我们离目标位置足够近时，可以认为它已经到了，那么就调用getNextPoint()，把目标调整下一个目标位置。

##### 获取下一个目标点

标记点已经通过WayPoints.cs预处理过了，所以我们只需调用它中的points数组即可

我们通过让waypointIndex++，表示我们要向下一个waypoint前进，同时让target = WayPoints.points[waypointIndex]，来更改目标位置。

```c#
void getNextPoint() {
		if(waypointIndex >= WayPoints.points.Length - 1) { //we have got to the last waypoints
			Destroy(gameObject);
			return ;
        }
		waypointIndex++;
		target = WayPoints.points[waypointIndex];
    }
```

### 使用方法

当你创建了一个敌人模型后，只需将该脚本挂载上去即可。不难发现，这个脚本只有一个pubilc变量，而且还是speed，所以只需设置速度即可（如果该敌人没有特殊的技能的话）