using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Gao.MvvmToolkit.Demo.Common
{
    public class PasswordBoxHelper
    {
        public static readonly DependencyProperty PasswordProperty = DependencyProperty.RegisterAttached(
            "Password", typeof(string), typeof(PasswordBoxHelper), new PropertyMetadata(default(string), OnPasswordChanged));

        public static string GetPassword(DependencyObject element) => (string)element.GetValue(PasswordProperty);

        public static void SetPassword(DependencyObject element, string value) => element.SetValue(PasswordProperty, value);

        public static readonly DependencyProperty AttachProperty = DependencyProperty.RegisterAttached(
            "Attach", typeof(bool), typeof(PasswordBoxHelper), new PropertyMetadata(default(bool), Attached));

        public static bool GetAttach(DependencyObject element) => (bool)element.GetValue(AttachProperty);
        public static void SetAttach(DependencyObject element, bool value) => element.SetValue(AttachProperty, value);

        private static readonly DependencyProperty IsUpdatingProperty = DependencyProperty.RegisterAttached(
            "IsUpdating", typeof(bool), typeof(PasswordBoxHelper));
        public static bool GetIsUpdating(DependencyObject element) => (bool)element.GetValue(IsUpdatingProperty);
        public static void SetIsUpdating(DependencyObject element, bool value) => element.SetValue(IsUpdatingProperty, value);

        /// <summary>
        /// 当password 发生变化时，同步PasswordBox的实际值与绑定值
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void Attached(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is not PasswordBox box) return;
            if ((bool)e.OldValue) box.PasswordChanged -= OnNativePasswordChanged;
            if ((bool)e.NewValue) box.PasswordChanged += OnNativePasswordChanged;
        }

        private static void OnNativePasswordChanged(object sender, RoutedEventArgs e)
        {
            if (sender is PasswordBox box)
            {
                SetIsUpdating(box, true);
                SetPassword(box, box.Password);
                SetIsUpdating(box, false);
            }
        }

        /// <summary>
        /// 发生变化时，同步PasswordBox的实际值与绑定值
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PasswordBox box)
            {
                box.PasswordChanged -= OnNativePasswordChanged;

                if (!(bool)GetIsUpdating(box))
                    box.Password = (string)e.NewValue;

                box.PasswordChanged += OnNativePasswordChanged;
            }
        }
    }
}
