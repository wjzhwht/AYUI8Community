﻿using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows;

namespace ay.Controls
{
    [MarkupExtensionReturnType(typeof(IValueConverter))]
    public class BooleanToVisbilityConverter : MarkupExtension, IValueConverter
    {
        private static BooleanToVisbilityConverter _converter;
        public static BooleanToVisbilityConverter Instance
        {
            get
            {
                if (_converter == null)
                {
                    _converter = new BooleanToVisbilityConverter();
                }
                return _converter;
            }
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Instance;
        }
        #region 属性

        #endregion

        #region 转换
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool flag = false;
            if (value is bool)
            {
                flag = (bool)value;
            }
            else if (value is bool?)
            {
                bool? nullable = (bool?)value;
                flag = nullable.Value;
            }
            return (flag ? Visibility.Visible : Visibility.Collapsed);
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !((value is Visibility) && (((Visibility)value) == Visibility.Collapsed));
        }
        #endregion
    }


}
