using System.Text;

namespace CDS005.IListWithGenericsDemo.BusinessModels
{
    public class PersonsInProvince
    {
        public string ProvinceName { get; set; }
        public int Amount { get; set; }

        public override string ToString()
        {
            return $"{this.ProvinceName} \t{this.Amount}";
        }

        public string ToBarChartStyle()
        {
            var space = "";

            var builder = new StringBuilder();
            builder.Append(space);
            for (int i = 0; i < Amount; i++)
            {
                builder.Append("█");
            }
            space = builder.ToString();

            return $"{this.ProvinceName} \t{this.Amount} \t{space}";
        }
    }
}
