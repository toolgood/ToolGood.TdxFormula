# ToolGood.TdxFormula
===================
 


支持递归
```
XXX(1)=REF(SELF,1)+1;
```


#### 行情函数
<table>
    <tr><td>函数名</td><td>说明</td></tr>
    <tr>
        <td>HIGH / H</td>
        <td> 返回该周期最高价.<br>用法: HIGH</td>
    </tr>
    <tr>
        <td>LOW / L</td>
        <td> 返回该周期最低价.<br>用法: LOW</td>
    </tr>
    </tr>
    <tr>
        <td>CLOSE / C</td>
        <td> 返回该周期收盘价.<br>用法: CLOSE</td>
    </tr>
     <tr>
        <td>OPEN / O</td>
        <td> 返回该周期开盘价.<br>用法: OPEN</td>
    </tr>
    <tr>
        <td>VOL / V</td>
        <td> 返回该周期成交量.<br>用法: VOL</td>
    </tr>
     <tr>
        <td>AMOUNT / AMO</td>
        <td> 返回该周期成交额.<br>用法: AMOUNT</td>
    </tr>
     <tr>
        <td>TURN / T</td>
        <td> 返回该周期换手率真。 <br>用法: TURN</td>
    </tr>
     <tr>
        <td>TR  </td>
        <td> 求真实波幅.<br>用法: TR</td>
    </tr>
    <tr>
        <td>INDEXA</td>
        <td> 返回对应的大盘成交额。 <br>用法: INDEXA</td>
    </tr>
    <tr>
        <td>INDEXC</td>
        <td> 返回对应的大盘收盘价。 <br>用法: INDEXC</td>
    </tr>
    <tr>
    <td>INDEXH</td>
        <td> 返回对应的大盘最高价。 <br>用法: INDEXH</td>
    </tr>
    <td>INDEXL</td>
        <td> 返回对应的大盘最低价。 <br>用法: INDEXL</td>
    </tr>
    <td>INDEXO</td>
        <td> 返回对应的大盘开盘价。 <br>用法: INDEXO</td>
    </tr>
    <td>INDEXV</td>
        <td> 返回对应的大盘成交量。 <br>用法: INDEXV</td>
    </tr>
</table>

#### 时间函数
<table>
    <tr><td>函数名</td><td>说明</td></tr>
    <tr>
        <td>DATE  </td>
        <td>  取得该周期从1900以来的的年月日.<br>用法: DATE<br>例如函数返回1000101,表示2000年1月1日,DATE+19000000后才是真正的日期值,公式内容中请不要直接写8位长的日期数字</td>
    </tr>
    <tr>
        <td>TIME  </td>
        <td>  取得该周期的时分,适用于日线以下周期<br>用法:  TIME 函数返回有效值范围为(0000-2359)</td>
    </tr>
    <tr>
        <td>TIME2  </td>
        <td>  取得该周期的时分秒,适用于日线以下周期.<br>用法:  TIME2  函数返回有效值范围为(000000-235959)</td>
    </tr>
    <tr>
        <td>YEAR  </td>
        <td>取得该周期的年份.<br>用法: YEAR</td>
    </tr>
    <tr>
        <td>MONTH   </td>
        <td>取得该周期的月份.<br>用法: MONTH  函数返回有效值范围为(1-12) </td>
    </tr>
    <tr>
        <td>DAY   </td>
        <td>取得该周期的日期.<br>用法: DAY  函数返回有效值范围为(1-31)
 </td>
    </tr>
    <tr>
        <td>HOUR   </td>
        <td>取得该周期的小时数.<br>用法: HOUR  函数返回有效值范围为(0-23),对于日线及更长的分析周期值为0 </td>
    </tr>
    <tr>
        <td>MINUTE   </td>
        <td> 取得该周期的分钟数.<br>用法: MINUTE  函数返回有效值范围为(0-59),对于日线及更长的分析周期值为0</td>
    </tr>
    <tr>
        <td>WEEKOFYEAR   </td>
        <td>取得该周是年内第几个周. <br>用法: WEEKOFYEAR </td>
    </tr>
    <tr>
        <td>WEEKDAY   </td>
        <td>取得该周期的星期数.<br>用法: WEEKDAY  函数返回有效值范围为(1,2,3,4,5,6,0) </td>
    </tr>
    <tr>
        <td>DAYSTOTODAY   </td>
        <td>取得该周期的日期离今天的天数. <br>用法: DAYSTOTODAY </td>
    </tr>
    <tr>
        <td>DATETODAY   </td>
        <td>指定日期到1990.12.19的天数.<br>用法: DATETODAY(date) 返回date到1990.12.19的天数.有效日期为(901219-1341231)<br>例如: DATETODAY(901219)返回0. </td>
    </tr>
