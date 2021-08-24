### 主要功能

* 通过WASD来控制摄像机的前后左右移动
* 当鼠标在画面的边界处时，也会向所指方向移动
* 通过鼠标滑轮来拉近或者拉远镜头

### 初始状态

相机初始的位置是在游戏平面的上方，角度向下倾斜，以便刚好将整个桌面覆盖。

![camera](pic\camera.png)

### 具体实现

**以向上移动为例**

如果检测到了用户**按下“W”键**，或者**鼠标位置的Y坐标离屏幕最高处的距离小于panBorderThickness**，就会触发向前移动，因为此时是在水平面上移动的，所以必须用世界坐标。

```c#
if(Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness) {
			transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
```

**拉近或者拉远**

```c++
Input.GetAxis("Mouse ScrollWheel")
```

这个函数能够根据鼠标滑轮的滑动来返回一个在$[-1,1]$之间的浮点数。向上滑动为正数，向下为负数，滑动速度决定了这个数绝对值的大小。

因为习惯，向上滑动我们希望拉近镜头（即X，Y坐标减少），所以要在前面乘一个负数

```c#
pos.y += -1 * scroll *1000 * scrollSpeed * Time.deltaTime;
```



同时我们也要保证我们的镜头不会传到地面下面或者太高，这个函数是返回第一个参数对第二个参数取max，对第三个参数取min操作后的值。

```c#
pos.y = Mathf.Clamp(pos.y, minY, maxY);
```

