using CDS000.Common;
using CDS005.IListWithGenericsDemo.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS005.IListWithGenericsDemo
{
    /// <summary>
    /// 用于处理 PersonList 的一组方法
    /// </summary>
    public class PersonListRepository
    {
        /// <summary>
        /// 初始化一组人员数据
        /// </summary>
        /// <returns></returns>
        public static PersonList InitialPersonList()
        {
            var persons = new PersonList();

            #region 初始化人员数据
            persons.Add(new Person { Name = "张小祎", Province = "北京", City = "北京", Sex = true, Birthday = DateTime.Parse("1964-09-08"), Email = "zhangxw@hotmail.com" });
            persons.Add(new Person { Name = "李珊柳", Province = "北京", City = "北京", Sex = false, Birthday = DateTime.Parse("1966-02-08"), Email = "lishsh@hotmail.com" });
            persons.Add(new Person { Name = "李华语", Province = "河北", City = "石家庄", Sex = true, Birthday = DateTime.Parse("1966-09-08"), Email = "lihy@hotmail.com" });
            persons.Add(new Person { Name = "黄慧琳", Province = "河北", City = "廊坊", Sex = false, Birthday = DateTime.Parse("1966-09-08"), Email = "huanghl@hotmail.com" });
            persons.Add(new Person { Name = "潘加伟", Province = "河北", City = "唐山", Sex = true, Birthday = DateTime.Parse("1963-10-08"), Email = "panjw@hotmail.com" });
            persons.Add(new Person { Name = "秦小梨", Province = "河北", City = "唐山", Sex = false, Birthday = DateTime.Parse("1966-09-08"), Email = "qinxl@hotmail.com" });
            persons.Add(new Person { Name = "覃晓琳", Province = "河北", City = "石家庄", Sex = true, Birthday = DateTime.Parse("1968-09-08"), Email = "qinxlin@hotmail.com" });
            persons.Add(new Person { Name = "韦长英", Province = "广西", City = "柳州", Sex = true, Birthday = DateTime.Parse("1969-03-08"), Email = "weichy@hotmail.com" });
            persons.Add(new Person { Name = "韦大东", Province = "广西", City = "南宁", Sex = true, Birthday = DateTime.Parse("1969-03-08"), Email = "1918625568@qq.com" });
            persons.Add(new Person { Name = "韦家文", Province = "广西", City = "柳州", Sex = true, Birthday = DateTime.Parse("1969-03-08"), Email = "2918625578@qq.com" });
            persons.Add(new Person { Name = "黎文新", Province = "广西", City = "柳州", Sex = true, Birthday = DateTime.Parse("1969-03-08"), Email = "1918625592@qq.com" });
            persons.Add(new Person { Name = "黎子流", Province = "广东", City = "广州", Sex = true, Birthday = DateTime.Parse("1969-03-08"), Email = "1918625593@qq.com" });
            persons.Add(new Person { Name = "余卫东", Province = "广东", City = "广州", Sex = true, Birthday = DateTime.Parse("1969-09-08"), Email = "1918625591@qq.com" });
            persons.Add(new Person { Name = "何家宝", Province = "广东", City = "广州", Sex = true, Birthday = DateTime.Parse("1970-08-08"), Email = "1918625566@qq.com" });
            persons.Add(new Person { Name = "何欣俊", Province = "广东", City = "广州", Sex = true, Birthday = DateTime.Parse("1970-08-08"), Email = "1918625555@qq.com" });
            persons.Add(new Person { Name = "余华亮", Province = "广东", City = "广州", Sex = true, Birthday = DateTime.Parse("1970-08-08"), Email = "1918625533@qq.com" });
            persons.Add(new Person { Name = "汤富贵", Province = "广东", City = "广州", Sex = true, Birthday = DateTime.Parse("1970-08-08"), Email = "1918625532@qq.com" });
            persons.Add(new Person { Name = "唐富贵", Province = "广东", City = "广州", Sex = true, Birthday = DateTime.Parse("1970-08-08"), Email = "1918625536@qq.com" });
            persons.Add(new Person { Name = "唐蔚佳", Province = "广东", City = "深圳", Sex = false, Birthday = DateTime.Parse("1964-09-08"), Email = "tangwj@hotmail.com" });
            persons.Add(new Person { Name = "谢显才", Province = "广东", City = "深圳", Sex = true, Birthday = DateTime.Parse("1972-09-08"), Email = "xiexc@hotmail.com" });
            persons.Add(new Person { Name = "解晓东", Province = "广东", City = "深圳", Sex = true, Birthday = DateTime.Parse("1972-09-08"), Email = "xiexd@hotmail.com" });
            persons.Add(new Person { Name = "谢家麟", Province = "广东", City = "深圳", Sex = true, Birthday = DateTime.Parse("1972-09-08"), Email = "xiejl@hotmail.com" });
            persons.Add(new Person { Name = "谢子怡", Province = "广东", City = "深圳", Sex = false, Birthday = DateTime.Parse("1973-09-08"), Email = "xieziy@hotmail.com" });
            persons.Add(new Person { Name = "张建光", Province = "广东", City = "深圳", Sex = true, Birthday = DateTime.Parse("1988-09-08"), Email = "zhangjg@163.com" });
            persons.Add(new Person { Name = "李振书", Province = "广东", City = "深圳", Sex = true, Birthday = DateTime.Parse("1988-09-08"), Email = "lizhsh@163.com" });
            persons.Add(new Person { Name = "陈丰州", Province = "广东", City = "深圳", Sex = true, Birthday = DateTime.Parse("1988-09-08"), Email = "chenfzh@163.com" });
            persons.Add(new Person { Name = "陈卫东", Province = "广东", City = "深圳", Sex = true, Birthday = DateTime.Parse("1988-09-08"), Email = "chenwd@163.com" });
            persons.Add(new Person { Name = "陈峰受", Province = "广东", City = "深圳", Sex = true, Birthday = DateTime.Parse("1988-09-08"), Email = "chenfsh@163.com" });
            persons.Add(new Person { Name = "陈金健", Province = "广东", City = "深圳", Sex = true, Birthday = DateTime.Parse("1988-09-08"), Email = "chenjj@163.com" });
            persons.Add(new Person { Name = "韦海波", Province = "广东", City = "深圳", Sex = true, Birthday = DateTime.Parse("1988-09-08"), Email = "weihb@163.com" });
            persons.Add(new Person { Name = "祁宣明", Province = "广东", City = "深圳", Sex = true, Birthday = DateTime.Parse("1988-09-08"), Email = "qixm@163.com" });
            persons.Add(new Person { Name = "戚计生", Province = "上海", City = "上海", Sex = true, Birthday = DateTime.Parse("1988-09-08"), Email = "qijsh@163.com" });
            persons.Add(new Person { Name = "石智生", Province = "广西", City = "柳州", Sex = true, Birthday = DateTime.Parse("1988-09-08"), Email = "shizhsh@163.com" });
            persons.Add(new Person { Name = "苏晓琳", Province = "广西", City = "柳州", Sex = false, Birthday = DateTime.Parse("1989-09-08"), Email = "suxl@hotmail.com" });
            persons.Add(new Person { Name = "苏振彪", Province = "广西", City = "柳州", Sex = true, Birthday = DateTime.Parse("1993-09-08"), Email = "suzhb@sina.com.cn" });
            persons.Add(new Person { Name = "谭家伟", Province = "广西", City = "柳州", Sex = true, Birthday = DateTime.Parse("1993-09-08"), Email = "tanjw@sina.com.cn" });
            persons.Add(new Person { Name = "谭俊杰", Province = "广西", City = "桂林", Sex = true, Birthday = DateTime.Parse("1993-09-08"), Email = "tanjj@sina.com.cn" });
            persons.Add(new Person { Name = "王定祠", Province = "广西", City = "桂林", Sex = true, Birthday = DateTime.Parse("1993-09-08"), Email = "wangdc@sina.com.cn" });
            persons.Add(new Person { Name = "王金生", Province = "广西", City = "北海", Sex = true, Birthday = DateTime.Parse("1993-09-08"), Email = "wangjsh@sina.com.cn" });
            persons.Add(new Person { Name = "王宝军", Province = "广西", City = "钦州", Sex = true, Birthday = DateTime.Parse("1993-09-08"), Email = "wangbj@sina.com.cn" });
            persons.Add(new Person { Name = "吴克标", Province = "广西", City = "防城港", Sex = true, Birthday = DateTime.Parse("1993-09-08"), Email = "wukb@hotmail.com" });
            persons.Add(new Person { Name = "吴斌", Province = "江西", City = "南昌", Sex = true, Birthday = DateTime.Parse("1993-09-08"), Email = "wubing@hotmail.com" });
            persons.Add(new Person { Name = "游毅峰", Province = "湖南", City = "长沙", Sex = true, Birthday = DateTime.Parse("1993-09-08"), Email = "youyf@hotmail.com" });
            persons.Add(new Person { Name = "柳君华", Province = "湖南", City = "长沙", Sex = true, Birthday = DateTime.Parse("1993-09-08"), Email = "liujh@hotmail.com" });
            persons.Add(new Person { Name = "刘小薇", Province = "湖南", City = "郴州", Sex = false, Birthday = DateTime.Parse("1993-09-08"), Email = "liuxw@hotmail.com" });
            persons.Add(new Person { Name = "陈东风", Province = "湖南", City = "衡阳", Sex = true, Birthday = DateTime.Parse("1999-09-08"), Email = "chendf@hotmail.com" });
            persons.Add(new Person { Name = "欧阳海", Province = "湖南", City = "长沙", Sex = true, Birthday = DateTime.Parse("1985-09-08"), Email = "ouyangpj@hotmail.com" });
            persons.Add(new Person { Name = "柳三变", Province = "湖南", City = "邵阳", Sex = true, Birthday = DateTime.Parse("1986-09-08"), Email = "liusb@hotmail.com" });
            persons.Add(new Person { Name = "郭骁", Province = "北京", City = "北京", Sex = true, Birthday = DateTime.Parse("1996-09-08"), Email = "zhanguoxiao@hotmail.com" });
            persons.Add(new Person { Name = "郭家铭", Province = "香港", City = "香港", Sex = true, Birthday = DateTime.Parse("1996-09-08"), Email = "guojm@hotmail.com" });
            persons.Add(new Person { Name = "陈兆年", Province = "四川", City = "成都", Sex = true, Birthday = DateTime.Parse("1996-09-08"), Email = "chanzhn@hotmail.com" });
            persons.Add(new Person { Name = "农卫红", Province = "四川", City = "成都", Sex = false, Birthday = DateTime.Parse("2000-09-08"), Email = "nongwh@hotmail.com" });
            persons.Add(new Person { Name = "农志升", Province = "四川", City = "成都", Sex = true, Birthday = DateTime.Parse("1989-09-08"), Email = "nongzhsh@hotmail.com" });
            persons.Add(new Person { Name = "农小琳", Province = "四川", City = "攀枝花", Sex = true, Birthday = DateTime.Parse("1988-09-08"), Email = "nongxl@hotmail.com" });
            persons.Add(new Person { Name = "徐荣国", Province = "四川", City = "泸州", Sex = true, Birthday = DateTime.Parse("1996-09-08"), Email = "xurg@live.com" });
            persons.Add(new Person { Name = "聂小威", Province = "四川", City = "泸州", Sex = true, Birthday = DateTime.Parse("1996-09-08"), Email = "niexw@live.com" });
            persons.Add(new Person { Name = "邱福林", Province = "四川", City = "泸州", Sex = true, Birthday = DateTime.Parse("1996-09-08"), Email = "qiufl@live.com" });
            persons.Add(new Person { Name = "范思坦", Province = "四川", City = "泸州", Sex = true, Birthday = DateTime.Parse("1996-09-08"), Email = "fanst@live.com" });
            persons.Add(new Person { Name = "邓唯佳", Province = "四川", City = "泸州", Sex = false, Birthday = DateTime.Parse("1998-09-08"), Email = "dengwj@hotmail.com" });
            persons.Add(new Person { Name = "马晓东", Province = "云南", City = "昆明", Sex = true, Birthday = DateTime.Parse("1999-09-08"), Email = "maxd@hotmail.com" });
            persons.Add(new Person { Name = "魏明翠", Province = "云南", City = "昆明", Sex = false, Birthday = DateTime.Parse("2000-09-08"), Email = "weimc@hotmail.com" });
            persons.Add(new Person { Name = "尹相杰", Province = "贵州", City = "贵阳", Sex = true, Birthday = DateTime.Parse("1993-09-08"), Email = "yinxj@hotmail.com" });
            persons.Add(new Person { Name = "张小祎", Province = "贵州", City = "凯里", Sex = false, Birthday = DateTime.Parse("1993-09-08"), Email = "zhangxw@163.com" });
            #endregion

            return persons;
        }

        /// <summary>
        /// 提取人员集合中，来自哪些省份的数据
        /// </summary>
        /// <param name="persons"></param>
        /// <returns></returns>
        public static List<string> GetProvinces(PersonList persons)
        {
            var result = new List<string>();
            foreach (var item in persons)
            {
                if (!result.Contains(item.Province))
                    result.Add(item.Province);
            }
            return result;
        }

        /// <summary>
        /// 使用 IList 的扩展方法 GroupBy 来获取来自哪些省份的数据
        /// </summary>
        /// <param name="persons"></param>
        /// <returns></returns>
        public static List<string> GetProvincesGroupBy(PersonList persons)
        {
            var result = new List<string>();
            foreach (var item in persons.GroupBy(x => x.Province))
            {
                result.Add(item.Key);
            }
            return result;
        }

        /// <summary>
        /// 使用 IList 的扩展方法 GroupBy 每个省份有多少人
        /// </summary>
        /// <param name="persons"></param>
        /// <returns></returns>
        public static List<PersonsInProvince> GetProvincesPersons(PersonList persons)
        {
            var result = new List<PersonsInProvince>();
            foreach (var item in persons.GroupBy(x => x.Province))
            {
                var data = new PersonsInProvince
                {
                    ProvinceName = item.Key,
                    Amount = item.Count()
                };
                result.Add(data);
            }
            return result;
        }

        /// <summary>
        /// 计算平均年龄
        /// </summary>
        /// <param name="persons">人员的 List 集合</param>
        /// <returns></returns>
        public static string AverageAge(PersonList persons)
        {
            var result = "";
            var totalDays = 0;  // 所有人员的全部天数
            var now = DateTime.Now;
            foreach(var item in persons)
            {
                totalDays = totalDays + Math.Abs(((TimeSpan)(now - item.Birthday)).Days);
            }

            var avgTotaldays = totalDays / persons.Count;
            var avgYears = avgTotaldays / 365;
            var avgDays = avgTotaldays - avgYears * 365;

            result = "平均年龄：" + avgYears + "周岁" + "-" + avgDays + "天";    
            return result;
        }

    }
}
