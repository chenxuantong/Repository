using LearningDemoForLINQ.Entities;
using LearningDemoForLINQ.Part01.Restriction_Operators;
using LearningDemoForLINQ.Part02.Projection_Operators;
using LearningDemoForLINQ.Part03.Partitioning_Operators;
using LearningDemoForLINQ.Part04.Ordering_Operators;
using LearningDemoForLINQ.Part05.Grouping_Operators;
using LearningDemoForLINQ.Part06.Set_Operators;
using LearningDemoForLINQ.Part07.Conversion_Operators;
using LearningDemoForLINQ.Part08.Element_Operators;
using LearningDemoForLINQ.Part09.Generation_Operators;
using LearningDemoForLINQ.Part10.Quantifiers;
using LearningDemoForLINQ.Part11.Aggregate_Operators;
using LearningDemoForLINQ.Part12.Miscellaneous_Operators;
using LearningDemoForLINQ.Part13.Custom_Sequence_Operators;
using LearningDemoForLINQ.Part14.Query_Execution;
using LearningDemoForLINQ.Part15.Join_Operators;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningDemoForLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 第一部分：数据限定性访问相关运算符
            //var linq_001_005 = new Linq_001_005();

            //linq_001_005.Linq001();  // 在数据集合：int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };中查询小于 5 的元素

            //linq_001_005.Linq002();  // 在商品的数据集合中，查询库存数量为零的商品

            //linq_001_005.Linq003();  // 在商品的数据集合中，查询 库存数量>0 并且单价>3.00的商品

            //linq_001_005.Linq004();  // 在客户的数据集合中，查询地区是 WA 的客户，然后再查询每个满足条件客户的所有的订单

            //linq_001_005.Linq005();  // 对于数据集合：string[] digits = { "zero", "one", "two", "three", "four", "five",
            //                         // "six", "seven", "eight", "nine" };查询集合元素的：字符长度小于其索引值 的元素。
            //Console.ReadKey();
            #endregion

            #region 第二部分：数据投射相关的运算符
            //var linq_006_019 = new Linq_006_019();

            //linq_006_019.Linq006();  // 使用 select 从已经存在的数据集的数据表 Numbers 的元素中，生成一个比原来 +1 的新的数据集合

            //linq_006_019.Linq007();  // 使用 select 从数据集的产品数据表中，只提取产品名称，构建一个新的产品名称的集合

            //linq_006_019.Linq008();  // 使用 select 从数据表 Numbers 的元素中，提取相应的整形数据，并将这些数据作为索引，
            //                         // 从 string[] 中检索出相应的字符串，构建一个新的数据集合。

            //linq_006_019.Linq009();  // 使用 select 从数据表 Words 构建全是大写、小写的新的数据集合。

            //linq_006_019.Linq010();  // 使用 select 从数据表 Numbers 和 Digits 中构建一个新的数据集合。

            //linq_006_019.Linq011();  // 使用 select 从商品数据表 Products 中抽取部分属性（例如：ProductName，Category，UnitPrice），构建一个新的数据集合，
            //                         // 其中还可以将 Product 属性的名称根据需要重新命名，例如将 UnitPrice 更改为 Price。

            //linq_006_019.Linq012();  // 使用 select 索引从从数据表 Numbers 中选择出数值和它的索引位置，并且判断两者是否，构建一个新的元素集合。

            //linq_006_019.Linq013();  // 根据数据表 Numbers 和 Digits 的内容，使用 select 和 where 构建一个简单的查询，
            //                         // 从 Numbers 中选择所有小于 5 的元素，然后根据 Digits 中的元素定义，返回对应的字符串文本。

            //linq_006_019.Linq014();  // 从数据表 NumbersA，NumbersB 中，分别从两个集合中选择两个数据元素构成一个对子，挑选前者的数据元素小于后者的元素，构建一个新的数据集合

            //linq_006_019.Linq015();  // 从客户和订单两个数据表中，选择那些订单金额少于 500 的订单

            //linq_006_019.Linq016();  // 从客户和订单两个数据表中，选择那些下单日期在 1998 年以及其后的订单。

            //linq_006_019.Linq017();  // 从客户和订单两个数据表中，选择那些订单大于 2000，并通过对订单金额赋值条件来处理避免重复请求代码的情况。

            //linq_006_019.Linq018();  // 从客户和订单两个数据表中，选择那些客户属于 WA 区域的，并且是指定的下单日期（DateTime(1997, 1, 1)）的订单数据。

            //linq_006_019.Linq019();  // 使用 SelectMany 从客户和订单两个数据表中，选择全部的订单和订单索引

            //Console.ReadKey();
            #endregion

            #region 第三部分：数据分割相关运算符
            //var linq_020_027 = new Linq_020_027();

            //linq_020_027.Linq020();   // 使用 Take 从数据集合元素中取出前面3个元素

            //linq_020_027.Linq021();   // 使用 Take 从所有属于华盛顿的客户的全部订单的前面3份订单

            //linq_020_027.Linq022();   // 使用 Skip 从数据集合元素中取出忽略前面4个元素的全部剩余元素

            //linq_020_027.Linq023();   // 使用 Skip 从所有属于华盛顿的客户的全部订单中，取出忽略前面两份订单的全部剩余订单

            //linq_020_027.Linq024();   // 使用 TakeWhile 从数据集合元素中从头开始逐个选取数据，直到满足不 小于 6 的元素结束。

            //linq_020_027.Linq025();   // 使用 TakeWhile 从数据集合元素中从头开始逐个选取数据，直到元素的索引不小于等于它的值为止。

            //linq_020_027.Linq026();   // 使用 SkipWhile 从数据集合元素中从头开始逐个选取数据，忽略哪些第一个可以被3整除的元素之前的全部元素。

            //linq_020_027.Linq027();   // 使用 SkipWhile 从数据集合元素中从头开始逐个选取数据，忽略哪些直到发现索引值小于元素值的元素。

            //Console.ReadKey();
            #endregion

            #region 第四部分：数据排序相关运算符
            //var linq_028_039 = new Linq_028_039();

            //linq_028_039.Linq028();  // 使用 OrderBy 对字符串数组 words 按照字母顺序进行排序。

            //linq_028_039.Linq029();  // 使用 OrderBy 对字符串数组 words 按照字符串长度进行排序。

            //linq_028_039.Linq030();  // 使用 OrderBy 对商品集合元素的 Name 属性进行排序，还可以添加 descending 反序条件

            //linq_028_039.Linq031();  // 使用 OrderBy 以及一个自定义的比较运算符，按照大小写敏感的次序对字符串数组进行排序

            //linq_028_039.Linq032();  // 使用 OrderBy 和 descending 对数值数组进行排序（高到低）

            //linq_028_039.Linq033();  // 使用 orderby 和 descending 将商品按照库存量从高到低排序

            //linq_028_039.Linq034();  // 使用 OrderByDescending 的方法以及自定义的比较运算符，对一个字符串数组进行排序

            //linq_028_039.Linq035();  // 使用混合 orderby 对一组数字字符串进行排序：先按照长度，而后按照字母顺序排序。

            //linq_028_039.Linq036();  // 第一个查询使用 OrderBy 先按照字符串长度排序，然后使用 ThenBy 再次按照自定的比较运算符排序
            //                         // 第二个查询其实就是前一种的另外一种写法

            //linq_028_039.Linq037();  // 使用混合 orderby 查询产品列表，先按照分类，然后按照单价排序列出来

            //linq_028_039.Linq038();  // 第一个查询使用 OrderBy 先按照字符串长度排序，然后使用 ThenByDescending 再次按照自定的比较运算符排序

            //linq_028_039.Linq039();  // 先查询出字符串中，第二个字符是 i 的元素，然后使用 Reverse 对结果集合进行反转操作。

            //Console.ReadKey();
            #endregion

            #region 第五部分：数据分组相关运算符 

            //var linq_040_045 = new Linq_040_045();

            //linq_040_045.Linq040();  // 使用 GroupBy 分解一个数字集合，使得按照集合元素被5除后的余数进行分组

            //linq_040_045.Linq041();  // 使用 group by 将一个列表按照第一个字母进行分组

            //linq_040_045.Linq042();  // 这个例子将产品按照类别进行分组

            //linq_040_045.Linq043();  // 这个例子将客户先按年度，然后按照月份进行分组

            //linq_040_045.Linq044();  // 使用 GroupBy 将一个字符串集合元素去掉空格以后，按照自定义的相等性运算符判断分组依据进行分组

            //linq_040_045.Linq045();  // 使用 GroupBy 将一个字符串集合元素去掉空格以后，使用自定义的字符串相等性比较运算符，
            //                         // 分别按照去掉空格的字符串，然后按照转为大写字符的方式进行分组
            //Console.ReadKey();

            #endregion

            #region 第六部分：数据集合相关运算符

            //var linq_046_053 = new Linq_046_053();

            //linq_046_053.Linq046();  // 应用 Uinon 运算符，在两个数据集合中，联合起来找出唯一存在的元素。

            //linq_046_053.Linq047();  // 使用 Union 运算符，从产品和客户数据集合中，抽取名称首字母重新构建一个的序列，并且首字母唯一

            //linq_046_053.Linq048();  // 应用 Intersect（交集） 创建一个新的包含两个数据集合公共的元素。

            //linq_046_053.Linq049();  // 使用 Intersect 从客户、商品数据集合中元素的名称中的首字母，创建一个新的序列，包含两者公共的字母。

            //linq_046_053.Linq050();  // 使用 Except 运算符，创建一个新的序列，在 A 集合中有，在 B 集合中没有

            //linq_046_053.Linq051();  // 使用 Except 从产品、客户数据集合中数据元素的首字母，创建一个新的序列，在产品集合中有，在 B 集合中没有

            //linq_046_053.Linq052();  // 使用 Except 运算符，创建一个新的序列，在 A 集合中有，在 B 集合中没有

            //linq_046_053.Linq053();  // 使用 Except 从产品、客户数据集合中数据元素的首字母，创建一个新的序列，在产品集合中有，在 B 集合中没有

            //Console.ReadKey();

            #endregion

            #region 第七部分：数据转换相关的运算符

            //var linq_054_057 = new Linq_054_057();

            //linq_054_057.Linq054();  // 使用 ToArray 将一个集合转换为数组

            //linq_054_057.Linq055();  // 使用 ToList 将一个集合转换为 List<T>

            //linq_054_057.Linq056();  // 使用 ToDictionary 将一个数据集合转为字典集合

            //linq_054_057.Linq057();  // 使用 OfType 返回数据集合元素中制定的类型

            //Console.ReadKey();

            #endregion

            #region 第八部分：数据元素操作相关的运算符

            //var linq_058_064 = new Linq_058_064();

            //linq_058_064.Linq058();  // 使用 First 从产品数据集合中找出产品标识（ProductID）为 12 的元素（产品）

            //linq_058_064.Linq059();  // 使用 First 从一个字符串集合中每个元素的第一个字符为 o 的所有元素抽取第一个

            //linq_058_064.Linq061();  // 使用 FirstOrDefault 返回第一个元素，如果集合或者在 where 约束后的集合为空，则返回一个空类型

            //linq_058_064.Linq062();  // 使用 FirstOrDefault 返回产品数据集合中，产品标识码为 789 的产品，判断这个产品是否存在

            //linq_058_064.Linq064();  // 使用 ElementAt 访问一个整数集合中，所有大于5 的第二个整数

            //Console.ReadKey();

            #endregion

            #region 第九部分：数据生成相关的运算符

            //var linq_065_066 = new Linq_065_066();

            //linq_065_066.Linq065();  // 本例使用 Range 生成 100 到 149 之间的数列，以便用来检查是奇数还是偶数

            //linq_065_066.Linq066();  // 使用 Repeat 产生 10 个 7 并返回一个数据集合

            //Console.ReadKey();

            #endregion

            #region 第十部份：数据量词相关的运算符

            //var linq_067_072 = new Linq_067_072();

            //linq_067_072.Linq067();  // 使用 Any 判断字符串集合中是否存在包含子串 “ei” 的字符串

            //linq_067_072.Linq069();  // 使用 Any 判断经过按照产品类型分组的产品中，只要存在库存数量为零的 产品分组

            //linq_067_072.Linq070();  // 使用 All 判断一个整数集合中，是否全都是奇数

            //linq_067_072.Linq072();  // 使用 All 判断经过按照产品类型分组的产品中，只要存在库存数量大于零的产品分组

            //Console.ReadKey();

            #endregion

            #region 第十一部份：数据集合元素聚合相关的运算符

            //var linq_073_093 = new Linq_073_093();
            //linq_073_093.Linq073();   // 使用 Count 获取一个整型数集合中不重复的元素的数量
            //linq_073_093.Linq074();   // 使用 Count 返回一个整型数集合中全部的奇数的数量。
            //linq_073_093.Linq076();   // 使用 Count 从客户数据集合中返回一个集合，其中的数据元素为：客户ID，订单数量
            //linq_073_093.Linq077();   // 使用 Count 从产品数据集合中，返回产品分类和对应的产品数量
            //linq_073_093.Linq078();   // 使用 Sum 对一个整数集合的全部元素求和
            //linq_073_093.Linq079();   // 使用 Sum 对一个字符串集合的所有元素的字符数量求和
            //linq_073_093.Linq080();   // 使用 Sum 获取每个产品分类的库存数量
            //linq_073_093.Linq081();   // 使用 Min 获取一个整数集合的最小值
            //linq_073_093.Linq082();   // 使用 Min 获取一个字符串数组中字符数量最少的元素
            //linq_073_093.Linq083();   // 使用 Min 获取每个产品分类中最便宜的产品单价
            //linq_073_093.Linq084();   // 使用 Min 获取获取每个产品分类中最便宜的产品
            //linq_073_093.Linq085();   // 使用 Max 获取一个整型数集合的最大值
            //linq_073_093.Linq086();   // 使用 Max 获取获取一个字符串数组中字符数量最多的元素
            //linq_073_093.Linq087();   // 使用 Max 获取每个产品分类中最贵的产品单价
            //linq_073_093.Linq088();   // 使用 Max 获取获取每个产品分类中最贵的产品
            //linq_073_093.Linq089();   // 使用 Average 获取整型数集合中所有元素的平均值
            //linq_073_093.Linq090();   // 使用 Average 获取一个字符串数组中所有元素的字符数平均值
            //linq_073_093.Linq091();   // 使用 Average 计算各个产品分类的产品的平均价格
            //linq_073_093.Linq092();   // 使用 Aggregate 一个数组元素的累计乘法的结果
            //                          // 这个语法可以做一些复杂的聚合运算，例如累计求和，累计求乘积。
            //                          // 它接受2个参数，一般第一个参数是称为累积数（默认情况下等于第一个值），而第二个代表了下一个值。
            //                          // 第一次计算之后，计算的结果会替换掉第一个参数，继续参与下一次计算。

            //linq_073_093.Linq093();   // 使用 Aggregate 对初始额度为 100 的某银行卡，累计扣减消费数，在余额不能低于 0 的条件下，计算出最后的额度。
            //Console.ReadKey();
            #endregion

            #region 第十二部份：数据元素串联和相等性相关的运算符

            var linq_094_097 = new Linq_094_097();

            //linq_094_097.Linq094();  // 使用 Concat 将两个数组的元素逐个合成

            //linq_094_097.Linq095();  // 使用 Concat 将客户和产品的名字合起来

            //linq_094_097.Linq096();  // 使用 SequenceEqual 比较两个数据集合的所有元素是否完全相同

            //linq_094_097.Linq097();  // 使用 SequenceEqual 比较两个数据集合的所有元素是否完全相同，并且次序也一样

            Console.ReadKey();

            #endregion

            #region 第十三部分：自定义的扩展序列应用运算符 
            //var linq_098_098 = new Linq_098_098();
            //linq_098_098.Linq098();  // 使用用户自己定义的 Combine 运算符对两个整型数数组进行处理
            //Console.ReadKey();
            #endregion

            #region 第十四部分：查询执行时机的一些话题

            //var linq_099_101 = new Linq_099_101();

            //linq_099_101.Linq099();   // 使用一个整型数数组，演示演示在 foreach 枚举之前，查询的执行情况

            //linq_099_101.Linq100();   // 演示一些方法和查询执行的情况

            //linq_099_101.Linq101();   // 应用延迟查询的例子

            //Console.ReadKey();

            #endregion

            #region 第十五部分：数据元素编联查询运算符

            var linq_102_107 = new Linq_102_107();

            linq_102_107.Linq102();   // 使用 join 的方法，将两个没有直接关系的数据集合结合起来，形成一个包含供应商、客户全部属性
                                      // 以及满足两者之间的指定属性 Country 匹配的结果集

            linq_102_107.Linq103();   // 使用 Join 构建一个有层次结构的序列

            linq_102_107.Linq104();   // 使用 join 和一个外置的数据集合，再构建一个新的数据集合

            linq_102_107.Linq105();   // 左编联的应用例子

            linq_102_107.Linq106();   // 对编联查询的结果，进行一些处理：SupplierName = s == null ? "(No suppliers)" : s.SupplierName

            linq_102_107.Linq107();   // 使用匿名对象作为编联条件的例子

            Console.ReadKey();

            #endregion
        }
    }
}
