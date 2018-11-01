﻿using System;
using System.ComponentModel;
using System.Windows;

using MVVMAqua.Interfaces;

namespace MVVMAqua.Windows
{
	public class BaseWindow : Window
	{
		internal Func<bool> WindowClosing { get; set; }
		
		protected override void OnClosing(CancelEventArgs e)
		{
			base.OnClosing(e);

			e.Cancel = DataContext is IWindowCloser windowCloser ? !windowCloser.CloseWindow() : !WindowClosing?.Invoke() ?? false;
		}
	}
}