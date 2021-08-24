### 主要内容

用于被场景中的Canvas->Shop中的对象调用，效果是设置buildManager.cs中的turretTiBuild，让其成为下次建造的防御塔。



### 使用方法

1. 在buildManager中创建一个GameObject，并把预设体赋值给它

```c#
public GameObject standardTurretPrefab;
```

2. 在此脚本中创建一个一个类似于它的函数

```c#
public void PurchaseStandardTurret() {
	BuildManager.instance.setTurretToBuild(buildManager.standardTurretPrefab);
}
```



3. 在Canvas->Shop中新建一个button，在Onclick()中调用你刚才创建的函数。