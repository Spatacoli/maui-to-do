﻿namespace maui_to_do;

public partial class App : Application
{
	public App(MainPage mp)
	{
		InitializeComponent();

		MainPage = mp;
	}
}