</table>


#### 引用函数
<table>
    <tr>
        <td> REF  </td>
        <td>引用若干周期前的数据.
<br>用法: REF(X,A),引用A周期前的X值.A可以是变量.
<br>例如: REF(CLOSE,BARSCOUNT(C)-1)表示第二根K线的收盘价. </td>
    </tr>
    <tr>
        <td>REFV   </td>
        <td>引用若干周期前的数据(平滑处理).
<br>用法: REFV(X,A),引用A周期前的X值.A可以是变量.
<br>例如: REFV(CLOSE,BARSCOUNT(C)-1)表示第二根K线的收盘价. </td>
    </tr>
    <tr>
        <td> MA  </td>
        <td>返回简单移动平均
<br>用法: MA(X,N):X的N日简单移动平均,<br>算法(X1+X2+X3+...+Xn)/N,N支持变量</td>
    </tr>
    <tr>
        <td> SMA  </td>
        <td>返回移动平均
<br>用法: SMA(X,N,M):X的N日移动平均,M为权重,如Y=(X*M+Y'*(N-M))/N </td>
    </tr>
    <tr>
        <td> TMA  </td>
        <td> 返回移动平均
<br>用法: TMA(X,A,B),A和B必须小于1,<br>算法	Y=(A*Y'+B*X),其中Y'表示上一周期Y值.初值为X</td>
    </tr>
    <tr>
        <td> MEMA  </td>
        <td>返回平滑移动平均
<br>用法: MEMA(X,N):X的N日平滑移动平均,如Y=(X+Y'*(N-1))/N
<br>MEMA(X,N)相当于SMA(X,N,1) </td>
    </tr>
    <tr>
        <td> EMA  </td>
        <td>返回指数移动平均
<br>用法: EMA(X,N):X的N日指数移动平均.<br>算法:Y=(X*2+Y'*(N-1))/(N+1)
<br>EMA(X,N)相当于SMA(X,N+1,2),N支持变量 </td>
    </tr>
    <tr>
        <td> EXPMA </td>
        <td> 与EMA的<br>用法一致</td>
    </tr>
    <tr>
        <td>  EXPMEMA  </td>
        <td>返回指数平滑移动平均
<br>用法: EXPMEMA(X,N):X的N日指数平滑移动平均
<br>EXPMEMA同EMA(EXPMA)的差别在于他的起始值为一平滑值 </td>
    </tr>
    <tr>
        <td>  WMA  </td>
        <td>返回加权移动平均
<br>用法: WMA(X,N):X的N日加权移动平均.<br>算法:Yn=(1*X1+2*X2+...+n*Xn)/(1+2+...+n) </td>
    </tr>
    <tr>
        <td> DMA   </td>
        <td>求动态移动平均.
<br>用法: DMA(X,A),求X的动态移动平均.
<br>算法:Y=A*X+(1-A)*Y',其中Y'表示上一周期Y值,A必须大于0且小于1.A支持变量.
<br>例如: DMA(CLOSE,VOL/CAPITAL)表示求以换手率作平滑因子的平均价 </td>
    </tr>
    <tr>
        <td> AMA   </td>
        <td> 求自适应均线值.
<br>用法: AMA(X,A),A为自适应系数,必须小于1.
<br>算法: Y=Y'+A*(X-Y').初值为X</td>
    </tr>
<tr>
        <td> HHV  </td>
        <td>求最高值.
<br>用法: HHV(X,N),求N周期内X最高值,N=0则从第一个有效值开始.
<br>例如: HHV(HIGH,30)表示求30日最高价 </td>
    </tr>
<tr>
        <td> HHVBARS  </td>
        <td>求上一高点到当前的周期数.
<br>用法: HHVBARS(X,N):求N周期内X最高值到当前周期数,N=0表示从第一个有效值开始统计
<br>例如: HHVBARS(HIGH,0)求得历史新高到到当前的周期数 </td>
    </tr>
<tr>
        <td> LLV  </td>
        <td> 求最低值.
<br>用法: LLV(X,N),求N周期内X最低值,N=0则从第一个有效值开始.
<br>例如: LLV(LOW,0)表示求历史最低价</td>
    </tr>
    <tr>
        <td>  LLVBARS </td>
        <td>求上一低点到当前的周期数.
<br>用法: LLVBARS(X,N):求N周期内X最低值到当前周期数,N=0表示从第一个有效值开始统计
<br>例如: LLVBARS(HIGH,20)求得20日最低点到当前的周期数 </td>
    </tr>
    <tr>
        <td> HOD   </td>
        <td>求高值名次.
<br>用法: HOD(X,N):求当前X数据是N周期内的第几个高值,N=0则从第一个有效值开始.
<br>例如: HOD(HIGH,20)返回是20日的第几个高价 </td>
    </tr>
    <tr>
        <td>LOD    </td>
        <td>求低值名次.
<br>用法: LOD(X,N):求当前X数据是N周期内的第几个低值,N=0则从第一个有效值开始.
<br>例如: LOD(LOW,20)返回是20日的第几个低价 </td>
    </tr>
    <tr>
        <td> SUM  </td>
        <td> 求总和.
<br>用法: SUM(X,N),统计N周期中X的总和,N=0则从第一个有效值开始.
<br>例如: SUM(VOL,0)表示统计从上市第一天以来的成交量总和</td>
    </tr>
    <tr>
        <td> SUMBARS </td>
        <td>向前累加到指定值到现在的周期数.
<br>用法: SUMBARS(X,A):将X向前累加直到大于等于A,返回这个区间的周期数,若所有的数据都累加后还不能达到A,则返回此时前面的总周期数.
 <br>例如:SUMBARS(VOL,CAPITAL)求完全换手到现在的周期数 </td>
    </tr>
    <tr>
        <td> COUNT  </td>
        <td>统计满足条件的周期数.
<br>用法: COUNT(X,N),统计N周期中满足X条件的周期数,若N<0则从第一个有效值开始.
<br>例如: COUNT(CLOSE>OPEN,20)表示统计20周期内收阳的周期数 </td>
    </tr>
    <tr>
        <td>MULAR   </td>
        <td>求累乘.
<br>用法: MULAR(X,N),统计N周期中X的乘积.N=0则从第一个有效值开始.
<br>例如: MULAR(C/REF(C,1),0)表示统计从上市第一天以来的复利 </td>
    </tr>
    <tr>
        <td>  CONST  </td>
        <td>CONST(A):取A最后的值为常量.<br>用法: CONST(INDEXC)表示取指数现价 </td>
    </tr>
    <tr>
        <td> BACKSET   </td>
        <td>属于未来函数,将当前位置到若干周期前的数据设为1.
<br>用法: BACKSET(X,N),若X非0,则将当前位置到N周期前的数值设为1.
<br>例如: BACKSET(CLOSE>OPEN,2)若收阳则将该周期及前一周期数值设为1,否则为0 </td>
    </tr>
    <tr>
        <td>BARSLAST   </td>
        <td> 上一次条件成立到当前的周期数.
<br>用法: BARSLAST(X):上一次X不为0到现在的周期数
<br>例如: BARSLAST(CLOSE/REF(CLOSE,1)>=1.1)表示上一个涨停板到当前的周期数</td>
    </tr>
    <tr>
        <td> BARSSINCE  </td>
        <td>第一个条件成立到当前的周期数.
<br>用法: BARSSINCE(X):第一次X不为0到现在的周期数
<br>例如: BARSSINCE(HIGH>10)表示股价超过10元时到当前的周期数 </td>
    </tr>
    <tr>
        <td>  BARSSINCEN </td>
        <td>N周期内第一个条件成立到当前的周期数.
<br>用法: BARSSINCEN(X,N):N周期内第一次X不为0到现在的周期数,N为常量
<br>例如: BARSSINCEN(HIGH>10,10)表示10个周期内股价超过10元时到当前的周期数 </td>
    </tr>
    <tr>
        <td> TOPRANGE   </td>
        <td>当前值是近多少周期内的最大值.
<br>用法: TOPRANGE(X):X是近多少周期内X的最大值
<br>例如: TOPRANGE(HIGH)表示当前最高价是近多少周期内最高价的最大值 </td>
    </tr>
    <tr>
        <td>  LOWRANGE  </td>
        <td> 当前值是近多少周期内的最小值.
<br>用法: LOWRANGE(X):X是近多少周期内X的最小值
<br>例如: LOWRANGE(LOW)表示当前最低价是近多少周期内最低价的最小值</td>
    </tr>
    <tr>
        <td>FILTERX    </td>
        <td> 反向过滤连续出现的信号.
<br>用法:FILTERX(X,N):X满足条件后,将其前N周期内的数据置为0,N为常量.
<br>例如: FILTERX(CLOSE>OPEN,5)查找阳线,前5天内出现过的阳线不被记录在内</td>
    </tr>
    <tr>
        <td> FINDHIGH   </td>
        <td> N周期前的M周期内的第T个最大值.<br>用法: FINDHIGH(VAR,N,M,T):VAR在N日前的M天内第T个最高价</td>
    </tr>
    <tr>
        <td>FINDHIGHBARS    </td>
        <td>N周期前的M周期内的第T个最大值到当前周期的周期数.<br>用法: FINDHIGHBARS(VAR,N,M,T):VAR在N日前的M天内第T个最高价到当前周期的周期数</td>
    </tr>
    <tr>
        <td> FINDLOW   </td>
        <td>N周期前的M周期内的第T个最小值.<br>用法: FINDLOW(VAR,N,M,T):VAR在N日前的M天内第T个最低价 </td>
    </tr>
    <tr>
        <td> FINDLOWBARS   </td>
        <td>N周期前的M周期内的第T个最小值到当前周期的周期数.<br>用法: FINDLOWBARS(VAR,N,M,T):VAR在N日前的M天内第T个最低价到当前周期的周期数. </td>
    </tr>
    <tr>
        <td> ZTPRICE </td>
        <td>返回涨停价
<br>用法: ZTPRICE(REF(CLOSE,1),0.1):按10%计算得到在昨收盘基础上的涨停价(对于复权序列K线,由于复权处理,根据前一天的收盘价计算结果可能与涨停价不符)
<br>比如: ZTPrice(REF(QHJSJ,1),0.1),得到期货的涨停价 </td>
    </tr>
    <tr>
        <td> DTPRICE   </td>
        <td>返回跌停价
<br>用法: DTPRICE(REF(CLOSE,1),0.1):按10%计算得到在昨收盘基础上的跌停价(对于复权序列K线,由于复权处理,根据前一天的收盘价计算结果可能与跌停价不符)
<br>比如: DTPrice(REF(QHJSJ,1),0.6),得到期货的跌停价(跌停比例为0.6的话) </td>
    </tr>
</table>

#### 逻辑函数
<table>
    <tr>
        <td> RANGE   </td>
        <td>RANGE(A,B,C):A在B和C范围之间,B<A<C.<br>用法: RANGE(A,B,C)表示A大于B同时小于C时返回1,否则返回0 </td>
    </tr>
    <tr>
        <td>BETWEEN</td>
        <td> 介于.<br>用法: BETWEEN(A,B,C)表示A处于B和C之间时返回1,B&lt;A&lt;C或C&lt;A&lt;B,否则返回0<br>例如: BETWEEN(CLOSE,MA(CLOSE,10),MA(CLOSE,5))表示收盘价介于5日均线和10日均线之间 </td>
    </tr>
    <tr>
        <td>  CROSS   </td>
        <td>两条线交叉.<br>用法: CROSS(A,B)表示当A从下方向上穿过B时返回1,否则返回0<br>例如: CROSS(MA(CLOSE,5),MA(CLOSE,10))表示5日均线与10日均线交金叉 </td>
    </tr>
    <tr>
        <td>  LONGCROSS   </td>
        <td> 两条线维持一定周期后交叉. <br>用法:LONGCROSS(A,B,N)表示A在N周期内都小于B,本周期从下方向上穿过B时返回1,否则返回0</td>
    </tr>
    <tr>
        <td>  UPNDAY   </td>
        <td>返回周期数内是否连涨.<br>用法: UPNDAY(CLOSE,M) 表示连涨M个周期,M为常量 </td>
    </tr>
    <tr>
        <td>DOWNNDAY     </td>
        <td>返回周期数内是否连跌.<br>用法: DOWNNDAY(CLOSE,M) 表示连跌M个周期,M为常量 </td>
    </tr>
    <tr>
        <td>NDAY</td>
        <td> 返回是否持续存在X>Y<br>用法: NDAY(CLOSE,OPEN,3) 表示连续3日收阳线</td>
    </tr>
    <tr>
        <td>EXIST</td>
        <td>是否存在.<br>例如: EXIST(CLOSE>OPEN,10)  表示10日内存在着阳线,第2个参数为常量 </td>
    </tr>
    <tr>
        <td>EXISTR</td>
        <td>EXISTR(X,A,B):是否存在(前几日到前几日间).<br>例如: EXISTR(CLOSE>OPEN,10,5)  表示从前10日内到前5日内存在着阳线 若A为0,表示从第一天开始,B为0,表示到最后日止,第2,3个参数为常量 </td>
    </tr>
    <tr>
        <td>EVERY</td>
        <td>一直存在.<br>例如: EVERY(CLOSE>OPEN,N)  表示N日内一直阳线(N应大于0,小于总周期数,N支持变量) </td>
    </tr>
    <tr>
        <td>LAST</td>
        <td>LAST(X,A,B):持续存在.<br>例如: LAST(CLOSE>OPEN,10,5)  表示从前10日到前5日内一直阳线 若A为0,表示从第一天开始,B为0,表示到最后日止 </td>
    </tr>
    <tr>
        <td>NOT</td>
        <td>求逻辑非.<br>用法: NOT(X)返回非X,即当X=0时返回1,否则返回0<br>例如: NOT(ISUP)表示平盘或收阴 </td>
    </tr>
    <tr>
        <td> ISVALID    </td>
        <td>判断是否是有效数值. </td>
    </tr>
</table>


#### 选择函数
<table>
    <tr>
        <td> IF / IFF   </td>
        <td>根据条件求不同的值.
<br>用法: IF(X,A,B)若X不为0则返回A,否则返回B
<br>例如: IF(CLOSE>OPEN,HIGH,LOW)表示该周期收阳则返回最高值,否则返回最低值.
 </td>
    <tr>
        <td>  IFN </td>
        <td>根据条件求不同的值,同IF判断相反.
<br>用法: IFN(X,A,B)若X不为0则返回B,否则返回A
<br>例如: IFN(CLOSE>OPEN,HIGH,LOW)表示该周期收阴则返回最高值,否则返回最低值  </td>
    </tr>
    <tr>
        <td> VALUEWHEN </td>
        <td>VALUEWHEN(COND,X) 当COND条件成立时,取X的当前值,否则取VALUEWHEN的上个值. </td>
    </tr>
</table>

#### 数学函数
<table>
    <tr>
        <td>MAX</td>
        <td> 求最大值.
<br>用法: MAX(A,B)返回A和B中的较大值
<br>例如: MAX(CLOSE-OPEN,0)表示若收盘价大于开盘价返回它们的差值,否则返回0 </td>
    </tr>
    <tr>
        <td>MIN</td>
        <td> 求最小值.
<br>用法: MIN(A,B)返回A和B中的较小值
<br>例如: MIN(CLOSE,OPEN)返回开盘价和收盘价中的较小值 </td>
    </tr>
    <tr>
        <td>MAX6</td>
        <td> 求6个参数中的最大值.<br>用法: MAX6(A,B,C,D,E,F)返回较大值 </td>
    </tr>
    <tr>
        <td>MIN6</td>
        <td> 求6个参数中的最小值.<br>用法: MIN6(A,B,C,D,E,F)返回较小值 </td>
    </tr>
    <tr>
        <td>ACOS</td>
        <td> 反余弦值.<br>用法: ACOS(X)返回X的反余弦值 </td>
    </tr>
    <tr>
        <td>ASIN</td>
        <td> 反正弦值.<br>用法: ASIN(X)返回X的反正弦值 </td>
    </tr>
    <tr>
        <td>ATAN</td>
        <td> 反正切值.<br>用法: ATAN(X)返回X的反正切值 </td>
    </tr>
    <tr>
        <td>COS</td>
        <td> 余弦值.<br>用法: COS(X)返回X的余弦值 </td>
    </tr>
    <tr>
        <td>SIN</td>
        <td> 正弦值.<br>用法: SIN(X)返回X的正弦值 </td>
    </tr>
    <tr>
        <td>TAN</td>
        <td> 正切值.<br>用法: TAN(X)返回X的正切值 </td>
    </tr>
    <tr>
        <td>EXP</td>
        <td> 指数.<br>用法: EXP(X)为e的X次幂<br>例如: EXP(CLOSE)返回e的CLOSE次幂 </td>
    </tr>
    <tr>
        <td>LN</td>
        <td> 求自然对数.<br>用法: LN(X)以e为底的对数<br>例如: LN(CLOSE)求收盘价的对数 </td>
    </tr>
    <tr>
        <td>LOG</td>
        <td> 求10为底的对数.<br>用法: LOG(X)取得X的对数<br>例如: LOG(100)等于2 </td>
    </tr>
    <tr>
        <td>SQRT</td>
        <td> 开平方.<br>用法: SQRT(X)为X的平方根<br>例如: SQRT(CLOSE)收盘价的平方根 </td>
    </tr>
    <tr>
        <td>ABS</td>
        <td> 求绝对值.<br>用法: ABS(X)返回X的绝对值<br>例如: ABS(-34)返回34 </td>
    </tr>
    <tr>
        <td>POW</td>
        <td> 乘幂.<br>用法: POW(A,B)返回A的B次幂<br>例如: POW(CLOSE,3)求得收盘价的3次方 </td>
    </tr>
    <tr>
        <td>CEILING</td>
        <td> 向上舍入.<br>用法: CEILING(A)返回沿A数值增大方向最接近的整数<br>例如: CEILING(12.3)求得13,CEILING(-3.5)求得-3 </td>
    </tr>
    <tr>
        <td>FLOOR</td>
        <td> 向下舍入.<br>用法: FLOOR(A)返回沿A数值减小方向最接近的整数<br>例如: FLOOR(12.3)求得12,FLOOR(-3.5)求得-4 </td>
    </tr>
    <tr>
        <td>INTPART</td>
        <td> 取整.<br>用法: INTPART(A)返回沿A绝对值减小方向最接近的整数<br>例如: INTPART(12.3)求得12,INTPART(-3.5)求得-3 </td>
    </tr>
    <tr>
        <td>FRACPART</td>
        <td>小数部分.<br>用法: FRACPART(X),返回X的小数部分  </td>
    </tr>
    <tr>
        <td>ROUND</td>
        <td>四舍五入.<br>用法: ROUND(X),返回X四舍五入到个位的数值</td>
    </tr>
    <tr>
        <td>ROUND2</td>
        <td> 四舍五入.<br>用法: ROUND2(X,N),返回X四舍五入到N位小数的数值  由于精度问题,数据越大误差可能越大 </td>
    </tr>
    <tr>
        <td>SIGN</td>
        <td> 取符号.<br>用法: SIGN(X),返回X的符号.当X>0,X=0,X<0分别返回1,0,-1 </td>
    </tr>
    <tr>
        <td>MOD</td>
        <td> 取模.<br>用法: MOD(M,N),返回M关于N的模(M除以N的余数)<br>例如: MOD(5,3)返回2 <br>注意:公式系统对有效数字部分有要求,如果数字部分超过7-8位,会有精度丢失 </td>
    </tr>
    <tr>
        <td>RAND</td>
        <td> 取随机数.<br>用法: RAND(N),返回一个范围在1-N的随机整数 </td>
    </tr>
</table>


#### 统计函数
<table>
    <tr>
        <td>AVEDEV</td>
        <td>AVEDEV(X,N) 返回平均绝对偏差  </td>
    </tr>
    <tr>
        <td>DEVSQ</td>
        <td> DEVSQ(X,N) 返回数据偏差平方和 </td>
    </tr>
    <tr>
        <td>FORCAST</td>
        <td>FORCAST(X,N) 返回线性回归预测值,N支持变量</td>
    </tr>
    <tr>
        <td>SLOPE</td>
        <td>SLOPE(X,N) 返回线性回归斜率,N支持变量</td>
    </tr>
    <tr>
        <td>STD</td>
        <td>STD(X,N) 返回估算标准差,N支持变量</td>
    </tr>
    <tr>
        <td>STDP</td>
        <td>STDP(X,N) 返回总体标准差,N支持变量</td>
    </tr>
    <tr>
        <td>STDDEV</td>
        <td>STDDEV(X,N) 返回标准偏差</td>
    </tr>
    <tr>
        <td>VAR</td>
        <td>VAR(X,N) 返回估算样本方差,N支持变量</td>
    </tr>
    <tr>
        <td>VARP</td>
        <td>VARP(X,N) 返回总体样本方差,N支持变量</td>
    </tr>
    <tr>
        <td>COVAR</td>
        <td>COVAR(X,Y,N) 返回X和Y的N周期的协方差,N支持变量</td>
    </tr>
    <tr>
        <td>RELATE</td>
        <td>RELATE(X,Y,N) 返回X和Y的N周期的相关系数,N支持变量</td>
    </tr>
</table>

#### 形态函数
<table>
    <tr>
        <td>ZIG</td>
        <td> 属于未来函数,之字转向.
<br>用法: ZIG(K,N),当价格变化量超过N%时转向,K表示0:开盘价,1:最高价,2:最低价,3:收盘价,其余:数组信息
<br>例如: ZIG(3,5)表示收盘价的5%的ZIG转向 </td>
    </tr>
    <tr>
        <td>ZIGA</td>
        <td> 属于未来函数,之字转向.
<br>用法: ZIGA(K,X),当价格变化超过X时转向,K表示0:开盘价,1:最高价,2:最低价,3:收盘价,其余:数组信息
<br>例如: ZIGA(3,1.5)表示收盘价变化1.5元的ZIGA转向 </td>
    </tr>
    <tr>
        <td>PEAK</td>
        <td> 属于未来函数,前M个ZIG转向波峰值.
<br>用法: PEAK(K,N,M)表示之字转向ZIG(K,N)的前M个波峰的数值,M必须大于等于1
<br>例如: PEAK(1,5,1)表示%5最高价ZIG转向的上一个波峰的数值 </td>
    </tr>
    <tr>
        <td>PEAKBARS</td>
        <td> 属于未来函数,前M个ZIG转向波峰到当前距离.
<br>用法: PEAKBARS(K,N,M)表示之字转向ZIG(K,N)的前M个波峰到当前的周期数,M必须大于等于1
<br>例如: PEAKBARS(0,5,1)表示%5开盘价ZIG转向的上一个波峰到当前的周期数 </td>
    </tr>
    <tr>
        <td>TROUGH</td>
        <td> 属于未来函数,前M个ZIG转向波谷值.
<br>用法: TROUGH(K,N,M)表示之字转向ZIG(K,N)的前M个波谷的数值,M必须大于等于1
<br>例如: TROUGH(2,5,2)表示%5最低价ZIG转向的前2个波谷的数值 </td>
    </tr>
    <tr>
        <td>TROUGHBARS</td>
        <td> 属于未来函数,前M个ZIG转向波谷到当前距离.
<br>用法: TROUGHBARS(K,N,M)表示之字转向ZIG(K,N)的前M个波谷到当前的周期数,M必须大于等于1
<br>例如: TROUGHBARS(2,5,2)表示%5最低价ZIG转向的前2个波谷到当前的周期数 </td>
    </tr>
    <tr>
        <td>WINNER</td>
        <td> 获利盘比例.
<br>用法: WINNER(CLOSE),表示以当前收市价卖出的获利盘比例,<br>例如返回0.1表示10%获利盘;WINNER(10.5)表示10.5元价格的获利盘比例 </td>
    </tr>
    <tr>
        <td>LWINNER</td>
        <td> 近期获利盘比例.
<br>用法: LWINNER(5,CLOSE),表示最近5天的那部分成本以当前收市价卖出的获利盘比例
<br>例如: 返回0.1表示10%获利盘 </td>
    </tr>
    <tr>
        <td>PWINNER</td>
        <td> 远期获利盘比例.
<br>用法: PWINNER(5,CLOSE),表示5天前的那部分成本以当前收市价卖出的获利盘比例
<br>例如: 返回0.1表示10%获利盘 </td>
    </tr>
    <tr>
        <td>COST</td>
        <td> 成本分布情况.
<br>用法: COST(10),表示10%获利盘的价格是多少,即有10%的持仓量在该价格以下,其余90%在该价格以上,为套牢盘 </td>
    </tr>
    <tr>
        <td>COSTEX</td>
        <td> 区间成本.
<br>用法: COSTEX(CLOSE,REF(CLOSE,1)),表示近两日收盘价格间筹码的成本 </td>
    </tr>
    <tr>
        <td>PPART</td>
        <td>远期成本分布比例.
<br>用法: PPART(10),表示10个周期前的成本占总成本的比例,0.2表示20%  </td>
    </tr>
    <tr>
        <td>SAR</td>
        <td>抛物转向.
<br>用法: SAR(N,S,M),N为计算周期,S为步长,M为极值
<br>例如: SAR(10,2,20)表示计算10日抛物转向,步长为2%,极限值为20%  </td>
    </tr>
    <tr>
        <td>SARTURN</td>
        <td> 抛物转向点.
<br>用法: SARTURN(N,S,M),N为计算周期,S为步长,M为极值,若发生向上转向则返回1,若发生向下转向则返回-1,否则为0
<br>其用法与SAR函数相同 </td>
    </tr>
</table>

 