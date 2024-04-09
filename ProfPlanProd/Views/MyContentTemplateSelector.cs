using ProfPlanProd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ProfPlanProd.Views
{
    internal class MyContentTemplateSelector : DataTemplateSelector
    {
        public DataTemplate FirstTemplate { get; set; }
        public DataTemplate SecondTemplate { get; set; }
        public DataTemplate ThirdTemplate { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (!(item is TableCollection tableCollection)) return null;

            string tableName = tableCollection.Tablename.ToLower();

            if (!tableName.Contains("итого") && !tableName.Contains("доп"))
            {
                return FirstTemplate;
            }
            else if (tableName.Contains("доп"))
            {
                return ThirdTemplate;
            }
            else
            {
                return SecondTemplate;
            }
        }
    }
}
