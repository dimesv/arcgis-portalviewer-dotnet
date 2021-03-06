﻿// (c) Copyright ESRI.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved

using System;
using Windows.Foundation.Collections;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;
using ArcGISPortalViewer.Popup.Utilities;
using System.Collections.Generic;

namespace ArcGISPortalViewer.Popup.Converters
{
    internal sealed class StringFormatToBitmapSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var dict = value as IDictionary<string, object>;
            var formatter = parameter as string;
            if (dict == null || string.IsNullOrWhiteSpace(formatter))
                return null;
            if (!string.IsNullOrEmpty(formatter))
            {
                var uriString = AttributeBindingHelper.ResolveBinding(dict, formatter);
                if (Uri.IsWellFormedUriString(uriString, UriKind.Absolute))
                    value = new BitmapImage(new Uri(uriString));
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
