﻿namespace infinite_runner;

public partial class MainPage : ContentPage;

bool estaMorto = false;
bool estaPulando = false;
const int tempoEntreFrames = 25;
int velocidade1 = 0;
int velocidade2 = 0;
int velocidade3 = 0;
int velocidade2 = 0;
int velocidade = 0;
int larguraJanela = 0;
int alturaJanela = 0;
{
	public MainPage()
{
	InitializeComponent();
}
protected overide void OnSizeAllocated(double w, double h)
{
	base.OnSizeAllocated(w, h);
	CorrigeTamanhoCenario(w, h);
	CalculaVelocidade(w);
}



























}

