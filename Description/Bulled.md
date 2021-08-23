### 主要内容

这是一个用于挂载在子弹预设体的脚本，功能如下：

* 让子弹向目标飞去（跟踪的）
* 接触到目标时候，摧毁子弹，并且将爆炸特效召唤出来。

### 参数说明

```c#
private Transform target;  //the target to hit
public float speed = 70f;  //speed of moving
public GameObject impactEffect;	// the impact effect when hitting the target
```

这一部分已经说的很清晰了，speed与impactEffect之所以public是因为：

* speed用来调整子弹飞行速度，不同的子弹有不同的速度，便于修改以及测试。
* impactEffect是爆炸特效，不同子弹显然有不同的爆炸特效，而且如果是private的花萼，需要专门写一个函数来赋予它爆炸特效。

### 具体实现

主要内容就是下面这个，如果下一帧就会击中目标，那么就直接执行hitTarget()，然后返回。

如果不会击中，那么就继续往目标方向移动。

```c#
		Vector3 dir = target.position - transform.position;
		float distanceThisFrame = speed * Time.deltaTime;

		if(dir.magnitude <= distanceThisFrame) {
			hitTarget();
			return;
        }
															
		transform.Translate(dir.normalized * distanceThisFrame, Space.World);
```



**击中目标**

在当前位置创建爆炸特效，然后删除子弹，并在两秒后删除爆炸特效。

```c#
void hitTarget() {
	GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
	Destroy(effectIns, 2f);
	Destroy(gameObject);
}
```

### 如何使用

* 在你完成了一个子弹模型的制作之后，那么只需把这个脚本挂载到模型上，然后把爆炸特效挂载上这个脚本。

* 在防御塔的射击函数上调用该脚本的seek函数，来为子弹创造目标。